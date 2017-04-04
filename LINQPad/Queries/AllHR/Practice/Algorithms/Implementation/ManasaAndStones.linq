<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	ManasaAndStones();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void ManasaAndStones()
{
	int t = Convert.ToInt32("2");
	int [][] input = new int[][] {
			new int[] { 3, 1, 2 }
		,	new int[] { 4, 10, 100 }
	};
	
	for(int i = 0; i < t; i++)
	{
		int[] temp = input[i];
		int n = temp[0], a = temp[1], b = temp[2];
		int num = 0;
		for(int x = 0; x < n -1; x++)
		{
			num = b * x;
			//Console.WriteLine($"num1:{num}");
			for(int y = x + 1; y < n; y++)
			{
				num += a;
			}
			Console.Write($"{num} ");
		}
		Console.Write($"{b * n - b} ");
		Console.WriteLine();
	}
}