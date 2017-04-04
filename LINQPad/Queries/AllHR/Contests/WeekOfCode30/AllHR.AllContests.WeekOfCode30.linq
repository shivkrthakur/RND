<Query Kind="Program" />

void Main()
{
	//CandyReplenishment();
	//FindTheMinimumNumber();
	//MelodiousPasswordOpt();
	//MelodiousPassword();
	//Poles();
	//RangeModularQueries();
	AGraphProblem();
/*
6
0 1 1 0 0 0
1 0 1 1 0 0
1 1 0 1 0 0
0 1 1 0 1 1
0 0 0 1 0 1
0 0 0 1 1 0
*/
}

void AGraphProblem()
{
	int n = Convert.ToInt32("6");
	//string [] S = { "0 1 1 0 0 0", "1 0 1 1 0 0", "1 1 0 1 0 0", "0 1 1 0 1 1", "0 0 0 1 0 1", "0 0 0 1 1 0"};
	string [] S = {"0 1 1 1 0 0",	"1 0 1 0 1 0",	"1 1 0 0 0 1",	"1 0 0 0 0 0",	"0 1 0 0 0 0",	"0 0 1 0 0 0" };

	int[][] g = new int[n][];
    //HashSet<Tuple<int,int>> edges = new HashSet<Tuple<int,int>>();
	List<Tuple<int,int>> AllEdges = new List<Tuple<int,int>>();
    for(int g_i = 0; g_i < n; g_i++)
	{
       string[] g_temp = S[g_i].Split(' ');
       int [] input = Array.ConvertAll(g_temp,Int32.Parse);
       g[g_i] = input;
       for(int i = 0; i < n; i++)
       {
            if(input[i] == 1)
            {
                AllEdges.Add(new Tuple<int,int>(g_i+1,i+1));    
            }
       }
    }
	List<Tuple<int,int>> edges = AllEdges;
   	//Console.WriteLine(edges);
   	HashSet<Tuple<int,int,int>> triangles = new HashSet<Tuple<int,int,int>>();
	//HashSet<Tuple<Tuple<int,int>,Tuple<int,int>,Tuple<int,int>>> triangleTuples = new HashSet<Tuple<Tuple<int,int>,Tuple<int,int>,Tuple<int,int>>>();
	List<Tuple<Tuple<int,int>,Tuple<int,int>,Tuple<int,int>>> triangleTuples = new List<Tuple<Tuple<int,int>,Tuple<int,int>,Tuple<int,int>>>();
	for(int x = 0; x < edges.Count; x++)
	{
		var edge = edges[x];
		int u = edge.Item1, v = edge.Item2;
		for(int y = x+1; y < edges.Count; y++)
		{
			var e = edges[y];
			if(e.Item1 == u)
			{
				for(int z = y+1; z < edges.Count; z++)
				{
					Tuple<int,int> e1 = edges[z];
					if(e.Item2 == e1.Item1 && e1.Item2 == v)
					{
						triangleTuples.Add(new Tuple<Tuple<int,int>,Tuple<int,int>,Tuple<int,int>>(edge,e,e1));
						//triangles.Add(new Tuple<int,int,int>(u, e.Item2, v));
						edges.Remove(e1);
						edges.Remove(e);
						edges.Remove(edge);
					}
				}
			}
		}
	}
	//Console.WriteLine(triangleTuples);
	double factor = 0.0;
	List<Tuple<Tuple<int,int>,Tuple<int,int>,Tuple<int,int>>> output = new List<Tuple<Tuple<int,int>,Tuple<int,int>,Tuple<int,int>>>();
	Dictionary<double,HashSet<int>> outputVertices = new Dictionary<double,HashSet<int>>();
	for(int p = 0; p < triangleTuples.Count; p++)
	{
		var triangle = triangleTuples[p];
		Tuple<int,int> edge1 = triangle.Item1, edge2 = triangle.Item2, edge3 = triangle.Item3;
		int trianglesCount = 1;
		double f1 = 1.0/(triangle.GetType().GetGenericArguments().Length);
		if(f1 > factor) 
		{ 
			output.Add(triangle); 
			HashSet<int> hs = new HashSet<int>();
			hs.Add(edge1.Item1);
			hs.Add(edge1.Item2);
			hs.Add(edge2.Item2);
			if(outputVertices.ContainsKey(f1))
			{
				outputVertices[f1] = hs;
			}
			else outputVertices.Add(f1,hs);
		}
		factor = Math.Max(f1,factor);
		//Console.WriteLine($"1==> trianglesCount:{trianglesCount} f1:{f1}	factor:{factor} vertices:{edge1.Item1},{edge1.Item2},{edge2.Item2}");
		//Console.WriteLine(outputVertices);
		for(int q = p + 1; q < triangleTuples.Count; q++)
		{
			var triangle1 = triangleTuples[q];
			Tuple<int,int> e1 = triangle1.Item1, e2 = triangle1.Item2, e3 = triangle1.Item3;
			if((edge1.Item1 == e1.Item2 && edge1.Item2 == e1.Item1) || (edge2.Item1 == e1.Item2 && edge2.Item2 == e1.Item1) || (edge3.Item1 == e1.Item2 && edge3.Item2 == e1.Item1)) 
			{
				trianglesCount++;
				f1 = ((float)trianglesCount)/(triangle.GetType().GetGenericArguments().Length+1);
				if(f1 > factor) { 
					output.Add(triangle1); 
					HashSet<int> hs = new HashSet<int>();
					hs.Add(edge1.Item1);
					hs.Add(edge1.Item2);
					hs.Add(edge2.Item2);
					hs.Add(e1.Item1);
					hs.Add(e1.Item2);
					hs.Add(e2.Item2);
					if(outputVertices.ContainsKey(f1))
					{
						outputVertices[f1] = hs;
					}
					else outputVertices.Add(f1,hs);
				}
				factor = Math.Max(f1,factor);
				//Console.WriteLine($"2==> trianglesCount:{trianglesCount} f1:{f1}	factor:{factor} vertices:({edge1.Item1},{edge1.Item2},{edge2.Item2})({e1.Item2},{e1.Item1}, {e2.Item2})");
				continue;
			}
			if((edge1.Item1 == e2.Item2 && edge1.Item2 == e2.Item1) || (edge2.Item1 == e2.Item2 && edge2.Item2 == e2.Item1) || (edge3.Item1 == e2.Item2 && edge3.Item2 == e2.Item1)) 
			{
				trianglesCount++;
				f1 = ((float)trianglesCount)/(triangle.GetType().GetGenericArguments().Length+1);
				if(f1 > factor) { 
					output.Add(triangle1); 
					HashSet<int> hs = new HashSet<int>();
					hs.Add(edge1.Item1);
					hs.Add(edge1.Item2);
					hs.Add(edge2.Item2);
					hs.Add(e2.Item1);
					hs.Add(e2.Item2);
					hs.Add(e3.Item1);
					if(outputVertices.ContainsKey(f1))
					{
						outputVertices[f1] = hs;
					}
					else outputVertices.Add(f1,hs);
				}
				factor = Math.Max(f1,factor);
				//Console.WriteLine($"3==> trianglesCount:{trianglesCount} f1:{f1}	factor:{factor} vertices:({edge1.Item1},{edge1.Item2},{edge2.Item2})({e2.Item2},{e2.Item1}, {e3.Item1})");
				continue;
			}
			if((edge1.Item1 == e3.Item2 && edge1.Item2 == e3.Item1) || (edge2.Item1 == e3.Item2 && edge2.Item2 == e3.Item1) || (edge3.Item1 == e3.Item2 && edge3.Item2 == e3.Item1)) 
			{
				trianglesCount++;
				f1 = ((float)trianglesCount)/(triangle.GetType().GetGenericArguments().Length+1);
				if(f1 > factor) 
				{ 
					output.Add(triangle1); 
					HashSet<int> hs = new HashSet<int>();
					hs.Add(edge1.Item1);
					hs.Add(edge1.Item2);
					hs.Add(edge2.Item2);
					hs.Add(e3.Item1);
					hs.Add(e3.Item2);
					hs.Add(e2.Item2);
					if(outputVertices.ContainsKey(f1))
					{
						outputVertices[f1] = hs;
					}
					else outputVertices.Add(f1,hs);
				}
				factor = Math.Max(f1,factor);
				//Console.WriteLine($"4==> trianglesCount:{trianglesCount} f1:{f1}	factor:{factor} vertices:({edge1.Item1},{edge1.Item2},{edge2.Item2})({e3.Item2},{e3.Item1}, {e2.Item2})");
				//Console.WriteLine($"trianglesCount:{trianglesCount} f1:{f1}	factor:{factor}");
				continue;
			}
		}
	}
	//Console.WriteLine(output);
	//Console.WriteLine(outputVertices);
	double maxValue = outputVertices.Keys.Max();
	Console.WriteLine(outputVertices[maxValue].Count);
	Console.WriteLine(string.Join(" ", outputVertices[maxValue].ToArray()));
	return;
	foreach(var triangle in triangleTuples)
	{
		int trianglesCount = 1;
		double f1 = 1/(triangle.GetType().GetGenericArguments().Length);
		factor = Math.Max(f1,factor);
		Console.WriteLine($"trianglesCount:{trianglesCount} f1:{f1}	factor:{factor}");
		Tuple<int,int> edge1 = triangle.Item1, edge2 = triangle.Item2, edge3 = triangle.Item3;
		foreach(var t2 in triangleTuples)
		{
			Tuple<int,int> e1 = t2.Item1, e2 = t2.Item2, e3 = t2.Item3;
			if((edge1.Item1 == e1.Item2 && edge1.Item2 == e1.Item1) || (edge2.Item1 == e1.Item2 && edge2.Item2 == e1.Item1) || (edge3.Item1 == e1.Item2 && edge3.Item2 == e1.Item1)) 
			{
				trianglesCount++;
				f1 = 1/(triangle.GetType().GetGenericArguments().Length+1);
				Console.WriteLine($"trianglesCount:{trianglesCount} f1:{f1}	factor:{factor}");
				continue;
			}
			if((edge1.Item1 == e2.Item2 && edge1.Item2 == e2.Item1) || (edge2.Item1 == e2.Item2 && edge2.Item2 == e2.Item1) || (edge3.Item1 == e2.Item2 && edge3.Item2 == e2.Item1)) 
			{
				trianglesCount++;
				f1 = 1/(triangle.GetType().GetGenericArguments().Length+1);
				Console.WriteLine($"trianglesCount:{trianglesCount} f1:{f1}	factor:{factor}");
				continue;
			}
			if((edge1.Item1 == e3.Item2 && edge1.Item2 == e3.Item1) || (edge2.Item1 == e3.Item2 && edge2.Item2 == e3.Item1) || (edge3.Item1 == e3.Item2 && edge3.Item2 == e3.Item1)) 
			{
				trianglesCount++;
				f1 = 1/(triangle.GetType().GetGenericArguments().Length+1);
				Console.WriteLine($"trianglesCount:{trianglesCount} f1:{f1}	factor:{factor}");
				continue;
			}
		}
	}
	return;
	/*
	for(int x = 0; x < edges.Count; x++)
	{
		var edge = edges[x];
		int u = edge.Item1, v = edge.Item2;
		for(int y = 0; y < edges.Count; y++)
		{
			var e = edges[y];
			for(int z = 0; z < edges.Count; z++)
			{
				Tuple<int,int> e1 = edges[z];
				if(e.Item2 == e1.Item1 && e1.Item2 == v)
				{
					triangles.Add(new Tuple<int,int,int>(u, e.Item2, v));
				}
			}
		}
	}
	Console.WriteLine(triangles);
	return;
	edges = AllEdges;
	Console.WriteLine(edges);
	triangles = new HashSet<Tuple<int,int,int>>(); 
	//*/
	///*
   foreach(var edge in edges)
   {
		int u = edge.Item1, v = edge.Item2;
		foreach(var e in edges)
		{
			if(e.Item1 == u)
			{
				foreach(var e1 in edges)
				{
					if(e.Item2 == e1.Item1 && e1.Item2 == v)
					{
						triangles.Add(new Tuple<int,int,int>(u, e.Item2, v));
					}
				}
			}
		}
   }//*/
   Console.WriteLine(triangles);
}

