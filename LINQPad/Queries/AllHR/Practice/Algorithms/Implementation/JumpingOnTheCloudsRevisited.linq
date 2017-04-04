<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	JumpingOnTheCloudsRevisited();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void JumpingOnTheCloudsRevisited()
{
	int n = 8, k = 2;
	int [] input = new [] {0, 0, 1, 0, 0, 1, 1, 0};
	int count = 100;
	for(int i = 0; ;)
	{
		i = (i + k) % n;
		count--;
		int temp = input[i];
		if(temp > 0) count -= 2;
		//Console.WriteLine(input[i]);
		Console.WriteLine($"i:{i} k:{k} count:{count} temp:{temp}");
		if(i == 0) break;
	}
	Console.WriteLine(count);
}
