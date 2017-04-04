<Query Kind="Program" />

void Main()
{
	RoadsAndLibraries();
	//JourneyToTheMoon();
	//BfsShortestReach();
	//SynchronousShopping();
}

void RoadsAndLibraries()
{
	int q = Convert.ToInt32("3");
	string [] NMLR = { "3 3 2 1", "6 6 2 5", "417 104 13548 90581" };
	string [][] R = { 
						new string[]{ "1,2" , "3,1", "2,3"}
					,	new string[]{ "1,3" , "3,4", "2,4", "1,2", "2,3", "5,6" }
					,	new string[]{ "340,57", "349,53", "93,381", "129,41", "117,79", "415,400", "404,403", "405,303", "46,400", "333,334", "2,60", "47,382", "367,331", "274,211", "15,151", "89,390", "284,167", "309,310", "164,177","73,7","295,333","116,133","20,63","344,415","290,53","319,397","15,277","53,160","320,22","16,78","191,205","270,204","385,296","337,116","2,284","68,297","50,191","401,323","366,142","94,38","314,343","343,211","173,292","401,177","229,66","63,318","108,338","413,107","126,340","6,388","379,146","354,105","257,325","147,412","347,331","248,230","290,383","316,284","315,235","237,87","32,169","222,148","325,149","403,55","165,238","162,5","163,141","332,387","360,130","259,70","197,252","273,142","299,288","413,188","35,381","381,211","64,210","225,193","187,416","185,357","208,45","2,409","324,408","152,363","145,36","109,357","276,334","380,313","76,410","40,61","57,335","33,242","230,4","356,284","260,183","215,84","160,168","101,318","106,52","101,211","175,410","377,344","20,394","205,104" }
					};

    for(int a0 = 0; a0 < q; a0++){
        string[] tokens_n = NMLR[a0].Split();
        int numberOfCities = Convert.ToInt32(tokens_n[0]);
        int numberOfRoads = Convert.ToInt32(tokens_n[1]);
        int costOfLib = Convert.ToInt32(tokens_n[2]);
        int costOfRoad = Convert.ToInt32(tokens_n[3]);
        bool [] visited = new bool[numberOfCities + 1];		
        Dictionary<long, List<long>> am = new Dictionary<long, List<long>>();
        for(var i=0; i <= numberOfCities; i++) {
            am.Add(i, new List<long>());
        }
        for(int a1 = 0; a1 < numberOfRoads; a1++){
            string[] tokens_city_1 = R[a0][a1].Split(',');
            int city_1 = Convert.ToInt32(tokens_city_1[0]);
            int city_2 = Convert.ToInt32(tokens_city_1[1]);
            am[city_1].Add(city_2);
            am[city_2].Add(city_1);
        }
        //Console.WriteLine(am);
        long roads = 0, libraries = 0;
        for(int k = 1; k < visited.Length; k++)
        {
            if(!visited[k])
            {
                roads += DFS(k, am, visited).Count - 1;
                libraries++;
            }
			//Console.WriteLine(visited);
        }
        long totalCost = (roads * costOfRoad) + (libraries * costOfLib);
        //Console.WriteLine($"roads:{roads} libraries:{libraries} totalCost:{totalCost}");
        if((costOfLib * numberOfCities) < totalCost) totalCost = (costOfLib * numberOfCities);
        Console.WriteLine(totalCost);
    }
}

