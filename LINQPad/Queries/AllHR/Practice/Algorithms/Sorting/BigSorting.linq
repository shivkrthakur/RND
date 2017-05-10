<Query Kind="Program" />

void Main()
{
	BigSortingEditorial();
	Console.WriteLine();
	BigSortingUsingInBuiltQuickSortOP();
	Console.WriteLine();
	BigSortingUsingQuickSortInPlace();
	Console.WriteLine();
	BigSortingUsingQuickSortOP();
	Console.WriteLine();
	BigSortingUsingInsertionSort();
	Console.WriteLine();
	BigSortingUsingInsertionSortOP();
}

// Define other methods and classes here
void BigSortingEditorial()
{
	int n = Convert.ToInt32("6");
	string [] S = { "2", "1", "3", "10", "3", "5" };
	Console.WriteLine(string.Join(" ", S));
  	Array.Sort(S, (left, right) => {
        if (left.Length != right.Length) {
            return left.Length - right.Length;
        } else {
            return left.CompareTo(right);
        }
    });
	Console.WriteLine(string.Join(" ", S));
}

void BigSortingUsingInsertionSort()
{
	int n = Convert.ToInt32("6");
	string [] S = { "2", "1", "3", "10", "3", "5" };
	int [] N = Array.ConvertAll(S, Int32.Parse);
	Console.WriteLine(string.Join(" ", N));
	for(int i = 1; i < n; i++)
	{
		int j = i;
		while(j > 0 && N[j] < N[j-1])
		{
			int temp = N[j];
			N[j] = N[j-1];
			N[j-1] = temp;
			j--;
		}
	}
	Console.WriteLine(string.Join(" ", N));
}

void BigSortingUsingInsertionSortOP()
{
	int n = Convert.ToInt32("6");
	string [] S = { "2", "1", "3", "10", "3", "5" };
	Console.WriteLine(string.Join(" ", S));
	for(int i = 1; i < n; i++)
	{
		int j = i;
		while(j > 0 && (S[j].Length < S[j-1].Length || (S[j].Length == S[j-1].Length && string.Compare(S[j],S[j-1]) == -1)))
		{
			string temp = S[j];
			S[j] = S[j-1];
			S[j-1] = temp;
			j--;
		}
	}
	Console.WriteLine(string.Join(" ", S));
}

void BigSortingUsingInBuiltQuickSort()
{
	int n = Convert.ToInt32("6");
	string [] S = { "2", "1", "3", "10", "3", "5" };
	Console.WriteLine(string.Join(" ", S));
	Array.Sort(S, (x,y) => {
		if((x.Length < y.Length || (x.Length == y.Length && (string.Compare(x,y) == -1 || string.Compare(x,y) == 0)))) return -1;
		else return 1;
	});
	Console.WriteLine(string.Join(" ", S));
}

void BigSortingUsingInBuiltQuickSortOP()
{
	int n = Convert.ToInt32("6");
	string [] S = { "2", "1", "3", "10", "3", "5" };
	Console.WriteLine(string.Join(" ", S));
	Array.Sort(S, StringAsIntegerCompare);
	Console.WriteLine(string.Join(" ", S));
}

int StringAsIntegerCompare(String s1, String s2)
{
    if(s1.Length > s2.Length) return 1;
    if(s1.Length < s2.Length) return -1;
    for(int i = 0; i < s1.Length; i++)
    {
        if((int)s1[i] > (int)s2[i]) return 1;
        if((int)s1[i] < (int)s2[i]) return -1;
    }
    return 0;
}

void BigSortingUsingQuickSortOP()
{
	int n = Convert.ToInt32("6");
	string [] S = { "2", "1", "3", "10", "3", "5" };
	Console.WriteLine(string.Join(" ", S));
	Console.WriteLine(string.Join(" ", QuickSort(S.ToList())));
}

List<string> QuickSort(List<string> inputArr)
{
	if(inputArr.Count <= 1) return inputArr;
	List<string> left = new List<string>();
	List<string> equal = new List<string>();
	List<string> right = new List<string>();
	string pivot = inputArr[0];
	equal.Add(pivot);
	for(int i = 1; i < inputArr.Count; i++)
	{
		string tgtVal = inputArr[i];
		int tLen = tgtVal.Length, pLen = pivot.Length;
		if((tLen < pLen || (tLen == pLen && string.Compare(tgtVal, pivot) == -1))) left.Add(tgtVal);
		else if (tLen == pLen && string.Compare(tgtVal, pivot) == 0) 	equal.Add(tgtVal);
		else right.Add(tgtVal);
	}
//	Console.WriteLine(left);
//	Console.WriteLine(equal);
//	Console.WriteLine(right);
	left = QuickSort(left);
	left.AddRange(equal);
	left.AddRange(QuickSort(right));
	return left;
}

void BigSortingUsingQuickSortInPlace()
{
	int n = Convert.ToInt32("6");
	string [] S = { "2", "1", "3", "10", "3", "5" };
	Console.WriteLine(string.Join(" ", S));
	QuickSortInPlace(S, 0, n -1);
	Console.WriteLine(string.Join(" ", S));
}

void QuickSortInPlace(string [] inputArr, int left, int right)
{
	if(left < right)
	{
		int p = Partition(inputArr, left, right);
		QuickSortInPlace(inputArr, left, p - 1);
		QuickSortInPlace(inputArr, p + 1, right);
	}
}

int Partition(string [] inputArr, int left, int right)
{
	string pivot = inputArr[right];
	int i = left - 1;
	while(left < right)
	{
		string tgtVal = inputArr[left];
		int tLen = tgtVal.Length;
		int pLen = pivot.Length;
		
		if((tLen < pLen || (tLen == pLen && string.Compare(tgtVal, pivot) == -1)) || (tLen == pLen && string.Compare(tgtVal, pivot) == 0)) 
		{
			i++;
			Swap(inputArr, i, left);	
		}
		left++;
	}
	Swap(inputArr, i + 1, right);
	return i + 1;
}

void Swap(String [] inputArr, int left, int right)
{
	string temp = inputArr[left];
	inputArr[left] = inputArr[right];
	inputArr[right] = temp;
}