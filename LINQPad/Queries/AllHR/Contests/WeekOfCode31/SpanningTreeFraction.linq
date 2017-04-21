<Query Kind="Program" />

void Main()
{
	SpanningTreeFraction();
}

void SpanningTreeFractionOp()
{
//	int [] VE = Array.ConvertAll("3 3".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 2 4", "2 0 1 2" };

//	int [] nm = Array.ConvertAll("4 5".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 2 4", "0 2 1 2", "0 3 4 3", "2 3 2 3" };

//	int [] nm = Array.ConvertAll("4 6".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 2 4", "0 2 1 2", "0 2 2 1", "0 3 4 3", "2 3 2 3" };

	int [] nm = Array.ConvertAll("4 7".Split(),Int32.Parse);
	string [] UVAB = { "0 1 1 1", "0 1 2 2", "1 2 2 4", "0 2 1 2", "0 2 2 1", "0 3 4 3", "2 3 2 3" };

	int V = nm[0], E = nm[1];
    Graph graph = new Graph(V, E);
	HashSet<Tuple<int,int>> edges = new HashSet<Tuple<int,int>>();
	for(int i = 0; i < E; i++)
	{
		int [] uvab = Array.ConvertAll(UVAB[i].Split(), Int32.Parse);
		int u = uvab[0], v = uvab[1], a = uvab[2], b = uvab[3];
		if(u == v) continue;
		int sV = u, eV = v;
		if(u > v) {	sV = v; eV = u; };
		var edge = new Tuple<int,int>(sV, eV); 
		//if(edges.Contains(edge)) { edgesU.Add(new Tuple<int,int,int,int>(sV, eV, a, a, b )); continue; }
		edges.Add(edge);
				
        graph.edges[i].src = sV;
        graph.edges[i].dest = eV;
        graph.edges[i].weightNum = a;
		graph.edges[i].weightDen = b;
	}
    graph.KruskalMST();
}

