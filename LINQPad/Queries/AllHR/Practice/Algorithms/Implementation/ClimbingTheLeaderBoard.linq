<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	ClimbingTheLeaderBoard();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
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