<Query Kind="Program" />

// Define other methods and classes here
void NominatingGroupLeadersOP4()
{
	int T = Convert.ToInt32("3");
	int [] N = { 5, 5, 10 };
	string [] A = { "0 1 4 0 3", "4 3 0 0 0", "1 2 2 3 7 0 0 0 9 9" }; 
	int [] GR = { 2, 2, 2 };
	string [][] LRX = {
							new string [] { "0 4 1", "2 4 2" }
						,	new string [] { "0 1 1", "2 4 3" }
						,	new string [] { "0 5 3", "2 8 3" }
					  };
	for(int t = 0; t < T; t++)
	{
		int n = N[t];
    	int [] votes = Array.ConvertAll(A[t].Split(), Int32.Parse);
		SegmentTree tree = new SegmentTree(votes);
		int G = GR[t];
		for(int g = 0; g < G; g++)
		{
			int [] lrx = Array.ConvertAll(LRX[t][g].Split(),Int32.Parse);
			int l = lrx[0], r = lrx[1], x = lrx[2];
			Dictionary<int,int> dict = tree.FindRange(l, r);
//			Console.WriteLine($"{string.Join(" ", votes)} 		l:{l}	r:{r}	x:{x}");
//			Console.WriteLine(dict);
			int nominee = Int32.MaxValue;
			foreach(var item in dict.Where(z => z.Value == x))
			{
				//Console.WriteLine(item);
				nominee = Math.Min(nominee,item.Key);
			}
			Console.WriteLine((nominee == Int32.MaxValue) ? -1 : nominee);
//			Console.WriteLine(dict);
//			Console.WriteLine();
		}
	}
}

/*
void NominatingGroupLeadersOP3()
{
	int T = Convert.ToInt32("3");
	int [] N = { 5, 5, 10 };
	string [] A = { "0 1 4 0 3", "4 3 0 0 0", "1 2 2 3 7 0 0 0 9 9" }; 
	int [] GR = { 2, 2, 2 };
	string [][] LRX = {
							new string [] { "0 4 1", "2 4 2" }
						,	new string [] { "0 1 1", "2 4 3" }
						,	new string [] { "0 5 3", "2 8 3" }
					  };
	for(int t = 0; t < T; t++)
	{
		int n = N[t];
		//char [] votes = Array.ConvertAll(A[t].Split(), Char.Parse);
		//StringBuilder votes = new StringBuilder(Console.ReadLine().Replace(" ", string.Empty));
        //string votes = A[t].Replace(" ", string.Empty);//Trim().Split(), Int32.Parse);
    	int [] votes = Array.ConvertAll(A[t].Split(), Int32.Parse);
		SegmentTree tree = new SegmentTree(votes);

		int G = GR[t];
		for(int g = 0; g < G; g++)
		{
			int [] lrx = Array.ConvertAll(LRX[t][g].Split(),Int32.Parse);
			int l = lrx[0], r = lrx[1], x = lrx[2];
			int [] op = Array.ConvertAll(tree.FindRange(l, r).Trim(',').Split(','), Int32.Parse);
			Dictionary<int,int> dict = new Dictionary<int,int>();
			for(int i = 0; i < op.Length; i++)
			{
				int val = op[i];
				if(dict.ContainsKey(val)) dict[val]++;
				else dict.Add(val, 1);
			}
			int nominee = Int32.MaxValue;
			foreach(var item in dict)
			{
				if(item.Value == x) nominee = Math.Min(nominee,item.Key);
			}
			Console.WriteLine((nominee == Int32.MaxValue) ? -1 : nominee);
		}
	}
}
*/

void NominatingGroupLeadersOP2()
{
	int T = Convert.ToInt32("3");
	int [] N = { 5, 5, 10 };
	string [] A = { "0 1 4 0 3", "4 3 0 0 0", "1 2 2 3 7 0 0 0 9 9" }; 
	int [] GR = { 2, 2, 2 };
	string [][] LRX = {
							new string [] { "0 4 1", "2 4 2" }
						,	new string [] { "0 1 1", "2 4 3" }
						,	new string [] { "0 5 3", "2 8 3" }
					  };
	
	for(int t = 0; t < T; t++)
	{
		int n = N[t];
		//char [] votes = Array.ConvertAll(A[t].Split(), Char.Parse);
		//StringBuilder votes = new StringBuilder(Console.ReadLine().Replace(" ", string.Empty));
        string votes = A[t].Replace(" ", string.Empty);//Trim().Split(), Int32.Parse);

		int G = GR[t];
		for(int g = 0; g < G; g++)
		{
			int [] lrx = Array.ConvertAll(LRX[t][g].Split(),Int32.Parse);
			int l = lrx[0], r = lrx[1], x = lrx[2];
			string subS = votes.Substring(l, r - l + 1);
			//Console.WriteLine($"l:{l}	r:{r}	x:{x}	subS:{subS}");
			Dictionary<int,int> dict = new Dictionary<int,int>();
			for(int i = 0; i < subS.Length; i++)
			{
				int val = (int)Char.GetNumericValue(subS[i]);
				if(dict.ContainsKey(val)) dict[val]++;
				else dict.Add(val, 1);
			}
			int nominee = Int32.MaxValue;
			foreach(var item in dict)
			{
				if(item.Value == x) nominee = Math.Min(nominee,item.Key);
			}
			Console.WriteLine((nominee == Int32.MaxValue) ? -1 : nominee);
		}
	}
}

