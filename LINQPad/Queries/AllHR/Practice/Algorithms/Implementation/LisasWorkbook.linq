<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	LisasWorkbook();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void LisasWorkbook()
{
	int [] nk = "5 3".Split().Select(Int32.Parse).ToArray();
	int n = nk[0], k = nk[1];
	int [] input = "4 2 6 1 10".Split().Select(Int32.Parse).ToArray();
	
	int pageNo = 0, pageCount = 0, spc = 0;
	for(int i = 0; i < n; i++)
	{
		int startPageNo = pageNo + 1;
		int prob = input[i];
		int q = prob/k;
		pageCount = q;
		int rem = prob % k;
		if(rem > 0) pageCount++;
		//Console.WriteLine($"startPageNo:{startPageNo} pageCount:{pageCount} prob:{prob} spc:{spc}");
		int ii = 1;
		for(int j = startPageNo; j < (startPageNo + pageCount); j++)
		{
			for(; ii <= prob; ii++)
			{
				//Console.WriteLine($"j:{j} ii:{ii} ");
				if(ii == j)
				{
					spc++;
				}
				if(ii >= k && ii % k == 0) { ii++; break; }
				//Console.WriteLine($"ii:{ii} j:{j} startPageNo:{startPageNo} pageCount:{pageCount}  spc:{spc}");
			}
			//Console.WriteLine();
			//ii+=k;
		}
		pageNo += pageCount;
		//Console.WriteLine($"startPageNo: {startPageNo} pageNo:{pageNo} pageCount:{pageCount} spc:{spc}");
	}
	Console.WriteLine(spc);
}