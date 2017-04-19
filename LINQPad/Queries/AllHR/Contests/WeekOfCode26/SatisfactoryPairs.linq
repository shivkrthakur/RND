<Query Kind="Program" />

void Main()
{
	SatisfactoryPairs();	
}

// Define other methods and classes here

static void SatisfactoryPairs() 
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
    int n = Convert.ToInt32("4");
    List<KeyValuePair<int, int>> pairs = new List<KeyValuePair<int, int>>();
    for (int a = 1; a < n; a++)
    {
        for (int b = a + 1; b < n; b++)
        {
            if(n % GCD(a,b) == 0)
            {
                for (int x = 1; x < n; x++)
                {
                    for (int y = 1; y < n; y++)
                    {
                        if ((a * x) + (b * y) == n)
                        {
                            if(!pairs.Contains(new KeyValuePair<int, int>(a, b)))
                                pairs.Add(new KeyValuePair<int, int>(a, b));
                        }
                    }
                }
            }
        }
    }
    
    Console.WriteLine(pairs.Count);
}
    
static int GCD(int a, int b)
{
    return (a % b == 0) ? Math.Abs(b) : GCD(b, a % b);
}