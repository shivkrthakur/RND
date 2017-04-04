<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	LibraryFine();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void LibraryFine()
{
	int[] aDayMonthYear = "9 6 2015".Split().Select(x => Int32.Parse(x)).ToArray();
	int aDay = aDayMonthYear[0], aMonth = aDayMonthYear[1], aYear = aDayMonthYear[2];
	int[] eDayMonthYear = "6 5 2015".Split().Select(x => Int32.Parse(x)).ToArray();
	int eDay = eDayMonthYear[0], eMonth = eDayMonthYear[1], eYear = aDayMonthYear[2];
	int fine = 0;
	
	if(aYear > eYear)
	{
		fine = 10000;
	}
	else
	{
		if(aMonth > eMonth)
		{
			int months = aMonth - eMonth;
			fine = months * 500;
		}
		else
		{
			if(aDay > eDay)
			{
				int days = aDay - eDay;
				fine = 15 * days;
			}
		}
	}
	Console.WriteLine(fine);
	
}

