<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	MagicSquareForming();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
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
