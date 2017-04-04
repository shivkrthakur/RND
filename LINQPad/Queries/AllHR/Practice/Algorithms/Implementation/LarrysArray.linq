<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	LarrysArray();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void LarrysArray()
{
	int [][] INPUT = new int[1][]{
		    //"2 1 8 12 10 5 14 3 11 7 6 13 4 9".Split().Select(Int32.Parse).ToArray()
		//,	"10 12 6 11 1 7 8 3 9 2 4 5".Split().Select(Int32.Parse).ToArray() 
		//,	"19 8 22 7 5 13 10 2 16 27 9 1 21 3 23 4 14 15 6 20 18 12 28 25 24 26 17 11".Split().Select(Int32.Parse).ToArray()
//			"1 9 2 7 6 8 3 5 10 4".Split().Select(Int32.Parse).ToArray()
		   "14 13 15 7 16 3 9 10 8 2 6 5 1 12 11 4".Split().Select(Int32.Parse).ToArray()
//		,	"16 17 23 3 13 8 15 20 2 27 10 6 29 14 24 7 9 21 22 18 12 19 26 1 28 11 25 5 4".Split().Select(Int32.Parse).ToArray()
//		,	"9 8 10 7 3 5 2 11 4 6 1".Split().Select(Int32.Parse).ToArray()
	};
	
	for(int x = 0; x < INPUT.Length; x++)
	{
		int [] input = INPUT[x];
		//Console.WriteLine(input);
		
		Console.WriteLine(string.Join(" ", input));
		bool sorted = true;
		int i = 0, count = 0;
		int n = input.Length;
		while(i < n - 1)
		{
			if(input[i] > input[i+1])
			{
				if((i+3) <= n)
				{
					RotateFwd(input, i);
					continue;
				}
				else sorted = false;
			}	
			i++;
		}
		i = 0;
		Console.WriteLine(string.Join(" ", input));
				while(i < n - 1)
		{
			if(input[i] > input[i+1])
			{
				if((i+3) <= n)
				{
					RotateFwd(input, i);
					continue;
				}
				else sorted = false;
			}	
			i++;
		}
		Console.WriteLine(string.Join(" ", input));
		Console.WriteLine();
		return;
		if(!sorted)
		{
			int j = n-1;
			while(j > 0)
			{
				//Console.WriteLine($"j:{j}");
				if(input[j-1] > input[j])
				{
					if((j - 2) >= 0)
					{
						RotateFwd(input,j-2);
						j = n - 1;
						Console.WriteLine(string.Join(" ", input));
						continue;
					}
				}
				j--;
			}
		}
		//Console.WriteLine(input);
		//Console.WriteLine($"i:{i}");
		if(i == n - 1) Console.WriteLine("YES");
		else Console.WriteLine("NO");
	}
}

private static void RotateFwd(int[] input, int startIndex)
{
	int temp = input[startIndex];
	input[startIndex] = input[startIndex+1];
	input[startIndex + 1] = input[startIndex + 2];
	input[startIndex + 2] = temp;
	//Console.WriteLine(string.Join(" ", input));
}

private static void RotateBwd(int[] input, int startIndex)
{
	int temp = input[startIndex];
	input[startIndex] = input[startIndex-2];
	input[startIndex - 2] = input[startIndex - 1];
	input[startIndex - 1] = temp;
	Console.WriteLine(string.Join(" ", input));
}

public static void LarrysArrayBkUp()
{
	int t = Convert.ToInt32("7");
//	int n = Convert.ToInt32("3");
//	int [] input = "3 1 2".Split().Select(Int32.Parse).ToArray();
	
	//int n = Convert.ToInt32("4");
	//int [] input = "1 3 4 2".Split().Select(Int32.Parse).ToArray();
	
	//int n = Convert.ToInt32("5");
	//int [] input = "1 2 3 5 4".Split().Select(Int32.Parse).ToArray();
//	int [][] INPUT = new int[4][]{
//			    "3 1 2".Split().Select(Int32.Parse).ToArray()
//			,	"1 3 4 2".Split().Select(Int32.Parse).ToArray() 
//			,	"1 2 3 5 4".Split().Select(Int32.Parse).ToArray()
//			,	"4 1 3 2".Split().Select(Int32.Parse).ToArray()
//		};
		
	int [][] INPUT = new int[7][]{
		    "2 1 8 12 10 5 14 3 11 7 6 13 4 9".Split().Select(Int32.Parse).ToArray()
		,	"10 12 6 11 1 7 8 3 9 2 4 5".Split().Select(Int32.Parse).ToArray() 
		,	"19 8 22 7 5 13 10 2 16 27 9 1 21 3 23 4 14 15 6 20 18 12 28 25 24 26 17 11".Split().Select(Int32.Parse).ToArray()
		,	"1 9 2 7 6 8 3 5 10 4".Split().Select(Int32.Parse).ToArray()
		,	"14 13 15 7 16 3 9 10 8 2 6 5 1 12 11 4".Split().Select(Int32.Parse).ToArray()
		,	"16 17 23 3 13 8 15 20 2 27 10 6 29 14 24 7 9 21 22 18 12 19 26 1 28 11 25 5 4".Split().Select(Int32.Parse).ToArray()
		,	"9 8 10 7 3 5 2 11 4 6 1".Split().Select(Int32.Parse).ToArray()
	};
	
	for(int x = 0; x < t; x++)
	{
		int [] input = INPUT[x];
		//Console.WriteLine(input);
		bool sorted = false;
		int i = 0, count = 0;
		int n = input.Length;
		while(i < n - 1)
		{
			if(input[i] > input[i+1])
			{
				//Console.WriteLine($"i:{i} input[i]:{input[i]} input[i+1]:{input[i+1]} count:{count}");
				if(count == 3) count = 0;
				if((i + 3) <= n)
				{
					//Console.WriteLine("Ready to rotate 1");
					if(count <= 2)
					{
						count++;
						Rotate(input, i);
						//Console.WriteLine(input);
						continue;
					}
					else
					{
						count = 0;
						break;
					}
				}
				else if(--i >= 0)
				{
					//Console.WriteLine("Ready to rotate 2");
					if(count <= 2)
					{
						count++;
						Rotate(input, i);
						//Console.WriteLine(input);
						continue;
					}
					else
					{
						count = 0;
						break;
					}
				}
			}
			i++;
		}
		//Console.WriteLine(input);
		//Console.WriteLine($"i:{i}");
		if(i == n - 1) Console.WriteLine("YES");
		else Console.WriteLine("NO");
	}
}

private static void Rotate(int[] input, int startIndex)
{
	int temp = input[startIndex];
	input[startIndex] = input[startIndex+1];
	input[startIndex + 1] = input[startIndex + 2];
	input[startIndex + 2] = temp;
}