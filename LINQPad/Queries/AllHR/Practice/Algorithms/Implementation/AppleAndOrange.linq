<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	AppleAndOrange();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void AppleAndOrange()
{
 	string[] tokens_s = "7 11".Split();//Console.ReadLine().Split(' ');
    int s = Convert.ToInt32(tokens_s[0]);
    int t = Convert.ToInt32(tokens_s[1]);
    string[] tokens_a = "5 15".Split();//Console.ReadLine().Split(' ');
    int a = Convert.ToInt32(tokens_a[0]);
    int b = Convert.ToInt32(tokens_a[1]);
    string[] tokens_m = "3 2".Split();//Console.ReadLine().Split(' ');
    int m = Convert.ToInt32(tokens_m[0]);
    int n = Convert.ToInt32(tokens_m[1]);
    string[] apple_temp = "-2 2 1".Split();//Console.ReadLine().Split(' ');
    int[] apple = Array.ConvertAll(apple_temp,Int32.Parse);
    string[] orange_temp = "5 -6".Split();//Console.ReadLine().Split(' ');
    int[] orange = Array.ConvertAll(orange_temp,Int32.Parse);
	
	int countA = 0, countO = 0;
	
	for(int i = 0; i < m; i++)
	{
		long sum = a + apple[i];
		//Console.WriteLine($"Sum:{sum}");
		if((a + apple[i]) >= s) countA++;
	}
	Console.WriteLine(countA);
	
	for(int i = 0; i < n; i++)
	{
		long sum = b + orange[i];
		//Console.WriteLine($"Sum:{sum}");
		if((sum) <= t && (sum) >= s) countO++;
	}
	Console.WriteLine(countO);
}