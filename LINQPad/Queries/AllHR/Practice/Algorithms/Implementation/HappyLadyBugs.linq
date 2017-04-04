<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	HappyLadyBugs();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void HappyLadyBugs()
{
	int g = Convert.ToInt32("4");
	int n = Convert.ToInt32("7");
	string input = "RBY_YBR";
	bool hasUS = input.Contains('_');
	Console.WriteLine($"hasUS:{hasUS}		 input:{input}");
	Console.WriteLine(input.IndexOf("\u00ADY"));
	//char[] charArr = input.ToCharArray();
	//Array.Sort(charArr);
	//Console.WriteLine($"hasUS:{hasUS} charArr:{new String(charArr)}");
	for(int i = 0; i < n; i++)
	{
		char c = input[i];
		//Console.WriteLine(c);
	}
}