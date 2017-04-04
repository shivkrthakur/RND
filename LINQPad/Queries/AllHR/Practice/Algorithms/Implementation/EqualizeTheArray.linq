<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	EqualizeTheArray();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void EqualizeTheArray()
{
	int n = Convert.ToInt32("5");
	int [] input = "3 3 2 1 3".Split().Select(Int32.Parse).ToArray();
	int numWithHighestCount = 0, prevCount = 0;
	for(int i = 0; i < n; i++)
	{
		int num = input[i];
		int count = input.Where(x => x == num).ToArray().Count();
		if(prevCount < count) 
		{
			prevCount = count;
			numWithHighestCount = num;
		}
		Console.WriteLine($"num:{num} count:{count}");
	}
	Console.WriteLine($"numWithHighestCount:{numWithHighestCount}");
	Console.WriteLine($"{input.Length - numWithHighestCount}");
}