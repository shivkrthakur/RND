<Query Kind="Program" />

void Main()
{
	Equal();
}

// Define other methods and classes here
void Equal()
{
	int q = Convert.ToInt32("1");
	string [] S = { "4", "2 2 3 7" };
	for(int i = 0; i < q; i++)
	{
		int n = Convert.ToInt32(S[i][0].ToString());
		int [] c = Array.ConvertAll(S[i+1].Split(), Int32.Parse);
		Console.WriteLine(n);
		Console.WriteLine(c);
		int min = c.Min();
		int j = 0, sum = 0;
		while(j < c.Length)
		{
			sum += c[j++] - min;
		}
		//Console.WriteLine(c);
		Console.WriteLine($"min:{min} sum:{sum}");
		Array.Sort(c);
		//Console.WriteLine(c);
		int count = Calculate(c, c.Length - 2);
		Console.WriteLine(count);
	}
}

int Calculate(int [] input, int index)
{
	int count = 1;
	if(index < 0) return 0;
	//Console.WriteLine($"1==> index:{index} input[index]:{input[index]}");
	int val1 = input[index];
	count +=Calculate(input, index-1);
	int val2 = input[++index];
	int diff = val2 - val1;
	if(diff > 0) count++;
	//Console.WriteLine($"val1:{val1} val2:{val2} diff:{diff}");
	//Console.WriteLine($"2==> index:{++index} input[index]:{input[index]}");
	return count;
	//Console.WriteLine($"2==> index:{index} input[index]:{input[index]}");
	//return input[index+1] - input[index];
}