<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	CountingValleys();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
void CountingValleys()
{
	int n = Convert.ToInt32("16");
	string N = "UDDDUDUUUDDDUDUUDDDUDUDUUUU";
	int val = 0, valleys = 0;
	int i = 0, prevVal = 0;
	while(i < N.Length) 
	{ 
		if(N[i++] == 'U') val++; else val--; 
		if(prevVal < 0 && val == 0) valleys++;
		prevVal = val;
	}
	Console.WriteLine(valleys);
}