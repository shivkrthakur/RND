<Query Kind="Program" />

void Main()
{
	MinimumAbsoluteDifferenceInAnArrayOP();
	//MinimumAbsoluteDifferenceInAnArray();
}

// Define other methods and classes here
void MinimumAbsoluteDifferenceInAnArrayOP()
{
	int n = Convert.ToInt32("3");
	int [] N = Array.ConvertAll("3 -7 0".Split(), Int32.Parse);
	int minValue = Int32.MaxValue;
	Array.Sort(N);
	for(int i = 0; i < n-1; i++)
	{
		minValue = Math.Min(minValue, Math.Abs(N[i] - N[i+1]));
	}
	Console.WriteLine(minValue);
}

void MinimumAbsoluteDifferenceInAnArray()
{
	int n = Convert.ToInt32("3");
	int [] N = Array.ConvertAll("3 -7 0".Split(), Int32.Parse);
	int minValue = Int32.MaxValue;
	for(int i = 0; i < n; i++)
	{
		for(int j = 0; j < n; j++)
		{
			if(i == j) continue;
			minValue = Math.Min(minValue, Math.Abs(N[i] - N[j]));
		}
	}
	Console.WriteLine(minValue);
}