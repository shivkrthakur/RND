<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	TheGridSearch1();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
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