void RangeModularQueries()
{
//	int [] nq = Array.ConvertAll("5 3".Split(), Int32.Parse);
//	int [] N = Array.ConvertAll("250 501 5000 5 4".Split(), Int32.Parse);
//	string [] Q = { "0 4 5 0", "0 4 10 0", "0 4 3 2" };

	int [] nq = Array.ConvertAll("10 10".Split(), Int32.Parse);
	int [] N = Array.ConvertAll("36245 25647 38654 14876 28974 24877 5456 8946 34845 81646".Split(), Int32.Parse);
	string [] Q = { "5 9 4868 564", "4 8 875 575", "1 4 35644 8848", "0 8 848 385",  "0 6 44 26",  "2 4 147 45",  "3 9 8487 457",  "7 9 4878 456",  "8 9 8897 8",  "9 9 4 2" };

	int n = nq[0], q = nq[1];
	for(int i = 0; i < q; i++)
	{
		int [] query = Array.ConvertAll(Q[i].Split(), Int32.Parse);
		int left = query[0], right = query[1], x = query[2], y = query[3];
		int count = 0;
		while(left <= right)
		{
			int num = N[left];
			Console.WriteLine($"left:{left}	num:{num} 		{num} % {x}:{num%x}");
			if(num % x == y) count++;
			left++;
		}
		Console.WriteLine($"count:{count}");
	}
}

