<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	UtopianTree();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void UtopianTree()
{
	int n = 3;
	int [] inputArr = new int[] { 0, 1, 4 };
	for(int i = 0; i < n; i++)
	{
		int output = 1;
		int cycles = inputArr[i];
		//Console.WriteLine($"0 cycles: {cycles}");
		if(cycles != 0)
		{
			if(cycles == 1) { //Console.WriteLine($"1 Cycles:{cycles} output:{output * 2}"); 
				output = output * 2;
			}
			else
			{
				int rem = cycles % 2;
				cycles = cycles / 2;
				int tempOp = (int)Math.Pow(2,cycles);
				output = (tempOp * 1) + tempOp - 1;
				if(rem > 0) output *= 2;
				//Console.WriteLine($"2 Cycles:{cycles} output:{output}");
			}
		}
		//Console.WriteLine($"3 Cycles:{cycles} output:{output}");
		Console.WriteLine(output);
	}
}