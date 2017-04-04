<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	ModifiedKaprekarNumbers();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void ModifiedKaprekarNumbers()
{
	int p = 2, q = 9;
	//int p = 1, q = 100;
	//int p = 45, q = 45;
	bool flag = true;
	for(int i = p; i <= q; i++)
	{
		string x = ((long)Math.Pow(i,2)).ToString();
		int length = x.Length;
		string leftString = "0" + x.Substring(0,length/2);
		string rightString = "0" + x.Substring(length/2,length - length/2);
		//Console.WriteLine($"x:{x} leftString:{leftString} rightString:{rightString}");
		//long left = Convert.ToInt64(String.IsNullOrEmpty(leftString)? "0": leftString);
		long left = Convert.ToInt64(leftString);
		long right = Convert.ToInt64(rightString);
		long sum = left + right;
		if(sum == i) 
		{
			Console.Write($"{i} ");
			flag = false;
		}
	}
	if(flag) Console.WriteLine($"INVALID RANGE");
}