<Query Kind="Program" />

void Main()
{
//	int [] S =	"0 0 1 0 1 0 1 1 1 0 0 0".Split().Select(Int32.Parse).ToArray();  
//	int s = 001010111000;
//	int i = 0;
//	while(i < S.Length)
//	{
//		s = s >> 1;
//		Console.WriteLine(s);
//		i++;
//	}
	ZeroOneGame();
}

// Define other methods and classes here
void ZeroOneGame()
{
	int G = Convert.ToInt32("3");
	int [] N = { 4, 5, 6 };
	string [] S = { "1 0 1 0 1", "0 0 1 0 1 0 1 1 1 0 0 0", "1 0 1 0 0 0 1", "1 0 0 0 0 0 1", "0 0 1 0 1 0 0", "1 0 1 0 1 0 1", "1 0 1 0 1 0 0", "1 0 1 1 0 0 1", "1 0 0 1", "0 0 0 0 0 0", "0 0 0 0 0 0 1", "1 1 0 0 0 0 1" };
	int totalLoops = 0;
	for(int g = 0; g < S.Length; g++)
	{
		int [] zeroOne = new int[2];
		//int [] s = S[g].Split().Select(Int32.Parse).ToArray();
		//string s = S[g].Replace(" ", string.Empty);
		
		StringBuilder s = new StringBuilder(new String(Array.ConvertAll(S[g].Split(), Char.Parse)));//.Select(Char.Parse).ToArray());
     	int count = 0, len = s.Length;
        while(s.ToString().Contains("010") || s.ToString().Contains("000"))
        {
            s.Replace("010","00");
            count += len - s.Length;
            len = s.Length;
            s.Replace("000", "00");
            count += len - s.Length;
            len = s.Length;
        }
		Console.WriteLine($"{((count & 1) == 0 ? "Bob" : "Alice")} ==> 	{s} ==> {s.ToString()} => count:{count}" );
		///*
		StringBuilder sb = new StringBuilder(new String(Array.ConvertAll(S[g].Split(), Char.Parse)));//.Select(Char.Parse).ToArray());
		//String s = sb.ToString();
		//Console.WriteLine(sb.ToString());
		int el = 0, loopCount = 0;
		//Console.WriteLine($"i:{0} sb:{sb.ToString()}");
		for(int i = 1; i < sb.Length - 1;)
		{
			if(sb[i-1] == '0' && sb[i+1] == '0') 
			{ 
				sb.Remove(i,1); 
				el++; 
				if(sb.ToString().Contains("010")  || sb.ToString().Contains("000"))
				{
					int zeroOnezero = sb.ToString().IndexOf("010");
					int zerozerozero = sb.ToString().IndexOf("000");
					if(zeroOnezero > -1 && zerozerozero > -1) 
					{
						i = Math.Min(zerozerozero, zeroOnezero);
					}
					else i = Math.Max(zerozerozero, zeroOnezero);
					i++;
				}
				else break;
			}
			else i++;
			loopCount++;
			//Console.WriteLine($"1	i:{i} j:{j} sb[i]:{sb[i]} sb[j]:{sb[j]}	sb:{sb.ToString()}");
			//if(sb[j-1] == '0' && sb[j+1] == '0') { sb.Remove(j,1); el++; i--; }
			//Console.WriteLine($"2	i:{i} j:{j} sb:{sb.ToString()}");
			//Console.WriteLine();
		}
		
//		for(int i = 1; i < sb.Length -1; i++)
//		{
//			if(sb[i-1] == '0' && sb[i+1] == '0') { sb.Remove(i,1); el++; }
//			Console.WriteLine($"i:{i} sb:{sb.ToString()}");
//		}
		totalLoops += loopCount;
		Console.WriteLine($"{((el & 1) == 0 ? "Bob" : "Alice")} ==> 	{s} ==> {sb.ToString()} => sz:{el} loopCount:{loopCount} totalLoops:{totalLoops}" );
		//*/
		/*
		Queue<int> queue = new Queue<int>(s);
		int prev = -1, zeroCount = 0;
		int xorSum = 0;
		for(int i = 0; i < s.Length - 2; i++)
		{
			xorSum += s[i];
		}
		//Console.WriteLine(xorSum);
		while(queue.Count > 0)
		{
			int next = -1;
			int cur = queue.Dequeue();
			if(queue.Count > 0) 
			{	
				next = queue.Peek();
			}
			if(cur == 0) zeroCount++;
			else if(prev == 0 && next == 0) zeroCount++;
			//else zeroCount--;
			//Console.WriteLine($"{prev}{cur}{next}		{zeroCount}");
			prev = cur;
			//Console.WriteLine(queue.Dequeue());
		}
		//Console.WriteLine(queue);
		int sz = zeroCount;
		*/
		/*
		int zeroes = 1;
		int total = 0;
		for(int i = 0; i < s.Length - 2; i++)
		{
			if(s[i] == s[i+1] && s[i+1] == 0) zeroes++;
			else if(s[i] == 0 && s[i + 1] == 1 && s[i + 2] == 0) { zeroes += 2; }
			else { if(zeroes >= 3) {  total += zeroes; } zeroes = 0; }
		}
		int sz = total;
		//Console.WriteLine(zeroOne);
		*/
		//Console.WriteLine($"{string.Join(" ",s)} => sz:{sz} {((sz & 1) == 0 ? "Bob" : "Alice")}" );
		/*
		for(int i = 0; i < s.Length - 2; i++)
		{
			if(s[i] == s[i+2] && s[i] == 0) 
			{
				sz++;
				or |= s[i+1];
			}
		}
		
		if(sz > 0 && (((sz & 1) != 0 && (s[0] + s[s.Length - 1] > 0))  || ((sz & 1) == 0 && or == 1))) Console.WriteLine($"{string.Join(" ",s)} => Alice 	sz:{sz} or:{or}" ); //Console.WriteLine("Alice");
		else Console.WriteLine($"{string.Join(" ",s)} => Bob	sz:{sz} or:{or}");//Console.WriteLine("Bob");
		*/
		/*
		int and = Convert.ToInt32(s[0].ToString()), or = Convert.ToInt32(s[0].ToString());
		for(int i = 0; i < s.Length; i++)
		{
			zeroOne[s[i]]++;
			and &= s[i];
			or |= s[i];
		}
		Console.WriteLine(string.Join(" ", zeroOne));
		Console.WriteLine($"{string.Join(" ", s)} and:{and} or:{or}");
//		if((zeroOne[0] > 0 && (zeroOne[0] & 1) == 0) && (zeroOne[1] > 0 && (zeroOne[1] & 1) == 0)  && and == 0 && or == 1) Console.WriteLine("BOB");
//		else if((zeroOne[0] > 0 && (zeroOne[0] & 1) == 0) && and == 0 && or == 0) Console.WriteLine("BOB");
//		else Console.WriteLine("Alice");
		//Console.WriteLine(0 & 1);
		*/
	}
}