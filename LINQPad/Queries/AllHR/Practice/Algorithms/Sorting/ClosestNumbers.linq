<Query Kind="Program" />

void Main()
{
	int n = Convert.ToInt32("10");
	//int [] N = Array.ConvertAll("-20 -3916237 -357920 -3620601 7374819 -7330761 30 6246457 -6461594 266854".Split(), Int32.Parse);
	int [] N = Array.ConvertAll("-20 -3916237 -357920 -3620601 7374819 -7330761 30 6246457 -6461594 266854 -520 -470".Split(), Int32.Parse);
	//int [] N = Array.ConvertAll("5 4 3 2".Split(), Int32.Parse);

	ClosesNumbers(N);
}

// Define other methods and classes here
void ClosesNumbers(int [] N)
{
	List<Tuple<int,int>> list = new List<Tuple<int,int>>();
	int minVal = Int32.MaxValue;
	int count = 0;
	for(int i = 0; i < N.Length; i++)
	{
		count++;
		for(int j = i + 1; j < N.Length; j++)
		{
			count++;
			int aD = Math.Abs(N[i] - N[j]);
			if(minVal >= aD)
			{
				if(minVal > aD) {	list.Clear(); minVal = aD; }
				list.Add(new Tuple<int,int>(N[i], N[j]));
			}
		}
	}
//	Console.WriteLine(count);
	//Console.WriteLine(list);
	foreach(var item in list) Console.Write($"{item.Item1} {item.Item2} ");
	Console.WriteLine();
	
	Array.Sort(N);
	minVal = Int32.MaxValue; 
	count = 0;
	List<ValueTuple<int,int>> valTList = new List<ValueTuple<int,int>>();
	for(int i =  0; i < N.Length - 1; i++)
	{
		int aD = Math.Abs(N[i] - N[i + 1]);
		count++;
		if(minVal >= aD)
		{
			if(minVal > aD) { valTList.Clear(); minVal = aD; }
			valTList.Add(new ValueTuple<int,int>(N[i], N[i+1]));
		}
	}
//	Console.WriteLine(count);
	//Console.WriteLine(valTList);
	foreach(var item in valTList) Console.Write($"{item.Item1} {item.Item2} ");
}