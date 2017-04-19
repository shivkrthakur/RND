<Query Kind="Program" />

void Main()
{
	Twins();
}

// Define other methods and classes here
void Twins()
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
    int[] inputArr = Array.ConvertAll("3 13".Split(),Int32.Parse);
    int n = inputArr[0], m = inputArr[1];
    int prevNo = 0, counter = 0;
    
    if(n > m) Console.WriteLine(0);
    int curNo = (n != 2 && n % 2 == 0 ) ? n + 1 : n;

    for(; curNo <= m; curNo += 2)
    {
        if (curNo == 3 || curNo == 5 || curNo == 7 || ((curNo % 5 != 0) && (curNo % 7 != 0) && (SumOfDigits(curNo) % 3 != 0)))
        {
            if(IsPrime(curNo))   
            {
                if((prevNo != 0) && (Math.Abs(curNo - prevNo) == 2))
                {
                    counter++;
                }
                prevNo = curNo;
            }
        }
    }
    
    Console.WriteLine(counter);
}
    
public static bool IsPrime(int number)
{
    if(number > 1 && (number & 1) != 0)
    {
        int limit = (int)Math.Sqrt(number);
        for(int i = 3; i <= limit; i += 2)
        {
           if((number % i) == 0) return false;
        }
        return true;
    }
    return (number == 2);
}

public static int SumOfDigits(int x)
{
    int sum = 0;
    while(x != 0)
    {
        sum += x % 10;
        x = x / 10;
    }
    return sum;
}

