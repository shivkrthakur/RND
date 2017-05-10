<Query Kind="Program" />

void Main()
{
	InsertionSortPart2();
	Console.WriteLine();
	//InsertionSort(Array.ConvertAll("1 4 3 5 6 2".Split(), Int32.Parse));
}

// Define other methods and classes here
void InsertionSortPart2()
{
	int n = Convert.ToInt32("6");
	int [] N = Array.ConvertAll("1 4 3 5 6 2".Split(), Int32.Parse);
	
	for(int i = 1; i < n; i++)
	{
		int val = N[i];
		int j = i;
		for(; j > 0 && val < N[j - 1]; j--)
		{
			Swap(N,j,j-1);
		}
		if(i != j) N[j] = val;
		Console.WriteLine(string.Join(" ", N)); 	
	}
}

void Swap(int [] input, int i , int j)
{
	int temp = input[i];
	input[i] = input[j];
	input[j] = temp;
}


void InsertionSort(int[] N) {
    int i = 0;
	while(++i < N.Length)
	{
		int j = 0;
		while(j < i)
		{
			if(N[i] < N[j])
			{
				int temp = N[i];
				for(int k = i; k > j; k--)
				{
					N[k] = N[k-1];
				}
				N[j] = temp;
				break;
			}
			j++;
		}
		Console.WriteLine(string.Join(" ", N));
	}
}