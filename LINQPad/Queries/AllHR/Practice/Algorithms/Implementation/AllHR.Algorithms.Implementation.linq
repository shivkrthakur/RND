<Query Kind="Program" />

//https://www.hackerrank.com/challenges/sherlock-and-the-beast/topics
void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	/*
	AbsolutePermutation();
	AlmostSorted();
	AngryProfessor();
    AppleAndOrange();
	AppendAndDelete();
	BeautifulDaysAtTheMovies();
	BeautifulTriplets();
	BetweenTwoSets();
	BiggerIsGreater();
	BomberMan();
	CavityMap();
	ChocolateFeast();
	ClimbingTheLeaderBoard();
	CountingValleys();
	CutTheSticks();
	ElectronicsShop();
	EmmasSuperComputer();
	Encryption();
	EqualizeTheArray();
	FindDigits();
	GradingStudents();
	HappyLadyBugsUnSolved();
	JumpingOnTheClouds();
	JumpingOnTheCloudsRevisited();
    Kangaroo();
	LarrysArray();
	LibraryFine();
	LisasWorkbook();
	MagicSquareForming();
	ManasaAndStones();
	MatrixLayerRotation();
	MatrixLayerRotationOp();
	MinimumDistances();
	ModifiedKaprekarNumbers();
    NewPDFDesign();
	NonDivisibleSubset();
	QueensAttackII();
	RepeatedStrings();
	SaveThePrisoner();
	SequenceEquation();
	SherlockAndSquares();
	SherlockAndTheBeast();
	SockMerchant();
	StrangeCounter();
	TaumAndBDay();
	TheGridSearch();
	TheHurdleRace();
	TheTimeInWords();
	UtopianTree();
	ViralAdvertising();
	*/
	//StrangeAdvertising();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

public static void MatrixLayerRotationOp()
{
//	int [] nmr = Array.ConvertAll("4 4 2".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4", "5 6 7 8", "9 10 11 12", "13 14 15 16" };
//	int [] nmr = Array.ConvertAll("5 4 7".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4", "7 8 9 10", "13 14 15 16", "19 20 21 22", "25 26 27 28" };
//	int [] nmr = Array.ConvertAll("2 2 3".Split(), Int32.Parse);
//	string [] s = new string[] { "1 1", "1 1"};
//	int [] nmr = Array.ConvertAll("5 5 7".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4 5", "7 8 9 10 11", "12 13 14 15 16", "17 19 20 21 22", "24 25 26 27 28" };
//	int [] nmr = Array.ConvertAll("5 6 7".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4 5 6", "7 8 9 10 11 12", "13 14 15 16 17 18", "19 20 21 22 23 24", "25 26 27 28 29 30" };

//	int [] nmr = Array.ConvertAll("6 6 7".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4 5 6", "7 8 9 10 11 12", "13 14 15 16 17 18", "19 20 21 22 23 24", "25 26 27 28 29 30", "31 32 33 34 35 36" };

//	int [] nmr = Array.ConvertAll("7 6 7".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4 5 6", "7 8 9 10 11 12", "13 14 15 16 17 18", "19 20 21 22 23 24", "25 26 27 28 29 30", "31 32 33 34 35 36", "37 38 39 40 41 42" };

//	int [] nmr = Array.ConvertAll("7 7 7".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4 5 6 50", "7 8 9 10 11 12 51", "13 14 15 16 17 18 52", "19 20 21 22 23 24 53", "25 26 27 28 29 30 54", "31 32 33 34 35 36 55", "37 38 39 40 41 42 56" };

//	int [] nmr = Array.ConvertAll("7 7 5".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4 5 6 7", "24 25 26 27 28 29 8", "23 40 41 42 43 30 9", "22 39 48 49 44 31 10", "21 38 47 46 45 32 11", "20 37 36 35 34 33 12", "19 18 17 16 15 14 13" };

	int [] nmr = Array.ConvertAll("2 2 3".Split(), Int32.Parse);
	string [] s = new string[] { "1 1", "1 1"};

	int n = nmr[0], m = nmr[1], R = nmr[2];

	int [,] input = new int[n,m];
    for(int row = 0; row < n; row++)
    {
		int [] tt = s[row].Split().Select(Int32.Parse).ToArray();
        for(int col = 0; col < m; col++)
        {
            input[row,col] = tt[col];
        }
    }
    Console.WriteLine(input);
    int left = 0, top = 0, bottom = n-1, right = m-1;
    while(left <= right && top <= bottom)
    {
		//Console.WriteLine($"left:{left} right:{right} top:{top} bottom:{bottom}");
		int rows = bottom-top + 1, cols = right - left + 1;
		int nOfS = (rows == 1 && cols == 1) ? 1 : ((2 * rows) + (2 * (cols - 2)));
		int rem = R % nOfS;
		//Console.WriteLine($"rows:{rows} cols:{cols} nOfS:{nOfS} rem:{rem}");
        int l = left, t = top, b = bottom, r = right;
		
		int [] tempArr = new int[nOfS];
		int [] rotatedArr = new int[nOfS];
		int i = 0;
        while(l < r){ tempArr[i++] = input[t,l++]; }
        while(t < b){ tempArr[i++] = input[t++,r]; }
        while(r > left){ tempArr[i++] = input[b,r--]; }
        while(b > top){ tempArr[i++] = input[b--,r]; }

		i = 0;
		while(i < nOfS){ rotatedArr[i] = tempArr[(i+rem) % nOfS]; i++; }
		
		//Console.WriteLine(string.Join(" ", tempArr));
		//Console.WriteLine(string.Join(" ", tempRotArr));
		//Console.WriteLine($"tempArr[rem]:{tempArr[rem]}");
		i = 0; l = left; t = top; b = bottom; r = right;
        while(l < r){ input[t,l++] = rotatedArr[i++]; }
        while(t < b){ input[t++,r] = rotatedArr[i++]; }
        while(r > left){ input[b,r--] = rotatedArr[i++]; }
        while(b > top){ input[b--,r] = rotatedArr[i++]; }
        left++; right--; top++; bottom--;
	}
	Console.WriteLine(input);
}

public static void MatrixLayerRotation()
{
//	int [] mnr = Array.ConvertAll("4 4 1".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4", "5 6 7 8", "9 10 11 12", "13 14 15 16" };

//	int [] mnr = Array.ConvertAll("4 4 2".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4", "5 6 7 8", "9 10 11 12", "13 14 15 16" };

//	int [] mnr = Array.ConvertAll("5 4 7".Split(), Int32.Parse);
//	string [] s = new string[] { "1 2 3 4", "7 8 9 10", "13 14 15 16", "19 20 21 22", "25 26 27 28" };

	int [] mnr = Array.ConvertAll("2 2 3".Split(), Int32.Parse);
	string [] s = new string[] { "1 1", "1 1"};
	int m = mnr[0], n = mnr[1], R = mnr[2];

	int [,] input = new int[m,n];
	for(int row = 0; row < m; row++)
	{
		int [] tt = s[row].Split().Select(Int32.Parse).ToArray();
		for(int col = 0; col < n; col++)
		{
			input[row,col] = tt[col];
		}
	}
	Console.WriteLine(input);
	for(int k = 0; k < R; k++)
	{
		int left = 0, top = 0, bottom = m-1, right = n-1;
		while(left < right && top < bottom)
		{
			int l = left, t = top, b = bottom, r = right;
			int temp = input[t,l];
			//Console.WriteLine($"l:{l} t:{t} b:{b} r:{r} temp:{temp}");
			while(l < r){ input[t,l++] = input[t,l]; }
			while(t < b){ input[t++,r] = input[t,r]; }
			while(r > left){ input[b,r--] = input[b,r]; }
			while(b > top){ input[b--,r] = input[b,r]; }
			input[++b,r] = temp;
			//Console.WriteLine(input);
			left++; right--; top++; bottom--;
		}
	}
	Console.WriteLine(input);
}

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

