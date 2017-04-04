<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	EmmasSuperComputer();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void EmmasSuperComputer()
{
//	int [] nm = "5 6".Split().Select(Int32.Parse).ToArray();
//	string [] inputStrs = new string[] { "GGGGGG", "GBBBGB", "GGGGGG", "GGBBGB", "GGGGGG" };

//	int [] nm = "6 6".Split().Select(Int32.Parse).ToArray();
//	string [] inputStrs = new string[] { "BGBBGB", "GGGGGG", "BGBBGB", "GGGGGG", "BGBBGB", "BGBBGB" };
	
//	int [] nm = "6 7".Split().Select(Int32.Parse).ToArray();
//	string [] inputStrs = new string[] { "GGGGGGG", "BGBBBBG", "BGBBBBG", "GGGGGGG", "GGGGGGG", "BGBBBBG" };

//	int [] nm = "7 7".Split().Select(Int32.Parse).ToArray();
//	string [] inputStrs = new string[] { "GBGBGGB", "GBGBGGB", "GBGBGGB", "GGGGGGG", "GGGGGGG", "GBGBGGB", "GBGBGGB" };

//	int [] nm = "12 12".Split().Select(Int32.Parse).ToArray();
//	string [] inputStrs = new string[] { "GGGGGGGGGGGG", "GBGGBBBBBBBG", "GBGGBBBBBBBG", "GGGGGGGGGGGG", "GGGGGGGGGGGG", "GGGGGGGGGGGG", "GGGGGGGGGGGG", "GBGGBBBBBBBG", "GBGGBBBBBBBG", "GBGGBBBBBBBG", "GGGGGGGGGGGG", "GBGGBBBBBBBG" };

//	int [] nm = "11 13".Split().Select(Int32.Parse).ToArray();
//	string [] inputStrs = new string[] { "BBGGBBGBBGBBG", "BBGGBBGBBGBBG", "GGGGGGGGGGGGG", "BBGGBBGBBGBBG", "GGGGGGGGGGGGG", "BBGGBBGBBGBBG"
//		, "BBGGBBGBBGBBG", "GGGGGGGGGGGGG", "BBGGBBGBBGBBG", "GGGGGGGGGGGGG", "BBGGBBGBBGBBG"
//	};

	int [] nm = "8 9".Split().Select(Int32.Parse).ToArray();
	string [] inputStrs = new string[] { "GGGGGGGGG", "GBBBGGBGG", "GBBBGGBGG", "GBBBGGBGG", "GBBBGGBGG" 
		, "GBBBGGBGG", "GBBBGGBGG", "GGGGGGGGG"
	};

	/*
	Expected output 1.	
	8 9
	GGGGGGGGG
	GBBBGGBGG
	GBBBGGBGG
	GBBBGGBGG
	GBBBGGBGG
	GBBBGGBGG
	GBBBGGBGG
	GGGGGGGGG

	Expected output 169.	
	11 13
	BBGGBBGBBGBBG
	BBGGBBGBBGBBG
	GGGGGGGGGGGGG
	BBGGBBGBBGBBG
	GGGGGGGGGGGGG
	BBGGBBGBBGBBG
	BBGGBBGBBGBBG
	GGGGGGGGGGGGG
	BBGGBBGBBGBBG
	GGGGGGGGGGGGG
	BBGGBBGBBGBBG

	Expected output 5.	
	6 7
	GGGGGGG
	BGBBBBG
	BGBBBBG
	GGGGGGG
	GGGGGGG
	BGBBBBG

	Expected output 81.	
		12 12
	GGGGGGGGGGGG
	GBGGBBBBBBBG
	GBGGBBBBBBBG
	GGGGGGGGGGGG
	GGGGGGGGGGGG
	GGGGGGGGGGGG
	GGGGGGGGGGGG
	GBGGBBBBBBBG
	GBGGBBBBBBBG
	GBGGBBBBBBBG
	GGGGGGGGGGGG
	GBGGBBBBBBBG
	
	Expected Output = 125
	14 14
	"GGGGGGGGGGGGGG",
	"GGBBBBGBBBBBGG",
	"GGBBBBGBBBBBGG",
	"GGBBBBGBBBBBGG",
	"GGGGGGGGGGGGGG",
	"GGGGGGGGGGGGGG",
	"GGGGGGGGGGGGGG",
	"GGGGGGGGGGGGGG",
	"GGBBBBGBBBBBGG",
	"GGBBBBGBBBBBGG",
	"GGGGGGGGGGGGGG",
	"GGBBBBGBBBBBGG",
	"GGBBBBGBBBBBGG",
	"GGGGGGGGGGGGGG"
	*/
//	int [] nm = "14 14".Split().Select(Int32.Parse).ToArray();
//	string [] inputStrs = new string[] { "GGGGGGGGGGGGGG","GGBBBBGBBBBBGG","GGBBBBGBBBBBGG","GGBBBBGBBBBBGG","GGGGGGGGGGGGGG","GGGGGGGGGGGGGG","GGGGGGGGGGGGGG","GGGGGGGGGGGGGG","GGBBBBGBBBBBGG","GGBBBBGBBBBBGG","GGGGGGGGGGGGGG","GGBBBBGBBBBBGG","GGBBBBGBBBBBGG","GGGGGGGGGGGGGG" };

	int n = nm[0], m = nm[1];
	string [] input = new string[n];
	int [,] output = new int[n,m];
	for(int row = 0; row < n; row++)
	{
		input[row] = inputStrs[row]; 	
	}
	//Console.WriteLine(input);
	HashSet<Tuple<int,int>> rowscols = new HashSet<Tuple<int,int>>();
	//Dictionary<Tuple<int,int>, int> dict = new Dictionary<Tuple<int,int>, int>();
	//HashSet<KeyValuePair<int,HashSet<KeyValuePair<int,int>>> list = new HashSet<KeyValuePair<int,KeyValuePair<int,int>>>():
	HashSet<KeyValuePair<int,Tuple<int,int>>> parentSet = new HashSet<KeyValuePair<int,Tuple<int,int>>>();
	//HashSet<KeyValuePair<Tuple<int,int>, List<Tuple<int,int>>>> childSet = new HashSet<KeyValuePair<Tuple<int,int>, List<Tuple<int,int>>>>();
	//Dictionary<Tuple<int,int>, List<Tuple<int,int>>> childSet = new Dictionary<Tuple<int,int>, List<Tuple<int,int>>>();
	List<KeyValuePair<Tuple<int,int>, List<Tuple<int,int>>>> childSet = new List<KeyValuePair<Tuple<int,int>, List<Tuple<int,int>>>>();
	var set = new List<KeyValuePair<int, List<Tuple<int,int>>>> ();
	for(int row = 1; row < input.Length-1; row++)
	{
		//Console.WriteLine(input[row]);
		//Console.WriteLine(input[row].Substring(1,input[row].Length-2));
		int maxSize = 0;
		for(int col = 1; col < input[row].Length-1; col++)
		{
			char c  = input[row][col];
			//Console.Write(c);
			if(c == 'G' && !rowscols.Contains(new Tuple<int,int>(row,col))) 
			{
				var rowcol = new Tuple<int,int>(row,col);
				var rowColList = new List<Tuple<int,int>>(); 
				rowColList.Add(rowcol);
				set.Add(new KeyValuePair<int,List<Tuple<int,int>>>(1, rowColList));

				//Console.WriteLine($"row:{row} col:{col}");
				int nextRowCount = 0, nextColCount = 0, prevRowCount = 0, prevColCount = 0;
				for(int nextRow = row+1; nextRow < input.Length && (input[nextRow][col] == 'G'); nextRow++) { nextRowCount++; }
				for(int nextCol = col+1; nextCol < input[row].Length && (input[row][nextCol] == 'G'); nextCol++) { nextColCount++; }
				for(int prevRow = row-1; prevRow >= 0 && (input[prevRow][col] == 'G'); prevRow--) { prevRowCount++; }
				for(int prevCol = col-1; prevCol >= 0 && (input[row][prevCol] == 'G'); prevCol--) { prevColCount++; }
				//Console.WriteLine($"nextRowCount:{nextRowCount} prevRowCount:{prevRowCount} nextColCount:{nextColCount} prevColCount:{prevColCount}");
				int minVal = Math.Min(nextRowCount, Math.Min(prevRowCount,Math.Min(nextColCount, Math.Min(prevColCount,Int32.MaxValue))));
				if(minVal > 0)
				{
					//Console.WriteLine($"nextRowCount:{nextRowCount} prevRowCount:{prevRowCount} nextColCount:{nextColCount} prevColCount:{prevColCount}");
//					var rowcol = new Tuple<int,int>(row,col);
//					var rowColList = new List<Tuple<int,int>>(); 
//					rowColList.Add(rowcol);
//					set.Add(new KeyValuePair<int,List<Tuple<int,int>>>(1, rowColList));
					
					int mv = 1;
					while(mv <= minVal)
					{
						int key = mv * 4 + 1;
						var childset = new List<Tuple<int,int>>();
						childset.Add(rowcol);
						int vm = 1;
						while(vm <= mv)
						{
							childset.Add(new Tuple<int,int>(row + vm, col));
							childset.Add(new Tuple<int,int>(row - vm, col));
							childset.Add(new Tuple<int,int>(row, col + vm));
							childset.Add(new Tuple<int,int>(row, col - vm));
							vm++;
						}
						set.Add(new KeyValuePair<int,List<Tuple<int,int>>>(key, childset));
						mv++;
					}
				}
				/*
				if(minVal > 0) 
				{
					//dict.Add(new Tuple<int,int>(row,col), minVal * 4 + 1);
					int key = minVal * 4 + 1;
					//Console.WriteLine($"minVal:{minVal} key:{key}");
					var rowcol = new Tuple<int,int>(row,col);
					parentSet.Add(new KeyValuePair<int,Tuple<int,int>>(key, rowcol));
					
					var rowColList = new List<Tuple<int,int>>(); rowColList.Add(rowcol);
					childSet.Add(new KeyValuePair<Tuple<int,int>, List<Tuple<int,int>>>(rowcol, rowColList));
					
					List<Tuple<int,int>> childList = new List<Tuple<int,int>>();
					while(minVal > 0)
					{
						var tuple1 = new Tuple<int,int>(row + minVal, col);
						var tuple2 = new Tuple<int,int>(row - minVal, col);
						var tuple3 = new Tuple<int,int>(row, col - minVal);
						var tuple4 = new Tuple<int,int>(row, col - minVal);
						childList.Add(tuple1);
						childList.Add(tuple2);
						childList.Add(tuple3);
						childList.Add(tuple4);
						var innerChild = new List<Tuple<int,int>>() { rowcol, tuple1, tuple2, tuple3, tuple4 };
						childSet.Add(new KeyValuePair<Tuple<int,int>, List<Tuple<int,int>>>(rowcol, innerChild));
						minVal--;
					}
					childList.Add(rowcol);
					childSet.Add(new KeyValuePair<Tuple<int,int>, List<Tuple<int,int>>>(rowcol, childList));
//					maxSize = Math.Max(maxSize,minVal);
				}*/
				//if(Math.Min(nextRowCount, Math.Min(prevRowCount,Math.Min(nextColCount, Math.Min(prevColCount,0)))) == 0) Console.WriteLine("No pluses on this row");
			}
		}
//		if(maxSize > 0)
//			Console.WriteLine(maxSize);
		//if(minPlusSize == 0) Console.WriteLine("No pluses on this row");
		//else Console.WriteLine("Pluses on this row");
	}
	//Console.WriteLine(childSet);
	int max = 0;
	//set = set.Where(x => x.Key == 13).ToList();
	//set = set.OrderByDescending(x => x.Key).ToList();
	Console.WriteLine($"count:{set.Count}");
	foreach(var item1 in set)//set.Where(x => x.Key == 13))
	{
		Console.WriteLine();
		foreach(var item2 in set)//set.Where(x => x.Key == 13))
		{
			bool collide = false;
//			Console.WriteLine($"{item1.Key} {item2.Key}");
//			Console.WriteLine(item1);
//			Console.WriteLine(item2);
			foreach(var childItem in item2.Value)
			{
				if(item1.Value.Contains(childItem)) 
				{ 
					//Console.WriteLine($"COLLISION: {childItem.Item1} {childItem.Item2}");
					collide = true; 
					break;
				}
			}
			if(!collide) 
			{
				//Console.WriteLine($"{item1.Key} {item2.Key} max:{max} Nmax:{item1.Key * item2.Key}");
				max = Math.Max(max, item1.Key * item2.Key);
			}
		}
		break; 
		Console.WriteLine();
	}
	if(max <= 1) max = set.Max(x => x.Key);
	Console.WriteLine(max);
	//Console.WriteLine(set.Where(x => x.Key == 13).OrderByDescending(x => x.Key));
}