<Query Kind="Program" />

//https://www.codeproject.com/Articles/2247/An-introduction-to-bitwise-operators
/*******************************************************************************************************************************************
Console.WriteLine(10 ^ 10); //Xoring a number with itself results in a 0. So the output 10 ^ 10 = 0
Console.WriteLine(10 >> 1); //1 Right Shift Divides the number by 2 i.e. 10 by 2 so the output is 5
Console.WriteLine(10 << 1); //1 Left Shift Multiplies the number with 2 i.e. 10 by 2 so the output is 20
**********************************************************************************************************************************************/

void Main()
{
	Console.WriteLine(10 ^ 10); //Xoring a number with itself results in a 0. So the output 10 ^ 10 = 0
	Console.WriteLine(10 >> 1); //1 Right Shift Divides the number by 2 i.e. 10 by 2 so the output is 5
	Console.WriteLine(10 << 1); //1 Left Shift Multiplies the number with 2 i.e. 10 by 2 so the output is 20
	Console.WriteLine(1  << 10); //Left Shifting 1 X number of times results in a number 2EX i.e. 2E10 = 1024 = 1000000000
	Console.WriteLine((int)'1');
	//Console.WriteLine(MaxConsecutiveOneInBinaryNumber(24));
}

void Misc()
{
	int a = 60;            /* 60 = 0011 1100 */ 
	int b = 13;            /* 13 = 0000 1101 */
	int c = 0; 
	 
	c = a & b;             /* 12 = 0000 1100 */ 
	Console.WriteLine("Line 1 - Value of c is {0}", c );
	
	c = a | b;             /* 61 = 0011 1101 */
	Console.WriteLine("Line 2 - Value of c is {0}", c);
	
	c = a ^ b;             /* 49 = 0011 0001 */
	Console.WriteLine("Line 3 - Value of c is {0}", c);
	
	c = ~a;                /*-61 = 1100 0011 */
	Console.WriteLine("Line 4 - Value of c is {0}", c);
	
	c = a << 2;      /* 240 = 1111 0000 */
	Console.WriteLine("Line 5 - Value of c is {0}", c);
	
	c = a >> 2;      /* 15 = 0000 1111 */
	Console.WriteLine("Line 6 - Value of c is {0}", c);
	Console.ReadLine();

	Console.WriteLine($"{Convert.ToInt32("00011", 2)}");
	Console.WriteLine($"{Convert.ToInt32("00101", 2)}");
	Console.WriteLine($"{Convert.ToInt32("01001", 2)}");
	Console.WriteLine($"{Convert.ToInt32("10001", 2)}");
	Console.WriteLine($"{Convert.ToInt32("10010", 2)}");
	Console.WriteLine($"{Convert.ToInt32("10100", 2)}");
	Console.WriteLine($"{Convert.ToInt32("11000", 2)}");
	Console.WriteLine($"{Convert.ToString(1024, 2)}");
}

// Define other methods and classes here
void BitArrayDemo()
{
	BitArray bitArray = new BitArray(32);
    // Set three bits to 1.
    bitArray[3] = true;     // You can set the bits with the indexer.
    bitArray[5] = true;
    bitArray.Set(10, true); // You can set the bits with Set.
	Console.WriteLine(bitArray);		
}

void LeftShift()
{
	Console.WriteLine(10 << 2);
	Console.WriteLine(10 << 3);
	Console.WriteLine(1 << 3);
	
	int num = 10;
	while(num > 0)
	{
		Console.WriteLine($"num:{Convert.ToString(num,2)} num << 1:{ Convert.ToString(num << 1,2) } num >> 1:{ Convert.ToString(num >> 1,2) } 1 << num:{1 << num} {Convert.ToString(num,2)}");
		num = num << 1;
		Console.WriteLine($"num:{num} {Convert.ToString(num,2)}");
		Console.WriteLine();
	}
}

void RightShift()
{
	Console.WriteLine(10 >> 2);
	Console.WriteLine(10 >> 3);
	
	string numS = "1010";
	while(numS != "0")
	{
		int n = Convert.ToInt32(numS,2);
		Console.WriteLine($"numS:{numS} {Convert.ToInt32(numS,2)}");
		n = n >> 1;
		numS = Convert.ToString(n,2);
		Console.WriteLine($"numS:{numS} {Convert.ToInt32(numS,2)}");
		Console.WriteLine();
	}

}

void And()
{
	Console.WriteLine(1 & 1);
}

void OR()
{
}

void XOR()
{
	//*******************************************https://www.hackerrank.com/topics/bit-manipulation*******************************************//
	Console.WriteLine(Convert.ToInt32('H'));
	Console.WriteLine(Convert.ToString(Convert.ToInt32('H'),2));
	foreach(char c in "HackerRank")
	{
		//Console.WriteLine($"{c} {Convert.ToString(Convert.ToInt32(c),2)}");
		Console.WriteLine($"{c} OR 8675309 => {Convert.ToString(Convert.ToInt32(c),2)} { Convert.ToString(8675309,2) } => {Convert.ToString(Convert.ToInt32(c) | 8675309,2)} => {Convert.ToInt32(c) | 8675309}");
	}
		Console.WriteLine();
	
	
	"HackerRank".ToList().ForEach(c => {Console.WriteLine($"{c} XOR 8675309 => {Convert.ToString(Convert.ToInt32(c),2)} { Convert.ToString(8675309,2) } => {Convert.ToString(Convert.ToInt32(c) ^ 8675309,2)} => {Convert.ToInt32(c) ^ 8675309}");});
	return;
	//*******************************************https://www.hackerrank.com/topics/bit-manipulation*******************************************//
}

void OnesComplementOrInversionOperator()
{

}

int FindXorSumOfAllArrayItems(List<int> intArr)
{	
	if(intArr == null)	intArr = Enumerable.Range(1,20).ToList();
	int xorSum = 1;
	intArr.ForEach(x => {
		if(x == 1) xorSum = x;
		else xorSum = xorSum ^ x;
		Console.WriteLine($"{x} {xorSum}");
	});
	
	Console.WriteLine("XorSum: " + xorSum);
	return xorSum;
}

int MaxConsecutiveOneInBinaryNumber(int number) 
{
	int count = 0;
	int max = 0;
	while (number != 0) {
	  if ((number & 1) == 1) {
	    count++;
	  } 
	  else 
	  {
	    max = Math.Max(count, max);
	    count = 0;
	  }
	  number = number >> 1;
	}
	return Math.Max(count, max);
}