// Define other methods and classes here
void Poles()
{
	int [] nk = Array.ConvertAll("6 3".Split(), Int32.Parse);
	int n = nk[0], k = nk[1];
	int [][] AW = {
			new int[] { 10, 15 }
		,	new int[] { 12, 17 }
		,	new int[] { 16, 18 }
		,	new int[] { 18, 13 }
		, 	new int[] { 30, 10 }
		,	new int[] { 32, 1 }
	};
	//Console.WriteLine(AW);
	Dictionary<int,int> dc = new Dictionary<int,int>();
	int [][] costs = new int[n-1][];
	if(n == k) Console.WriteLine(0);
	else {
			int [] aw = AW[0];
			CacluateSums(AW, costs, 0);
			/*
			for(int i = 0; i < n; i++)
			{
				int a = AW[i][0], w = AW[i][1];
				int cost = 0;
				for(int j = i + 1; j < n; j++)
				{
					int aa = AW[j][0], ww = AW[j][1];
					cost = ww * (aa - a);
					Console.WriteLine($"a:{a} aa:{aa} ww:{ww} cost:{cost}");
				}
				Console.WriteLine();
				costs[i] = cost;
			}
			Console.WriteLine(costs);
			*/
			//Console.WriteLine(costs);
			int tgtCost = costs[k-1].Sum();
			Console.WriteLine($"tgtCost:{tgtCost}");
			//int prevCount = Int32.MaxValue;
			for(int y = 1; y < costs.Length; y+=(k-1))
			{
				int sum = 0;
				for(int z = y; z < costs[y].Length; z++)
				{
					Console.WriteLine($"y:{y} z:{z} costs[y][z]:{costs[y][z]}");
					sum += costs[y][z];
					//Console.WriteLine(sum);
				}
				for(int yy = y - k; yy >= 0; yy--)
				{
					for(int zz = y - 1; zz >= 0; zz--)
					{
						Console.WriteLine($"yy:{yy} zz:{zz} costs[yy][zz]:{costs[yy][zz]}");
						sum+=costs[yy][zz];
					}
				}
				tgtCost = Math.Min(sum,tgtCost);
				//Console.WriteLine($"sum:{sum} prevCount:{prevCount}");
			}
			Console.WriteLine($"output:{tgtCost}");
		}
}