void SpanningTreeFraction()
{
//	int [] nm = Array.ConvertAll("3 3".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 2 4", "2 0 1 2" };

//	int [] nm = Array.ConvertAll("3 4".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 2 4", "2 0 1 2", "2 0 2 1" };

//	int [] nm = Array.ConvertAll("3 5".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 2 1", "0 1 1 1", "1 2 2 4", "2 0 1 2", "2 0 2 1" };

	int [] nm = Array.ConvertAll("4 7".Split(),Int32.Parse);
	string [] UVAB = { "0 1 2 1", "0 1 1 1", "1 2 2 4", "2 0 1 2", "2 0 2 1", "2 3 2 3", "3 0 4 3" };

	int n = nm[0], m = nm[1];
	List<Tuple<Tuple<int,int>,Tuple<int,int>>> dict = new List<Tuple<Tuple<int,int>,Tuple<int,int>>>();
	//List<KeyValuePair<Tuple<int,int>, Tuple<int,int>>> dict = new List<KeyValuePair<Tuple<int,int>, Tuple<int,int>>>();
	for(int i = 0; i < m; i++)
	{
		int [] uvab = Array.ConvertAll(UVAB[i].Split(), Int32.Parse);
		int u = uvab[0], v = uvab[1], a = uvab[2], b = uvab[3];
		if(u == v) continue;
		var edge = new Tuple<int,int>(u,v);
		//if(u > v) edge = new Tuple<int,int>(v,u);
		var weight = new Tuple<int,int>(a,b);
		//if(a > b) weight = new Tuple<int,int>(b,a);
		var tup = new Tuple<Tuple<int,int>,Tuple<int,int>>(weight,edge);
		dict.Add(tup);
		//dict.Add(new KeyValuePair<Tuple<int,int>,Tuple<int,int>>(edge, weight));
	}
	//Console.WriteLine(dict); //return;
	Console.WriteLine(string.Join(" 	", dict.Select( x => x.Item2)));
	Console.WriteLine(string.Join(" 	", dict.Select( x => x.Item1)));

	double max = 0.0;
	int maxDen = 0, maxNum = 0, count = 0;
	for(int i = 0; i < dict.Count; i++)
	{	
		var item1 = dict[i];
		HashSet<Tuple<int,int>> vPair = new HashSet<Tuple<int,int>>();
		HashSet<int> vertices = new HashSet<int>();
		List<Tuple<int,int>> edgeWeights = new List<Tuple<int,int>>();
		for(int j = 0; j < dict.Count; j++)
		{
			var item2 = dict[j];
			if((i == j) || (item1.Item2.Item1 == item2.Item2.Item1 && item1.Item2.Item2 == item2.Item2.Item2)) continue; 
			if(vPair.Contains(item2.Item2)) continue;
			
			vPair.Add(item1.Item2);
			vPair.Add(item2.Item2);
			vertices.Add(item1.Item2.Item1);
			vertices.Add(item1.Item2.Item2);
			vertices.Add(item2.Item2.Item1);
			vertices.Add(item2.Item2.Item2);
			edgeWeights.Add(item2.Item1);
			
			Console.WriteLine($"i:{i} j:{j} 				{++count}");
			Console.WriteLine($"item1 => ({item1.Item2.Item1},{item1.Item2.Item2})");
			Console.WriteLine($"item2 => ({item2.Item2.Item1},{item2.Item2.Item2})");
			//Console.WriteLine(vPair);
			Console.WriteLine();

			if(vertices.Count == n)
			{
				edgeWeights.Add(item1.Item1);
				Console.WriteLine(vertices);
				//Console.WriteLine(edgeWeights);
				int num = 0, den = 0;
				foreach(var item in edgeWeights)
				{
					num += item.Item1;
					den += item.Item2;
				}
				var summation = num/(double)den;
				max = Math.Max(summation,max);
				if(summation == max) 
				{
					maxNum = num;
					maxDen = den;
				}
				vertices = new HashSet<int>(); 
				edgeWeights = new List<Tuple<int,int>>();
			}
		}
	}
	int gcd = GCD(maxNum, maxDen);
	if(gcd > 1)
	{
		maxNum /= gcd;
		maxDen /= gcd;
	}
	Console.WriteLine($"{maxNum}/{maxDen}");
	
	/*
	for(int i = 0; i < dict.Count; i++)
	{
		var item1 = dict[i];
		vertices.Add(item1.Key.Item1);
		vertices.Add(item1.Key.Item2);
		List<Tuple<int,int>> edgeWeights = new List<Tuple<int,int>>();
		for(int j = i + 1; j < dict.Count; j++)
		{
			//Console.WriteLine($"i:{i} j:{j}");
			var item2 = dict[j];
			if(item1.Key.Item1 == item2.Key.Item1 && item1.Key.Item2 == item2.Key.Item2) continue;
			vertices.Add(item2.Key.Item1);
			vertices.Add(item2.Key.Item2);
			edgeWeights.Add(item2.Value);
			if(vertices.Count == n)
			{
				edgeWeights.Add(item1.Value);
				int num = 0, den = 0;
				foreach(var item in edgeWeights)
				{
					num += item.Item1;
					den += item.Item2;
				}
				var summation = num/(double)den;
				max = Math.Max(summation,max);
				if(summation == max) 
				{
					maxNum = num;
					maxDen = den;
				}
				//Console.WriteLine($"num:{num} den:{den} num/(double)den: {num/(double)den} max:{max}");
				//Console.WriteLine();
				edgeWeights = new List<Tuple<int,int>>();
			}
		}
	}
	int gcd = GCD(maxNum, maxDen);
	if(gcd > 1)
	{
		maxNum /= gcd;
		maxDen /= gcd;
	}
	Console.WriteLine($"{maxNum}/{maxDen}");
	//*/
	/*

	foreach(var item1 in dict)
	{
		vertices.Add(item1.Key.Item1);
		vertices.Add(item1.Key.Item2);
		//keys.Add(item1.Key);
		List<Tuple<int,int>> edgeWeights = new List<Tuple<int,int>>();
		foreach(var item2 in dict)
		{
			//if(!keys.Contains(item2.Key))
			if(item1.Key != item2.Key)
			{
				Console.WriteLine(item1.Key);
				Console.WriteLine(item2.Key);
				vertices.Add(item2.Key.Item1);
				vertices.Add(item2.Key.Item2);
				edgeWeights.AddRange(item2.Value);
				if(vertices.Count == n)
				{
					Console.WriteLine(vertices);
					edgeWeights.AddRange(item1.Value);
					//Console.WriteLine(vertices);
					int num = 0, den = 0;
					//Console.WriteLine(edgeWeights);
					foreach(var item in edgeWeights)
					{
						num += item.Item1;
						den += item.Item2;
					}
					Console.WriteLine($"num:{num} den:{den}");
					Console.WriteLine();
					edgeWeights = new List<Tuple<int,int>>();
					vertices.RemoveWhere(x => x != item1.Key.Item1 && x != item1.Key.Item2);
				}
			}
		}
	}
	*/
}

// Define other methods and classes here
int GCD(int a, int b)
{
    if (a == 0)
        return b;
    return GCD(b%a, a);
}

