<Query Kind="Program" />

void Main()
{
	Console.WriteLine(RemoveACharFromStringAtSpecificIndex("This is crazy", 9, 4));
	//Console.WriteLine(CountStringOccurrences("0101000101010100","101"));
}

static void Misc()
{
	int index = "isThis is a test".IndexOf("is",1);
	Console.WriteLine(index);
	return;
	
	
	string n = "20251";
	int len = n.Length;
	string n1 = n.Substring(0,len/2);
	string n2 = n.Substring(len/2,len - len/2);
	
	Console.WriteLine(n1);
	Console.WriteLine(n2);
	Console.WriteLine("THis is a test".Substring(1,10));
	
/*
	char [] vowels = { 'a', 'e', 'i', 'o', 'u' };
	char [] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
	var a = new string(vowels.Where((c,i) => i % 2 == 0).ToArray());
	var b = new string(consonants.Where((c,i) => i % 2 != 0).ToArray());
	Console.WriteLine(a);
	Console.WriteLine(b);

*/
}

void StringLiterals()
{
	//https://msdn.microsoft.com/en-us/library/h21280bw.aspx
	//https://www.codeproject.com/Articles/371232/Escaping-in-Csharp-characters-strings-string-forma
	//https://msdn.microsoft.com/en-us/library/aa691090(v=vs.71).aspx
	string a = "hello, world";                  // hello, world
	string b = @"hello, world";               // hello, world
	string c = "hello \t world";               // hello     world
	string d = @"hello \t world";               // hello \t world
	string e = "Joe said \"Hello\" to me";      // Joe said "Hello" to me
	string f = @"Joe said ""Hello"" to me";   // Joe said "Hello" to me
	string g = "\\\\server\\share\\file.txt";   // \\server\share\file.txt
	string h = @"\\server\share\file.txt";      // \\server\share\file.txt
	string i = "one\r\ntwo\r\nthree";
	string j = @"one
	two
	three";
}
string RemoveACharFromStringAtSpecificIndex(string srcStr, int indexToRemoveCharsAt, int noOfCharsToRemove)
{
	var aStringBuilder = new StringBuilder(srcStr);
	aStringBuilder.Remove(indexToRemoveCharsAt, noOfCharsToRemove); //Remove noOfCharsToRemove char at index indexToRemoveCharAt.
	//aStringBuilder.Insert(3, "ZX");
	return aStringBuilder.ToString();

}

int CountStringOccurrences(string text, string pattern)
{
    // Loop through all instances of the string 'text'.
    int count = 0;
    int i = 0;
    while ((i = text.IndexOf(pattern, i)) != -1)
    {
        i += pattern.Length;
        count++;
    }
    return count;
}

string Reverse(string s1, int index)
{
	if(index == s1.Length) return string.Empty;
	return Reverse(s1, index + 1) + s1[index++].ToString();
}

bool IsPalindrome(string s1)
{
	string s1R = Reverse(s1, 0);
	//Console.WriteLine($"s1:{s1} s1R:{s1R}");
	if(s1 == s1R) return true;
	return false;
}