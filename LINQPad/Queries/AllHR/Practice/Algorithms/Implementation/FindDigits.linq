<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	FindDigits();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void FindDigits()
{
	long t = 2, n = 1012;
	long tempN = n, counter = 0;
	
	while(n > 0)
	{
		int rem = (int)n % 10;
		if(rem > 0 && tempN % rem == 0) counter++;
		n = n/10;
	}
	Console.WriteLine(counter);
}
