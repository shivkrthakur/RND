<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	AbsolutePermutation();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void AbsolutePermutation()
{
	int t = Convert.ToInt32("1");
	string [] input = new string[] { "3 2" };
	
	//string [] input = new string[] { "2 1", "3 0", "3 2" };
	//int [] input = "2 1".Split().Select(x => Int32.Parse(x)).ToArray();
	for(int j = 0; j < t; j++)
	{
		int [] inputInt = input[j].Split().Select(x => Int32.Parse(x)).ToArray();
		int n = inputInt[0], k = inputInt[1];
		bool [] output = new bool[n+1];
		int [] op = new int[n];
		bool np = false;
		for(int i = 1; i <= n; i++)
		{
			//Console.WriteLine(i);
			int x1 = i + k;
			int x2 = i - k;
			
			//Console.WriteLine($"x1:{x1} x2:{x2}");
			if(x1 > 0 && x1 <= n && x2 > 0 && x2 <= n)
			{
				if(x1 < x2)
				{
					if(!output[x1])
					{
						output[x1] = true;
						op[i-1] = x1;
						//Console.Write(x1 + " ");
					}
					else if(!output[x2])
					{
						output[x2] = true;
						op[i-1] = x2;
						//Console.Write(x2 + " ");
					}
				}
				else
				{
					if(!output[x2])
					{
						output[x2] = true;
						op[i-1] = x2;
						//Console.Write(x2 + " ");
					}
					else if(!output[x1])
					{
						output[x1] = true;
						op[i-1] = x1;
						//Console.Write(x1 + " ");
					}
				}
			}
			else if(x1 > 0 && x1 <= n && !output[x1])
			{
				output[x1] = true;
				op[i-1] = x1;
				//Console.Write(x1 + " ");
			}
			else if(x2 > 0 && x2 <= n && !output[x2])
			{
				output[x2] = true;
				op[i-1] = x2;
				//Console.Write(x2 + " ");
			}
			else
			{
				np = true;
			}
		}
		
		//Console.WriteLine(output);
		//Console.WriteLine();
		if(np)
		{
			Console.WriteLine(-1);
		}
		else
		{
			Console.WriteLine(string.Join(" ",op));
		}
	}
}