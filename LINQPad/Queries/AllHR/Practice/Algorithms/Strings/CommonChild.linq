<Query Kind="Program" />

void Main()
{
	CommonChild();
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
	};
	string op = string.Empty;
	for(int i = 0; i < S.Length; i++)
	{
		string [] s = S[i];
		string s1 = s[0], s2 = s[1];
		char [] ch = new char[s1.Length];
		HashSet<int> hs = new HashSet<int>();
		HashSet<char> hsChar = new HashSet<char>();
		int [] pch = new int[s1.Length];
		if(string.Equals(s1, s2)) op = s1;
		else
		{
			Console.WriteLine($"s1:{s1} s2:{s2}");
			while(!string.Equals(s1, s2))
			{
				int l1 = s1.Length;
				int k = 0;
				string ss1 = string.Empty, ss2 = string.Empty;
				while(k < l1)
				{
					char c = s1[k];
					if(s2.IndexOf(c) > -1) { ss1 += c; }
					c = s2[k];
					if(s1.IndexOf(c) > -1) { ss2 += c; }
					k++;
				}
				Console.WriteLine($"ss1:{ss1} ss2:{ss2}");
				s1 = ss1;
				s2 = ss2;
			}
			Console.WriteLine();
		}
	}
}
