<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	NonDivisibleSubset();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void NonDivisibleSubset()
{
	int[] tempArr = "5 5".Split().Select(Int32.Parse).ToArray();
	int[] inputSet = Array.ConvertAll("2 7 12 17 22".Split(),Int32.Parse);

	//int[] tempArr = "10 4".Split().Select(Int32.Parse).ToArray();
	//int[] inputSet = Array.ConvertAll("1 2 3 4 5 6 7 8 9 10".Split(),Int32.Parse);

	//int[] tempArr = "4 3".Split().Select(Int32.Parse).ToArray();
	//int[] inputSet = Array.ConvertAll("1 7 2 4".Split(),Int32.Parse);

	//int[] tempArr = "10 10".Split().Select(Int32.Parse).ToArray();
	//int[] inputSet = Array.ConvertAll("2 8 20 4 6 90 5 7 16 17".Split(),Int32.Parse);

//	int[] tempArr = "6 9".Split().Select(Int32.Parse).ToArray();
//	int[] inputSet = Array.ConvertAll("422346306 940894801 696810740 862741861 85835055 313720373".Split(),Int32.Parse);
	int n = tempArr[0], k = tempArr[1];
	int[] inputSetRem = inputSet.Select(x => x % k).ToArray();
	int count = 0, stC = 0, gtC = 0, zC = 0, eC = 0;
	int[] output = new int[k];
	Console.WriteLine(inputSetRem);
	int half = k / 2;
	for(int i = 0; i < n; i++)
	{
		int mod = inputSetRem[i];
		if(mod == 0) { if(output[mod] == 0) output[mod]++; }
		//else if(output[k-mod] > 0) output[mod] -= 1;
		else output[mod]++;
		//output[mod]++;
		//if(mod <= half) Console.WriteLine($"mod:{mod} half:{half} stC:{++stC}");
		//else Console.WriteLine($"mod:{mod} half:{half} gtC:{++gtC}");
	}
	Console.WriteLine(output);
	count += output[0];
	Console.WriteLine(count);
	Console.WriteLine(half);
	for(int j = 1; j <= half; j++)
	{
		if(output[j] !=  0 && output[j] == output[k -j]) count++;
		else if(output[j] > output[k -j]) count += output[j];
		else count += output[k-j];
		//Console.WriteLine(j + " " + count);
//		if(j <= half) { stC += output[j]; //Console.WriteLine($"SC: {j} {stC}"); 
//		}
//		else { gtC += output[j]; //Console.WriteLine($"GC: {j} {gtC}"); 
//		}
	}
	//if(stC > gtC) Console.WriteLine(stC + output[0]);
	//else Console.WriteLine(gtC + output[0]);
	
	Console.WriteLine(count);
}