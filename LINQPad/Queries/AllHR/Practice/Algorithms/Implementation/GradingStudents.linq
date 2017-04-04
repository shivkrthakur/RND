<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	GradingStudents();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
private static void GradingStudents()
{
	int n = Convert.ToInt32("4");
	int [] N = { 40, 73, 67, 38, 33 };
	for(int i = 0; i < N.Length; i++)
	{
		int grade = N[i];
		if(grade < 38) Console.WriteLine(grade);
		else if(((5 * ((grade/5) + 1)) - grade) < 3) Console.WriteLine(5 * ((grade/5) + 1));
		else Console.WriteLine(grade);
	}
}