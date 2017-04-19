<Query Kind="Program" />

static void Main(String[] args) 
{
	ArmyGame();
}

static void ArmyGame()
{
    string[] tokens_n = "2 2".Split(' ');
    int n = Convert.ToInt32(tokens_n[0]);
    int m = Convert.ToInt32(tokens_n[1]);
    int output = 0;
    
    if(n == 1 && m == 1)
    {
        output = 1;
    }
    else if((n % 2 == 0) && (m % 2 == 0))
    {
        output = (n*m)/4;
    }
    else if((n % 2 == 0) && (m % 2 != 0))
    {
        output = ((n * (m - 1))/4) + n/2;
    }
    else if((n % 2 != 0) && (m % 2 == 0))
    {
        output = (((n - 1) * m)/4) + m/2;
    }
    else 
    {
        output = (((n - 1) * (m-1))/4) + n/2 + m/2 + 1;
    }
    
    Console.WriteLine(output);
}