private void CacluateSums(int[][] AW, int [][] costs, int index = 0)
{
	if(index == AW.Length - 1) return;
	int a = AW[index][0], w = AW[index][1];
	int cost = 0;
	int index2 = 0;
	int [] tempCost = new int[AW.Length];
	for(int j = index + 1; j < AW.Length; j++)
	{
		int aa = AW[j][0], ww = AW[j][1];
		cost = ww * (aa - a);
		tempCost[index + 1 + index2++] = cost;
		//Console.WriteLine($"a:{a} aa:{aa} ww:{ww} cost:{cost}");
	}
	//Console.WriteLine(tempCost);
	costs[index] = tempCost;
	//Console.WriteLine();
	CacluateSums(AW, costs, ++index);
}

void MelodiousPasswordOpt()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	int n = Convert.ToInt32("6");
    string vowString = "aeiou", conString = "bcdfghjklmnpqrstvwxz";
	int vowCount = vowString.Length, conCount = conString.Length, iterations = 0;
	HashSet<string> opHS = new HashSet<string>(string.Format("{0}{1}", vowString, conString).Select(x => x.ToString()).ToArray());
	for (int nn = 1; nn < n; nn++)
    {
		string [] temp = opHS.ToArray();
		opHS = new HashSet<string>();
		for(int i = 0; i < temp.Length; i++)
		{
			string val = temp[i];
			if(vowString.IndexOf(val[val.Length-1]) > -1)
			{
				for(int c = 0; c < conCount; c++)
				{
					iterations++;
					int index = conCount * i + c;
					string consonant = conString[c].ToString();
					opHS.Add(string.Format("{0}{1}", val, consonant));
				}
			}
			else
			{
				for(int v = 0; v < vowCount; v++)
				{
					iterations++;
					int index = vowCount * i + v;
					string vowel = vowString[v].ToString();
					opHS.Add(string.Format("{0}{1}", val, vowel));			
				}
			}
		}
	}
	Console.WriteLine(opHS.Count);
	//Console.WriteLine(opHS);
	//Console.WriteLine(string.Join(Environment.NewLine, opHS.ToArray()));
	//Console.WriteLine(string.Join(Environment.NewLine, vowOP));
	//Console.WriteLine(string.Join(Environment.NewLine, conOP));
	sw.Stop();
	Console.WriteLine($"sw.ElapsedTicks:{sw.ElapsedTicks}	sw.Elapsed:{sw.Elapsed} 	sw.ElapsedMilliseconds:{sw.ElapsedMilliseconds}");
}