void SynchronousShopping()
{
	int [] NMK = Array.ConvertAll("5 5 5".Split(), Int32.Parse);
	int n = NMK[0], m = NMK[1], k = NMK[2];
	string [] SF = { "1 1", "1 2", "1 3", "1 4", "1 5" };
	string [] R = { "1 2 10", "1 3 10", "2 4 10", "3 5 10", "4 5 10" };
	int [,] matrix = new int[n+1,n+1];
	bool [] visited = new bool[n+1];
	for(int i = 0; i < n; i++)
	{
		int [] cf = Array.ConvertAll(SF[i].Split(), Int32.Parse);
		int c = cf[0], ft = cf[1];
		int [] r = Array.ConvertAll(R[i].Split(), Int32.Parse);
		int s = r[0], e = r[1], t = r[2];
		matrix[s,e] = 1;
		matrix[e,s] = 1;
	}
	Console.WriteLine(matrix);
	Console.WriteLine($"BFS");
	int noOfNodes = matrix.GetUpperBound(0);
	Queue<int> queue = new Queue<int>();
	queue.Enqueue(1);
	visited[1] = true;
	
	while(queue.Count > 0)
	{
		int val = queue.Peek();
		int count = 0;
		for(int i = 1; i <= noOfNodes; i++)
		{
			if(!visited[i] && matrix[val,i] == 1) 
			{ 
				queue.Enqueue(i);
				visited[i] = true;
				count++;
			}
		}
		Console.WriteLine(queue.Dequeue());
	}
	Console.WriteLine($"DFS");
	visited = new bool[n+1];
	Stack<int> stack = new Stack<int>();
	stack.Push(1);
	visited[1] = true;
	Console.WriteLine(1);
	bool flag = false;
	while(stack.Count > 0)
	{
		int val = stack.Peek();
		for(int i = 1; i <= noOfNodes; i++)
		{
			if(!visited[i] && matrix[val,i] == 1) 
			{ 
				stack.Push(i); 
				visited[i] = true;
				val = i;
				i = 1;
				
				Console.WriteLine(val);
				//if(val == noOfNodes) { flag = true; break; }
				continue;
			}
		}
		if(flag) break;
		stack.Pop();
	}
	
}

void BfsShortestReach()
{
	int q = Convert.ToInt32("3");
	string [] NM = { "4 2", "3 1", "6 4" };
	string [][] E = { 
						  new string[]{ "1 2", "1 3" }
						, new string[]{ "2 3" }
						, new string[]{ "1 2", "2 3", "2 5", "5 4" }
					};
	int [] SN = new int[] { 1, 2, 1 };
	
	for(int i = 0; i < q; i++)
	{
		int[] nm = Array.ConvertAll(NM[i].Split(), Int32.Parse);
		int n = nm[0], m = nm[1];
		int s = SN[i];
		int [,] matrix = new int[n+1,n+1];
		int [] output = Enumerable.Repeat(-1,n-1).ToArray();
		for(int j = 0; j < m; j++)
		{
			int [] e = Array.ConvertAll(E[i][j].Split(), Int32.Parse);
			int u = e[0], v = e[1];
			matrix[u,v] = 1;
			matrix[v,u] = 1;
		}
		//Console.WriteLine(matrix);
		bool[] visited = new bool[n+1];
		Queue<int> queue = new Queue<int>();
		queue.Enqueue(s);
		int k = s, c = 0;
		visited[k] = true;
		while(queue.Count > 0)
		{
			k = queue.Peek();
			bool flag = true;
			for(int l = 1; l <= matrix.GetUpperBound(1); l++)
			{
				//Console.WriteLine($"k:{k} l:{l} matrix[k,l]:{matrix[k,l]} visited[l]:{visited[l]} ");
				if(matrix[k,l] == 1 && !visited[l]) 
				{ 
					if(flag) { c++; flag = !flag; } 
					queue.Enqueue(l); visited[l] = true; 
					output[l-2] = c * 6;
					//Console.WriteLine($"k:{k} l:{l} matrix[k,l]:{matrix[k,l]} visited[l]:{visited[l]} ");
				}
			}
			queue.Dequeue();
			//Console.WriteLine($"Dequeued:{queue.Dequeue()}");
		}
		//Console.WriteLine();
		//Console.WriteLine($"c:{c}");
		//Console.WriteLine(output);
		Console.WriteLine(string.Join(" ", output));
		/*
		var hs = BFS(s,matrix).ToArray();
		for(int p = 1; p < hs.Length; p++)
		{
			output[hs[p]-2] = 6; 
		}
		Console.WriteLine(string.Join(" ", output));
		*/
	}
}

