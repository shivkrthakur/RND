<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	BeautifulDaysAtTheMovies();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void BeautifulDaysAtTheMovies()
{
	long i = 117, j = 129, k = 6;
	//long i = 20, j = 23, k = 6;
	long counter = 0;
	for(long x = i; x <= j; x++)
	{
		long temp = x;
		long revx = 0;
		while(temp > 0)
		{
			int rem = (int)(temp % 10);
			temp = temp/10;
			revx = (revx * 10) + rem;
		}
		//Console.WriteLine($"x:{x} temp:{temp} revN:{revx}");
		
		/* THe following time outs for 3 test cases.
		string input = x.ToString();
		char[] inputCharArr = input.ToCharArray();
		Array.Reverse(inputCharArr);
		long revx = Convert.ToInt32(string.Join("",inputCharArr));
		*/
		long diff = Math.Abs(x - revx);
		if(diff % k == 0) counter++;
		//Console.WriteLine($"x:{x} revx:{revx} diff:{diff} counter:{counter}");
		//if((x % k == 0) && (revx % k == 0)) counter++;
	}
	Console.WriteLine(counter);
}