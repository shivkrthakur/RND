<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	SockMerchant();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void SockMerchant()
{
	int n = 15;
	int [] socks = new int[] {6, 5, 2, 3, 5, 2, 2, 1, 1, 5, 1, 3, 3, 3, 5};

	//int n = 9;
	//int [] socks = new int[] {10, 20, 20, 10, 10, 30, 50, 10, 20 };
	
	Array.Sort(socks);
	Console.WriteLine(String.Join(" ", socks));
	int outputCounter = 0;
	for(int j = 0; j < n; j++)
	{
		int count = 1;
		for(int k = j+1; k < n; k++)
		{
			if(socks[k] > 0 && (socks[j] == socks[k]))
			{
				socks[k] = -1;
				count++;
			}
			Console.WriteLine($"j:{j} k:{k} socks[j]: {socks[j]} socks[k]: {socks[k]} count: {count}");
		}
		
		outputCounter += count/2;
		Console.WriteLine($"outputCounter: {outputCounter}");
	}
	Console.WriteLine(outputCounter);
}