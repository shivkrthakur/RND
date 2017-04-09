<Query Kind="Program" />

void Main() 
{
    int n = Convert.ToInt32(Console.ReadLine());
    string s = Convert.ToString(n,2);
    //Console.WriteLine(s);
    int count = 0, max = 0;
    for(int i = 0; i < s.Length; i++)
    {
        if(s[i] == '0') count = 0;
        else count++;
        max = Math.Max(max,count);
    }
    Console.WriteLine(max);
}
