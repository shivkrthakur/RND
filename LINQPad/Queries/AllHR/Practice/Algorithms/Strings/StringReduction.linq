<Query Kind="Program" />

//http://stackoverflow.com/questions/8033553/stumped-on-a-java-interview-need-some-hints/8715230#8715230
void Main()
{
	StringReduction();
	//StringReductionRecursive();
}

// Define other methods and classes here
void StringReduction()
{
	int t = Convert.ToInt32("3");
	string [] S = { "cab", "bcab", "ccccc", "babacabbabca", "bbbbbbcbbbcbbb" };
	t = S.Length;
	
	for(int i = 0; i < t; i++)
	{
		var dict = new Dictionary<char,int>() {	{ 'a', 0 },	{ 'b', 0 },	{ 'c', 0 } };
		string s = S[i];
		for(int j = 0; j < s.Length; j++) dict[s[j]]++;
		//Console.WriteLine(dict);
		if((dict['a'] == 0 && dict['b'] == 0) || (dict['b'] == 0 && dict['c'] == 0) || (dict['a'] == 0 && dict['c'] == 0))
			Console.WriteLine(dict.Single(x => x.Value > 0).Value);
		else
			if(((dict['a'] % 2 == 0) && (dict['b'] % 2 == 0) && (dict['c'] % 2 == 0)) || (((dict['a'] & 1) > 0) && (dict['b'] % 2 > 0) && (dict['c'] % 2 > 0))) Console.WriteLine(2);
			else Console.WriteLine(1);
	}
}

void StringReductionRecursive()
{
	int t = Convert.ToInt32("3");
	string [] S = { "cab", "bcab", "ccccc", "babacabbabca", "bbbbbbcbbbcbbb" };
	t = S.Length;
	
	for(int i = 0; i < t; i++)
	{
		Console.WriteLine(ReduceString(S[i], "ab", "c"));
	}
}

int ReduceString(string input, string tgt, string rep)
{
	if(!input.Contains(tgt)) return input.Length;
	//Console.WriteLine($"B	==>	input:{input}");
	input = input.Replace(tgt, rep);
	//Console.WriteLine($"A	==>	input:{input}");
	int length = input.Length;
	length = Math.Min(ReduceString(input, "ba", "c"), length);

	length = Math.Min(ReduceString(input, "bc", "a"), length);
	length = Math.Min(ReduceString(input, "cb", "a"), length);

	length = Math.Min(ReduceString(input, "ac", "b"), length);
	length = Math.Min(ReduceString(input, "ca", "b"), length);

	//Console.WriteLine($"length:{length}");
	return length;
}

/*
Observe that, all the characters of the final string have to be equal. If it's not true then we can replace two adjacent different characters with a single character and get an even shorter string. Based on this fact, we will build our solution.
Lets solve an easier sub-problem
Given a string can you check if we can reduce a substring to a single character ?
Let's consider a substring of the string which starts at index  and ends at index . To check if it is possible to convert the substring  to a particular single character  , we can use dynamic programming.
If () then just check whether the character at position  is equal to  or not.
Else if there exists any  satisfying  where we can reduce the substring  to  and the substring  to , then return true. Return false otherwise. [ Here  and  are the characters which are not equal to ]
The complexity of calculating this is  where  is the length of the string.
Now lets go back to the original problem
Let's fix the character that is going to stay in the final string. Let  be the smallest length of the resultant string which can be achieved by applying the reduction operation over the prefix ending at position  in an optimal order such that the characters left on the final string are equal to .
Now how to calculate  ?
The key observation here is that we must convert a suffix of that prefix to a single character which is equal to .
So for all  we need to check if we can reduce the suffix starting from index j ( and ending at index i) to a single character equal to  . If we can , then  for all such .
Time complexity:  per test case where  is the length of the string.
There also exists another solution which doesn't require DP. Click here to see it.
Editorialist's Solution

#include<stdio.h>
#include<string.h>
#include<stdbool.h>
#define MAXN    105

char str[MAXN];
int dp[3][MAXN], canDP[MAXN][MAXN][3], vis[MAXN][MAXN][3], cs;
const int INF = 1000000;

inline int min(int u, int v) {return u < v ? u : v;}

bool Can(int st, int ed, char ch) 
{
	//Can we reduce the substring [st, ed] to a single character ch?
    
    if(st == ed) return (str[st] == ch);
    if(vis[st][ed][ch] == cs) return canDP[st][ed][ch];
    vis[st][ed][ch] = cs;

    int u, v, k;
    if(ch == 0) u = 1, v = 2;
    if(ch == 1) u = 0, v = 2;
    if(ch == 2) u = 0, v = 1;

    for(k = st; k < ed; k++)
        if( (Can(st, k, u) && Can(k+1, ed, v)) || (Can(st, k, v) && Can(k+1, ed, u)) )
            return canDP[st][ed][ch] = true;

    return canDP[st][ed][ch] = false;
}

int main()
{
    int i, j, tcase;
    int len, ch;

    scanf("%d", &tcase);
    while(tcase--)
    {
        cs++;
        scanf("%s", str + 1);
        len = strlen( str + 1);

        for(i = 1; i <= len; i++) str[i] -= 'a'; // Replacing a, b & c with 0, 1 & 2.
        for(ch = 0; ch < 3; ch++)
            for(i = 1; i <= len; i++)
            {
                dp[ch][i] = INF;
                for(j = 1; j <= i; j++)
                    if( Can(j, i, ch) )
                        dp[ch][i] = min(dp[ch][i], dp[ch][j-1] + 1);
            }

        printf("%d\n", min(dp[0][len], min(dp[1][len], dp[2][len])));
    }
    return 0;
}
*/