/************************************************************************************************************************************************************************/
public class Edge: IComparable<Edge>
{
    public int src, dest, weightNum, weightDen;

    // Comparator function used for sorting edges based on
    // their weight
    public int CompareTo(Edge compareEdge)
    {
		double thisDiff = this.weightNum/(float)this.weightDen;
		double incDiff = compareEdge.weightNum/(float)compareEdge.weightDen;
		//Console.WriteLine($"({this.weightNum},{this.weightDen}) ({compareEdge.weightNum},{compareEdge.weightDen}) 	({thisDiff},{incDiff}) 		({(int)thisDiff},{(int)incDiff})");
		if(incDiff > thisDiff ) return 1;
		else if(incDiff == thisDiff) return 0;
		else return -1;

//		if(thisDiff  > incDiff) return 1;
//		else if(incDiff == thisDiff) return 0;
//		else return -1;
		//return (int)((this.weightNum/(float)this.weightDen) - (compareEdge.weightNum/(float)compareEdge.weightDen));
		//return (int)((compareEdge.weightNum/(float)compareEdge.weightDen) - (this.weightNum/(float)this.weightDen));
    }
}
	
public class Graph
{
    // A class to represent a subset for union-find
    class Subset
    {
        public int parent;
		public int rank;
    };
 
    int V, E;    // V-> no. of vertices & E->no.of edges
    public Edge [] edge; // collection of all edges
  	public Edge [] edges;

    // Creates a graph with V vertices and E edges
    public Graph(int v, int e)
    {
        V = v;
        E = e;
        edge = new Edge[E];
		edges = new Edge[E];
        for (int i=0; i < e; i++) edges[i] = new Edge();
    	Array.Copy(edges, edge, e);
    }
 
    // A utility function to find set of an element i
    // (uses path compression technique)
    int find(Subset [] subsets, int i)
    {
        // find root and make root as parent of i (path compression)
        if (subsets[i].parent != i)
            subsets[i].parent = find(subsets, subsets[i].parent);
 
        return subsets[i].parent;
    }
 
    // A function that does union of two sets of x and y
    // (uses union by rank)
    void Union(Subset [] subsets, int x, int y)
    {
        int xroot = find(subsets, x);
        int yroot = find(subsets, y);
 
        // Attach smaller rank tree under root of high rank tree
        // (Union by Rank)
        if (subsets[xroot].rank < subsets[yroot].rank)
            subsets[xroot].parent = yroot;
        else if (subsets[xroot].rank > subsets[yroot].rank)
            subsets[yroot].parent = xroot;
 
        // If ranks are same, then make one as root and increment
        // its rank by one
        else
        {
            subsets[yroot].parent = xroot;
            subsets[xroot].rank++;
        }
    }
 
    // The main function to construct MST using Kruskal's algorithm
    public void KruskalMST()
    {
        Edge [] result = new Edge[V];  // Tnis will store the resultant MST
        int e = 0;  // An index variable, used for result[]
        int i = 0;  // An index variable, used for sorted edges
        for (i=0; i < V; i++)
            result[i] = new Edge();
 
        // Step 1:  Sort all the edges in non-decreasing order of their
        // weight.  If we are not allowed to change the given graph, we
        // can create a copy of array of edges
        Console.WriteLine(edge);
		Array.Sort(edge);
 		Console.WriteLine(edge);
        // Allocate memory for creating V ssubsets
        Subset [] subsets = new Subset[V];
        for(i=0; i<V; ++i)
            subsets[i]=new Subset();
 
        // Create V subsets with single elements
        for (int v = 0; v < V; ++v)
        {
            subsets[v].parent = v;
            subsets[v].rank = 0;
        }
 
        i = 0;  // Index used to pick next edge
 
        // Number of edges to be taken is equal to V-1
        while (e < V - 1)
        {
            // Step 2: Pick the smallest edge. And increment the index
            // for next iteration
            Edge next_edge = new Edge();
            next_edge = edge[i++];
 
            int x = find(subsets, next_edge.src);
            int y = find(subsets, next_edge.dest);
 
            // If including this edge does't cause cycle, include it
            // in result and increment the index of result for next edge
            if (x != y)
            {
                result[e++] = next_edge;
                Union(subsets, x, y);
            }
            // Else discard the next_edge
        }
 
        // print the contents of result[] to display the built MST
        Console.WriteLine("Following are the edges in the constructed MST");
        for (i = 0; i < e; ++i)
            Console.WriteLine(result[i].src + " -- " + result[i].dest+ " == " + result[i].weightNum + "," + result[i].weightDen);
    }
}