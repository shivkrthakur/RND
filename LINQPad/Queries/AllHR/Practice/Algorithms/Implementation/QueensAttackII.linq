<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	QueensAttackII();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
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