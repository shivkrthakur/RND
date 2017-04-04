<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	Encryption();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void Encryption()
{
	string s = "chillout";//"haveaniceday";//"chillout";//"feedthedog";//"haveaniceday";
	int len = s.Length;
	int rows = (int)Math.Floor(Math.Sqrt(len));
	int cols = (int)Math.Ceiling(Math.Sqrt(len));
	int mul = rows * cols;
	Console.WriteLine($"==>		rows:{rows} cols:{cols} mul:{mul} len:{len}");
	if(mul < len)
	{	
		rows++;
		//mul = rows * cols;
		//Console.WriteLine($"mul:{mul}");
	}
	
	Console.WriteLine($"==>		rows:{rows} cols:{cols} NewMul:{rows*cols} OldMul:{mul} len:{len}");
	string [] op = new string[cols];
	
	for(int i = 0, j= 0; i < len; i += cols, j++)
	{
		string temp = string.Empty;
		if(i + cols < len)
			temp = s.Substring(i, cols);
		else temp = s.Substring(i, len - i);
		for(int c = 0; c < temp.Length; c++)
		{
			op[c] += temp[c];
		}
	}
	//Console.WriteLine($"rows:{rows} cols:{cols} op:{string.Join(" ", op)}");
	Console.WriteLine($"{string.Join(" ", op)}");
}