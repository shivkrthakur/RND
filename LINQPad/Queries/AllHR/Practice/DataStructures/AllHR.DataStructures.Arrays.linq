<Query Kind="Program" />

void Main()
{
	//TwoDArrayDS();
	//DynamicArray();
	//LeftRotation();
	//SparseArrays();
	//AlgorithmicCrush();
	AlgorithmicCrushOptimized();
}

public static void AlgorithmicCrushOptimized()
{
	int [] nm = "5 3".Split().Select(Int32.Parse).ToArray();
	int n = nm[0], m = nm[1];
	long [] list = new long[n];
	string [] input = new string[] { "1 2 100", "2 5 100", "3 4 100" };
			
}

public static void AlgorithmicCrush()
{
	int [] nm = "5 3".Split().Select(Int32.Parse).ToArray();
	int n = nm[0], m = nm[1];
	long [] list = new long[n];
	string [] input = new string[] { "1 2 100", "2 5 100", "3 4 100" };
	for(int i = 0; i < m; i++)
	{
		int[] abk = input[i].Split().Select(Int32.Parse).ToArray();
		int a = abk[0], b = abk[1], k = abk[2];
		
		for(int j = a-1; j <= b-1; j++)
		{
			Console.WriteLine($"j:{j} i:{i} a:{a} b:{b} k: {k}");
			list[j] += k;
		}
		Console.WriteLine(list);
	}
	Console.WriteLine(list.Max());
}

public static void SparseArrays()
{
	int n = Convert.ToInt32("4");
	string [] strings = new string[] {"aba", "baba", "aba", "xzxb"};
	int q = Convert.ToInt32("3");
	string [] queries = new string[] {"aba", "xzxb", "ab"};
	for(int j = 0; j < q; j++)
	{
		int counter = 0;
		string query = queries[j];
		for(int i = 0; i < n; i++)
		{
			if(strings[i] == query) counter++;			
		}
		Console.WriteLine(counter);
	}
}

public static void LeftRotation()
{
	int [] nd = "5 6".Split().Select(Int32.Parse).ToArray();
	int n = nd[0], d = nd[1];
	int [] input = "1 2 3 4 5".Split().Select(Int32.Parse).ToArray();
	int [] output = new int[n];
	for(int i = 0; i < n; i++)
	{
		int t = (i + d) % n;
		output[i] = input[t];
		//Console.WriteLine(t);
	}
	Console.WriteLine(string.Join(" ",output));
}

// Define other methods and classes here
public static void DynamicArray()
{
	int [] NQ = "2 5".Split().Select(Int32.Parse).ToArray();
	string [] input = new string [] { "1 0 5", "1 1 7", "1 0 3", "2 1 0", "2 1 1"};
	int n = NQ[0], Q = NQ[1];
	int [][] seqList = new int[n][];
	/*for(int j = 0; j < n; j++)
	{
		seqList[j] = new int[]{0};
	}*/
	//Console.WriteLine(seqList); 
	
	int lastAns = 0;
	for(int i = 0; i < Q; i++)
	{
		int [] qxy = input[i].Split().Select(Int32.Parse).ToArray();
		int q = qxy[0], x = qxy[1], y = qxy[2];
		int index;
		int [] seq;
		switch(q)
		{
			case 1: 
				index = (x ^ lastAns) % n;
				seq = seqList[index];
				//Console.WriteLine($"Case0 seq:{string.Join(" ", seq)}");
				if(seq == null ) { seq = new int[] { y }; seqList[index] = seq; }
				else
				{
					Array.Resize(ref seq, seq.Length + 1);
					seq[seq.Length - 1] = y;
					seqList[index] = seq;
				}
				//Console.WriteLine($"Case1 q:{q} x:{x} y:{y} index:{index} seq:{string.Join(" ", seq)} lastAns:{lastAns}");
				//Console.WriteLine(seqList);
				/*if(op == null) op = new int[]{y};
				else
				{
					Array.Resize(ref op, op.Length + 1);
					op[op.Length - 1] = y;
				}*/
				//Console.WriteLine($"Case1: {string.Join(" ",qxy)} lastAns:{lastAns}"); 
				//Console.WriteLine(seqList); 
				break;
				
			case 2: 
				index = (x ^ lastAns) % n;
				seq = seqList[index];
				lastAns = y % seq.Length;
				lastAns = seq[lastAns];
				Console.WriteLine($"lastAns:{lastAns}");
				//Console.WriteLine($"Case2 q:{q} x:{x} y:{y} index:{index} seq:{string.Join(" ", seq)}");
				//Console.WriteLine(seqList); 
				/*
				if(seq != null) 
				{
					int t = y % seq.Length;
					lastAns = seq[t];
				}*/
				//Console.WriteLine($"Case2: {string.Join(" ",qxy)} lastAns:{lastAns}"); 
				//Console.WriteLine(seqList); 
				break;
		}
		
		
	}
}


