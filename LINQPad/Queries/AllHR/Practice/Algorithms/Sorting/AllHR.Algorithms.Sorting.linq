<Query Kind="Program" />

void Main()
{
	//TutorialIntro();
	//InsertionSort1();
	//InsertionSort2();
	//insertionSort();
	//RunningTimeOfAlgorithms();
	//QuickSort1();
	QuickSort2();
}

private static void QuickSort2()
{
	int n = Convert.ToInt32("6");
	int [] N = Array.ConvertAll("4 5 3 4 7 2".Split(), Int32.Parse);
	int p = N[0];
	Console.WriteLine(string.Join(" ", N));	
	int [] M = QuickSort(N, 0, n - 1);
	Console.WriteLine(string.Join(" ", M));	
}

private static int[] QuickSort(int[] a, int left, int right)
{
	int i = left;
    int j = right;
    double pivotValue = ((left + right) / 2);
    int x = (int)a[int.Parse(pivotValue.ToString())];
	//int x = a[0];
    while (i <= j)
    {
		Console.WriteLine($"###########################################################");
		Console.WriteLine($"i:{i} a[{i}]:{a[i]} x:{x}");
        while (((IComparable)a[i]).CompareTo(x) < 0)
        {
            i++;
			Console.WriteLine($"In Loop 1==> i:{i} j:{j} a[{i}]:{a[i]} x:{x}");
        }
		Console.WriteLine($"i:{i} a[{i}]:{a[i]} x:{x}");
		Console.WriteLine($"###########################################################");
		Console.WriteLine($"j:{j} x:{x} a[{j}]:{a[j]}");
        while (((IComparable)x).CompareTo(a[j]) < 0)
        {
            Console.WriteLine($"In Loop 2==> i:{i} j:{j} x:{x} a[{j}]:{a[j]}");
			j--;
			
        }
		Console.WriteLine($"j:{j} x:{x} a[{j}]:{a[j]}");
		Console.WriteLine($"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
		Console.WriteLine($"i:{i} j:{j}");
        if (i <= j)
        {
            int temp = a[i];
            a[i] = a[j];
            i++;
            a[j] = temp;
            j--;
        }
		Console.WriteLine($"i:{i} j:{j}");
		Console.WriteLine($"OUTOUT: {string.Join(" ", a)}");	
		Console.WriteLine($"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
    }
	Console.WriteLine($"//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
	Console.WriteLine($"i:{i} right:{right} left:{left} j:{j}");
    if (left < j)
    {
        QuickSort(a, left, j);
    }
    if (i < right)
    {
        QuickSort(a, i, right);
    }
	Console.WriteLine($"RETURNING i:{i} right:{right} left:{left} j:{j} a:{string.Join(" ", a)}");
    return a;
}

private static void QuickSort1()
{
	int n = Convert.ToInt32("5");
	int [] N = Array.ConvertAll("4 5 3 7 2".Split(), Int32.Parse);
	int p = N[0];
	int i = 0, k = 0, j = n - 1;
	
	Console.WriteLine(string.Join(" ", N));	
	Console.WriteLine();	
	while(++i < n)
	{
		int candidate = N[i];
		if(candidate < p)
		{
			N[i] = N[k];
			N[k++] = candidate;
		}
		else if(candidate > p)
		{
			N[i] = N[j];
			N[j--] = candidate;
		}
		else if(candidate == p) continue;
		Console.WriteLine(string.Join(" ", N));	
	}
	Console.WriteLine();	
	Console.WriteLine(string.Join(" ", N));	
	
	/*
	int i = 0, k = 0, j = n -1;
	int [] O = new int[n];
	while(++i < n)
	{
		if(N[i] < p)
		{
			O[k++] = N[i];
		}
		else if(N[i] > p)
		{
			O[j--] = N[i];
		}
	}
	if(k == j) O[k] = p;
	else if(k < j) { O[k] = p; O[j] = p; }
	
	Console.WriteLine($"i:{i} k:{k} j:{j}");
	Console.WriteLine(string.Join(" ", O));
	*/
	
	/*
	StringBuilder smaller = new StringBuilder();
	StringBuilder greater = new StringBuilder();
	StringBuilder equal = new StringBuilder();
	equal.Append(p).Append(" ");
	while(++i < n)
	{
		int candidate = N[i];
		if(candidate == p) equal.Append(candidate).Append(" ");
		else if(candidate < p) smaller.Append(candidate).Append(" ");
		else greater.Append(candidate).Append(" ");
	}
	Console.WriteLine($"{smaller.ToString()} {equal.ToString()} {greater.ToString()}"); 
	*/
}

private static void RunningTimeOfAlgorithms()
{
	int n = Convert.ToInt32("5");
	int [] N = Array.ConvertAll("2 1 3 1 2".Split(), Int32.Parse);
	Console.WriteLine(string.Join(" ", N));
	int i = 0;
	int shifts = 0;
	while(++i < n)
	{
		int j = 0;
		while(j < i && N[i] < N[j])
		{
			int temp = N[i];
			for(int k = i; k > j; k--)
			{
				N[k] = N[k-1];
				shifts++;
			}
			N[j] = temp;
			//shifts++;
			j++;
		}
		Console.WriteLine($"shifts:{shifts}");
		Console.WriteLine(string.Join(" ", N));
	}
	Console.WriteLine(shifts);
}

public static void insertionSort() { 
	int [] A = Array.ConvertAll("7 4 3 5 6 2".Split(), Int32.Parse);
    var j = 0; 
    for (var i = 1; i < A.Length; i++) { 
        var value = A[i]; 
        j = i - 1; 
        while (j >= 0 && value < A[j]) { 
            A[j + 1] = A[j];
            j = j - 1; 
        } 
        A[j + 1] = value; 
    } 
    Console.WriteLine(string.Join(" ", A)); 
}
	
// Define other methods and classes here
private static void InsertionSort2()
{
	int n = Convert.ToInt32("6");
	int [] N = Array.ConvertAll("1 4 3 5 6 2".Split(), Int32.Parse);
	
	int i = 0;
	while(++i < n)
	{
		int j = 0;
		while(j < i)
		{
			if(N[i] < N[j])
			{
				int temp = N[i];
				for(int k = i; k > j; k--)
				{
					N[k] = N[k-1];
				}
				N[j] = temp;
				break;
			}
			j++;
		}
		Console.WriteLine(string.Join(" ", N));
	}
}

private static void InsertionSort1()
{
	int n = Convert.ToInt32("5");
	int [] N = Array.ConvertAll("2 4 6 8 3".Split(), Int32.Parse);
	int val = N[n-1];
	int i = n-1;
	while(--i >= 0 && val < N[i]) { N[i+1] = N[i]; Console.WriteLine(string.Join(" ", N)); }
	N[i+1] = val;
	Console.WriteLine(string.Join(" ", N));
}

private static void TutorialIntro()
{
	int V = Convert.ToInt32("4");
	int n = Convert.ToInt32("6");
	int [] N = Array.ConvertAll("1 4 5 7 9 12".Split(), Int32.Parse);
	int i = -1;
	while(++i < n && V != N[i]);
	Console.WriteLine(i);
}