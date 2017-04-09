<Query Kind="Program" />

void Main()
{
	DetectHTMLTags();
}

// Define other methods and classes here
void DetectHTMLTags()
{
	int n = Convert.ToInt32("2");
	string [] input = { "<p><a href=\"http://www.quackit.com/html/tutorial/html_links.cfm\">Example Link</a></p>"
						, "<div class=\"more-info\"><a href=\"http://www.quackit.com/html/examples/html_links_examples.cfm\">More Link Examples...</a></div>"
						};
	string exp = @"<[a-zA-Z]>\w</[a-zA-Z]>";
	for(int i = 0; i < input.Length; i++)
	{
		foreach(Match m in Regex.Matches(input[i], exp))
		{
			Console.WriteLine(m);
		}
	}
}