static HashSet<int> BFS(int startNode, int[,] matrix)
{
	HashSet<int> hashSet = new HashSet<int>();
	Queue<int> queue = new Queue<int>();
	queue.Enqueue(startNode);
	int i = startNode;
	for(int j = 1; j <= matrix.GetUpperBound(1); j++)
	{
		//Console.WriteLine($"(i,j):({i},{j}) matrix[i,j]:{matrix[i,j]} matrix.GetUpperBound(1):{matrix.GetUpperBound(1)}"); 
		if(matrix[i,j] == 1) queue.Enqueue(j);
	}
	
	while(queue.Count > 0)
	{
		int d = queue.Dequeue();
		hashSet.Add(d);
		//Console.WriteLine(d);
	}
	return hashSet;
}

// Define other methods and classes here
void JourneyToTheMoon()
{
	int [] NP = Array.ConvertAll("5 3".Split(),Int32.Parse);
	string [] R = { "0 1", "2 3", "0 4" };
//	int [] NP = Array.ConvertAll("4 1".Split(),Int32.Parse);
//	string [] R = { "0 2" };

//	int [] NP = Array.ConvertAll("10 7".Split(),Int32.Parse);
//	string [] R = { "0 2", "1 8", "1 4", "2 8", "2 6", "3 5", "6 9" };

//	int [] NP = Array.ConvertAll("100000 2".Split(),Int32.Parse);
//	string [] R = { "1 2", "3 4" };
//		
	int n = NP[0], p = NP[1];

	Dictionary<long, List<long>> am = new Dictionary<long, List<long>>();
//    for(var i=0; i < n; i++) {
//        dict.Add(i, new List<long>());
//    }

	bool [] visited = new bool[n];
	for(int i = 0; i < p; i++)
	{
		int [] ab = Array.ConvertAll(R[i].Split(),Int32.Parse);
		int a = ab[0], b = ab[1];
		if(!am.ContainsKey(a)) am.Add(a, new List<long>());
		if(!am.ContainsKey(b)) am.Add(b, new List<long>());
		am[a].Add(b);
		am[b].Add(a);
		//Console.WriteLine($"a:{a} b:{b}");
	}
	//Console.WriteLine(am);
	//HashSet<int> results = new HashSet<int>();
	//HashSet<int> opHS1 = DFSHS(0, dict, visited);
	//Console.WriteLine(opHS1);
	//return;
	int ts = 1, sumTotal = 0;
	List<int> results = new List<int>();
	List<int> results2 = new List<int>();
	for(int i = 0; i < n; i++)
	{	
		if(!visited[i])
		{
			if(am.ContainsKey(i))
			{
				HashSet<int> opHS = DFS(i, am, visited);
				//Console.WriteLine(opHS);
				int op = opHS.Count;
				//Console.WriteLine($"op:{op} i:{i} visited[i]:{visited[i]}");
//				results2 = results2.Select(x => x + (x * op)).ToList();
				//results2 = results2.Select(x => x * op).ToList();
				sumTotal += results.Select(x => x * op).Sum();
				results.Add(op);
				//results2.Add(op);
				Console.WriteLine(results);
				//Console.WriteLine(results2);
//				ts *= op;
//				sumTotal += ts;
				Console.WriteLine($"ts:{ts} op:{op} sumTotal:{sumTotal}");
			}
			else 
			{ 
				HashSet<int> opHS = new HashSet<int>();
				opHS.Add(i);
				//results2 = results2.Select(x => x + (x * 1)).ToList();
				sumTotal += results.Select(x => x * 1).Sum();
				//results2 = results2.Select(x => x * 1).ToList();
				results.Add(opHS.Count);
				//results2.Add(opHS.Count);
				Console.WriteLine(results);
				//Console.WriteLine(results2);
//				ts *= 1;
//				sumTotal += ts;
				Console.WriteLine($"ts:{ts} sumTotal:{sumTotal}");
			}
			
		}
	}
	
	//Console.WriteLine(results);
	Console.WriteLine(sumTotal);
	return;
	Console.WriteLine(results2);
	//return;
	Console.WriteLine($"sumTotal:{sumTotal}");
	//Console.WriteLine("Results");
	//Console.WriteLine(results);
	int [] output = results.ToArray();
	//Console.WriteLine(output);
	int sum = 0;
	for(int f = 0; f < output.Length; f++)
	{
		for(int g = f+1; g < output.Length; g++)
		{
			if(output[f] > 0 && output[g] > 0)
			{
				int mul = output[f] * output[g];
				sum += mul;
			}
			//Console.WriteLine($"sum:{sum} total:{total}");
		}
		//sum += total;	
	}
	
	//Console.WriteLine(sum);
	Console.WriteLine(sum);
	//Console.WriteLine(am);
	//Console.WriteLine(results);
}

