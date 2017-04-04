<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	SaveThePrisoner();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void SaveThePrisoner()
{
	//499999999 999999997 2
	//499999999 999999998 2
	//999999999 999999999 1
	long n = 499999999, m = 999999997, pid = 2;
	//long n = 352926151, m = 380324688, pid = 94730870;
	//long t = 1, n = 5, m = 2, pid = 10;
	//long t = 1, n = 5, m = 2, pid = 3;
	//long t = 1, n = 5, m = 14, pid = 3;
	long op = (m + pid - 1) % n;
	if(op == 0) op = n;
	Console.WriteLine(op);
}
