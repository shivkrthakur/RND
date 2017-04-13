<Query Kind="Program" />

void Main()
{
	Console.WriteLine($"SByte.MaxValue:{SByte.MaxValue}			Byte.MaxValue:{Byte.MaxValue}");
	Console.WriteLine($"Int32.MaxValue:{Int32.MaxValue} 		UInt32.MaxValue:{UInt32.MaxValue}");
	Console.WriteLine($"Int64.MaxValue:{Int64.MaxValue} 		UInt64.MaxValue:{UInt64.MaxValue}");
	Console.WriteLine();
	
	sbyte sbVal = 127;
	byte bVal = 255;

	int intVal   = 2100000000;
	uint uIntVal = 4000000000;
	//uint negtveUIntVal = -4;
	//int negtveIntVal = -4;
	
	long longValue = 9223372036854775807;
	ulong uLongValue = 18446744073709551615;
}

// Define other methods and classes here
