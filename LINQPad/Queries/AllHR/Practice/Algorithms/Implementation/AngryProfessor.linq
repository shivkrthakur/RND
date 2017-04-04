<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	AngryProfessor();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void AngryProfessor()
{
	int t = 2;
	int n = 4, k = 3;
	int [] at = new[]{ -1, -3, 4, 2 };
	//int n = 4, k = 2;
	//int [] at = new[]{ 0, -1, 2, 1 };
	var result = at.Where(x => x <= 0).Count();
	//Console.WriteLine($"result:{result}");
	if(result < k) Console.WriteLine("YES");
	else Console.WriteLine("NO");
}