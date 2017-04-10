<Query Kind="Program" />

void Main()
{
	DetechHTMLLinksOP();
}

// Define other methods and classes here
void DetechHTMLLinksOP()
{
//7
//<center>
//<div class="noresize" style="height: 242px; width: 600px; "><map name="ImageMap_1_971996215" id="ImageMap_1_971996215">
//<area href="/wiki/File:Pardalotus_punctatus_female_with_nesting_material_-_Risdon_Brook.jpg" shape="rect" coords="3,3,297,238" alt="Female" title="Female" />
//<area href="/wiki/File:Pardalotus_punctatus_male_with_nesting_material_-_Risdon_Brook.jpg" shape="rect" coords="302,2,597,238" alt="Male" title="Male" /></map><img alt="Pair of Spotted Pardalotes" src="//upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Female_and_male_Pardalotus_punctatus.jpg/600px-Female_and_male_Pardalotus_punctatus.jpg" width="600" height="242" srcset="//upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Female_and_male_Pardalotus_punctatus.jpg/900px-Female_and_male_Pardalotus_punctatus.jpg 1.5x, //upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Female_and_male_Pardalotus_punctatus.jpg/1200px-Female_and_male_Pardalotus_punctatus.jpg 2x" usemap="#ImageMap_1_971996215" />
//<div style="margin-left: 0px; margin-top: -20px; text-align: left;"><a href="/wiki/File:Female_and_male_Pardalotus_punctatus.jpg" title="About this image"><img alt="About this image" src="//bits.wikimedia.org/static-1.22wmf7/extensions/ImageMap/desc-20.png" style="border: none;" /></a></div>
//</div>
//</center>

	string [] S = {
		//	"<li style=\"-moz-float-edge: content-box\">... that <a href=\"/wiki/Orval_Overall\" title=\"Orval Overall\">Orval Overall</a> <i>(pictured)</i> is the only <b><a href=\"/wiki/List_of_Major_League_Baseball_pitchers_who_have_struck_out_four_batters_in_one_inning\" title=\"List of Major League Baseball pitchers who have struck out four batters in one inning\">Major League Baseball player to strike out four batters in one inning</a></b> in the <a href=\"/wiki/World_Series\" title=\"World Series\">World Series</a>?</li>"
			"<li class=\"interwiki-da\"><a href=\"//da.wikipedia.org/wiki/\" title=\"\" lang=\"da\" hreflang=\"da\"><b>Dansk</b></a></li>"
	//		"<div style=\"margin-left: 0px; margin-top: -20px; text-align: left;\"><a href=\"/wiki/File:Female_and_male_Pardalotus_punctatus.jpg\" title=\"About this image\"><img alt=\"About this image\" src=\"//bits.wikimedia.org/static-1.22wmf7/extensions/ImageMap/desc-20.png\" style=\"border: none;\" /></a></div>"
	//  , 	"<li style=\"-moz-float-edge: content-box\">... that the three cities of the <b><a href=\"/wiki/West_Triangle_Economic_Zone\" title=\"West Triangle Economic Zone\">West Triangle Economic Zone</a></b> contribute 40% of Western China's GDP?</li>"
	//  , 	"<li style=\"-moz-float-edge: content-box\">... that <i><a href=\"/wiki/Kismet_(1943_film)\" title=\"Kismet (1943 film)\">Kismet</a></i>, directed by <b><a href=\"/wiki/Gyan_Mukherjee\" title=\"Gyan Mukherjee\">Gyan Mukherjee</a></b>, ran at the <a href=\"/wiki/Roxy_Cinema_(Kolkata)\" title=\"Roxy Cinema (Kolkata)\">Roxy, Kolkata</a>, for 3 years and 8 months?</li>"
	//	, 	"<li style=\"-moz-float-edge: content-box\">... that <a href=\"/wiki/Vauix_Carter\" title=\"Vauix Carter\">Vauix Carter</a> both coached and played for the <b><a href=\"/wiki/1882_Navy_Midshipmen_football_team\" title=\"1882 Navy Midshipmen football team\">1882 Navy Midshipmen football team</a></b>?</li>"
	//	, 	"<li style=\"-moz-float-edge: content-box\">... that <a href=\"/wiki/Zhu_Chenhao\" title=\"Zhu Chenhao\">Zhu Chenhao</a> was sentenced to <a href=\"/wiki/Slow_slicing\" title=\"Slow slicing\">slow slicing</a> for leading the <b><a href=\"/wiki/Prince_of_Ning_rebellion\" title=\"Prince of Ning rebellion\">Prince of Ning rebellion</a></b> against the <a href=\"/wiki/Ming_Dynasty\" title=\"Ming Dynasty\">Ming Dynasty</a> <a href=\"/wiki/Zhengde_Emperor\" title=\"Zhengde Emperor\">emperor Zhengde</a>?</li>"
	//	, 	"<li style=\"-moz-float-edge: content-box\">... that <b><a href=\"/wiki/Mirza_Adeeb\" title=\"Mirza Adeeb\">Mirza Adeeb</a></b> was a prominent modern Pakistani <a href=\"/wiki/Urdu\" title=\"Urdu\">Urdu</a> playwright whose later work focuses on social problems and daily life?</li>"
	//	, 	"<li style=\"-moz-float-edge: content-box\">... that in <i><b><a href=\"/wiki/La%C3%9Ft_uns_sorgen,_la%C3%9Ft_uns_wachen,_BWV_213\" title=\"Lat uns sorgen, lat uns wachen, BWV 213\">Die Wahl des Herkules</a></b></i>, Hercules must choose between the good cop and the bad cop?<br style=\"clear:both;\" />"
	//	, 	"<div style=\"text-align: right;\" class=\"noprint\"><b><a href=\"/wiki/Wikipedia:Recent_additions\" title=\"Wikipedia:Recent additions\">Archive</a></b>  <b><a href=\"/wiki/Wikipedia:Your_first_article\" title=\"Wikipedia:Your first article\">Start a new article</a></b>  <b><a href=\"/wiki/Template_talk:Did_you_know\" title=\"Template talk:Did you know\">Nominate an article</a></b></div>"
	//	, 	"</li>"
		};

	string exp = @"href=([""'])(.*?)(<\s*/\s*a\s*>)";
	for(int i = 0; i < S.Length; i++)
	{
		string text = S[i];
		foreach(Match m in Regex.Matches(text,exp))
		{
			string tgt = m.Groups[2].Value;
			string url = tgt.Substring(0,tgt.IndexOf('"'));
			string name = tgt.Substring(tgt.LastIndexOf('>')+1, tgt.Length - tgt.LastIndexOf('>')-1).Trim();
		    if(string.IsNullOrEmpty(name)) 
            {    
                tgt = Regex.Match(tgt,@"(>*?)(.*?)(</)").Groups[2].Value;
                name = tgt.Substring(tgt.LastIndexOf('>')+1, tgt.Length - tgt.LastIndexOf('>')-1).Trim();
            }
			Console.WriteLine($"{url},{name}");
		}
	}
}