static HashSet<int> DFS(int startNode, Dictionary<long, List<long>> am, bool[] visited)
{
	HashSet<int> cities = new HashSet<int>();
	Stack<int> stack = new Stack<int>();
   
    int element = startNode;		
	cities.Add(element);
 	//Console.WriteLine("element 1 : " + element + "\t");		
    visited[startNode] = true;		
    stack.Push(startNode);

    while (stack.Count != 0)
    {
        element = stack.Peek();
    	int number_of_nodes = am[element].Count;;
        int i = 0;	
		//Console.WriteLine($"number_of_nodes:{number_of_nodes} element:{element}");
	    while (i < number_of_nodes)
	    {
			int val = (int) am[element][i];
			//Console.WriteLine($"val:{val} visited[val]:{visited[val]}");
	 	    if(!visited[val])
	        {
                stack.Push(val);
                visited[val] = true;
                element = val;
                i = 0;
				number_of_nodes = am[element].Count;;
    			cities.Add(element);
				//Console.WriteLine($"element 2:{element} number_of_nodes:{number_of_nodes}");
	            continue;
	        }
	        i++;
	    }
        int popVal = stack.Pop();	
		//Console.WriteLine($"popVal:{popVal} i:{i}");
    }
	return cities;
}


public HashSet<int> DFSHS(int startNode, int [,] adjacency_matrix, bool[] visited)
{
	HashSet<int> cities = new HashSet<int>();
	Stack<int> stack = new Stack<int>();
    int number_of_nodes = adjacency_matrix.GetUpperBound(0);
    
    int element = startNode;		
    int i = startNode;		
	cities.Add(element);
 	//Console.WriteLine(element + "\t");		
    visited[startNode] = true;		
    stack.Push(startNode);

    while (stack.Count != 0)
    {
        element = stack.Peek();
        i = element;	
	    while (i <= number_of_nodes)
	    {
	 	    if (adjacency_matrix[element,i] == 1 && !visited[i])
	        {
                stack.Push(i);
                visited[i] = true;
                element = i;
                i = 1;
    			cities.Add(element);
				//Console.WriteLine(element + "\t");
	            continue;
	        }
	        i++;
	    }
        stack.Pop();	
    }
	return cities;
}

