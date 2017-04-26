<Query Kind="Program" />

void Main()
{
	LuckBalance();
}

// Define other methods and classes here
void LuckBalance()
{
	int [] NK = Array.ConvertAll("6 3".Split(), Int32.Parse);
	int n = NK[0], k = NK[1];
	
	string [] LT = { "5 1", "2 1", "1 1", "8 1", "10 0", "5 0" };
	List<int> imps = new List<int>();
	int totalLuck = 0;
	for(int i = 0; i < n; i++)
	{
		int [] lt = Array.ConvertAll(LT[i].Split(), Int32.Parse);
		int l = lt[0], t = lt[1];
		
		if(t == 1) 
		{
		 	imps.Add(l);
		}
		totalLuck += l;
	}
	//Console.WriteLine(totalLuck);
	//Console.WriteLine(imps);
	imps= imps.OrderBy(x => x).ToList();
	int totalImps = imps.Count;
	int mustWin = totalImps - k;
	//Console.WriteLine(imps);
	for(int j = 0; j < mustWin; j++)
	{
		totalLuck -= 2 * imps[j];
	}
	Console.WriteLine(totalLuck);
}