void NominatingGroupLeadersOP1()
{
	int T = Convert.ToInt32("2");
	int [] N = { 5, 5 };
	string [] A = { "0 1 4 0 3", "4 3 0 0 0" }; 
	int [] GR = { 2, 2 };
	string [][] LRX = {
							new string [] { "0 4 1", "2 4 2" }
						,	new string [] { "0 1 1", "2 4 3" }
					  };
	
	for(int t = 0; t < T; t++)
	{
		int n = N[t];
		int [] votes = Array.ConvertAll(A[t].Split(), Int32.Parse);
		Dictionary<int,SortedSet<int>> dict = new Dictionary<int,SortedSet<int>>();
		for(int v = 0; v < n; v++)
		{
			int vote = votes[v];
			if(dict.ContainsKey(vote)) 
			{
				var set = dict[vote];
				set.Add(v);
				dict[vote] = set;
			}
			else 
			{
				var set = new SortedSet<int>();
				set.Add(v);
				dict[vote] = set;
			}
		}
		//Console.WriteLine(dict);

		int G = GR[t];
		for(int g = 0; g < G; g++)
		{
			int [] lrx = Array.ConvertAll(LRX[t][g].Split(),Int32.Parse);
			int l = lrx[0], r = lrx[1], x = lrx[2];
			//Console.WriteLine($"l:{l}	r:{r}	x:{x}");
			int nominee = Int32.MaxValue;
			foreach(var item in dict)
			{
				var set = item.Value.ToArray();
				if(set.Length >= x)
				{
					//Console.WriteLine($"set.Length:{set.Length} {string.Join(" ", set)}");
					//Console.WriteLine(set);
					int count = 0;
					for(int i = 0; i < set.Length; i++)
					{
						if(l <= set[i] && set[i] <= r) 
						{
							//Console.WriteLine($"i:{i} set[i]:{set[i]}");
							count++; 
						}
					}
					if(count == x) nominee = Math.Min(nominee,item.Key);
					//Console.WriteLine($"count:{count} nominee:{nominee}");
				}
				//Console.WriteLine();
			}
			Console.WriteLine((nominee == Int32.MaxValue)? -1 : nominee);
			//Console.WriteLine();
		}
	}
}


void NominatingGroupLeaders()
{
	int G = Convert.ToInt32("2");
	int [] N = { 5, 5 };
	string [] A = { "0 1 4 0 3", "4 3 0 0 0" }; 
	int [] GR = { 2, 2 };
	string [][] LRX = {
							new string [] { "0 4 1", "2 4 2" }
						,	new string [] { "0 1 1", "2 4 3" }
					  };
					  
	for(int g = 0; g < G; g++)
	{
		int n = N[g];
		int [] votes = Array.ConvertAll(A[g].Split(), Int32.Parse);
		int groups = GR[g];
		for(int h = 0; h < groups; h++)
		{
			int [] lrx = Array.ConvertAll(LRX[g][h].Split(),Int32.Parse);
			int l = lrx[0], r = lrx[1], x = lrx[2];
			int [] v = new int[n];
			for(; l <= r; l++)
			{
				v[votes[l]]++;
				//Console.WriteLine(votes[l]);
			}
			int nominee = -1;
			for(int i = n - 1; i >= 0; i--)
			{
				if(v[i] == x) nominee = i;
			}
			Console.WriteLine(nominee);
			//Console.WriteLine();
		}
	}
}

void Main()
{
	/*
	2
	5
	0 1 4 0 3 
	2
	0 4 1
	2 4 2
	5
	4 3 0 0 0 
	2
	0 1 1
	2 4 3
	*/
	NominatingGroupLeadersOP4();
	Console.WriteLine("******************************OP4**************************************************");
	//NominatingGroupLeadersOP3();
	//Console.WriteLine("******************************OP3**************************************************");
	NominatingGroupLeadersOP2();
	Console.WriteLine("******************************OP2**************************************************");
	NominatingGroupLeadersOP1();
	Console.WriteLine("******************************OP1**************************************************");
	NominatingGroupLeaders();
	Console.WriteLine("*******************************BF*************************************************");
}


