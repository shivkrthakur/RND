<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	MatrixLayerRotation();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
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