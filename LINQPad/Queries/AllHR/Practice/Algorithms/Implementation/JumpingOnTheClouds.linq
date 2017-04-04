<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	JumpingOnTheClouds();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void JumpingOnTheClouds()
{
	//int n = Convert.ToInt32("7");
	//int [] c = "0 0 1 0 1 1 0".Split().Select(Int32.Parse).ToArray();
	int n = Convert.ToInt32("6");
	int [] c = "0 0 0 0 1 0".Split().Select(Int32.Parse).ToArray();

	int i = 0, count = 0;
	for(i = 2; i < n; i += 2)
	{
		if(c[i] == 1) 
		{
			i--;
		}
		count++;
		Console.WriteLine($"i:{i} c[i]:{c[i]} count:{count}");
	}
	
	Console.WriteLine(count);
}