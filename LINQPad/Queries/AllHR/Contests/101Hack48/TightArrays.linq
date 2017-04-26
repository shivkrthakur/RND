<Query Kind="Program" />

void Main()
{
	TightArrays();
}

// Define other methods and classes here
void TightArrays()
{
	//int [] abc = Array.ConvertAll("5 7 11".Split(), Int32.Parse);
	//int [] abc = Array.ConvertAll("3 1 2".Split(), Int32.Parse);
	int [] abc = Array.ConvertAll("5 5 6".Split(), Int32.Parse);
	int a = abc[0], b = abc[1], c = abc[2];
	
	int d1 = Math.Abs(a - b);
	int d2 = Math.Abs(b - c);
	
	Console.WriteLine(d1);
	Console.WriteLine(d2);
	Console.WriteLine(d1 + d2 + 1);
}