public static void BomberMan()
{
	int [] rcn = "3 3 1".Split().Select(Int32.Parse).ToArray();
	string [] inputStr = new string[] { "..O", "...", "..O" };
	//int [] rcn = "6 7 6".Split().Select(Int32.Parse).ToArray();
	//string [] inputStr = new string[] { ".......", "...O...", "....O..", ".......",  "OO.....", "OO....." };
	//int [] rcn = "1 199 181054341".Split().Select(Int32.Parse).ToArray();
	//string [] inputStr = new string[] { "O..OO........O..O........OO.O.OO.OO...O.....OOO...OO.O..OOOOO...O.O..O..O.O..OOO..O..O..O....O...O....O...O..O..O....O.O.O.O.....O.....OOOO..O......O.O.....OOO....OO....OO....O.O...O..OO....OO..O...O" };
	/*output: OOOOO........OOOO........OOOOOOOOOO...O.....OOO...OOOOOOOOOOO...OOOOOOOOOOOOOOOOOOOOOOOOO....O...O....O...OOOOOOO....OOOOOOO.....O.....OOOOOOO......OOO.....OOO....OO....OO....OOO...OOOOO....OOOOO...O */
	
	//int [] rcn = "1 10 7".Split().Select(Int32.Parse).ToArray();
	//string [] inputStr = new string[] { "O..OO....." };
	
	int r = rcn[0], c = rcn[1], n = rcn[2];
	string [] input = new string[r];
	char[][] baseOutput = new char[r][];
	for(int i = 0; i < r; i++)
	{
		input[i] = inputStr[i];
		//output[i] = new String('O',c).Select(x => (int)x).ToArray();
		baseOutput[i] = Enumerable.Repeat('O', c).ToArray();
	}
	if(n % 2 == 0) for(int j = 0; j < r; j++) { Console.WriteLine(new string(baseOutput[j])); }
	else
	{
		var output = baseOutput.Select(a => a.ToArray()).ToArray();
		for(int row = 0; row < r; row++)
		{
			for(int col = 0; col < c; col++)
			{
				//Console.WriteLine($"{row} {col}");
				if(input[row][col] == 'O')  
				{
					output[row][col] = '.';
					if(row > 0) output[row - 1][col] = '.';
					if(row < r - 1) output[row + 1][col] = '.';
					if(col > 0) output[row][col - 1] = '.';
					if(col < c - 1) output[row][col + 1] = '.';
				}

			}
		}
	
		if(n == 1) { Console.WriteLine(string.Join(Environment.NewLine,input)); }
		else if(((n/2) & 1) != 0)
		{
			for(int j = 0; j < r; j++) { Console.WriteLine(new string(output[j])); }
		}
		else
		{
		
			//var temp = new char[r][];
			var temp = baseOutput.Select(a => a.ToArray()).ToArray();
			//output.Select(a => a.ToArray()).ToArray();
			//Console.WriteLine(temp);
			//Console.WriteLine(output);

			for(int row = 0; row < r; row++)
			{
				for(int col = 0; col < c; col++)
				{
					//Console.WriteLine($"{row} {col}");
					if(output[row][col] == 'O')  
					{
						temp[row][col] = '.';
						if(row > 0) temp[row - 1][col] = '.';
						if(row < r - 1) temp[row + 1][col] = '.';
						if(col > 0) temp[row][col - 1] = '.';
						if(col < c - 1) temp[row][col + 1] = '.';
					}
	
				}
			}
			//Console.WriteLine(temp);
			//Console.WriteLine(output);
			for(int j = 0; j < r; j++) { Console.WriteLine(new string(temp[j])); }
			//Console.WriteLine(string.Join(" ",input));
		}
	}
}

void MagicSquareForming()
{
	int [,] arr = new int[3,3];
	int [] l1 = Array.ConvertAll("10 2 3".Split(), Int32.Parse);
	int [] l2 = Array.ConvertAll("10 2 3".Split(), Int32.Parse);
	int [] l3 = Array.ConvertAll("10 2 3".Split(), Int32.Parse);
	string [] input = { "4 9 2", "3 5 7", "8 1 5" };
	for(int i = 0; i < 3; i++)
	{
		int [] row = Array.ConvertAll(input[i].Split(), Int32.Parse);
		Console.WriteLine($"rowSum:{row.Sum()}");
		for(int j = 0; j < 3; j++)
		{
			arr[i,j] = row[j];
		}
	}	
	Console.WriteLine(arr);
	for(int col = 0; col < 3; col++)
	{
		for(int row = 0; row < 3; row++)
		{
			
		}
	
	}
}

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

void CountingValleys()
{
	int n = Convert.ToInt32("16");
	string N = "UDDDUDUUUDDDUDUUDDDUDUDUUUU";
	int val = 0, valleys = 0;
	int i = 0, prevVal = 0;
	while(i < N.Length) 
	{ 
		if(N[i++] == 'U') val++; else val--; 
		if(prevVal < 0 && val == 0) valleys++;
		prevVal = val;
	}
	Console.WriteLine(valleys);
}

static bool present(int x, int y, string[] G, string[] P) 
{
	Console.WriteLine();
    for(int i = 0; i < P.Length; ++i) 
	{
        for(int j = 0; j < P[0].Length; ++j) 
		{
            int ii = i + x, jj = j + y;
			if(ii < G.Length && jj < G[0].Length)	Console.WriteLine($"ii:{ii} jj:{jj} G[ii][jj]:{G[ii][jj]} P[i][j]:{P[i][j]}");
            if(ii >= G.Length || jj >= G[0].Length) return false;
            else if(G[ii][jj] != P[i][j]) return false;
            else continue;
        }
    }
    return true;
}

public static void TheGridSearch()
{
	int t = Convert.ToInt32("2");
	//string [][] input = new string[][]{  new string[]{ "989999", "211211" }, new string[]{ "99", "11" } };
	//string [][] input = new string[][]{  new string[]{ "34889246430321978567","58957542800420926643","35502505614464308821","14858224623252492823","72509980920257761017","22842014894387119401","01112950562348692493","16417403478999610594","79426411112116726706","65175742483779283052","89078730337964397201","13765228547239925167","26113704444636815161","25993216162800952044","88796416233981756034","14416627212117283516","15248825304941012863","88460496662793369385","59727291023618867708","19755940017808628326" }, new string[]{ "1641","7942","6517","8907","1376","2691","2599" } };
	//string [][] input = new string[][]{  new string[]{ "123412","561212","123634","781288" }, new string[]{ "12", "34" } };
	string [][] input = new string[][]{  new string[]{ "111111111111111","111111111111111","111111011111111","111111111111111","111111111111111" }, new string[]{ "11111","11111","11110" } };
    
	for(int z = 0; z < t; z++){
		string [] G = input[z];
		int gRows = G.Length;
		int gCols = G[0].Length;
		
		string [] P = input[++z];
		int pRows = P.Length;
		int pCols = P[0].Length;
		
		///* EDITORIAL SOLUTION
		bool isPresent = false;
	    for(int i = 0; i < gRows; ++i) 
		{
	        for(int j = 0; j < gCols; ++j) 
			{
				Console.WriteLine($"i:{i} j:{j}");		
	            isPresent = present(i, j, G, P);
	            if(isPresent)
	                break;
	        }
	        if(isPresent)
	            break;
	    }
		//*/
		
		/* Passed
		string pString = P[0];
        List<KeyValuePair<int,int>> list = new List<KeyValuePair<int,int>>();
        for(int gRow = 0; gRow < gRows; gRow++)
        {
            string gString = G[gRow];
            int index = gString.IndexOf(pString);
            if(index > -1)
            {
                //Console.WriteLine($"gString:{gString} pString:{pString} gRow:{gRow} index:{index}");
				list.Add(new KeyValuePair<int,int>(gRow,index));
                for(int gCol = index+1; gCol < gCols; gCol++)
                {
                    index = gString.IndexOf(pString, gCol);
					//Console.WriteLine($"gString:{gString} pString:{pString} gRow:{gRow} index:{index}");
                    var kv = new KeyValuePair<int,int>(gRow,index);
                    if(index > -1 && !list.Contains(kv)) list.Add(kv);
                    else break;
                }
            }
        }
		//Console.WriteLine(list);
		int prevCol = list[0].Value;
		int equalsCount = 0;
        foreach(var item in list)
        {
            int row = item.Key;
            int col = item.Value;
			equalsCount = 1;
			for(int pRow = 1, gRow = row + 1; pRow < pRows && gRow < gRows; pRow++, gRow++)
            {
                string gString = G[gRow];
                pString = P[pRow];
                int index = gString.IndexOf(pString, col);
				//Console.WriteLine($"prevCol:{prevCol} gString:{gString} pString:{pString} index:{index} col:{col}");
                if(col == index) { equalsCount++; }
            }
			//Console.WriteLine(equalsCount);
			//Console.WriteLine();
        }
        Console.WriteLine((equalsCount == pRows) ? "YES" : "NO");
		Console.WriteLine($"equalsCount:{equalsCount} pRows:{pRows}");
		*/
		//Console.WriteLine();Console.WriteLine();Console.WriteLine();Console.WriteLine();
        /*
		pString = P[0];
        //List<KeyValuePair<int,int>> list = new List<KeyValuePair<int,int>>();
		HashSet<Tuple<int,int>> list2 = new HashSet<Tuple<int,int>>();
        for(int gRow = 0; gRow < gRows; gRow++)
        {
            string gString = G[gRow];
            int index = gString.IndexOf(pString);
			if(index > -1)
            {
            	Console.WriteLine($"gString:{gString} pString:{pString} gRow:{gRow} index:{index}");
                //list.Add(new KeyValuePair<int,int>(gRow,index));
				list2.Add(new Tuple<int,int>(gRow,index));
                for(int gCol = index+1; gCol < gCols; gCol++)
                {
                    index = gString.IndexOf(pString, gCol);
					Console.WriteLine($"gString:{gString} pString:{pString} gRow:{gRow} index:{index}");
                    if(index > -1) list2.Add(new Tuple<int,int>(gRow,index));//list.Add(new KeyValuePair<int,int>(gRow,index));
                    else break;
                }
            }
        }
		var arr = list2.ToArray();
		Console.WriteLine(list2);
		equalsCount = 1;
		for(int k = 0; k < list2.Count; k++)
		{
			int row = arr[k].Item1;			
			int col = arr[k].Item2;
			for(int pRow = 1, gRow = row + 1; pRow < pRows && gRow < gRows; pRow++, gRow++)
            {
                string gString = G[gRow];
                pString = P[pRow];
                int index = gString.IndexOf(pString, col);
				Console.WriteLine($"gString:{gString} pString:{pString} index:{index} col:{col}");
				if(index == col) equalsCount++; //Console.WriteLine("EQUAL"); 
            }
		}
		
		if(equalsCount == pRows) Console.WriteLine("Yes"); else Console.WriteLine("No");
		Console.WriteLine($"equalsCount:{equalsCount} pRows:{pRows}");
		//*/
		
		/*
        foreach(var item in list)
        {
            int row = item.Key;
            int col = item.Value;
            patternFound = true;
            for(int pRow = 1, gRow = row + 1; pRow < pRows && gRow < gRows; pRow++, gRow++)
            {
                string gString = G[gRow];
                pString = P[pRow];
                int index = gString.IndexOf(pString);
                if(col != index)
                {
                    patternFound = false;
                    for(int gCol = index + 1; gCol < gCols; gCol++)
                    {
                        int i = gString.IndexOf(pString, gCol);
                        if(i > gCol) gCol = i;
                        if(col == i) { patternFound = true; break; }
                    }
                    break;
                }
            }
            if(patternFound) break;
        }
		*/
        //if(patternFound) Console.WriteLine("YES");
        //else Console.WriteLine("NO");
    }
}

