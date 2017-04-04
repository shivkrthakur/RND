<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	SequenceEquation();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
private static void SequenceEquation()
{
	int n = Convert.ToInt32("3");
	int [] N = Array.ConvertAll("2 3 1".Split(),Int32.Parse);
	Console.WriteLine(N);
	
	int i = 1;
	while(i <= n)
	{
		int j = 0;
		int k = 0;
		while(j < n)
		{
			if(i == N[j])
			{
				k = j + 1;
				for(int l = 0; l < n; l++)
				{
					if(k == N[l]) 
					{
						Console.WriteLine(l+1);
						break;
					}
				}
				break;
			}
			//Console.WriteLine($"i:{i} N[i]:{N[i]} N[j]:{N[j]} j:{j+1}");
			j++;
		}
		i++;
	}
}