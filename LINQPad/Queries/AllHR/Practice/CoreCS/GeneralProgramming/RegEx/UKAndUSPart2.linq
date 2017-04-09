<Query Kind="Program" />

void Main()
{
	UKAndUSPart2();
}

// Define other methods and classes here
static void UKAndUSPart2() 
{
	/*
	int N = Convert.ToInt32("2");
	string [] text = {		"the odour coming out of the left over food was intolerable"
						, 	"ammonia has a very pungent odor" };
	string [] expressions = { "odour" };
	int T = Convert.ToInt32("1");
	//*/
	///* OUTPUT: 2 3 4 2 0 5 4 1 1
	int N = Convert.ToInt32("10");
	string [] text = { 		
						"splendour wealth piece recognition savoury endeavour oil cannot reality fish"
						,"sincere savor argument vigour chain awake cap surprising savoury jump"
						,"natural study process immoral flag vigour habit assist candy pet"
						,"shoulder aside slightly onto crash later disagreement savour rumour entrance"
						,"splendour petrol unable inevitably crowd growth fasten leading responsibility artificially"
						,"equally alarmed also knowledge ok splendor armory pick sale be"
						,"activity rumour ending alcoholic savory curve splendour honestly enjoyable rumour"
						,"determined used rumor union affair odor granddaughter elect endeavor alter"
						,"savor hour enjoyable waiter divorce at mental prepared folding primary"
						,"cheaply vegetable upon splendor disease savor it cast hear cardboard"
					};
	string [] expressions = { 
			"endeavour","savoury","savour","vigour","valour","splendour","rumour","odour","armoury"
		};
	int T = Convert.ToInt32("9"); //*/
	for(int t = 0; t < T; t++)
	{
        string exp = expressions[t];
        exp = exp.Replace("u","(u*)");
        exp = @"\b" + exp + @"\b";
        int count = 0;
        foreach(string str in text)
        {
            count += Regex.Matches(str,exp).Count;
        }
        Console.WriteLine(count);
	}
}