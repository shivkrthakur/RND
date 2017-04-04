<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	TheHurdleRace();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
private static void TheHurdleRace()
{
	int [] nk  = Array.ConvertAll("5 4".Split(),Int32.Parse);
	int n = nk[0], k = nk[1];
	int [] h = Array.ConvertAll("1 6 3 5 2".Split(),Int32.Parse);
	int p = 0;
	for(int i = 0; i < n; i++)
	{
		if(h[i] > k)  { p += (h[i] - k); k += p; }
	}
	Console.WriteLine(p);
}