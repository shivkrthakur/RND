<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	MinimumDistances();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void MinimumDistances()
{
	int n = Convert.ToInt32("6");
	int [] A = "7 1 3 4 1 7".Split().Select(Int32.Parse).ToArray();
	int minDistance = Int32.MaxValue;
	for(int i = 0; i < n; i++)
	{
		int distance = 0;
		for(int k = i + 1; k < n; k++)
		{
			if(A[i] == A[k]) { distance = k - i; break; }
		}
		//Console.WriteLine($"distance:{distance}");
		if(distance > 0 && distance < minDistance) minDistance = distance;
	}
	Console.WriteLine(minDistance);
}