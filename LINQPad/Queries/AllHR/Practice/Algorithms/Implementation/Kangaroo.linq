<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	Kangaroo();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void Kangaroo()
{
	//int x1 = 0, v1 = 3, x2 = 4, v2 = 2;
	int x1 = 21, v1 = 6, x2 = 47, v2 = 3;
	if((x1 <= x2 && v1 < v2) | (x2 <= x1 && v2 < v1))
	{
		Console.WriteLine("NO");
	}
	
	int xdiff = x1 - x2;
	int vdiff = v2 - v1;
	var y = xdiff/((float)vdiff);
	
	Console.WriteLine(y);
	Console.WriteLine(y.GetType());
	if((y - (int)y) == 0)
    	Console.WriteLine($"xdiff:{xdiff} vdiff:{vdiff} y:{y}");
	else Console.WriteLine("NO");
	/*
	for(int i = 1; i <= 5; i++)
	{
		int sum1 = v1 * i + x1;
		int sum2 = v2 * i + x2;
		if(sum1 == sum2) break;
		Console.WriteLine($"OP: {v1 * i + x1} {v2 * i + x2}");
	}
	*/
	
}