public static void TheGridSearchSlow()
{
//	string [][] input = new string[][]{  new string[]{ "7283455864", "6731158619", "8988242643", "3830589324", "2229505813", "5633845374", "6473530293", "7053106601", "0834282956", "4607924137" }
//										, new string[]{ "9505", "3845", "3530" }
//										, new string[]{ "400453592126560", "114213133098692", "474386082879648", "522356951189169", "887109450487496", "252802633388782", "502771484966748", "075975207693780", "511799789562806", "404007454272504"
//, "549043809916080", "962410809534811", "445893523733475", "768705303214174", "650629270887160" }
//										, new string[]{ "99", "99"}
//								 	  };

//		string [][] input = new string[][]{  new string[]{ "7283455864", "6731158619", "8988242643", "3830589324", "2229505813", "5633845374", "6473530293", "7053106601", "0834282956", "4607924137" }
//										, new string[]{ "9505", "3845", "3530" }
//										, new string[]{ "400453592126560", "114213133098692", "474386082879648", "522356951189169", "887109450487496", "252802633388782", "502771484966748", "075975207693780", "511799789562806", "404007994272504"
//, "549043809916080", "962499809534811", "445893529933475", "768705303214174", "650629270887160" }
//										, new string[]{ "99", "99"}
//								 	  };

	string [][] input = new string[][]{  new string[]{ "989999", "211211" }, new string[]{ "99", "11" } };
	//Console.WriteLine(input);
	for(int z = 0; z < input.Length; z++)
	{
		string [] G = input[z];
		int gRows = G.Length;
		int gCols = G[0].Length;
		
		string [] P = input[++z];
		int pRows = P.Length;
		int pCols = P[0].Length;
		
//		Console.WriteLine(G);
//		Console.WriteLine(P);
//		Console.WriteLine($"gRows:{gRows} gCols:{gCols} G:{string.Join(" ", G)}");
//		Console.WriteLine($"pRows:{pRows} pCols:{pCols} P:{string.Join(" ", P)}");
//		Console.WriteLine();
		
		string pString = P[0];
		List<KeyValuePair<int,int>> list = new List<KeyValuePair<int,int>>();
		for(int gRow = 0; gRow < gRows; gRow++)
		{
			string gString = G[gRow];
			int index = gString.IndexOf(pString);
			//Console.WriteLine($"pString:{pString} gString:{gString} index:{index}");
			if(index > -1)
			{
				list.Add(new KeyValuePair<int,int>(gRow,index));
				for(int gCol = index+1; gCol < gCols; gCol++)
				{
					index = gString.IndexOf(pString, gCol);
					//Console.WriteLine($"pString:{pString} gString:{gString} index:{index}");
					if(index > -1) list.Add(new KeyValuePair<int,int>(gRow,index));
					else break;
				}
			}
		}
		//Console.WriteLine(list);
		//return;
		//Console.WriteLine();
		//Console.WriteLine();
		bool patternFound = false;
		foreach(var item in list)
		{
			//Console.WriteLine(item);
			int row = item.Key;
			int col = item.Value;
			patternFound = true;
			for(int pRow = 1, gRow = row + 1; pRow < pRows && gRow < gRows; pRow++, gRow++)
			{
				string gString = G[gRow];
				pString = P[pRow];
				int index = gString.IndexOf(pString);
				if(col != index)
				{
					patternFound = false;
					for(int gCol = index + 1; gCol < gCols; gCol++)
					{
						int i = gString.IndexOf(pString, gCol);
						//Console.WriteLine($"gString:{gString} pString:{pString} index:{i} gCol:{gCol}");
						if(i > gCol) gCol = i;
						if(col == i) { patternFound = true; break; }
					}
					break;
				}
			}
			if(patternFound) break;
		}
		//Console.WriteLine(list);
		//Console.WriteLine();
		if(patternFound) Console.WriteLine("YES");
		else Console.WriteLine("NO");
	}
}

