<Query Kind="Statements" />

Console.WriteLine(10 << 2);
Console.WriteLine(10 >> 2);

Console.WriteLine(10 << 3);
Console.WriteLine(10 >> 3);

Console.WriteLine(1 & 1);
Console.WriteLine(Convert.ToString(255,2));
return;

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

List<int> intArr = Enumerable.Range(1,20).ToList();
int xorSum = 1;
intArr.ForEach(x => {
	if(x == 1) xorSum = x;
	else xorSum = xorSum ^ x;
	Console.WriteLine($"{x} {xorSum}");
});

Console.WriteLine("XorSum: " + xorSum);

//*******************************************************************************************************************************************//
Console.WriteLine(10 ^ 10); /*Xoring a number with itself results in a 0. So the output 10 ^ 10 = 0*/
Console.WriteLine(10 >> 1); /*Divides the number i.e. 10 by 2 so the output is 5*/
Console.WriteLine(10 << 1); /*Multiplies the number i.e. 10 by 2 so the output is 20*/

