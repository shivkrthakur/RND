<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	BetweenTwoSets();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void BetweenTwoSets()
{
	int n = 2, m = 3;
	int [] a = new int[]{2,4};
	int [] b = new int[]{16,32,96};
	Array.Sort(a);
	Array.Sort(b);
	int aLength = a.Length, bLength = b.Length;
	int counter = 0;
	bool flag = false;
	Console.WriteLine($"{a[aLength-1]} {b[0]}");
	for(int x = a[aLength-1]; x <= b[0]; x++)
	{
		flag = false;
		for(int j = 0; j < aLength; j++)
		{
			//Console.WriteLine($"1	x:{x} a[j]:{a[j]}");
			if((x % a[j]) != 0) 
			{
				//Console.WriteLine($"1.1	x:{x} a[j]:{a[j]}");
				flag = true;
				break;
			}
		}
		
		if(flag) continue;
		
		for(int k = 0; k < bLength; k++)
		{
			//Console.WriteLine($"2	x:{x} b[k]:{b[k]}");
			if((b[k] % x) != 0) 
			{
				//Console.WriteLine($"2.1	x:{x} b[k]:{b[k]}");
				flag = true;
				break;
			}
		}
		
		if(flag) continue;
		counter++;
		Console.WriteLine($"counter:{counter} x:{x}");
	}
	Console.WriteLine(counter);
}