void ClimbingTheLeaderBoard()
{
	int n = Convert.ToInt32("7");
	int [] lScores = Array.ConvertAll("100 100 50 40 40 20 10".Split(), Int32.Parse);
	int m = Convert.ToInt32("4");
	int [] aScores = Array.ConvertAll("5 25 50 120".Split(), Int32.Parse);
	//int m = Convert.ToInt32("8");
	//int [] aScores = Array.ConvertAll("1 5 25 30 40 45 50 120".Split(), Int32.Parse);
	
	int rank = 1;
	int j = 0;
	int prevNo = 0;;
	int p = m;
	int [] op = new int[m];
	for(int i = m-1; i >= 0; i--)
	{
		for(; j < n;j++)
		{
			//Console.WriteLine($"i:{i} j:{j} aScores[i]:{aScores[i]} lScores[j]:{lScores[j]} prevNo:{prevNo} rank:{rank}");
			if(aScores[i] >= lScores[j]) 
			{ 
				op[--p] = rank; 
				//Console.WriteLine($"RANK HERE: i:{i} j:{j} aScores[i]:{aScores[i]} lScores[j]:{lScores[j]} rank:{rank}"); 
				break; 
			}
			if(prevNo != lScores[j]) rank++;
			prevNo = lScores[j];
		}
	}
	while(--p >= 0) op[p] = rank;
	Console.WriteLine(string.Join(Environment.NewLine,op));
	
    /* Successful solution but times out on three test cases;
	
	int rnk = 1;
    for(int i = 0; i < n-1; i++)
    {
        if(lScores[i] != lScores[i+1]) rnk++;
    }    
    //Console.WriteLine($"{rnk}");
    for(int j = 0; j < m; j++)
    {
        int rank = rnk;
        int aj = aScores[j];
        int output = 1;
        for(int k = n-1; k > 0; k--)
        {
            int si = lScores[k];
            //Console.WriteLine($"aj:{aj} si:{si} rank:{rank}");
            if(aj < si) { output = rank + 1;  break; }
            else if((aj == si) || (aj > si && aj < lScores[k-1])) { output = rank; break; } 
            //else if (aj > si && aj < scores[k-1]) { Console.WriteLine(rank - 1); break; }
            if(si != lScores[k-1]) rank--;
        }
        Console.WriteLine(output);
    }//*/
	
	/* EDITORIAL SOLUTION BELOW:
	int [] rank = new int[n];
    for (int i = 0; i < n; i++) 
	{
        if (i == 0) 
		{
            rank[i] = 1;
        }
        else 
		{
            if (lScores[i] == lScores[i-1]) 
			{
                rank[i] = rank[i - 1];
        	}
	        else 
			{
	                rank[i] = rank[i - 1] + 1;
	        }
       }
    }
	Console.WriteLine(rank);
	for(int j = 0; j < m; j++) 
	{
		int point = n-1;	
        int current_rank = 1;
		//Console.WriteLine($"j:{j}");
		while (point >= 0 && aScores[j] > lScores[point]) {
            point--;
        }
        
        if (point == -1) {
            current_rank = 1;
        }
        else if (aScores[j] == lScores[point]) {
            current_rank = rank[point];
        }
        else if (aScores[j] < lScores[point]) {
            current_rank = rank[point] + 1;
        }
		Console.WriteLine(current_rank);
    }
	*/
}
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

private static void TheHurdleRace()
{
	int [] nk  = Array.ConvertAll("5 4".Split(),Int32.Parse);
	int n = nk[0], k = nk[1];
	int [] h = Array.ConvertAll("1 6 3 5 2".Split(),Int32.Parse);
	int p = 0;
	for(int i = 0; i < n; i++)
	{
		if(h[i] > k)  { p += (h[i] - k); k += p; }
	}
	Console.WriteLine(p);
}

private static void GradingStudents()
{
	int n = Convert.ToInt32("4");
	int [] N = { 40, 73, 67, 38, 33 };
	for(int i = 0; i < N.Length; i++)
	{
		int grade = N[i];
		if(grade < 38) Console.WriteLine(grade);
		else if(((5 * ((grade/5) + 1)) - grade) < 3) Console.WriteLine(5 * ((grade/5) + 1));
		else Console.WriteLine(grade);
	}
}

private static void QueensAttackII()
{
	string[] tokens_n = "5 3".Split(' ');
    int n = Convert.ToInt32(tokens_n[0]);
    int k = Convert.ToInt32(tokens_n[1]);
    string[] tokens_rQueen = "4 3".Split(' ');
    int rQueen = Convert.ToInt32(tokens_rQueen[0]);
    int cQueen = Convert.ToInt32(tokens_rQueen[1]);
	string [] obstacles = new string[]{ "5 5", "4 2", "2 3" };
	HashSet<Tuple<int,int>> hs = new HashSet<Tuple<int,int>>();
    for(int a0 = 0; a0 < k; a0++){
        string[] tokens_rObstacle = obstacles[a0].Split(' ');
        int rObstacle = Convert.ToInt32(tokens_rObstacle[0]);
        int cObstacle = Convert.ToInt32(tokens_rObstacle[1]);
        // your code goes here
		hs.Add(new Tuple<int,int>(rObstacle,cObstacle));
    }
	
	int count = 0;
	int row = rQueen;
	int col = cQueen;
	while(++row <= n && !hs.Remove(new Tuple<int,int>(row,col))) { //if(list.Contains(new Tuple<int,int>(row,col))) break;		
		count++; 
	}
	//Console.WriteLine($"===>	count:{count}");
	
	row = rQueen;
	while(--row > 0  && !hs.Remove(new Tuple<int,int>(row,col))) { //Console.WriteLine($"row:{row} rQueen:{rQueen}"); 
	//if(list.Contains(new Tuple<int,int>(row,col))) { break;}
	count++; }
	//Console.WriteLine($"===>	count:{count}");
	
	col = cQueen;
	row = rQueen;
	while(++col <= n && !hs.Remove(new Tuple<int,int>(row,col))) { //Console.WriteLine($"row:{col} cQueen:{cQueen}"); 
	//if(list.Contains(new Tuple<int,int>(row,col))) break;
	count++; }
	//Console.WriteLine($"===>	count:{count}");
	
	col = cQueen;
	while(--col > 0 && !hs.Remove(new Tuple<int,int>(row,col))) { //Console.WriteLine($"row:{col} cQueen:{cQueen}"); 
	//if(list.Contains(new Tuple<int,int>(row,col))) break;
	count++; }
	//Console.WriteLine($"===>	count:{count}");

	row = rQueen;
	col = cQueen;
	while(++col <= n && ++row <= n  && !hs.Remove(new Tuple<int,int>(row,col))) { //Console.WriteLine($"row:{row} col:{col} rQueen:{rQueen} cQueen:{cQueen}"); 
	//if(list.Contains(new Tuple<int,int>(row,col))) break;
	count++; }
	//Console.WriteLine($"===>	count:{count}");

	row = rQueen; 	col = cQueen;
	while(--col > 0 && --row > 0  && !hs.Remove(new Tuple<int,int>(row,col))) { //Console.WriteLine($"row:{row} col:{col} rQueen:{rQueen} cQueen:{cQueen}"); 
	//if(list.Contains(new Tuple<int,int>(row,col))) break;
	count++; }
	//Console.WriteLine($"===>	count:{count}");

	row = rQueen;
	col = cQueen;
	while(++col <= n && --row > 0 && !hs.Remove(new Tuple<int,int>(row,col))) { //Console.WriteLine($"row:{row} col:{col} rQueen:{rQueen} cQueen:{cQueen}"); 
	
	count++; }
	//Console.WriteLine($"===>	count:{count}");

	row = rQueen;
	col = cQueen;
	while(--col > 0 && ++row <= n && !hs.Remove(new Tuple<int,int>(row,col))) { //Console.WriteLine($"row:{row} col:{col} rQueen:{rQueen} cQueen:{cQueen}"); 
	//if(list.Contains(new Tuple<int,int>(row,col))) break;
	count++; }
	Console.WriteLine($"===>	count:{count}");
}

