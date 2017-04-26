<Query Kind="Program" />

void Main()
{
	CommonChildRecursiveAndMemoization();
	//CommonChildRecursive();
	//CommonChild();
}

// Define other methods and classes here
void CommonChild()
{	
	string [][] S = {
			new string[] { "HARRY", "SALLY" }
		,	new string[] { "AA", "BB" }
		,	new string[] { "SHINCHAN", "NOHARAAA" }
		,	new string[] { "ABCDEF", "FBDAMN" }
		,	new string[] { "ABCDEFTIO", "FBDAMNDGE" }
		,	new string[] { "OUDFRMYMAW", "AWHYFCCMQX"}
		,	new string[] { "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS"
						 , "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC" }
	};
	string op = string.Empty;
	for(int i = 6; i < S.Length; i++)
	{
		string [] s = S[i];
		string s1 = s[0], s2 = s[1];
		int max = 0;
		if(string.Equals(s1, s2)) max = s1.Length;
		else
		{
			Console.WriteLine($"s1:{s1} {Environment.NewLine} s2:{s2}");
			int pk = 0, pj = 0, count = 0;
			bool matched = false, flag = false;
			for(int j = 0; j < s1.Length; j++)
			{
				for(int k = 0; k < s2.Length; k++)
				{
					if(s1[j] == s2[k])  
					{
						Console.Write("======>");
						if(!flag) { pj = j; flag = true; }
						matched = true;
						pk = k; 
						count++;
						Console.WriteLine($"j:{j} k:{k} ({s1[j]},{s2[k]}) count:{count}");
						Console.WriteLine(new StringBuilder(s1).Insert(j," [").Insert(j + 3, "] ").ToString());
						Console.WriteLine(new StringBuilder(s2).Insert(k," [").Insert(k + 3, "] ").ToString());
					}
					if(flag)
					{
						if(matched) {  j++; if(j == s1.Length) break; matched = false; continue; }
						else 
						{ 
							if(k == s2.Length - 1) 
							{ 
								k = pk; 
								j++; 
								if(j == s1.Length) 
									break; 
							} 
						} 
					} //else Console.WriteLine($"j:{j} k:{k} ({s1[j]},{s2[k]}) count:{count}");
				}
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine($"s1:{s1} {Environment.NewLine} s2:{s2}");

				max = Math.Max(max, count);
				if(flag) { j = pj; flag = false; count = 0; }
			}
			Console.WriteLine(max);
		}
	}
}

static void CommonChildRecursive() 
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
	string [][] S = {
			new string[] { "HARRY", "SALLY" }
		,	new string[] { "AA", "BB" }
		,	new string[] { "SHINCHAN", "NOHARAAA" }
		,	new string[] { "ABCDEF", "FBDAMN" }
		,	new string[] { "ABCDEFTIO", "FBDAMNDGE" }
		,	new string[] { "OUDFRMYMAW", "AWHYFCCMQX"}
		,	new string[] { "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS"
						 , "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC" }
	};
	
	for(int i = 0; i < S.Length; i++)
	{
	    int count = FindLongestCommonSubsequence(S[i][0], S[i][1], S[i][0].Length, S[i][1].Length);
	    Console.WriteLine(count);
	}
}

static int FindLongestCommonSubsequence(string s1, string s2, int n, int m)
{
    if(n == 0 || m == 0) return 0;
    if(s1[n-1] == s2[m-1])
    {
        return 1 + FindLongestCommonSubsequence(s1, s2, n - 1, m - 1);
    }
    else
    {
        return Math.Max(FindLongestCommonSubsequence(s1, s2, n , m - 1), FindLongestCommonSubsequence(s1, s2, n - 1, m));
    }
}

static void CommonChildRecursiveAndMemoization() {
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
	string [][] S = {
			new string[] { "HARRY", "SALLY" }
		,	new string[] { "AA", "BB" }
		,	new string[] { "SHINCHAN", "NOHARAAA" }
		,	new string[] { "ABCDEF", "FBDAMN" }
		,	new string[] { "ABCDEFTIO", "FBDAMNDGE" }
		,	new string[] { "OUDFRMYMAW", "AWHYFCCMQX"}
		,	new string[] { "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS"
						 , "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC" }
	};
	
	for(int i = 0; i < S.Length; i++)
	{
	    string s1 = S[i][0];
	    string s2 = S[i][1];
    	int[,] matrix = new int[s1.Length+1, s2.Length+1];
    	int count = FindLongestCommonSubsequence(s1, s2, s1.Length, s2.Length, matrix);
	    Console.WriteLine(count);
	}
}

static int FindLongestCommonSubsequence(string s1, string s2, int n, int m, int [,] matrix)
{
    if(n == 0 || m == 0) return 0;
    int result = 0;
    if(matrix[n,m] > 0) result = matrix[n,m];
    else
    {
        if(s1[n-1] == s2[m-1])
            result = 1 + FindLongestCommonSubsequence(s1, s2, n - 1, m - 1, matrix);
        else
            result = Math.Max(FindLongestCommonSubsequence(s1, s2, n , m - 1, matrix), FindLongestCommonSubsequence(s1, s2, n - 1, m, matrix));
        
        matrix[n,m] = result;
    }
    return result;
}