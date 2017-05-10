<Query Kind="Program" />

void Main()
{
	InsertionSortPart1();
}

// Define other methods and classes here
void InsertionSortPart1()
{
	int n = Convert.ToInt32("5");
	int [] N = Array.ConvertAll("2 4 6 8 3".Split(), Int32.Parse);
	
	int tgVal = N[n-1];
	int i = n - 2;
	while(i > 0 && tgVal < N[i]) 
	{
		N[i + 1] = N[i]; 
		i--;  
		Console.WriteLine(string.Join(" ", N)); 
	}
	N[i+1] = tgVal;
	Console.WriteLine(string.Join(" ", N)); 
}