void MelodiousPassword()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	int n = Convert.ToInt32("6");
    string vowString = "aeiou", conString = "bcdfghjklmnpqrstvwxz";
	int vowCount = vowString.Length, conCount = conString.Length;
	//Console.WriteLine($"vowCount:{vowCount} conCount:{conCount}");
	int iterations = 0;
    bool flag = true;
	string[] vowOP = vowString.ToCharArray().Select(x => x.ToString()).ToArray();
	string[] conOP = conString.ToCharArray().Select(x => x.ToString()).ToArray();
    for (int nn = 1; nn < n; nn++)
    {
		iterations++;
		int size = 0;
		///*
		string [] tempV = vowOP;
		int tempVLen = tempV.Length;
		size = (flag) ? tempVLen * conCount : tempVLen * vowCount;
		vowOP = new string[size];
		for(int v = 0; v < tempVLen; v++)
		{
			iterations++;
			string val = tempV[v];
			if(flag) 
			{
				for(int c = 0; c < conCount; c++)
				{
					iterations++;
					int index = conCount * v + c;
					string valC = conString[c].ToString();
					vowOP[index] = string.Format("{0}{1}",val,valC);			
				}
			}
			else
			{
				for(int c = 0; c < vowCount; c++)
				{
					iterations++;
					int index = vowCount * v + c;
					string valV = vowString[c].ToString();
					vowOP[index] = string.Format("{0}{1}",val,valV);			
				}
			}
		}
		//*/
		
		//Console.WriteLine(vowOP.Length);
		//Console.WriteLine(vowOP);
		
		string [] tempC = conOP;
		int tempCLen = tempC.Length;
		size = (flag) ? tempCLen * vowCount : tempCLen * conCount;
		conOP = new string[size];
		for(int c = 0; c < tempCLen; c++)
		{
			iterations++;
			string val = tempC[c];
			if(flag) 
			{
				for(int v = 0; v < vowCount; v++)
				{
					iterations++;
					int index = vowCount * c + v;
					string valV = vowString[v].ToString();
					conOP[index] = string.Format("{0}{1}",val,valV);			
				}
			}
			else
			{
				for(int v = 0; v < conCount; v++)
				{
					iterations++;
					int index = conCount * c + v;
					string valC = conString[v].ToString();
					conOP[index] = string.Format("{0}{1}",val,valC);			
				}
			}
		}
		//Console.WriteLine(conOP);
		flag = !flag;
	}
	//Console.WriteLine($"iterations:{iterations++}");
	Console.WriteLine(vowOP.Length + conOP.Length);
	//Console.WriteLine(string.Join(Environment.NewLine, vowOP));
	//Console.WriteLine(string.Join(Environment.NewLine, conOP));
	
