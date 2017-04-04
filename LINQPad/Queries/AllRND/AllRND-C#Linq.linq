<Query Kind="Statements" />

string sentence = "The quick brown fox jumped over the lazy dog.";
string[] sentenceArr = sentence.Split(' ');
var output = sentenceArr.Aggregate((a,b) => b + " " + a);
Console.WriteLine(output);
sentenceArr.ToList().ForEach(a => {
	char[] charArr = a.ToArray();
	var res = charArr.Aggregate((p,q) => p);
	Console.WriteLine(res);
});
return;

List<int> array = new List<int>(){1,2,3,4,5};
var result = array.Aggregate((a, b) => b * a);
 // 1 * 2 = 2
 // 2 * 3 = 6
 // 6 * 4 = 24
 // 24 * 5 = 120
 Console.WriteLine(result);
 return;


var list = new List<Tuple<string, int>>
           {
               new Tuple<string, int>("will", 31),
               new Tuple<string, int>("jeremy", 48),
               new Tuple<string, int>("daniel", 26)
           };

var query1 = list.Where(item => item.Item2 > 30);
var query2 = list.Select(item => item.Item1);
var query3 = list.Select(item => item.Item2 > 30);

query1.ToList().ForEach(x => {
	Console.WriteLine(x);	
});
Console.WriteLine();
query2.ToList().ForEach(x => {
	Console.WriteLine(x);	
});
Console.WriteLine();
query3.ToList().ForEach(x => {
	Console.WriteLine(x);	
});

Array.Sort(values);
Array.Reverse(values);
Array.Sort(values, (a,b)=>(-a.CompareTo(b)));