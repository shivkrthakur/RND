<Query Kind="Program" />

void Main()
{
	TheBritishAndAmericanStyleOfSpelling();
}

// Define other methods and classes here
static void TheBritishAndAmericanStyleOfSpelling() 
{
	/*
	int N = Convert.ToInt32("2");
	string [] text = { 		"hackerrank has such a good ui that it takes no time to familiarise its environment"
						, 	"to familiarize oneself with ui of hackerrank is easy" };
	string [] expressions = { "familiarize" };
	int T = Convert.ToInt32("1");
	*/
	///*
	int N = Convert.ToInt32("7");
	string [] text = { 		
							"unfair arrival faint region pride realise paralyse length officially disturbing"
						, 	"call fashionable room take claim capable biscuit cough qualified realze"
						, 	"decoration indeed caramelise gas habit downward salad realize on knee"
						, 	"catalyse blade artistic put careless league final waste catalyse bedroom"
						, 	"door materialize catalyse round point routine celebration paralyse stranger weather"
						, 	"artificially materialise personally elegant lane celebration statement whom tend bone"
						, 	"realise infect coloured planet pet estimate lane infectious destroy exchange"
					};
	string [] expressions = { "materialize", "catalyze", "realize", "hydrolyze", "caramelize", "recognize", "organize", "paralyze", "colonize" };
	int T = Convert.ToInt32("9"); //*/
	for(int t = 0; t < T; t++)
	{
        string exp = expressions[t];
        exp = exp.Substring(0,exp.Length - 2);
        exp = exp + "[sz]e";
        int count = 0;
        foreach(string str in text)
        {
			//Console.WriteLine($"str:{str} exp:{exp}");
            count += Regex.Matches(str,exp).Count;
        }
        Console.WriteLine(count);
	}
}