//	Console.WriteLine(vowOP);
//	Console.WriteLine(conOP);
//	HashSet<string> vowHS = new HashSet<string>(vowOP);
//	HashSet<string> conHS = new HashSet<string>(conOP);
//	Console.WriteLine($"{vowHS.Count + conHS.Count} vowHS.Count:{vowHS.Count} conHS.Count:{conHS.Count}");
	sw.Stop();
	Console.WriteLine($"sw.ElapsedTicks:{sw.ElapsedTicks}	sw.Elapsed:{sw.Elapsed} 	sw.ElapsedMilliseconds:{sw.ElapsedMilliseconds}");

}

private void FindTheMinimumNumber()
{
    int n = Convert.ToInt32("6");
	string s = " min( int, {0})";
	string t = "{0}";
	for(int i = 2; i < n; i++)
	{
		t = String.Format(t, s);
	}
	Console.WriteLine(string.Format(t," min( int, int)"));
}


private void CandyReplenishment()
{
	int [] nt = Array.ConvertAll("8 3".Split(), Int32.Parse);
	int [] c = Array.ConvertAll("5 2 4".Split(), Int32.Parse);//Array.ConvertAll("3 1 7 5".Split(), Int32.Parse);
	
	int n = nt[0], t = nt[1];
	
	int candiesLeft = n, candiesAdded = 0;
	for(int i = 0; i < t; i++)
	{
		int candiesTaken = c[i];
		candiesLeft = candiesLeft - candiesTaken;
		//Console.WriteLine($"candiesTaken:{candiesTaken} candiesLeft:{candiesLeft}");
		if(candiesLeft < 5 && i != t - 1)
		{
			candiesAdded += (n - candiesLeft);
			candiesLeft = n;
		}
		//Console.WriteLine($"candiesAdded:{candiesAdded} candiesTaken:{candiesTaken} candiesLeft:{candiesLeft}");
	}
	Console.WriteLine(candiesAdded);
}