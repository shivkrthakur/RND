<Query Kind="Program" />

void Main()
{
	SumOfSubArrays();
}

// Define other methods and classes here
void SumOfSubArrays()
{
    //int n = Convert.ToInt32("4");
    //string[] a_temp = "1 2 3 4 5".Split(' ');
	string[] a_temp = "3 1 4 2".Split(' ');
	int[] a = Array.ConvertAll(a_temp,Int32.Parse);
	var mod = Math.Pow(2,64);
	//Array.Sort(a);
	int n = a.Length; 
	long sum = 0;
	for(int i = 0; i < n; i++)
	{
		for(int j = 0, k = 0; j < n; k++, j++)
		{
			//Console.WriteLine($"");
			StringBuilder s = new StringBuilder(a[i]);
			int small = Int32.MaxValue, max = Int32.MinValue, val = 0;
			for(int l = i; l < k+1; l++)
			{
				//Console.WriteLine($"l:{l} k:{k}");
				max = Math.Max(a[l], max);
				small = Math.Min(a[l], small);
				//max = a[k-1];
				s.Append(a[l]);
			}
			if(max != Int32.MinValue && small != Int32.MaxValue)
			{
				val = (int)Math.Pow(max - small,2);
				sum += val;
				//Console.WriteLine($"max:{max} small:{small} val:{val} sum:{sum}");
				Console.WriteLine($"max:{max} small:{small} val:{val} k:{k} sum:{sum} 				{s.ToString()}"); 
			}
				//Console.WriteLine(s.ToString());
		}
	}
	Console.WriteLine($"sum:{sum % mod} mod:{mod}");
	Console.WriteLine();
}