public class SegmentTree 
{
    public class TreeNode
	{
	    public int start;
	    public int end;
	    public int value;
	    public TreeNode leftChild;
	    public TreeNode rightChild;
	 	public Dictionary<int,int> dict;
	    public TreeNode(int left, int right, int value, Dictionary<int,int> d)
		{
	        this.start=left;
	        this.end=right;
	        this.value=value;
			this.dict = d;
	    }
	    public TreeNode(int left, int right)
		{
	        this.start=left;
	        this.end=right;
	        this.value=0;
			this.dict = new Dictionary<int,int>();
	    }
	}

	public TreeNode root = null;
 
    public SegmentTree(int[] nums) 
	{
        if(nums==null || nums.Length==0) return;
        this.root = BuildTree(nums, 0, nums.Length-1);    
    }
	
	public Dictionary<int,int> FindRange(int i, int j){ return FindRange(this.root, i, j); } 
	
    public Dictionary<int,int> FindRange(TreeNode root, int i, int j)
	{
		var dict = new Dictionary<int,int>();
        if(root==null || j < root.start || i > root.end || i > j ) return dict;
		if(i <= root.start && j >= root.end) return root.dict;

		int mid = root.start + (root.end - root.start)/2;
        var result1 = FindRange(root.leftChild, i, Math.Min(mid, j));
		foreach(var item in result1) dict.Add(item.Key,item.Value);
		var result2 = FindRange(root.rightChild, Math.Max(mid+1, i), j);
		foreach(var item in result2) if(dict.ContainsKey(item.Key)) dict[item.Key] += item.Value; else dict.Add(item.Key, item.Value);
		return dict;
    }

	public TreeNode BuildTree(int[] nums, int i, int j)
	{
		var dict = new Dictionary<int,int>();
        if(nums==null || nums.Length==0|| i > j) return null;
        if(i==j) 
		{ 
			var v = nums[i];
			dict.Add(v,1);
			return new TreeNode(i, j, v, dict); 
		}
        TreeNode current = new TreeNode(i, j);
        int mid = i + (j - i)/ 2;
        current.leftChild = BuildTree(nums, i, mid);
		foreach(var item in current.leftChild.dict) dict.Add(item.Key,item.Value);
		current.rightChild = BuildTree(nums, mid + 1, j);
		foreach(var item in current.rightChild.dict) if(dict.ContainsKey(item.Key)) dict[item.Key] += item.Value; else dict.Add(item.Key, item.Value);
		current.dict = dict;
		return current;
    }
}

/*
public class SegmentTree 
{
    public class TreeNode
	{
	    public int start;
	    public int end;
	    public int sum;
	    public TreeNode leftChild;
	    public TreeNode rightChild;
	 
	    public TreeNode(int left, int right, int sum)
		{
	        this.start=left;
	        this.end=right;
	        this.sum=sum;
	    }
	    public TreeNode(int left, int right)
		{
	        this.start=left;
	        this.end=right;
	        this.sum=0;
	    }
	}

	public TreeNode root = null;
 
    public SegmentTree(int[] nums) 
	{
        if(nums==null || nums.Length==0) return;
        this.root = BuildTree(nums, 0, nums.Length-1);    
    }
	
	public string FindRange(int i, int j){ return FindRange(this.root, i, j); } 
	
    public string FindRange(TreeNode root, int i, int j)
	{
        if(root==null || j < root.start || i > root.end || i > j ) return string.Empty;
 
        if(root.start == root.end) return root.sum.ToString();
        
		int mid = root.start + (root.end - root.start)/2;
		StringBuilder  result = new StringBuilder();
        var result1 = FindRange(root.leftChild, i, Math.Min(mid, j));
        result.Append(result1);
        result.Append(",");
		var result2 = FindRange(root.rightChild, Math.Max(mid+1, i), j);
        result.Append(result2);
		return result.ToString();            
    }

    public TreeNode BuildTree(int[] nums, int i, int j)
	{
        if(nums==null || nums.Length==0|| i > j) return null;
        if(i==j) return new TreeNode(i, j, nums[i]);
        TreeNode current = new TreeNode(i, j);
        int mid = i + (j-i)/2;
        current.leftChild = BuildTree(nums, i, mid);
        current.rightChild = BuildTree(nums, mid+1, j);
        current.sum = current.leftChild.sum+current.rightChild.sum;
        return current;
    }
}

*/