<Query Kind="Program" />

void Main()
{
	BestDivisor();
}

// Define other methods and classes here
static void BestDivisor() 
{
    int n = Convert.ToInt32("12");
    int counter = 0;
    Dictionary<int, int> dictResults = new Dictionary<int,int>();
    while(counter++ <= n)
    {
        if((n % counter) == 0)
        {
           int sumOfDigits = 0, innerCounter = counter;
           while(innerCounter != 0)
           {
              sumOfDigits += innerCounter % 10;
              innerCounter /= 10;
           }
           dictResults.Add(counter, sumOfDigits); 
        }
    }
    
    int result = 0;
    if(dictResults.Count > 0)
    {
        var valuesList = dictResults.Select(x => x.Value).OrderByDescending(x => x).ToList();
        int greatestValue = valuesList[0];
        result = Convert.ToInt32(dictResults.Where(x => x.Value == greatestValue).Select(x => x.Key).OrderBy(x => x).ToList()[0]);
    }
    Console.WriteLine(result);
}
