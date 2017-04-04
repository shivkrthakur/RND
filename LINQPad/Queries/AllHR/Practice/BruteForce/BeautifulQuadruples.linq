<Query Kind="Program" />

void Main()
{
	BeautifulQuadruples();
}

// Define other methods and classes here
static void BeautifulQuadruples() {
    int[] tokens_A = Array.ConvertAll("50 35 34 1".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 16965
    //int[] tokens_A = Array.ConvertAll("10 3 4 5".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 185
    //int[] tokens_A = Array.ConvertAll("1 2 3 4".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 16965
	
    int A = tokens_A[0];
    int B = tokens_A[1];
    int C = tokens_A[2];
    int D = tokens_A[3];
	//Console.WriteLine($"A:{A} B:{B} C:{C} D:{D}");
    int count = 0, c = 0;
	HashSet<string> hs = new HashSet<string>();
    for(int i = 1; i <= A; i++)
    {
        for(int j = i; j <= B; j++)
        {
            for(int k = j; k <= C; k++)
            {
                for(int l = k; l <= D; l++)
                {
                    //Console.WriteLine($"({i},{j},{k},{l})");   
					//string s = i.ToString() + j.ToString() + k.ToString() + l.ToString();
					//string s = new String(string.Join("", new int[]{ i, j , k , l}.OrderBy(x => x)).ToArray());
					//s = new String(s.OrderBy(x => x).ToArray());
					//Console.WriteLine(s);
					c++;
					//hs.Add(s);
					if((i ^ j ^ k ^ l) != 0)
					{
						count++;
					}
                }
				//Console.WriteLine();
            }
        }
    }
	Console.WriteLine(count);
	Console.WriteLine(hs.Count());
	Console.WriteLine(c);
}