public static void TwoDArrayDS()
{
	int [][] input = new int[6][];
	/*input[0] = new int[6]{1, 1, 1, 0, 0, 0};	input[1] = new int[6]{0, 1, 0, 0, 0, 0};	input[2] = new int[6]{1, 1, 1, 0, 0, 0};	input[3] = new int[6]{0, 0, 2, 4, 4, 0};	input[4] = new int[6]{0, 0, 0, 2, 0, 0};	input[5] = new int[6]{0, 0, 1, 2, 4, 0};	*/
	/*input[0] = new int[6]{1, 1, 1, 0, 0, 0};	input[1] = new int[6]{0, 1, 0, 0, 0, 0};	input[2] = new int[6]{1, 1, 1, 0, 0, 0};	input[3] = new int[6]{0, 9, 2, -4, -4, 0};	input[4] = new int[6]{0, 0, 0, -2, 0, 0};	input[5] = new int[6]{0, 0, -1, -2, -4, 0};*/	
	input[0] = new int[6]{-1, -1, 0, -9, -2, -2};
	input[1] = new int[6]{-2, -1, -6, -8, -2, -5};
	input[2] = new int[6]{-1, -1, -1, -2, -3, -4};
	input[3] = new int[6]{-1, -9, -2, -4, -4, -5};
	input[4] = new int[6]{-7, -3, -3, -2, -9, -9};
	input[5] = new int[6]{-1, -3, -1, -2, -4, -5};

	int prevResult = Int32.MinValue;
	for(int row = 0; row < input.Length - 2; row++)
	{
		for(int col = 0; col < input[row].Length - 2; col++)
		{
			int rowCounter = 0, result = 0; 
			for(int row_i = row; row_i < row + 3 && row_i < input.Length; row_i++)
			{
				int colCounter = 0;
				for(int col_i = col; col_i < col + 3 && col_i < input[row].Length; col_i++)
				{
					//Console.WriteLine($"rowCounter:{rowCounter} colCounter:{colCounter}");
					if(rowCounter == 1 & colCounter != 1) 
					{	
						colCounter++; 
						//Console.Write("   "); 
					}
					else 
					{
						result += input[row_i][col_i];
						//Console.Write($"{input[row_i][col_i]} ");
						colCounter++; 
					}
				}
				//Console.WriteLine();
				rowCounter++;
			}
			//if(Math.Abs(prevResult) < Math.Abs(result)) prevResult = result;
			if(prevResult < result) prevResult = result;
			//Console.WriteLine($"result: {result} prevResult:{prevResult}");
		}
	}
	Console.WriteLine(prevResult);
	/*
	for(int row = 0; row < input.Length - 2; row++)
	{
		int result = 0; 
		for(int row_i = row; row_i < row + 3 && row_i < input.Length; row_i++)
		{
			int counter = 0;
			for(int col = 0; col < input[row].Length - 2; col++)
			{
				for(int col_i = col; col_i < col + 3 && col_i < input[row].Length; col_i++)
				{
					//if(counter == 1) { counter = 0; continue;}
					result += input[row_i][col_i];
					Console.Write($"{input[row_i][col_i]} ");
				}
				Console.Write("		");
				//Console.Write($"{input[row][col]} ");
			}
			counter++;
			Console.WriteLine();
			Console.WriteLine($"{result}");
		}
		Console.WriteLine();
		Console.WriteLine($"{result}");
	}
	*/
}