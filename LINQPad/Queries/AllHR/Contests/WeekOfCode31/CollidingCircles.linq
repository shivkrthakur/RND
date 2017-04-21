<Query Kind="Program" />

void Main()
{
//	int [] NK = Array.ConvertAll("5 2".Split(),Int32.Parse);
//	int [] N = Array.ConvertAll("1 2 3 4 5".Split(),Int32.Parse);

//	int [] NK = Array.ConvertAll("3 1".Split(),Int32.Parse);
//	int [] N = Array.ConvertAll("1 2 3".Split(),Int32.Parse);

//	int [] NK = Array.ConvertAll("3 1".Split(),Int32.Parse);
//	int [] N = Array.ConvertAll("1 2 3".Split(),Int32.Parse);

//	int [] NK = Array.ConvertAll("5 3".Split(),Int32.Parse);
//	int [] N = Array.ConvertAll("1 2 3 4 5".Split(),Int32.Parse);

	int [] NK = Array.ConvertAll("4 2".Split(),Int32.Parse);
	int [] N = Array.ConvertAll("1 2 3 4".Split(),Int32.Parse);
 
	int n = NK[0], K = NK[1];
	int count = 0;
    int [] data=new int[K + 1];
	int []indexes = new int[K + 1];
    double totalArea = FindCombinations(N, data, 0, n-1, 0, K + 1, indexes, ref count);
	//Console.WriteLine($"count:{count} totalArea:{totalArea} output:{totalArea/count}");
	Console.WriteLine(totalArea/count);

}

static double FindCombinations(int [] inputArr, int [] data, int start, int end, int index, int r, int [] indexes, ref int count)
{
    if (index == r)
    {
		count++;
		int sum = 0;
        for (int j = 0; j < r; j++) sum += data[j];
		double area = Math.PI * Math.Pow(sum,2);
		
		int y = 0;
		for(int x = 0; x <= end; x++)
		{
			if(y < r && x == indexes[y]) { y++; continue; }
			double temp = Math.PI * Math.Pow(inputArr[x],2);
			area += temp;
		}
        return area;
    }

	double areaSum = 0.0;
    for (int i=start; i<=end && end-i+1 >= r-index; i++)
    {
		data[index] = inputArr[i];
		indexes[index] = i;
        areaSum += FindCombinations(inputArr, data, i + 1, end, index + 1, r, indexes, ref count);
    }
	return areaSum;
}