<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	SherlockAndTheBeast();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void SherlockAndTheBeast()
{
	int t = 4;
	int[] input = new int[] {1, 3, 5, 11};
	
	for(int i = 0; i < t; i++)
	{
		int n = input[i];
		if((n < 3) || (n % 3 != 0 & n % 5 != 0)) Console.WriteLine($"n:{n} -1");
	}
}