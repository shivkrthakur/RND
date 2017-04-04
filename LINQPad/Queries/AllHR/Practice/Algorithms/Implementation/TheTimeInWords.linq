<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	TheTimeInWords();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void TheTimeInWords()
{
	int h = 5; int m = 15;
	string [] num = new string[] { "o' clock", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
	"nineteen", "twenty", "twenty one", "twenty two", "twenty three", "twenty four", "twenty five", "twenty six", "twenty seven", "twenty eight", "twenty nine", "half past" };
	string output = string.Empty;
	if(m == 0) output =string.Format("{0} {1}", num[h], num[m]);
	else if(m < 30) 
	{
		if(m == 15)
			output =string.Format("quarter past {0}", num[h]);
		else
			output =string.Format("{0} {1} past {2}", num[m], m == 1 ? "minute" : "minutes", num[h]);
	}
	else if(m == 30) output =string.Format("{0} {1}", num[m], num[h]);
	else if(m > 30) output = string.Format("{0} to {1}", m == 45 ? "quarter" : string.Format("{0} {1}", num[60 - m], "minutes"), num[h+1]);
	Console.WriteLine(output);
}