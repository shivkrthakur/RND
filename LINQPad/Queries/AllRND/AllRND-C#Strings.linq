<Query Kind="Program" />

void Main()
{
	Misc();
	//GenerateAllSubstring("abba");
	//Console.WriteLine(RemoveACharFromStringAtSpecificIndex("This is crazy", 9, 4));
	//Console.WriteLine(CountStringOccurrences("0101000101010100","101"));
}

static void Misc()
{
	var sub2 = "cdab".OrderBy(x => x);
	Console.WriteLine(string.Join("", "asfaishfia".OrderBy(x => x)));
	Console.WriteLine(sub2);
	return;
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

void GenerateAllSubstring(string inputString)
{
	int len = inputString.Length;
	int count = 0;
	for(int k = 1; k < len; k++)
	{
		for(int i = 0; i <= len - k; i++)
		{
			var sub1 = inputString.Substring(i, k).ToCharArray();
			for(int j = i + 1; j <= len - k; j++)
			{
				var sub2 = inputString.Substring(j, k).ToCharArray();
				Array.Sort(sub1);
				Array.Sort(sub2);
				if(string.Equals(new string(sub1), new string(sub2))) count++;
				//Console.WriteLine($"i:{i+1} j:{j+1} {inputString[i]},{inputString[j]} sub1:{sub1} sub2:{sub2}");
				//Console.WriteLine($"{sub1},{sub2}");
			}
		}
	}
	Console.WriteLine(count);
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

/*
http://stackoverflow.com/questions/12261344/fastest-search-method-in-stringbuilder
*/
public static class StringBuilderSearching
{
  public static bool Contains(this StringBuilder haystack, string needle)
  {
    return haystack.IndexOf(needle) != -1;
  }
  public static int IndexOf(this StringBuilder haystack, string needle)
  {
    if(haystack == null || needle == null)
      throw new ArgumentNullException();
    if(needle.Length == 0)
      return 0;//empty strings are everywhere!
    if(needle.Length == 1)//can't beat just spinning through for it
    {
      char c = needle[0];
      for(int idx = 0; idx != haystack.Length; ++idx)
        if(haystack[idx] == c)
          return idx;
      return -1;
    }
    int m = 0;
    int i = 0;
    int[] T = KMPTable(needle);
    while(m + i < haystack.Length)
    {
      if(needle[i] == haystack[m + i])
      {
        if(i == needle.Length - 1)
          return m == needle.Length ? -1 : m;//match -1 = failure to find conventional in .NET
        ++i;
      }
      else
      {
        m = m + i - T[i];
        i = T[i] > -1 ? T[i] : 0;
      }
    }
    return -1;
  }      
  private static int[] KMPTable(string sought)
  {
    int[] table = new int[sought.Length];
    int pos = 2;
    int cnd = 0;
    table[0] = -1;
    table[1] = 0;
    while(pos < table.Length)
      if(sought[pos - 1] == sought[cnd])
        table[pos++] = ++cnd;
      else if(cnd > 0)
        cnd = table[cnd];
      else
        table[pos++] = 0;
    return table;
  }
}