private static void SequenceEquation()
{
	int n = Convert.ToInt32("3");
	int [] N = Array.ConvertAll("2 3 1".Split(),Int32.Parse);
	Console.WriteLine(N);
	
	int i = 1;
	while(i <= n)
	{
		int j = 0;
		int k = 0;
		while(j < n)
		{
			if(i == N[j])
			{
				k = j + 1;
				for(int l = 0; l < n; l++)
				{
					if(k == N[l]) 
					{
						Console.WriteLine(l+1);
						break;
					}
				}
				break;
			}
			//Console.WriteLine($"i:{i} N[i]:{N[i]} N[j]:{N[j]} j:{j+1}");
			j++;
		}
		i++;
	}
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

public static void TheGridSearch1()
{
	int t = 10;
	string [][] input = new string[][]{  new string[]{ "7283455864", "6731158619", "8988242643", "3830589324", "2229505813", "5633845374", "6473530293", "7053106601", "0834282956", "4607924137" }
										, new string[]{ "9505", "3845", "3530" }
										, new string[]{ "400453592126560", "114213133098692", "474386082879648", "522356951189169", "887109450487496", "252802633388782", "502771484966748", "075975207693780", "511799789562806", "404007454272504"
, "549043809916080", "962410809534811", "445893523733475", "768705303214174", "650629270887160" }
										, new string[]{ "99", "99"}
								 	  };
	
	Console.WriteLine(input);
	return;
	IList<KeyValuePair<int,KeyValuePair<int,int>>> list;
	for(int z = 0; z < input.Length; z++)
	{
		list = new List<KeyValuePair<int,KeyValuePair<int,int>>>();
		string [] G = input[z];
		int Rows = G.Length;
		int Cols = G[0].Length;
		
		string [] P = input[++z];
		int rows = P.Length;
		int cols = P[0].Length;
		
		//Console.WriteLine($"Rows:{Rows} Cols:{Cols} rows:{rows} cols:{cols} G:{string.Join(" ", G)} P:{string.Join(" ", P)}");
		int index = 0, pIndex = -1;
		int[,] output = new int[Rows,Cols];
		for(int row = 0; row < rows; row++)
		{
			string p = P[row];
			for(int Row = 0; Row < Rows; Row++)
			{
				string g = G[Row];
				pIndex = index + 1;
				index = g.IndexOf(p);
				//Console.WriteLine($"g:{g} p:{p} pIndex:{pIndex} index:{index}");
				if(index > -1)
				{
					var item = new KeyValuePair<int,KeyValuePair<int,int>>(Convert.ToInt32(p),new KeyValuePair<int,int>(Row,index));
					//var item = new KeyValuePair<int,int>(Row,index);
					if(!list.Contains(item))
						list.Add(item);
					//output[Row,index]++;
				}
			}
			Console.WriteLine();
		}
		//Console.WriteLine(output);
		//Console.WriteLine(list);
		bool found = false;
		if(list.Count >= rows)
		{
			int distinctRowsCount = list.Select(x => x.Key).Distinct().Count();
			int distinctColsCount = list.Select(x => x.Value).Distinct().Count();
			//Console.WriteLine(list.Select(x => x.Key).Count());
			//Console.WriteLine(list.Select(x => x.Key).Distinct().Count());
		}
		
		for(int zz = 0; zz < list.Count; zz++)
		{
			Console.WriteLine(list[zz]);
		}
	}
}

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

public static void BomberMan1()
{
	int [] rcn = "6 7 0".Split().Select(Int32.Parse).ToArray();
	int r = rcn[0], c = rcn[1], n = rcn[2];
	string [] inputStr = new string[] { ".......", "...O...", "....O..", ".......",  "OO.....", "OO....." };
	char [,] input = new char[r,c];
	char[,] output = new char[r,c];
	for(int row = 0; row < r; row++)
	{
		for(int col = 0; col < c; col++)
		{
			output[row,col] = 'O';
			input[row,col] = inputStr[row][col];
		}
	}
	//char[,] output = (char[,])input.Clone();
	Console.WriteLine(input);
	Console.WriteLine(output);

	if(n % 3 == 2) 
	{
		Console.WriteLine(new int[r,c]);
	}
	else
	{
		//Console.WriteLine(input);
		for(int i = 2; i <= n; i += 3)
		{
			for(int row = 0; row < r; row++)
			{
				for(int col = 0; col < c; col++)
				{
					
					//Console.WriteLine($"row:{row} col:{col} input[row,col]:{input[row,col]}");
					if(input[row,col] == 'O')  
					{
						output[row,col] = '.';
						if(row > 0) output[row - 1,col] = '.';
						if(row < r - 1) output[row + 1,col] = '.';
						if(col > 0) output[row,col - 1] = '.';
						if(col < c - 1) output[row,col + 1] = '.';
					}
					//Console.WriteLine(output);
				}
			}
		}
		//Console.WriteLine();
		Console.WriteLine(output);
	}
}

public static void AlmostSorted()
{
	//int n = Convert.ToInt32("2");
	int [] input = "4 2".Split().Select(Int32.Parse).ToArray();
	//int [] input = "1 5 4 3 2 6".Split().Select(Int32.Parse).ToArray();
	//int [] input = "1 2 3 4 5 6".Split().Select(Int32.Parse).ToArray();
	//int [] input = "1 5 3 4 2 6".Split().Select(Int32.Parse).ToArray();
	//Console.WriteLine(input);
	int n = input.Length;
	
	int i = n - 1;
	while(i > 0 && input[i] > input[i-1]) i--;
	
	if(i == 0) { Console.WriteLine("yes"); return; }
	//Console.WriteLine($"i:{i}");
	
	int k = 0;
	while(k < i && input[k] < input[k+1]) k++;
	//Console.WriteLine($"k:{k}");
	
	int l = i;
	while(l > k && input[l] < input[l-1]) l--;
	//Console.WriteLine($"l:{l}");
	
	if(l > 0 && k > 0 && l == k) Console.WriteLine($"reverse {k+1} {i+1}");
	else 
	{
		int t = input[k];
		input[k] = input[i];
		input[i] = t;
		//Console.WriteLine(input);
		
		int index = n - 1;
		while(index > 0 && input[index] > input[index-1]) index--;
		//Console.WriteLine(index);
		if(index == 0) Console.WriteLine($"swap {k} {i}");
	}
}

public static void AbsolutePermutation()
{
	int t = Convert.ToInt32("1");
	string [] input = new string[] { "3 2" };
	
	//string [] input = new string[] { "2 1", "3 0", "3 2" };
	//int [] input = "2 1".Split().Select(x => Int32.Parse(x)).ToArray();
	for(int j = 0; j < t; j++)
	{
		int [] inputInt = input[j].Split().Select(x => Int32.Parse(x)).ToArray();
		int n = inputInt[0], k = inputInt[1];
		bool [] output = new bool[n+1];
		int [] op = new int[n];
		bool np = false;
		for(int i = 1; i <= n; i++)
		{
			//Console.WriteLine(i);
			int x1 = i + k;
			int x2 = i - k;
			
			//Console.WriteLine($"x1:{x1} x2:{x2}");
			if(x1 > 0 && x1 <= n && x2 > 0 && x2 <= n)
			{
				if(x1 < x2)
				{
					if(!output[x1])
					{
						output[x1] = true;
						op[i-1] = x1;
						//Console.Write(x1 + " ");
					}
					else if(!output[x2])
					{
						output[x2] = true;
						op[i-1] = x2;
						//Console.Write(x2 + " ");
					}
				}
				else
				{
					if(!output[x2])
					{
						output[x2] = true;
						op[i-1] = x2;
						//Console.Write(x2 + " ");
					}
					else if(!output[x1])
					{
						output[x1] = true;
						op[i-1] = x1;
						//Console.Write(x1 + " ");
					}
				}
			}
			else if(x1 > 0 && x1 <= n && !output[x1])
			{
				output[x1] = true;
				op[i-1] = x1;
				//Console.Write(x1 + " ");
			}
			else if(x2 > 0 && x2 <= n && !output[x2])
			{
				output[x2] = true;
				op[i-1] = x2;
				//Console.Write(x2 + " ");
			}
			else
			{
				np = true;
			}
		}
		
		//Console.WriteLine(output);
		//Console.WriteLine();
		if(np)
		{
			Console.WriteLine(-1);
		}
		else
		{
			Console.WriteLine(string.Join(" ",op));
		}
	}
}

public static void BiggerIsGreater()
{
	int t = Convert.ToInt32(5);
	string[] input = new string[] {"ab", "bb", "hefg", "dhck", "dkhc" };
	for(int i = 0; i < t; i++)
	{
		string str = input[i];
		int [] c = str.ToCharArray().Select(x => (int)x).ToArray();
		if(NextPermutation(c))
			Console.WriteLine(string.Join("", c.Select(x => (char)x).ToArray()));
		else Console.WriteLine("no answer");
	}
}

public static bool NextPermutation(int [] array)
{
	//1. Find the pivot
	int i = array.Length - 1;
	while(i > 0 && array[i-1] >= array[i]) i--;
	if(i <= 0) return false;
	
	//2. find the right most element greater than the next pivot i.e. i - 1
	int j = array.Length - 1;
	while(j >= i && array[j] <= array[i-1]) j--;
	
	//3. Swap the array[j] and array[i-1]
	int temp = array[j];
	array[j] = array[i-1];
	array[i-1] = temp;
	
	//4. Reverse the suffix.
	j = array.Length -1;
	while(j > i)
	{
		temp = array[j];
		array[j] = array[i];
		array[i] = temp;
		j--;
		i++;
	}
	return true;
}

public static void Encryption()
{
	string s = "chillout";//"haveaniceday";//"chillout";//"feedthedog";//"haveaniceday";
	int len = s.Length;
	int rows = (int)Math.Floor(Math.Sqrt(len));
	int cols = (int)Math.Ceiling(Math.Sqrt(len));
	int mul = rows * cols;
	Console.WriteLine($"==>		rows:{rows} cols:{cols} mul:{mul} len:{len}");
	if(mul < len)
	{	
		rows++;
		//mul = rows * cols;
		//Console.WriteLine($"mul:{mul}");
	}
	
	Console.WriteLine($"==>		rows:{rows} cols:{cols} NewMul:{rows*cols} OldMul:{mul} len:{len}");
	string [] op = new string[cols];
	
	for(int i = 0, j= 0; i < len; i += cols, j++)
	{
		string temp = string.Empty;
		if(i + cols < len)
			temp = s.Substring(i, cols);
		else temp = s.Substring(i, len - i);
		for(int c = 0; c < temp.Length; c++)
		{
			op[c] += temp[c];
		}
	}
	//Console.WriteLine($"rows:{rows} cols:{cols} op:{string.Join(" ", op)}");
	Console.WriteLine($"{string.Join(" ", op)}");
}

public static void HappyLadyBugs()
{
	int g = Convert.ToInt32("4");
	int n = Convert.ToInt32("7");
	string input = "RBY_YBR";
	bool hasUS = input.Contains('_');
	Console.WriteLine($"hasUS:{hasUS}		 input:{input}");
	Console.WriteLine(input.IndexOf("\u00ADY"));
	//char[] charArr = input.ToCharArray();
	//Array.Sort(charArr);
	//Console.WriteLine($"hasUS:{hasUS} charArr:{new String(charArr)}");
	for(int i = 0; i < n; i++)
	{
		char c = input[i];
		//Console.WriteLine(c);
	}
}

public static void StrangeCounter()
{
	long t = Convert.ToInt64("25");
	long x = 0;
	long y = 0;
	long z = 1;
	while(x + z <= t)
	{
		
		z = x + z;
		x = 3 * (long)Math.Pow(2,y);
		//Console.WriteLine($"z:{z} x:{x}");		
		y++;
	}
	
	long diff = t - z;
	long output = x - diff;
	//Console.WriteLine();
	//Console.WriteLine($"z:{z} x:{x} diff:{diff} output:{output}");
	Console.WriteLine($"{output}");
}

public static void JumpingOnTheClouds()
{
	//int n = Convert.ToInt32("7");
	//int [] c = "0 0 1 0 1 1 0".Split().Select(Int32.Parse).ToArray();
	int n = Convert.ToInt32("6");
	int [] c = "0 0 0 0 1 0".Split().Select(Int32.Parse).ToArray();

	int i = 0, count = 0;
	for(i = 2; i < n; i += 2)
	{
		if(c[i] == 1) 
		{
			i--;
		}
		count++;
		Console.WriteLine($"i:{i} c[i]:{c[i]} count:{count}");
	}
	
	Console.WriteLine(count);
}

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

public static void ChocolateFeast()
{
	int t = Convert.ToInt32("3");
	int [][] input = new int[][] {
			new int[] { 10, 2, 5 }
		,	new int[] { 12, 4, 4 }
		,	new int[] { 6, 2, 2 }
	};
	
	for(int i = 0; i < t; i++)
	{
		int [] inputArr = input[i];
		int n = inputArr[0], c = inputArr[1], m = inputArr[2];
		//Console.WriteLine(input[i]);
		int nC = n / c;
		int temp = nC;
		while(temp > 0)
		{
			nC += temp/m;
			int rem = temp % m;
			temp = temp/m; 
			if(temp > 0)
				temp += rem;
			//Console.WriteLine($"temp:{temp}");
		}
		//Console.WriteLine($"n:{n} c:{c} m:{m} nC:{nC}");
		Console.WriteLine(nC);
	}
}

public static void CavityMap()
{
	//int n = Convert.ToInt32("4");
	//string [] inputArray = new string[] {"1112", "1912", "1892", "1234"};
	int n = Convert.ToInt32("7");
	string [] inputArray = new string[] {"2476387", "1485738", "6591334", "9589583", "6827769", "2559498", "1822388"};
	string [] outputArray = (string[])inputArray.Clone();//new string[n];
	
	/*
	int n = Convert.ToInt32(Console.ReadLine());
	string [] inputArray = new string[n]; 

  	for(int x = 0; x < n; x++)
	{
       inputArray[x] = Console.ReadLine();
	}*/
    
	Console.WriteLine(inputArray);
	for(int i = 0; i < n; i++)
	{
		string inputStr = inputArray[i];
		
        if(i == 0 || i == n - 1) continue;
        for(int k = 0; k < inputArray[i].Length; k++)
        {
            if(k == 0 || k == inputStr.Length - 1) continue;
            //int src = Convert.ToInt32(inputStr[k]);
			int src = Convert.ToInt32(inputStr[k].ToString());
			string o1 = inputArray[i][k-1].ToString();
			string p1 = inputArray[i][k+1].ToString();
			string q1 = inputArray[i-1][k].ToString();
			string r1 = inputArray[i+1][k].ToString();
			
			if(o1 == "X" || p1== "X" || q1 == "X" || r1 == "X") continue;
            
			int o = Convert.ToInt32(inputArray[i][k-1].ToString());
            int p = Convert.ToInt32(inputArray[i][k+1].ToString());
            int q = Convert.ToInt32(inputArray[i-1][k].ToString());
            int r = Convert.ToInt32(inputArray[i+1][k].ToString());

            //Console.WriteLine($"i:{i} k:{k} src:{src} o:{o} p:{p} q:{q} r:{r}");
            if(src > Convert.ToInt32(inputStr[k-1].ToString()) && src > Convert.ToInt32(inputStr[k+1].ToString()) && src > Convert.ToInt32(inputArray[i-1][k].ToString()) && src > Convert.ToInt32(inputArray[i+1][k].ToString()))
            {
            	//Console.WriteLine($"i:{i} k:{k} src:{src} inputStr:{inputStr} 		o:{o} p:{p} q:{q} r:{r} o1:{o1} p1:{p1} q1:{q1} r1:{r1}");
                //Console.WriteLine(inputArray[i][k]);			
               	StringBuilder tgt = new StringBuilder(inputArray[i]);
				tgt[k] = 'X';
                //tgt = tgt.Replace(src.ToString(), "X");
                inputArray[i] = tgt.ToString();
				//outputArray[i] = tgt;
				//Console.WriteLine($"src:{src} src:{(char)src}	 	inputArray[i]: {inputArray[i]} tgt:{tgt}");
				
            }
        }
        //Console.WriteLine(string.Join(Environment.NewLine,inputArray));
    }
		
	Console.WriteLine(string.Join(Environment.NewLine,inputArray));
}

public static void MinimumDistances()
{
	int n = Convert.ToInt32("6");
	int [] A = "7 1 3 4 1 7".Split().Select(Int32.Parse).ToArray();
	int minDistance = Int32.MaxValue;
	for(int i = 0; i < n; i++)
	{
		int distance = 0;
		for(int k = i + 1; k < n; k++)
		{
			if(A[i] == A[k]) { distance = k - i; break; }
		}
		//Console.WriteLine($"distance:{distance}");
		if(distance > 0 && distance < minDistance) minDistance = distance;
	}
	Console.WriteLine(minDistance);
}

public static void ManasaAndStones()
{
	int t = Convert.ToInt32("2");
	int [][] input = new int[][] {
			new int[] { 3, 1, 2 }
		,	new int[] { 4, 10, 100 }
	};
	
	for(int i = 0; i < t; i++)
	{
		int[] temp = input[i];
		int n = temp[0], a = temp[1], b = temp[2];
		int num = 0;
		for(int x = 0; x < n -1; x++)
		{
			num = b * x;
			//Console.WriteLine($"num1:{num}");
			for(int y = x + 1; y < n; y++)
			{
				num += a;
			}
			Console.Write($"{num} ");
		}
		Console.Write($"{b * n - b} ");
		Console.WriteLine();
	}
}

public static int CalculateCount(int[] inputSet, int startIndex, int k)
{
	if(startIndex >= inputSet.Length - 1) return 0;
	int count = CalculateCount(inputSet, startIndex + 1, k);
	int sum = inputSet[startIndex] + inputSet[startIndex + 1];
	if((sum % k) != 0) count++;
	Console.WriteLine($"startIndex:{startIndex} sum:{sum} count:{count} subSet:{inputSet[startIndex]},{inputSet[startIndex+1]} inputSet:{string.Join(" ",inputSet)}");
	return count;
}

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

public static void EqualizeTheArray()
{
	int n = Convert.ToInt32("5");
	int [] input = "3 3 2 1 3".Split().Select(Int32.Parse).ToArray();
	int numWithHighestCount = 0, prevCount = 0;
	for(int i = 0; i < n; i++)
	{
		int num = input[i];
		int count = input.Where(x => x == num).ToArray().Count();
		if(prevCount < count) 
		{
			prevCount = count;
			numWithHighestCount = num;
		}
		Console.WriteLine($"num:{num} count:{count}");
	}
	Console.WriteLine($"numWithHighestCount:{numWithHighestCount}");
	Console.WriteLine($"{input.Length - numWithHighestCount}");
}

public static void TaumAndBDay()
{
	int t = Convert.ToInt32("5");
	int[][] inputArray = new int[][] {
					new int[2] { 212, 369}
				, 	new int[3] { 2568, 6430, 5783 }
				, 	new int[2] { 5, 9 }
				, 	new int[3] { 2, 3, 4 }
				, 	new int[2] { 3, 6 }
				, 	new int[3] { 9, 1, 1 }
				, 	new int[2] { 7, 7 }
				, 	new int[3] { 4, 2, 1 }
				, 	new int[2] { 3, 3 }
				, 	new int[3] { 1, 9, 2 }

				} ;
	//*
	for(int i = 0; i < t * 2; i++)
	{
		//2917086
		int [] input0 = inputArray[i];	//"10 10".Split().Select(Int32.Parse).ToArray(); //"5 9".Split().Select(Int32.Parse).ToArray();
		int b = input0[0], w = input0[1];
		int [] input1 = inputArray[++i];			//"1 1 1".Split().Select(Int32.Parse).ToArray(); //input = "2 3 4".Split().Select(Int32.Parse).ToArray();
		//Console.WriteLine($"input0: {string.Join(" ",input0)} 		input1: {string.Join(" ",input1)}");
		int x = input1[0], y = input1[1], z = input1[2];
		Console.WriteLine($"b:{b} w:{w}      x:{x} y:{y} z:{z}");
		int totalAmount = 0;
		if((y+z) < x)
		{
			totalAmount = b * (y + z) + w * y;
		}
		else if((x + z) < y)
		{
			totalAmount = b * x + w * (x + z);
		}
		else
		{
			totalAmount = b * x + w * y;
		}
		Console.WriteLine($"totalAmount:{totalAmount}");
	}
	//*/
}

public static void BeautifulTriplets()
{
	int[] input = "7 3".Split().Select(Int32.Parse).ToArray();
	int n = input[0], d = input[1];
	input = "1 2 4 5 7 8 10".Split().Select(Int32.Parse).ToArray();
	int counter = 0;
	for(int i = 0; i < n; i++)
	{
		for(int j = i + 1; j < n; j++)
		{
			int d1 = input[j] - input[i];
			if(d1 == d)
			{
				for(int k = j + 1; k < n; k++)
				{
					int d2 = input[k] - input[j];
					if(d2 == d)
					{
						Console.WriteLine($"input[i]:{input[i]} input[j]:{input[j]} input[k]:{input[k]}");
						counter++;
					}
				}
			}
		}
	}
	Console.WriteLine($"counter:{counter}");
}

public static void CutTheSticks()
{
	//int n = Convert.ToInt32("6");
	//int [] sticks = "5 4 4 2 2 8".Split().Select(Int32.Parse).ToArray();
	
	int n = Convert.ToInt32("8");
	int [] sticks = "1 2 3 4 3 3 2 1".Split().Select(Int32.Parse).ToArray();

	Array.Sort(sticks);
	//Console.WriteLine(sticks);
	for(int i = 0; i < n; i++)
	{
		if(sticks[i] <= 0) continue;
		int counter = 0;
		int num = sticks[i];
		for(int k = i; k < n; k++)
		{
			//Console.WriteLine($"i:{i} k:{k} sticks[i]:{sticks[i]} sticks[k]:{sticks[k]}");
			if(sticks[k] > 0)
			{
				sticks[k] = sticks[k] - num;
				counter++;
			}
		}
		//Console.WriteLine(sticks);
		Console.WriteLine(counter);
	}
}

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

public static void SherlockAndSquares()
{
	int t = 1; 
	for(int i = 0; i < t; i++)
	{
		//int[] input = Array.ConvertAll("3 9".Split(), Int32.Parse);
		int[] input = Array.ConvertAll("17 24".Split(), Int32.Parse);
		int a = input[0], b = input[1];
		int counter = 0;
		for(int x = a; x <= b; x++)
		{
			int sqrt = (int)Math.Sqrt(x);
			if(sqrt * sqrt == x) counter++;
			Console.WriteLine($"x:{x} sqrt:{sqrt} asqrt:{Math.Sqrt(x)}");
		}
		Console.WriteLine($"counter:{counter}");
		
	}
}

public static void AppendAndDelete()
{
	//string s = "abcHacke",  t = "abc"; int k = 5;
	//string s = "hackerhappy", t = "hackerrank"; int k = 9;
	//string s = "zzzzz", t = "zzzzzzz"; int k = 4;
	string s = "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv"
	, t = "bsdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv"; 
	int k = 100;
	//string s = "aba", t = "aba"; int k = 7;
	int sLen = s.Length;
	int tLen = t.Length;
	//Console.WriteLine($"sLen:{sLen} tLen:{tLen}");
	if((sLen + tLen) <= k)
	{
		Console.WriteLine("Yes");
		return;
	}

	if(sLen > tLen) 
	{
		int index = s.IndexOf(t);
		int diff = sLen - tLen;
		if(index == 0 && ((diff) == k || ((diff) < k) && ((k & 1) == (diff & 1)))) { Console.WriteLine("Yes"); return; }
		//else { Console.WriteLine("No"); return; }
	}
	
	int smallerLen = sLen < tLen ? sLen : tLen;
	int i = 0;
	while(i < smallerLen && s[i] == t[i]) i++;
	//Console.WriteLine($"i:{i}");
	if(i == smallerLen)
	{
		int diff = Math.Max(sLen, tLen) - i;
		int reqDiff = k - diff;
		//Console.WriteLine(diff);
		if(k > diff)
		{
			if((reqDiff & 1) == 0){ Console.WriteLine("Yes"); return; }
			else { Console.WriteLine("No"); return; }
		}
		else { Console.WriteLine("No"); return; }
	}
	else if(i > 0)
	{
		int sDiff = sLen - i;
		int tDiff = tLen - i;
		int sum = sDiff + tDiff;
		//Console.WriteLine($"sDiff:{sDiff} tDiff:{tDiff} sum:{sum}");
		if(sum == k) { Console.WriteLine("Yes"); return; }
		else { Console.WriteLine("No"); return; }
	}
	else Console.WriteLine("No");
	
	//Console.WriteLine($"i:{i} sLen:{sLen} tLen:{tLen}");
}

public static void SherlockAndTheBeast()
{
	int t = 4;
	int[] input = new int[] {1, 3, 5, 11};
	
	for(int i = 0; i < t; i++)
	{
		int n = input[i];
		if((n < 3) || (n % 3 != 0 & n % 5 != 0)) Console.WriteLine($"n:{n} -1");
	}
}

public static void ModifiedKaprekarNumbers()
{
	int p = 2, q = 9;
	//int p = 1, q = 100;
	//int p = 45, q = 45;
	bool flag = true;
	for(int i = p; i <= q; i++)
	{
		string x = ((long)Math.Pow(i,2)).ToString();
		int length = x.Length;
		string leftString = "0" + x.Substring(0,length/2);
		string rightString = "0" + x.Substring(length/2,length - length/2);
		//Console.WriteLine($"x:{x} leftString:{leftString} rightString:{rightString}");
		//long left = Convert.ToInt64(String.IsNullOrEmpty(leftString)? "0": leftString);
		long left = Convert.ToInt64(leftString);
		long right = Convert.ToInt64(rightString);
		long sum = left + right;
		if(sum == i) 
		{
			Console.Write($"{i} ");
			flag = false;
		}
	}
	if(flag) Console.WriteLine($"INVALID RANGE");
}

public static void FindDigits()
{
	long t = 2, n = 1012;
	long tempN = n, counter = 0;
	
	while(n > 0)
	{
		int rem = (int)n % 10;
		if(rem > 0 && tempN % rem == 0) counter++;
		n = n/10;
	}
	Console.WriteLine(counter);
}

public static void JumpingOnTheCloudsRevisited()
{
	int n = 8, k = 2;
	int [] input = new [] {0, 0, 1, 0, 0, 1, 1, 0};
	int count = 100;
	for(int i = 0; ;)
	{
		i = (i + k) % n;
		count--;
		int temp = input[i];
		if(temp > 0) count -= 2;
		//Console.WriteLine(input[i]);
		Console.WriteLine($"i:{i} k:{k} count:{count} temp:{temp}");
		if(i == 0) break;
	}
	Console.WriteLine(count);
}

public static void SaveThePrisoner()
{
//499999999 999999997 2
//499999999 999999998 2
//999999999 999999999 1
	long n = 499999999, m = 999999997, pid = 2;
	//long n = 352926151, m = 380324688, pid = 94730870;
	//long t = 1, n = 5, m = 2, pid = 10;
	//long t = 1, n = 5, m = 2, pid = 3;
	//long t = 1, n = 5, m = 14, pid = 3;
	long op = (m + pid - 1) % n;
	if(op == 0) op = n;
	Console.WriteLine(op);
}

public static void ViralAdvertising()
{
	int n = 5;
	int initialCount = 5;
	int totalLikes = 0;
	for(int i = 0; i < n; i++)
	{
		initialCount = initialCount/2;
		totalLikes += initialCount;
		initialCount *= 3;
	}
	Console.WriteLine(totalLikes);
}

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

public static void AngryProfessor()
{
	int t = 2;
	int n = 4, k = 3;
	int [] at = new[]{ -1, -3, 4, 2 };
	//int n = 4, k = 2;
	//int [] at = new[]{ 0, -1, 2, 1 };
	var result = at.Where(x => x <= 0).Count();
	//Console.WriteLine($"result:{result}");
	if(result < k) Console.WriteLine("YES");
	else Console.WriteLine("NO");
}

public static void UtopianTree()
{
	int n = 3;
	int [] inputArr = new int[] { 0, 1, 4 };
	for(int i = 0; i < n; i++)
	{
		int output = 1;
		int cycles = inputArr[i];
		//Console.WriteLine($"0 cycles: {cycles}");
		if(cycles != 0)
		{
			if(cycles == 1) { //Console.WriteLine($"1 Cycles:{cycles} output:{output * 2}"); 
				output = output * 2;
			}
			else
			{
				int rem = cycles % 2;
				cycles = cycles / 2;
				int tempOp = (int)Math.Pow(2,cycles);
				output = (tempOp * 1) + tempOp - 1;
				if(rem > 0) output *= 2;
				//Console.WriteLine($"2 Cycles:{cycles} output:{output}");
			}
		}
		//Console.WriteLine($"3 Cycles:{cycles} output:{output}");
		Console.WriteLine(output);
	}
}

public static void SockMerchant()
{
	int n = 15;
	int [] socks = new int[] {6, 5, 2, 3, 5, 2, 2, 1, 1, 5, 1, 3, 3, 3, 5};

	//int n = 9;
	//int [] socks = new int[] {10, 20, 20, 10, 10, 30, 50, 10, 20 };
	
	Array.Sort(socks);
	Console.WriteLine(String.Join(" ", socks));
	int outputCounter = 0;
	for(int j = 0; j < n; j++)
	{
		int count = 1;
		for(int k = j+1; k < n; k++)
		{
			if(socks[k] > 0 && (socks[j] == socks[k]))
			{
				socks[k] = -1;
				count++;
			}
			Console.WriteLine($"j:{j} k:{k} socks[j]: {socks[j]} socks[k]: {socks[k]} count: {count}");
		}
		
		outputCounter += count/2;
		Console.WriteLine($"outputCounter: {outputCounter}");
	}
	Console.WriteLine(outputCounter);
}

public static void BetweenTwoSets()
{
	int n = 2, m = 3;
	int [] a = new int[]{2,4};
	int [] b = new int[]{16,32,96};
	Array.Sort(a);
	Array.Sort(b);
	int aLength = a.Length, bLength = b.Length;
	int counter = 0;
	bool flag = false;
	Console.WriteLine($"{a[aLength-1]} {b[0]}");
	for(int x = a[aLength-1]; x <= b[0]; x++)
	{
		flag = false;
		for(int j = 0; j < aLength; j++)
		{
			//Console.WriteLine($"1	x:{x} a[j]:{a[j]}");
			if((x % a[j]) != 0) 
			{
				//Console.WriteLine($"1.1	x:{x} a[j]:{a[j]}");
				flag = true;
				break;
			}
		}
		
		if(flag) continue;
		
		for(int k = 0; k < bLength; k++)
		{
			//Console.WriteLine($"2	x:{x} b[k]:{b[k]}");
			if((b[k] % x) != 0) 
			{
				//Console.WriteLine($"2.1	x:{x} b[k]:{b[k]}");
				flag = true;
				break;
			}
		}
		
		if(flag) continue;
		counter++;
		Console.WriteLine($"counter:{counter} x:{x}");
	}
	Console.WriteLine(counter);
}

public static void Kangaroo()
{
	//int x1 = 0, v1 = 3, x2 = 4, v2 = 2;
	int x1 = 21, v1 = 6, x2 = 47, v2 = 3;
	if((x1 <= x2 && v1 < v2) | (x2 <= x1 && v2 < v1))
	{
		Console.WriteLine("NO");
	}
	
	int xdiff = x1 - x2;
	int vdiff = v2 - v1;
	var y = xdiff/((float)vdiff);
	
	Console.WriteLine(y);
	Console.WriteLine(y.GetType());
	if((y - (int)y) == 0)
    	Console.WriteLine($"xdiff:{xdiff} vdiff:{vdiff} y:{y}");
	else Console.WriteLine("NO");
	/*
	for(int i = 1; i <= 5; i++)
	{
		int sum1 = v1 * i + x1;
		int sum2 = v2 * i + x2;
		if(sum1 == sum2) break;
		Console.WriteLine($"OP: {v1 * i + x1} {v2 * i + x2}");
	}
	*/
	
}

public static void AppleAndOrange()
{
 	string[] tokens_s = "7 11".Split();//Console.ReadLine().Split(' ');
    int s = Convert.ToInt32(tokens_s[0]);
    int t = Convert.ToInt32(tokens_s[1]);
    string[] tokens_a = "5 15".Split();//Console.ReadLine().Split(' ');
    int a = Convert.ToInt32(tokens_a[0]);
    int b = Convert.ToInt32(tokens_a[1]);
    string[] tokens_m = "3 2".Split();//Console.ReadLine().Split(' ');
    int m = Convert.ToInt32(tokens_m[0]);
    int n = Convert.ToInt32(tokens_m[1]);
    string[] apple_temp = "-2 2 1".Split();//Console.ReadLine().Split(' ');
    int[] apple = Array.ConvertAll(apple_temp,Int32.Parse);
    string[] orange_temp = "5 -6".Split();//Console.ReadLine().Split(' ');
    int[] orange = Array.ConvertAll(orange_temp,Int32.Parse);
	
	int countA = 0, countO = 0;
	
	for(int i = 0; i < m; i++)
	{
		long sum = a + apple[i];
		//Console.WriteLine($"Sum:{sum}");
		if((a + apple[i]) >= s) countA++;
	}
	Console.WriteLine(countA);
	
	for(int i = 0; i < n; i++)
	{
		long sum = b + orange[i];
		//Console.WriteLine($"Sum:{sum}");
		if((sum) <= t && (sum) >= s) countO++;
	}
	Console.WriteLine(countO);
}

public static void NewPDFDesign()
{
 	int[] h = new int[] {1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};
    string word = "abc";
    //Console.WriteLine(String.Join(",",h));
	//char[] alphabets = Enumerable.Range('a',26).Select(x => (char)x).ToArray();
	//Console.WriteLine(String.Join(",",alphabets));
	int width = 0, height = 0, length = word.Length;
	for(int i = 0; i < length; i++)
	{
		//int tempH = h[((int)word[i] - 97)];
		//if(height < tempH) height = tempH;
		height = Math.Max(height, h[((int)word[i] - (int)'a')]);
	}
	Console.WriteLine(length * 1 * height);
}

// Define other methods and classes here