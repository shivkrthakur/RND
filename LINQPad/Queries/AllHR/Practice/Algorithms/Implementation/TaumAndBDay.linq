<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	TaumAndBDay();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void TaumAndBDay()
{
	int t = Convert.ToInt32("5");
	int[][] inputArray = new int[][] {
					new int[2] { 212, 369}
				, 	new int[3] { 2568, 6430, 5783 }
				, 	new int[2] { 5, 9 }
				, 	new int[3] { 2, 3, 4 }
				, 	new int[2] { 3, 6 }
				, 	new int[3] { 9, 1, 1 }
				, 	new int[2] { 7, 7 }
				, 	new int[3] { 4, 2, 1 }
				, 	new int[2] { 3, 3 }
				, 	new int[3] { 1, 9, 2 }

				} ;
	//*
	for(int i = 0; i < t * 2; i++)
	{
		//2917086
		int [] input0 = inputArray[i];	//"10 10".Split().Select(Int32.Parse).ToArray(); //"5 9".Split().Select(Int32.Parse).ToArray();
		int b = input0[0], w = input0[1];
		int [] input1 = inputArray[++i];			//"1 1 1".Split().Select(Int32.Parse).ToArray(); //input = "2 3 4".Split().Select(Int32.Parse).ToArray();
		//Console.WriteLine($"input0: {string.Join(" ",input0)} 		input1: {string.Join(" ",input1)}");
		int x = input1[0], y = input1[1], z = input1[2];
		Console.WriteLine($"b:{b} w:{w}      x:{x} y:{y} z:{z}");
		int totalAmount = 0;
		if((y+z) < x)
		{
			totalAmount = b * (y + z) + w * y;
		}
		else if((x + z) < y)
		{
			totalAmount = b * x + w * (x + z);
		}
		else
		{
			totalAmount = b * x + w * y;
		}
		Console.WriteLine($"totalAmount:{totalAmount}");
	}
	//*/
}