<Query Kind="Program" />

void Main()
{
	//OP: 2/3
//	int [] nm = Array.ConvertAll("3 3".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 2 4", "2 0 1 2" };

	//OP: 3/1
//	int [] nm = Array.ConvertAll("3 4".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "0 1 2 2", "1 2 1 2", "2 0 2 0" };

	//OP: 3/4
//	int [] nm = Array.ConvertAll("3 5".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "0 1 2 5", "1 2 2 4", "2 0 1 2", "0 2 2 3" };

	//OP: 5/3
//	int [] nm = Array.ConvertAll("4 4".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 1 2", "2 3 2 3", "3 0 3 0" };

	int [] nm = Array.ConvertAll("4 5".Split(),Int32.Parse);
	string [] UVAB = { "0 1 1 1", "1 2 1 2", "0 2 0 2", "2 3 2 3", "3 0 3 0" };

//	int [] nm = Array.ConvertAll("4 6".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "1 2 2 4", "0 2 1 2", "0 2 2 1", "0 3 4 3", "2 3 2 3" };

//	int [] nm = Array.ConvertAll("4 7".Split(),Int32.Parse);
//	string [] UVAB = { "0 1 1 1", "0 1 2 2", "1 2 2 4", "0 2 1 2", "0 2 2 1", "0 3 4 3", "2 3 2 3" };

	int V = nm[0], E = nm[1];
    Graph graph = new Graph(V, E);
	HashSet<Tuple<int,int>> edges = new HashSet<Tuple<int,int>>();
	Tuple<int,int> [] weights = new Tuple<int,int>[E];
	for(int i = 0; i < E; i++)
	{
		int [] uvab = Array.ConvertAll(UVAB[i].Split(), Int32.Parse);
		int u = uvab[0], v = uvab[1], a = uvab[2], b = uvab[3];
		if(u == v) continue;
		var w = new Tuple<int,int>(a,b);
        graph.edges[i].src = u;
        graph.edges[i].dest = v;
		graph.edges[i].weights = w;
	}
    double max = 0.0;
    int maxDen = 0, maxNum = 0;
	for(int i = 0; i < E; i++)
	{
		for(int j = 0; j < E; j++)
		{
			int index = (j + i) % E;
			//Console.WriteLine($"index:{index} j:{j}");
			graph.edges[index].weight = j;
			weights[j] = graph.edges[index].weights;
		}
		Console.WriteLine(graph.edges);
		//Console.WriteLine();
    	var ws = graph.Kruskal();
		/*
		//Console.WriteLine(ws);
		int num = 0, den = 0; 
		for(int o = 0; o < ws.Length; o++)
		{
			var tup = weights[ws[o]];
			//Console.WriteLine(tup);
			num += tup.Item1;
			den += tup.Item2;
		}
		var summation = num/(double)den;
		Console.WriteLine($"{num}/{den} ==> {summation}");
        max = Math.Max(summation,max);
        if(summation == max) 
        {
            maxNum = num;
            maxDen = den;
        }
		**/
		Console.WriteLine();
	}
 	
	int gcd = GCD(maxNum, maxDen);
    if(gcd > 1)
    {
        maxNum /= gcd;
        maxDen /= gcd;
    }
    Console.WriteLine($"{maxNum}/{maxDen}");
}

int GCD(int a, int b)
{
    if (a == 0)
        return b;
    return GCD(b%a, a);
}
// Define other methods and classes here
// Java program for Kruskal's algorithm to find Minimum Spanning Tree
// of a given connected, undirected and weighted graph
public class Edge: IComparable<Edge>
{
    public int src, dest, weight;
	public Tuple<int,int> weights;
//	Dictionary<int, Tuple<int,int>> dict = new Dictionary<int,Tuple<int,int>>();
//	public Tuple<int,int> Weight 
//	{
//		get
//		{
//			return dict[weight];
//		} 
//		set
//		{
//			dict.Add(weight, value);
//		}
//	}
	// Comparator function used for sorting edges based on
    // their weight
    public int CompareTo(Edge compareEdge)
    {
		return this.weight- compareEdge.weight;
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
 	public Edge [] edges; // collection of all edges
 
    // Creates a graph with V vertices and E edges
    public Graph(int v, int e)
    {
        V = v;
        E = e;
		edge = new Edge[E];
		edges = new Edge[E];
        for (int i=0; i<e; ++i)
            edges[i] = new Edge();
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
    public int[] Kruskal()
    {
    	Array.Copy(edges, edge, E);
        Edge [] result = new Edge[V];  // Tnis will store the resultant MST
        int e = 0;  // An index variable, used for result[]
        int i = 0;  // An index variable, used for sorted edges
        for (i=0; i < V; i++)
            result[i] = new Edge();
 
        // Step 1:  Sort all the edges in non-decreasing order of their
        // weight.  If we are not allowed to change the given graph, we
        // can create a copy of array of edges
        //Console.WriteLine(edge);
		Array.Sort(edge);
 		//Console.WriteLine(edge);
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
        //Console.WriteLine($"Following are the edges in the constructed MST {result.Length}");
		//List<Tuple<int,int>> list = new List<Tuple<int,int>>();
		HashSet<int> w = new HashSet<int>();
        for (i = 0; i < e; ++i)
		{
			w.Add(result[i].weight);
            //list.Add(new Tuple<int,int>(result[i].src, result[i].dest));
			Console.WriteLine(result[i].src + " -- " + result[i].dest+ " == " + result[i].weight);// + "," + weights[result[i].weight]);
		}
		return w.ToArray();
    }
}
//This code is contributed by Aakash Hasija
