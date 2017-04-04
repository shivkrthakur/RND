<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	BeautifulTriplets();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void BeautifulTriplets()
{
	int[] input = "7 3".Split().Select(Int32.Parse).ToArray();
	int n = input[0], d = input[1];
	input = "1 2 4 5 7 8 10".Split().Select(Int32.Parse).ToArray();
	int counter = 0;
	for(int i = 0; i < n; i++)
	{
		for(int j = i + 1; j < n; j++)
		{
			int d1 = input[j] - input[i];
			if(d1 == d)
			{
				for(int k = j + 1; k < n; k++)
				{
					int d2 = input[k] - input[j];
					if(d2 == d)
					{
						Console.WriteLine($"input[i]:{input[i]} input[j]:{input[j]} input[k]:{input[k]}");
						counter++;
					}
				}
			}
		}
	}
	Console.WriteLine($"counter:{counter}");
}