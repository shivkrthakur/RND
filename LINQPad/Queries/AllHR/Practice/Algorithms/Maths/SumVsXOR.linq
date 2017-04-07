<Query Kind="Program" />

void Main()
{
	SumVsXOR();
	SumVsXOROptimized1();
	SumVsXOROptimized2();
	SumVsXOROptimizedFS();
}

// Define other methods and classes here
void SumVsXOR()
{
	long n = Convert.ToInt32("5");
    int count = 0;
    for(int i = 0; i <= n; i++)
    {
        if((i + n) == (i ^ n)) count++;
    }
    Console.WriteLine(count);
}

void SumVsXOROptimized1()
{
    long n = Convert.ToInt64("0");
    string ns = n == 0 ? string.Empty : Convert.ToString(n,2);
    int count = 0;
	//Console.WriteLine($"ns:{ns} count:{count}");
    for(int i = 0; i < ns.Length; i++)
    {
        if(ns[i] == '0') count++;
    }
    Console.WriteLine(Math.Pow(2,count));
}

void SumVsXOROptimized2()
{
    long n = Convert.ToInt64("5");
	int count = 0;
	while(n > 0)
	{
		if((n % 2) == 0) count++;
		n = n /2;
	}
    Console.WriteLine(Math.Pow(2,count));
}

void SumVsXOROptimizedFS()
{
    long n = Convert.ToInt64(Console.ReadLine());
    int count = (n == 0) ? 0 : Convert.ToString(n,2).Count(x => x == '0');
    Console.WriteLine(Math.Pow(2,count));
}
/* EDITORIAL */
/*
XOR operation is equivalent to adding two bits igoring the carry. Let's see the truth table for XOR:
0 ^ 0 = 0
0 ^ 1 = 1
1 ^ 0 = 1
1 ^ 1 = 0
You can see that XOR behaves exactly like add operation except in one case when A = 1 AND B = 1.
From this observation, you can find out when x + n  = x ^ n  will be true. If for any i, the ith bit of x and n are both 1,
we have to take care of carry bit during adding the number and the equation won't be true.
Take the binary representation of x and count the number of zeros(ignoring leading zeros). If the ith bit of x is 1, 
you must place a 1 in the ith bit of n. Otherwise, you can put either 0 or 1. So if the number of zero in binary is b, the answer is 2Eb.
*/
/*
http://www.geeksforgeeks.org/add-two-numbers-without-using-arithmetic-operators/
http://www.geeksforgeeks.org/equal-sum-xor/

Look at the truth table of XOR:
0 ^ 0 = 0
0 ^ 1 = 1
1 ^ 0 = 1
1 ^ 1 = 0
Now look at the truth table of addition in binary:
0 + 0 = 0 (carry 0)
0 + 1 = 1 (carry 0)
1 + 0 = 1 (carry 0)
1 + 1 = 0 WITH CARRY 1 (=10)
This means the addition between two digits in binary is the XOR of the two bits, and the carry is the AND of the bits.
If you look for two operands A, B where A ^ B = A + B, you need that you never have a carry when summing them. 
This happens if it NEVER happens that the i-th bit of A and the i-th bit of B are both 1. 
So given the operand A, all the bits in A which are 1 must be 0 in B. 
They are fixed bits and you have no choice for them. But all other bits in B are free and you can set them to 1 or 0 
and the equation will keep being true. To count all possible values of B, you must then count the 0's in A 
(i.e. the number of free bits in B) and calculate 2 to the power of the free bits.
*/

