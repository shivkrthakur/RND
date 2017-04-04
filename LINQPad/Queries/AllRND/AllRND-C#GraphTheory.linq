<Query Kind="Program" />

void Main()
{
//   Graph g = new Graph(4);
//    g.AddEdge(0, 1);
//    g.AddEdge(0, 2);
//    g.AddEdge(1, 2);
//    g.AddEdge(2, 0);
//    g.AddEdge(2, 3);
//    g.AddEdge(3, 3);
	
	Graph g = new Graph(4);
	g.AddEdge(1, 2);
	Console.WriteLine(g.adj);
	g.AddEdge(3, 1);
	Console.WriteLine(g.adj);
	g.AddEdge(2, 3);
	Console.WriteLine(g.adj);
    Console.WriteLine("Following is Depth First Traversal "+ "(starting from vertex 2)");
	
    g.DFS(1);	
}


public class Graph
{
	private int V;   // No. of vertices
 
    // Array  of lists for Adjacency List Representation
    public LinkedList<int> [] adj;
 
    // Constructor
    public Graph(int v)
    {
        V = v;
        adj = new LinkedList<int>[v];
        for (int i = 0; i < v; i++)
            adj[i] = new LinkedList<int>();
		//Console.WriteLine(adj);
    }
 
    //Function to add an edge into the graph
    public void AddEdge(int v, int w)
    {
        adj[v].AddLast(w);  // Add w to v's list.
    }
 
    // A function used by DFS
    public void DFSUtil(int v, bool [] visited)
    {
        // Mark the current node as visited and print it
        visited[v] = true;
        Console.WriteLine(v + " ");
 
        // Recur for all the vertices adjacent to this vertex
        var i = adj[v].GetEnumerator();
        while (i.MoveNext())
        {
            int n = i.Current;
            if (!visited[n])
                DFSUtil(n, visited);
        }
    }
 
    // The function to do DFS traversal. It uses recursive DFSUtil()
    public void DFS(int v)
    {
        // Mark all the vertices as not visited(set as
        // false by default in java)
        bool [] visited = new bool[V];
        // Call the recursive helper function to print DFS traversal
        DFSUtil(v, visited);
    }
}