/*
static HashSet<int> DFS(int startNode, Dictionary<long, List<long>> am, bool[] visited)
{
    HashSet<int> cities = new HashSet<int>();
    Stack<int> stack = new Stack<int>();

    int element = startNode;		
    cities.Add(element);
    //Console.WriteLine("element 1 : " + element + "\t");		
    visited[startNode] = true;		
    stack.Push(startNode);

    while (stack.Count != 0)
    {
        element = stack.Peek();
        int number_of_nodes = am[element].Count;;
        int i = 0;	
        //Console.WriteLine($"number_of_nodes:{number_of_nodes} element:{element}");
        while (i < number_of_nodes)
        {
            int val = (int) am[element][i];
            //Console.WriteLine($"val:{val} visited[val]:{visited[val]}");
            if(!visited[val])
            {
                stack.Push(val);
                visited[val] = true;
                element = val;
                i = 0;
                number_of_nodes = am[element].Count;;
                cities.Add(element);
                //Console.WriteLine($"element 2:{element} number_of_nodes:{number_of_nodes}");
                continue;
            }
            i++;
        }
        int popVal = stack.Pop();	
        //Console.WriteLine($"popVal:{popVal} i:{i}");
    }
    return cities;
}
*/
void RoadsAndLibrariesBkUp()
{
	int q = Convert.ToInt32("3");
	string [] NMLR = { "3 3 2 1", "6 6 2 5", "417 104 13548 90581" };
	string [][] R = { 
						new string[]{ "1,2" , "3,1", "2,3"}
					,	new string[]{ "1,3" , "3,4", "2,4", "1,2", "2,3", "5,6" }
					,	new string[]{ "340,57", "349,53", "93,381", "129,41", "117,79", "415,400", "404,403", "405,303", "46,400", "333,334", "2,60", "47,382", "367,331", "274,211", "15,151", "89,390", "284,167", "309,310", "164,177","73,7","295,333","116,133","20,63","344,415","290,53","319,397","15,277","53,160","320,22","16,78","191,205","270,204","385,296","337,116","2,284","68,297","50,191","401,323","366,142","94,38","314,343","343,211","173,292","401,177","229,66","63,318","108,338","413,107","126,340","6,388","379,146","354,105","257,325","147,412","347,331","248,230","290,383","316,284","315,235","237,87","32,169","222,148","325,149","403,55","165,238","162,5","163,141","332,387","360,130","259,70","197,252","273,142","299,288","413,188","35,381","381,211","64,210","225,193","187,416","185,357","208,45","2,409","324,408","152,363","145,36","109,357","276,334","380,313","76,410","40,61","57,335","33,242","230,4","356,284","260,183","215,84","160,168","101,318","106,52","101,211","175,410","377,344","20,394","205,104" }
					};
	for(int i = 0; i < q; i++)
	{
		//Console.WriteLine(R[2].Length);
		int [] nmlr = Array.ConvertAll(NMLR[i].Split(), Int32.Parse);
		int numberOfCities = nmlr[0], numberOfRoads = nmlr[1], costOfLib = nmlr[2], costOfRoad = nmlr[3];	
		int [,] am = new int[numberOfCities+1,numberOfCities+1];
		bool [] visited = new bool[numberOfCities + 1];		
		//Console.WriteLine(am);
		for(int j = 0; j < numberOfRoads; j++)
		{
			int [] r = Array.ConvertAll(R[i][j].Split(','), Int32.Parse);
			int s = r[0], e = r[1];
			am[s,e] = 1;
			am[e,s] = 1;
		}
		
		long roads = 0, libraries = 0;
		for(int k = 1; k < visited.Length; k++)
		{
			if(!visited[k])
			{
				roads += DfsUsingStack(k, am, visited) - 1;
				libraries++;
			}
		}
		long totalCost = (roads * costOfRoad) + (libraries * costOfLib);
		Console.WriteLine($"roads:{roads} libraries:{libraries} totalCost:{totalCost}");
		if((costOfLib * numberOfCities) < totalCost) totalCost = (costOfLib * numberOfCities);
		Console.WriteLine(totalCost);
		Console.WriteLine();
	}
}

public int DFS(int startNode, int [,] adjacency_matrix, bool[] visited)
{
	int cities = 0;
	Stack<int> stack = new Stack<int>();
    int number_of_nodes = adjacency_matrix.GetUpperBound(0);
    
    int element = startNode;		
    int i = startNode;		
	cities++;
 	//Console.WriteLine(element + "\t");		
    visited[startNode] = true;		
    stack.Push(startNode);

    while (stack.Count != 0)
    {
        element = stack.Peek();
        i = element;	
	    while (i <= number_of_nodes)
	    {
	 	    if (adjacency_matrix[element,i] == 1 && !visited[i])
	        {
                stack.Push(i);
                visited[i] = true;
                element = i;
                i = 1;
                //Console.WriteLine(element + "\t");
				cities++;
	            continue;
	        }
	        i++;
	    }
        stack.Pop();	
    }
	return cities;
}

public int[] DfsUsingLinkedList(int vertex, LinkedList<int> [] list, int[] visited)
{
	int[] outputVertices = new int[visited.Length];
	//outputVertices[0] = head;
	DFS(vertex, list, visited, outputVertices, 1);
	return outputVertices;
}

public void DFS(int vertex, LinkedList<int> [] list, int[] visited, int[] outputVertices, int index)
{
	Console.WriteLine(vertex);
	visited[vertex] = 1;
	var head = list[vertex].First;
	//Console.WriteLine(head);
	while(head != null)
	{
		int value = head.Value;
		head = head.Next;
		if(visited[value] == 0)
		{
			DFS(value, list, visited, outputVertices, index);
		}
	}
}

public int DfsUsingStack(int startNode, int[,] adjacency_matrix, bool[] visited)
{
	return DFS(startNode, adjacency_matrix, visited);
}