<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Collections</Namespace>
</Query>

public static void Main(string[] args)
{
	/*
	string searchString = ".exts";
    string[] sourceArray = new string[] { "Test.pdf","Test.exts", "Test.mvc", "Test.ndf", "Test.doc"  };
	string result = DoesExtensionExists(searchString, sourceArray);
	
    Console.WriteLine(result);
	Console.WriteLine();
	*/
	
	/*
	string[] strArray = CopyArray(sourceArray);
	Console.WriteLine("Copied array ouputted below");
	for(int i = 0; i < strArray.Length; i++)
	{
		Console.WriteLine(strArray[i]);
	}*/
	
	/*
	Console.WriteLine();
	Console.WriteLine(ReverseString("This is a Test!"));
	Console.WriteLine(ReverseStringUsingRecursion("This is a Test!"));
	*/
	
	
	int [] srcArray = new int[] { 2, 43, 23, 96, 34 };
	int [] trgArray;
	
	Console.WriteLine("Intput:" + srcArray.ExtendToString());
	//trgArray = BubbleSort(srcArray);
	trgArray = SelectionSort(srcArray);
	Console.WriteLine("Output:" + trgArray.ExtendToString());
}



public static int[] SelectionSort(int [] srcArray, int? debug = null)
{
	//Console.WriteLine(srcArray.ExtendToString());
	for(int i = 0; i < srcArray.Length; i++)
	{
		int min = i;
		for(int j = i + 1; j < srcArray.Length; j++)
		{
			//Console.WriteLine($"Inside For loop. Source Index: {i}, Source value: {srcArray[i]} , Target Index: {j} Target value: {srcArray[j]}");
			if(srcArray[j] < srcArray[min])
			{
				//Console.WriteLine($"This target index {j} value {srcArray[j]} is smaller than source index: {i} value: {srcArray[i]}. min Index value:{j}");
				min = j;			
			}
		}
		
		if(min != i)
		{
			int temp = srcArray[i];
			srcArray[i] = srcArray[min];
			srcArray[min] = temp;
			Console.Write("Update:" + srcArray.ExtendToString());
			Console.WriteLine($"\t\tMin Index:{min}");
		}
		
		//Console.WriteLine();	
	}
	return srcArray;
}
		
public static int[] BubbleSort(int [] srcArray, int? debug = null)
{
	var arrayToSort = srcArray;
	int iterationsCount = 0;
	///*
	for(int i = 0; i < srcArray.Length; i++)
	{
		for(int j = i + 1; j < srcArray.Length; j++)
		{
			Console.WriteLine($"i: {i}, j:{j}");
			if(srcArray[i] > srcArray[j])
			{
				//Console.WriteLine($"Inside For loop. Index: {i}, source value: {srcArray[i]} , target value: {srcArray[i+1]}");
				int temp = srcArray[i];
				srcArray[i] = srcArray[j];
				srcArray[j] = temp;
				
			}
			iterationsCount++;
		}
	}
	Console.WriteLine($"IterationsCount = {iterationsCount}");//*/
	
	//Bubble Sort Logic from http://www.codeproject.com/Articles/132757/Visualization-and-Comparison-of-sorting-algorithms#BubbleSort
	int iterationsCount2 = 0;
	int n = arrayToSort.Length - 1;
	for (int i = 0; i < n; i++)
    {
        for (int j = n; j > i; j--)
        {
			Console.WriteLine($"i: {i}, j:{j}");
            if (((IComparable)arrayToSort[j - 1]).CompareTo(arrayToSort[j]) > 0)
            {
                object temp = arrayToSort[j - 1];
                arrayToSort[j - 1] = arrayToSort[j];
                arrayToSort[j] = (int)temp;
            }
			iterationsCount2++;
        }
    }
	Console.WriteLine($"iterationsCount2 = {iterationsCount2}");
	/*
	for(int i = 0; i < srcArray.Length -1; i++)
	{
		if(srcArray[i] > srcArray[i+1])
		{
			Console.WriteLine($"Inside For loop. Index: {i}, source value: {srcArray[i]} , target value: {srcArray[i+1]}");
			int temp = srcArray[i+1];
			srcArray[i+1] = srcArray[i];
			srcArray[i] = temp;
		}
	}
	
	for(int i = 0; i < srcArray.Length -1; i++)
	{
		if(srcArray[i] > srcArray[i+1])
		{
			Console.WriteLine($"Inside For loop. Index: {i}, source value: {srcArray[i]} , target value: {srcArray[i+1]}");
			int temp = srcArray[i+1];
			srcArray[i+1] = srcArray[i];
			srcArray[i] = temp;
		}
	}
	*/
	return srcArray;
}

public static string ReverseString(string inputString)
{
	string trgString = string.Empty;
	
	for(int i = 0, j = inputString.Length - 1; i < inputString.Length; i++, j--)
	{
		trgString += inputString[j];
	}
	
	return trgString;
}


public static string ReverseStringUsingRecursion(string inputString)
{
	string trgString = string.Empty;
	int i = inputString.Length;
	
	if(i == 0) return string.Empty;
	trgString = inputString[inputString.Length-1] + ReverseStringUsingRecursion(inputString.Substring(0,--i));
	return trgString;
}

public static string DoesExtensionExists(string searchString, string[] sourceArray)
{
    for (int i = 0; i < 5; i++)
    {
       //Console.WriteLine(Path.GetExtension(sourceArray[i]));
	   Console.Write(string.Compare(Path.GetExtension(sourceArray[i]), searchString) == 0);
	   Console.WriteLine($"\t {Path.GetExtension(sourceArray[i])} , \t  {searchString} ");
	   if (sourceArray[i].Contains(searchString))
        {
            return sourceArray[i];
        }
    }
	return "String not found";	
}

public bool DoesExtensionExist(string [] fileNames, string extension)
{
      int i = 0;
      for (i = 0; i < fileNames.Length; i++)
         if (String.Compare(Path.GetExtension(fileNames[i]), extension, true) == 0)
            return true;

      return false;   // If we reach here, we didn't find the extension
}

public static string[] CopyArray(string [] srcArray)
{
	string[] targetArray = new string[srcArray.Length];
	srcArray.CopyTo(targetArray, 0);
	
	/*
	for(int i = 0; i < srcArray.Length; i++)
	{
		targetArray[i] = srcArray[i];
	}
	*/
	return targetArray;
}

public static class MyExtensions 
{
	public static string ExtendToString(this int [] array)
	{
		string valuesString = string.Empty;
		foreach(var r in array)
		{
			valuesString = valuesString  + ',' + r;
		}
		
		return valuesString.Substring(1,valuesString.Length-1);
	}
}