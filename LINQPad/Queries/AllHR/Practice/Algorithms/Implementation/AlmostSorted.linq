<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	AlmostSorted();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void AlmostSorted()
{
	//int n = Convert.ToInt32("2");
	int [] input = "4 2".Split().Select(Int32.Parse).ToArray();
	//int [] input = "1 5 4 3 2 6".Split().Select(Int32.Parse).ToArray();
	//int [] input = "1 2 3 4 5 6".Split().Select(Int32.Parse).ToArray();
	//int [] input = "1 5 3 4 2 6".Split().Select(Int32.Parse).ToArray();
	//Console.WriteLine(input);
	int n = input.Length;
	
	int i = n - 1;
	while(i > 0 && input[i] > input[i-1]) i--;
	
	if(i == 0) { Console.WriteLine("yes"); return; }
	//Console.WriteLine($"i:{i}");
	
	int k = 0;
	while(k < i && input[k] < input[k+1]) k++;
	//Console.WriteLine($"k:{k}");
	
	int l = i;
	while(l > k && input[l] < input[l-1]) l--;
	//Console.WriteLine($"l:{l}");
	
	if(l > 0 && k > 0 && l == k) Console.WriteLine($"reverse {k+1} {i+1}");
	else 
	{
		int t = input[k];
		input[k] = input[i];
		input[i] = t;
		//Console.WriteLine(input);
		
		int index = n - 1;
		while(index > 0 && input[index] > input[index-1]) index--;
		//Console.WriteLine(index);
		if(index == 0) Console.WriteLine($"swap {k} {i}");
	}
}
