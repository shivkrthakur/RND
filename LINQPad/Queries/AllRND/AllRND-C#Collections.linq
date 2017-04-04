<Query Kind="Program" />

void Main()
{
	Queue();
	return;
	List();
	Misc();
	Dictionary();
}

// Define other methods and classes here
void Misc()
{
	List<string> names = new List<string>(){"Tthis-is-a-test"};
	Console.WriteLine(names.OrderBy(s => s.Split('-')[0]).ThenBy(s => s.Split('-')[1]));
}

void Queue()
{
	Queue queue = new Queue();
	queue.Enqueue(1);
	queue.Enqueue(2);
	queue.Enqueue(3);
	queue.Enqueue(4);
	
	while(queue.Count > 0)
	{
		Console.WriteLine(queue.Dequeue());
	}
	
	Console.WriteLine();
	Queue<int> someQueue = new Queue<int>();
	for(int  x = 0; x < 5; x++) someQueue.Enqueue(x);
	Console.WriteLine(someQueue);
	Console.WriteLine(string.Join(" ",someQueue));

}

void List()
{
	List<int> someList = new List<int>(){ 1, 3, 4, 4 };
	someList = someList.Select(x => x * 2).ToList();
	Console.WriteLine(someList);	
}


void Dictionary()
{
	Dictionary<char,int> charsDict = new Dictionary<char,int>();
	var top5 = charsDict.OrderByDescending(p1 => p1.Value).Take(5);
	var bottom5 = charsDict.OrderBy(p2 => p2.Value).Take(5);
	var top5Dict = charsDict.OrderByDescending(p3 => p3.Value).Take(5).ToDictionary(p3 => p3.Key, p3 => p3.Value);
	Console.WriteLine(charsDict.OrderBy(x => x.Value));

	Dictionary<int,int> input = new Dictionary<int,int>() { {1,10}, {2,20}, {3,30}, {4,40}, {5,50} };
	Console.WriteLine(input.Values.Max());
	Console.WriteLine(input.Keys.Max());
}

void KeyValuePair()
{
	KeyValuePair<int,int> pair1 = new KeyValuePair<int,int>(1,2);
	KeyValuePair<int,int> pair2 = new KeyValuePair<int,int>(2,3);
	KeyValuePair<int,int> pair3 = new KeyValuePair<int,int>(3,4);
	List<KeyValuePair<int,int>> list = new List<KeyValuePair<int,int>>();
	list.Add(pair1);
	list.Add(pair2);
	list.Add(pair3);
	var pair = list.Select(x => x).FirstOrDefault();
	Console.WriteLine(pair);
	Console.WriteLine(list);
}

void Tuple()
{
	var a = new Tuple<int, int>(1, 2);
	var aType = a.GetType();
	var numberOfGenericParameters = aType.GetGenericArguments().Length;
}

void Enumerables()
{
	var temp1 = Enumerable.Range(1,3).ToList();
	Console.WriteLine(temp1);
	
	temp1.AddRange(temp1);
	Console.WriteLine(temp1);
	
	var temp2 = Enumerable.Range(4,3);
	Console.WriteLine(temp2);
	temp2.ToList().AddRange(temp1);
	Console.WriteLine(temp2);
	
	Random rand = new Random();
	var results = Enumerable.Range(0, rand.Next(100)).Select(r => rand.Next(10)).ToList();
							
	int [] intArr = Enumerable.Range(1,3).OrderByDescending(x => x).ToArray();
	Console.WriteLine(intArr);
	Array.Sort(intArr,1,2);
	Console.WriteLine(intArr);
	
	int[] myIntArray = Enumerable.Repeat(-1, 20).ToArray();
	Console.WriteLine(myIntArray);
}