<Query Kind="Program" />

void Main()
{
	CountingSort3();
}

void CountingSort3()
{
	int n = Convert.ToInt32("10");
	string [] S = { "4 that", "3 be", "0 to", "1 be", "5 question", "1 or", "2 not", "4 is", "2 to", "4 the" };
	
	int [] output = new int[100];
	for(int i = 0; i < n; i++) output[Convert.ToInt32(S[i].Split()[0].ToString())]++;
	//Console.WriteLine($"{string.Join(" ", output)}");
	
	for(int i = 0; i < 100; i++)
	{
		int total = 0, j = i;
		while(j >= 0) total += output[j--];
		Console.Write($"{total} ");
	}
	
	//for(int i = 1; i < 100; i++) output[i] += output[i - 1];
	//Console.WriteLine($"{string.Join(" ", output)}");
}