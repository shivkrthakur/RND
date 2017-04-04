<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	BiggerIsGreater();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void BiggerIsGreater()
{
	int t = Convert.ToInt32(5);
	string[] input = new string[] {"ab", "bb", "hefg", "dhck", "dkhc" };
	for(int i = 0; i < t; i++)
	{
		string str = input[i];
		int [] c = str.ToCharArray().Select(x => (int)x).ToArray();
		if(NextPermutation(c))
			Console.WriteLine(string.Join("", c.Select(x => (char)x).ToArray()));
		else Console.WriteLine("no answer");
	}
}

public static bool NextPermutation(int [] array)
{
	//1. Find the pivot
	int i = array.Length - 1;
	while(i > 0 && array[i-1] >= array[i]) i--;
	if(i <= 0) return false;
	
	//2. find the right most element greater than the next pivot i.e. i - 1
	int j = array.Length - 1;
	while(j >= i && array[j] <= array[i-1]) j--;
	
	//3. Swap the array[j] and array[i-1]
	int temp = array[j];
	array[j] = array[i-1];
	array[i-1] = temp;
	
	//4. Reverse the suffix.
	j = array.Length -1;
	while(j > i)
	{
		temp = array[j];
		array[j] = array[i];
		array[i] = temp;
		j--;
		i++;
	}
	return true;
}