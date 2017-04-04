<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	AppendAndDelete();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}
// Define other methods and classes here
public static void AppendAndDelete()
{
	//string s = "abcHacke",  t = "abc"; int k = 5;
	//string s = "hackerhappy", t = "hackerrank"; int k = 9;
	//string s = "zzzzz", t = "zzzzzzz"; int k = 4;
	string s = "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv"
	, t = "bsdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv"; 
	int k = 100;
	//string s = "aba", t = "aba"; int k = 7;
	int sLen = s.Length;
	int tLen = t.Length;
	//Console.WriteLine($"sLen:{sLen} tLen:{tLen}");
	if((sLen + tLen) <= k)
	{
		Console.WriteLine("Yes");
		return;
	}

	if(sLen > tLen) 
	{
		int index = s.IndexOf(t);
		int diff = sLen - tLen;
		if(index == 0 && ((diff) == k || ((diff) < k) && ((k & 1) == (diff & 1)))) { Console.WriteLine("Yes"); return; }
		//else { Console.WriteLine("No"); return; }
	}
	
	int smallerLen = sLen < tLen ? sLen : tLen;
	int i = 0;
	while(i < smallerLen && s[i] == t[i]) i++;
	//Console.WriteLine($"i:{i}");
	if(i == smallerLen)
	{
		int diff = Math.Max(sLen, tLen) - i;
		int reqDiff = k - diff;
		//Console.WriteLine(diff);
		if(k > diff)
		{
			if((reqDiff & 1) == 0){ Console.WriteLine("Yes"); return; }
			else { Console.WriteLine("No"); return; }
		}
		else { Console.WriteLine("No"); return; }
	}
	else if(i > 0)
	{
		int sDiff = sLen - i;
		int tDiff = tLen - i;
		int sum = sDiff + tDiff;
		//Console.WriteLine($"sDiff:{sDiff} tDiff:{tDiff} sum:{sum}");
		if(sum == k) { Console.WriteLine("Yes"); return; }
		else { Console.WriteLine("No"); return; }
	}
	else Console.WriteLine("No");
	
	//Console.WriteLine($"i:{i} sLen:{sLen} tLen:{tLen}");
}