void DetectHTMLLinks()
{
	int n = Convert.ToInt32("2");
//	string [] S = { 
//			"<div class=\"portal\" role=\"navigation\" id='p-navigation'>"
//		,	"<h3>Navigation</h3>"
//		,	"<div class=\"body\">"
//		,	"<ul>"
//		,	"<li id=\"n-mainpage-description\"><a href=\"/wiki/Main_Page\" title=\"Visit the main page [z]\" accesskey=\"z\" >Main page</a></li>"
//		,	"<li id=\"n-contents\"><a href=\"/wiki/Portal:Contents\" title=\"Guides to browsing Wikipedia\">Contents</a></li>"
//		,	"<li id=\"n-featuredcontent\"><a href=\"/wiki/Portal:Featured_content\" title=\"Featured content  the best of Wikipedia\">Featured content</a></li>"
//		,	"<li id=\"n-currentevents\"><a href=\"/wiki/Portal:Current_events\" title=\"Find background information on current events\">Current events</a></li>"
//		,	"<li id=\"n-randompage\"><a href=\"/wiki/Special:Random\" title=\"Load a random article [x]\" accesskey=\"x\">Random article</a></li>"
//		,	"<li id=\"n-sitesupport\"><a href=\"//donate.wikimedia.org/wiki/Special:FundraiserRedirector?utm_source=donate&utm_medium=sidebar&utm_campaign=C13_en.wikipedia.org&uselang=en\" title=\"Support us\">Donate to Wikipedia</a></li>"
//		,	"</ul>"
//		,	"</div>"
//		,	"</div>"
//		,	"<p><a href=\"http://www.quackit.com/html/tutorial/html_links.cfm\">Example Link</a   ></p>"
//		,	"<div class=\"more-info\"><a href=\"http://www.quackit.com/html/examples/html_links_examples.cfm\">More Link Examples...</a></div>"
//	};

string [] S = {
		"<li style=\"-moz-float-edge: content-box\">... that <a href=\"/wiki/Orval_Overall\" title=\"Orval Overall\">Orval Overall</a> <i>(pictured)</i> is the only <b><a href=\"/wiki/List_of_Major_League_Baseball_pitchers_who_have_struck_out_four_batters_in_one_inning\" title=\"List of Major League Baseball pitchers who have struck out four batters in one inning\">Major League Baseball player to strike out four batters in one inning</a></b> in the <a href=\"/wiki/World_Series\" title=\"World Series\">World Series</a>?</li>"
	//, 	"<li style=\"-moz-float-edge: content-box\">... that the three cities of the <b><a href=\"/wiki/West_Triangle_Economic_Zone\" title=\"West Triangle Economic Zone\">West Triangle Economic Zone</a></b> contribute 40% of Western China's GDP?</li>"
 	//, 	"<li style=\"-moz-float-edge: content-box\">... that <i><a href=\"/wiki/Kismet_(1943_film)\" title=\"Kismet (1943 film)\">Kismet</a></i>, directed by <b><a href=\"/wiki/Gyan_Mukherjee\" title=\"Gyan Mukherjee\">Gyan Mukherjee</a></b>, ran at the <a href=\"/wiki/Roxy_Cinema_(Kolkata)\" title=\"Roxy Cinema (Kolkata)\">Roxy, Kolkata</a>, for 3 years and 8 months?</li>"
//	, 	"<li style=\"-moz-float-edge: content-box\">... that <a href=\"/wiki/Vauix_Carter\" title=\"Vauix Carter\">Vauix Carter</a> both coached and played for the <b><a href=\"/wiki/1882_Navy_Midshipmen_football_team\" title=\"1882 Navy Midshipmen football team\">1882 Navy Midshipmen football team</a></b>?</li>"
//	, 	"<li style=\"-moz-float-edge: content-box\">... that <a href=\"/wiki/Zhu_Chenhao\" title=\"Zhu Chenhao\">Zhu Chenhao</a> was sentenced to <a href=\"/wiki/Slow_slicing\" title=\"Slow slicing\">slow slicing</a> for leading the <b><a href=\"/wiki/Prince_of_Ning_rebellion\" title=\"Prince of Ning rebellion\">Prince of Ning rebellion</a></b> against the <a href=\"/wiki/Ming_Dynasty\" title=\"Ming Dynasty\">Ming Dynasty</a> <a href=\"/wiki/Zhengde_Emperor\" title=\"Zhengde Emperor\">emperor Zhengde</a>?</li>"
//	, 	"<li style=\"-moz-float-edge: content-box\">... that <b><a href=\"/wiki/Mirza_Adeeb\" title=\"Mirza Adeeb\">Mirza Adeeb</a></b> was a prominent modern Pakistani <a href=\"/wiki/Urdu\" title=\"Urdu\">Urdu</a> playwright whose later work focuses on social problems and daily life?</li>"
//	, 	"<li style=\"-moz-float-edge: content-box\">... that in <i><b><a href=\"/wiki/La%C3%9Ft_uns_sorgen,_la%C3%9Ft_uns_wachen,_BWV_213\" title=\"Lat uns sorgen, lat uns wachen, BWV 213\">Die Wahl des Herkules</a></b></i>, Hercules must choose between the good cop and the bad cop?<br style=\"clear:both;\" />"
//	, 	"<div style=\"text-align: right;\" class=\"noprint\"><b><a href=\"/wiki/Wikipedia:Recent_additions\" title=\"Wikipedia:Recent additions\">Archive</a></b>  <b><a href=\"/wiki/Wikipedia:Your_first_article\" title=\"Wikipedia:Your first article\">Start a new article</a></b>  <b><a href=\"/wiki/Template_talk:Did_you_know\" title=\"Template talk:Did you know\">Nominate an article</a></b></div>"
//	, 	"</li>"
	};
	//string exp1 = "(?i)href\\s*=\\s*\"(.+?)\".?>(<[^/]>)(.?)<.*?/a>";
	//string exp1 = "<\\s*a\\s*href\\s*=\\s*\\\"(.*?)\\\".*?>(<.*?>)*\\s*(.*?)\\s*<";
	//string exp1 = "href=\"([^\"]+)\"[^>]*>(<.>)?(.*?)(?=</|<)";
	//string exp1 = "<a href=\"([^\"]*)\"[^>]*>(?:<[^>]*>)*([^<]*)(?:<\\/[^a]>)*(?:<\\/a>)";
	//string exp1 =  @"href=""[\w\W]+""\s?";
	string exp1 = @"href=([""'])(.*?)\1";
	//string exp1 = @"href=((?:\\.|[^""\\])*)";
	//string exp1 = @"<a href=""([^""]*)"".*?>([^<]*)</b?";
	//string exp2 = @"<\s*a\s*.+>.+<\s*/\s*a\s*>";
	string exp3 = @"(<a.*?)([\s\w]+)(<\s*/\s*a\s*)>";
	//string exp3 = @"([""']).*<\s*/\s*a\s*>";
	//string exp3 = @"(>[^<].*<\s*/\s*a\s*>)((\w\s?)+)";
	for(int i = 0; i < S.Length; i++)
	{
		string text = S[i];
		var urlMatches = Regex.Matches(text, exp1);
		var nameMatches = Regex.Matches(text, exp3);
		foreach(Match m in urlMatches)
		{
			Console.WriteLine(m.Groups[2].Value);			
		}
		//Console.WriteLine(text);
		foreach(Match m in nameMatches)
		{
			Console.WriteLine(m.Groups[2].Value);			
		}
		
		/*
		string url = Regex.Match(text, exp1).Groups[2].Value;
		string name = Regex.Match(text, exp3).Groups[2].Value;
		//Console.WriteLine(Regex.Match(text, exp3).Groups[2].Value);
		//Console.WriteLine($"url:{url},				Name:{name}");
		//Console.WriteLine();
		if(!string.IsNullOrEmpty(url))
		{
			//url = url.Substring(url.IndexOf('"')+1,url.IndexOf('"',url.IndexOf('"')+1) - url.IndexOf('"')-1);
			//url = url.Substring(6,url.Length-7);//,url.IndexOf('"')+1) - url.IndexOf('"')-1);
//			if(!string.IsNullOrEmpty(name))
//			{
//				name = name.Substring(1, name.IndexOf('<')-1);
//			}
			*/
			//Console.WriteLine($"{url},{name}");
		//}
		
		//Console.WriteLine($"{Regex.Match(url,@"""([^""]*)[\w\W]+""")},{Regex.Match(name,@"(\w\s?)+")}");
		//Console.WriteLine($"{url.Substring(url.IndexOf('"')+1,url.Length - url.IndexOf('"',url.IndexOf('"')+1) -1)},{name.Substring(1, name.IndexOf('<')-1)}");
//		foreach(Match m in Regex.Matches(text, exp1))
//		{
//			Console.WriteLine(m.Value);
//			//Console.WriteLine(m);
//		}
//		foreach(Match m in Regex.Matches(text, exp3))
//		{
//			Console.WriteLine(m.Value);
//		}
	}
	Console.WriteLine();
}

/*
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class Solution
{
  static void Main(String[] args)
  {
    // Regex for finding <a>...</a>.
    Regex hyperlinkRegex = new Regex(@"<a([^>]+)>.*?</a>");

    // Regex for finding the href.
    Regex hrefRegex = new Regex(" href=[\\'\"]?([^\\'\" >]+)");

    // Regex for finding the title.
    Regex titleRegex = new Regex(@"(?<=^|>)[^><]+?(?=<|$)");

    // Get the number of lines.
    int N = Int32.Parse(Console.ReadLine());

    // Get the entire text.
    StringBuilder sb = new StringBuilder();
    for (int n = 0; n < N; n++)
    {
      sb.AppendLine(Console.ReadLine());
    }
    string fragment = sb.ToString();

    // Get all hyperlinks
    foreach (Match hyperlinkMatch in hyperlinkRegex.Matches(fragment))
    {
      string href = hrefRegex.Match(hyperlinkMatch.Value).Groups[1].Value;
      string title = titleRegex.Match(hyperlinkMatch.Value).Value.Trim();

      Console.WriteLine("{0},{1}", href, title);      
    }
  }
}
*/