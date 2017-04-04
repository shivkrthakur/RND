<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	ElectronicsShop();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
void ElectronicsShop()
{
//	int [] snm = Array.ConvertAll("10 2 3".Split(), Int32.Parse);
//	int [] N = Array.ConvertAll("3 1".Split(), Int32.Parse);
//	int [] M = Array.ConvertAll("5 2 8".Split(), Int32.Parse);

	int [] snm = Array.ConvertAll("5 1 1".Split(), Int32.Parse);
	int [] N = Array.ConvertAll("4".Split(), Int32.Parse);
	int [] M = Array.ConvertAll("5".Split(), Int32.Parse);

	int s = snm[0], n = snm[1], m = snm[2];
	int max = -1;
	for(int i = 0; i < n; i++)
	{
		int kb = N[i];
		for(int j = 0; j < m; j++)
		{
			int usb = M[j];
			int sum = kb + usb;
			Console.WriteLine($"kb:{kb} usb:{usb} sum:{sum} max:{max}");
			if(sum <= s)
				max = Math.Max(max, sum);
		}
	}
	Console.WriteLine(max);
}