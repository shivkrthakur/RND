<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	ChocolateFeast();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void ChocolateFeast()
{
	int t = Convert.ToInt32("3");
	int [][] input = new int[][] {
			new int[] { 10, 2, 5 }
		,	new int[] { 12, 4, 4 }
		,	new int[] { 6, 2, 2 }
	};
	
	for(int i = 0; i < t; i++)
	{
		int [] inputArr = input[i];
		int n = inputArr[0], c = inputArr[1], m = inputArr[2];
		//Console.WriteLine(input[i]);
		int nC = n / c;
		int temp = nC;
		while(temp > 0)
		{
			nC += temp/m;
			int rem = temp % m;
			temp = temp/m; 
			if(temp > 0)
				temp += rem;
			//Console.WriteLine($"temp:{temp}");
		}
		//Console.WriteLine($"n:{n} c:{c} m:{m} nC:{nC}");
		Console.WriteLine(nC);
	}
}