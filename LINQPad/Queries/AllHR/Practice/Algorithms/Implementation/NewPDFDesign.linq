<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	NewPDFDesign();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void NewPDFDesign()
{
 	int[] h = new int[] {1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};
    string word = "abc";
    //Console.WriteLine(String.Join(",",h));
	//char[] alphabets = Enumerable.Range('a',26).Select(x => (char)x).ToArray();
	//Console.WriteLine(String.Join(",",alphabets));
	int width = 0, height = 0, length = word.Length;
	for(int i = 0; i < length; i++)
	{
		//int tempH = h[((int)word[i] - 97)];
		//if(height < tempH) height = tempH;
		height = Math.Max(height, h[((int)word[i] - (int)'a')]);
	}
	Console.WriteLine(length * 1 * height);
}