<Query Kind="Program" />

void Main()
{
	OneDimensionalArray();
	//TwoDimensionalArray();
	//CharArrayManipulation();
}

// Define other methods and classes here
void OneDimensionalArray()
{
    var products = new[] { new { Name = "Apple", Category = "Fruit", Price = 10M }
		, new { Name = "Orange", Category = "Fruit", Price = 18M }
		, new { Name = "Banana", Category = "Fruit", Price = 12M }
		, new { Name = "Peach", Category = "Fruit", Price = 5M }
	};
	Console.WriteLine(products);
	//Array.Sort(products);
	//Console.WriteLine(products);
	Array.Sort(products, (item1, item2) => { return Comparer<decimal>.Default.Compare(item1.Price, item2.Price); });
	Console.WriteLine(products);
	Console.WriteLine(products.
	return;

	int [] input = "3 3 2 1 3".Split().Select(Int32.Parse).ToArray();
	int count = input.Where(x => x == 3).ToArray().Count();
	Console.WriteLine(count);
	
	int [] at = new[]{ 0, -1, 2, 1 };
	var result1 = at.Where(x => (x <= 0)).ToArray().Length;
	Console.WriteLine(result1);
	var result2 = at.Select(x => (x += 1)).ToArray();
	Console.WriteLine(result2);
	var result3 = at.Select(x => (x <= 1)).ToArray(); //--> Returns a boolean array
	Console.WriteLine(result3);
	
	IEnumerable<int> list = Enumerable.Range(1,3);
	Console.WriteLine(list);
	Console.WriteLine(list.Select(x => new int [] { x }));
	Console.WriteLine(list.Select(x => new int [] { x }).Select(y => list.Where(p => !y.Contains(p))));
	Console.WriteLine(list.Select(x => new int [] { x }).SelectMany(y => list.Where(p => !y.Contains(p)), (p1, p2) => p1.Concat(new int [] {p2})));
	Console.WriteLine(list.Select(x => new int [] { x }).SelectMany(y => list.Where(p => !y.Contains(p)), (p1, p2) => (new int [] {p2}).Concat(p1)));
}

void CharArrayManipulation()
{
	string input = "aaa";
	int count = input.Take(2).Where(x => x == 'a').ToArray().Count();
	Console.WriteLine(count);
	
	char[] ip1 = Enumerable.Repeat((char)79,10).ToArray();
	char[] ip2 = Enumerable.Range((char)97,26).ToString().ToCharArray();
	Console.WriteLine(Enumerable.Range(97,26).Select(x => (char)x).ToArray());
	Console.WriteLine(Enumerable.Range(65,26).Select(x => (char)x).ToArray());
	Console.WriteLine(Enumerable.Range('a','z' - 'a').Select(i => (char)i).ToArray());
	
	Console.WriteLine((int)'a');
	Console.WriteLine((int)'z');
	char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
	char[] alphabetsA = Enumerable.Range(97,122).Select(i => (char)i).ToArray();
	char[] alphabetsB = Enumerable.Range(97,26).Select(i => (char)i).ToArray();
	char[] alphabetsC = Enumerable.Range('a',26).Select(i => (char)i).ToArray();
	Console.WriteLine($"Count:{alphabets.Count()} {String.Join(" ", alphabets)}");
	int[] myIntArray = Enumerable.Repeat(-1, 20).ToArray();
}

void TwoDimensionalArray()
{
	//Jagged Array below
	var array = Enumerable.Range(0, 10).Select(x => Enumerable.Repeat('x', 10).ToArray()).ToArray();
	Console.WriteLine(array);
	return;
	var orig2D = new int[][] {
						new int []{ 1, 2, 3, 4 }
					, 	new int []{ 5, 6, 7, 8 } 
					, 	new int []{ 9, 10, 11, 12 } 
				};
	Console.WriteLine(orig2D);
	var copy2D = orig2D.Select(a => a.ToArray()).ToArray();
	Console.WriteLine(copy2D);
}