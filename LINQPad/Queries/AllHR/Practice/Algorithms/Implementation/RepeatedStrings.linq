<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	RepeatedStrings();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void RepeatedStrings()
{
	string s = "a";//"aba";
	long n = Convert.ToInt64("1000000000000");
	Console.WriteLine(n);
	long len = s.Length;
	long count = s.Where(x => x == 'a').ToArray().Count();
	
	if(n > len) 
	{
		long y = n/len;
		count = count * y;
		int rem = (int)(n % len);
		count += s.Take(rem).Where(x => x == 'a').ToArray().Count();	
	}
	Console.WriteLine(count);	
}