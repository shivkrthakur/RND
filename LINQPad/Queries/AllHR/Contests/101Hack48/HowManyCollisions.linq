<Query Kind="Program" />

void Main()
{
	int q = Convert.ToInt32(5);
	string [] input = { "r", "lrrl", "rrrll", "rrdlldrr", "rrrdllrllrrl" };
	for(int a0 = 0; a0 < q; a0++){
        string s = input[a0];
        // Returns the number of times moving robots collide.
        int result = HowManyCollisions(s);
        Console.WriteLine(result);
		Console.WriteLine();
    }

}

// Define other methods and classes here
static int HowManyCollisions(string s)
{
    // Complete this function
	string col1 = "rl", col2 = "rd", col3 = "dl";

	
	string o = s.Replace("rl", string.Empty).Replace("rd", string.Empty).Replace("dl", string.Empty);
//	Console.WriteLine(o);
	int rC = 0, lC = 0, dC = 0;
	char cur = 'x', prev = 'x';
	int count = 0, len = s.Length;
	Console.WriteLine(s);
	for(int i = 0; i < len; i++)
	{
		cur = s[i];
		if((prev == 'r' && cur == 'l') || (prev == 'r' && cur == 'd') || (prev == 'd' && cur == 'l'))
		{
			if(prev == 'r' && cur == 'l') count += 2;
			if(prev == 'r' && cur == 'd') count += 1;
			if(prev == 'd' && cur == 'l') count += 1;
			
			int ci = i-2;
			while(ci >= 0 && s[ci--] == 'r') count++;
//			Console.WriteLine($"firstCount:{count} i:{i}");
			ci = i+1;
//			Console.WriteLine($"2ndCount1:{count} ci:{ci} i:{i}");
			while(ci < len && s[ci++] == 'l') count++;
			i = ci-2;
//			Console.WriteLine($"2ndCount2:{count} ci:{ci} i:{i}");
//			Console.WriteLine();
		}
		prev = cur;
	}
	return count;
}