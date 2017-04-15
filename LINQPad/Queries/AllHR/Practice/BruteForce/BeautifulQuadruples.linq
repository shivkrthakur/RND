<Query Kind="Program" />

void Main()
{
	BeautifulQuadruples();
	BeautifulQuadruplesOP1();
}

// Define other methods and classes here
static void BeautifulQuadruples() {
    //int[] tokens_A = Array.ConvertAll("50 35 34 1".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 16965
    int[] tokens_A = Array.ConvertAll("10 3 4 5".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 185
    //int[] tokens_A = Array.ConvertAll("2 3 4 5".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 34
	//int[] tokens_A = Array.ConvertAll("1 2 3 4".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 11
	
    int A = tokens_A[0];
    int B = tokens_A[1];
    int C = tokens_A[2];
    int D = tokens_A[3];
	
	//Console.WriteLine($"A:{A} B:{B} C:{C} D:{D}");
    int count = 0;
    for(int i = 1; i <= A; i++)
    {
        for(int j = i; j <= B; j++)
        {
            for(int k = j; k <= C; k++)
            {
                for(int l = k; l <= D; l++)
                {
					if((i ^ j ^ k ^ l) != 0)
					{
                    	//Console.WriteLine($"NON ZEROES ==> ({i},{j},{k},{l})");   
						count++;
					}
                }
            }
        }
    }
	Console.WriteLine(count);
}

void BeautifulQuadruplesOP1()
{
    //int[] tokens_A = Array.ConvertAll("50 35 34 1".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 16965
    int[] tokens_A = Array.ConvertAll("10 3 4 5".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 185
    //int[] tokens_A = Array.ConvertAll("2 3 4 5".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 34
	//int[] tokens_A = Array.ConvertAll("1 2 3 4".Split(),Int32.Parse).OrderBy(x => x).ToArray(); //OUTPUT: 11
	long A = tokens_A[0], B = tokens_A[1], C = tokens_A[2], D = tokens_A[3];

	int [] cnt = new int[C * D];
	int total = 0;

	for (int i = 1; i <= C; i++) {
		for (int j = i; j <= D; j++) {
			cnt[i ^ j]++;
			total++;
		}
	}
//	Console.WriteLine(cnt);
//	Console.WriteLine(total);
	long ans = 0;
	for (int b = 1; b <= B; b++) {
		for (int a = 1; a <= Math.Min(A, b); a++) {
			ans += total - cnt[a ^ b];
		}
		for (int d = b; d <= D; d++) {
			cnt[b ^ d]--;
			total--;
		}
	}
	Console.WriteLine(ans);
}