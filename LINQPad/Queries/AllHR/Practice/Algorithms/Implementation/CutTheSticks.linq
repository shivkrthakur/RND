<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	CutTheSticks();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void CutTheSticks()
{
	//int n = Convert.ToInt32("6");
	//int [] sticks = "5 4 4 2 2 8".Split().Select(Int32.Parse).ToArray();
	
	int n = Convert.ToInt32("8");
	int [] sticks = "1 2 3 4 3 3 2 1".Split().Select(Int32.Parse).ToArray();

	Array.Sort(sticks);
	//Console.WriteLine(sticks);
	for(int i = 0; i < n; i++)
	{
		if(sticks[i] <= 0) continue;
		int counter = 0;
		int num = sticks[i];
		for(int k = i; k < n; k++)
		{
			//Console.WriteLine($"i:{i} k:{k} sticks[i]:{sticks[i]} sticks[k]:{sticks[k]}");
			if(sticks[k] > 0)
			{
				sticks[k] = sticks[k] - num;
				counter++;
			}
		}
		//Console.WriteLine(sticks);
		Console.WriteLine(counter);
	}
}