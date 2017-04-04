<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	StrangeCounter();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void StrangeCounter()
{
	long t = Convert.ToInt64("25");
	long x = 0;
	long y = 0;
	long z = 1;
	while(x + z <= t)
	{
		
		z = x + z;
		x = 3 * (long)Math.Pow(2,y);
		//Console.WriteLine($"z:{z} x:{x}");		
		y++;
	}
	
	long diff = t - z;
	long output = x - diff;
	//Console.WriteLine();
	//Console.WriteLine($"z:{z} x:{x} diff:{diff} output:{output}");
	Console.WriteLine($"{output}");
}