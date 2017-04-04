<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	ViralAdvertising();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void ViralAdvertising()
{
	int n = 5;
	int initialCount = 5;
	int totalLikes = 0;
	for(int i = 0; i < n; i++)
	{
		initialCount = initialCount/2;
		totalLikes += initialCount;
		initialCount *= 3;
	}
	Console.WriteLine(totalLikes);
}