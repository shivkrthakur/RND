<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	SherlockAndSquares();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void SherlockAndSquares()
{
	int t = 1; 
	for(int i = 0; i < t; i++)
	{
		//int[] input = Array.ConvertAll("3 9".Split(), Int32.Parse);
		int[] input = Array.ConvertAll("17 24".Split(), Int32.Parse);
		int a = input[0], b = input[1];
		int counter = 0;
		for(int x = a; x <= b; x++)
		{
			int sqrt = (int)Math.Sqrt(x);
			if(sqrt * sqrt == x) counter++;
			Console.WriteLine($"x:{x} sqrt:{sqrt} asqrt:{Math.Sqrt(x)}");
		}
		Console.WriteLine($"counter:{counter}");
		
	}
}