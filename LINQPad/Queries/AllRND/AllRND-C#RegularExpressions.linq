<Query Kind="Program" />

void Main()
{
	RegularExpressions();
}

// Define other methods and classes here
void RegularExpressions()
{
	string t = "<li style=\"-moz-float-edge: content-box\">... that <a href=\"/wiki/Orval_Overall\" title=\"Orval Overall\">Orval Overall</a> <i>(pictured)</i> is the only <b><a href=\"/wiki/List_of_Major_League_Baseball_pitchers_who_have_struck_out_four_batters_in_one_inning\" title=\"List of Major League Baseball pitchers who have struck out four batters in one inning\">Major League Baseball player to strike out four batters in one inning</a></b> in the <a href=\"/wiki/World_Series\" title=\"World Series\">World Series</a>?</li>";
	Console.WriteLine(Regex.Matches(t, @"href=([""'])(.*?)(<\s*/\s*a\s*>)"));
	Console.WriteLine(Regex.Matches(t, @"href=([""'])(.*?)\1"));

	//Console.WriteLine(Regex.Match(t, @"href=([""'])(.*?)(<\s*/\s*a\s*>)").Groups);
	//Console.WriteLine(Regex.Match(t, @"href=([""'])(.*?)\1").Groups);
	//Console.WriteLine(Regex.Match(t, @"href=([""'])(.*?)(<\s*/\s*a\s*>)").Groups);
	return;
	string text = "This is a test text string to run regular expression matches. This will help you familiarize yourself with how regular expressions work. It will also familiarise you with various regex criteria.";
	Console.WriteLine(Regex.Matches(text, "familiari[sz]e").Count); // Matches both familiarize and familiarise. Output: 2
	Console.WriteLine(Regex.Matches(text, @"\sThis").Count); //Matches the This which has a space before it. Output: 1
	Console.WriteLine(Regex.Matches(text, @"This\s").Count); //Matches the This which has a space before it. Output: 2
	Console.WriteLine(Regex.Matches(text, @"\sThis\s").Count); //Matches the This which has a space before it. Output: 2
}

/*
http://eloquentjavascript.net/1st_edition/chapter10.html
https://gist.github.com/gruber/8891611
https://code.tutsplus.com/tutorials/8-regular-expressions-you-should-know--net-6149
https://www.mikesdotnetting.com/article/46/c-regular-expressions-cheat-sheet
https://www.codeproject.com/Articles/9099/The-Minute-Regex-Tutorial
https://regexone.com/references/csharp
https://www.tutorialspoint.com/csharp/csharp_regular_expressions.htm
http://www.regular-expressions.info

http://www.regextester.com/20
	abc…		Letters
	123…		Digits
	\d			Any Digit
	\D			Any Non-digit character
	.			Any Character
	\.			Period
	[abc]		Only a, b, or c
	[^abc]		Not a, b, nor c
	[a-z]		Characters a to z
	[0-9]		Numbers 0 to 9
	\w			Any Alphanumeric character
	\W			Any Non-alphanumeric character
	{m}			m Repetitions
	{m,n}		m to n Repetitions
	*			Zero or more repetitions
	+			One or more repetitions
	?			Optional character
	\s			Any Whitespace
	\S			Any Non-whitespace character
	^…$			Starts and ends
	(…)			Capture Group
	(a(bc))		Capture Sub-group
	(.*)		Capture all
	(abc|def)	Matches abc or def
*/

/*
Character			Description
\					Marks the next character as either a special character or escapes a literal. For example, "n" matches the character "n". "\n" matches a newline character. The sequence "\\" matches "\" and "\(" matches "(".
					Note: double quotes may be escaped by doubling them: "<a href=""...>"
^					Depending on whether the MultiLine option is set, matches the position before the first character in a line, or the first character in the string.
$					Depending on whether the MultiLine option is set, matches the position after the last character in a line, or the last character in the string.
*					Matches the preceding character zero or more times. For example, "zo*" matches either "z" or "zoo".
+					Matches the preceding character one or more times. For example, "zo+" matches "zoo" but not "z".
?					Matches the preceding character zero or one time. For example, "a?ve?" matches the "ve" in "never".
.					Matches any single character except a newline character.
(pattern)			Matches pattern and remembers the match. The matched substring can be retrieved from the resulting Matches collection, using Item [0]...[n]. To match parentheses characters ( ), use "\(" or "\)".
(?<name>pattern)	Matches pattern and gives the match a name.
(?:pattern)			A non-capturing group
(?=...)				A positive lookahead
(?!...)				A negative lookahead
(?<=...)			A positive lookbehind .
(?<!...)			A negative lookbehind .
x|y					Matches either x or y. For example, "z|wood" matches "z" or "wood". "(z|w)oo" matches "zoo" or "wood".
{n}					n is a non-negative integer. Matches exactly n times. For example, "o{2}" does not match the "o" in "Bob," but matches the first two o's in "foooood".
{n,}				n is a non-negative integer. Matches at least n times. For example, "o{2,}" does not match the "o" in "Bob" and matches all the o's in "foooood." "o{1,}" is equivalent to "o+". "o{0,}" is equivalent to "o*".
{n,m}				m and n are non-negative integers. Matches at least n and at most m times. For example, "o{1,3}" matches the first three o's in "fooooood." "o{0,1}" is equivalent to "o?".
[xyz]				A character set. Matches any one of the enclosed characters. For example, "[abc]" matches the "a" in "plain".
[^xyz]				A negative character set. Matches any character not enclosed. For example, "[^abc]" matches the "p" in "plain".
[a-z]				A range of characters. Matches any character in the specified range. For example, "[a-z]" matches any lowercase alphabetic character in the range "a" through "z".
[^m-z]				A negative range characters. Matches any character not in the specified range. For example, "[m-z]" matches any character not in the range "m" through "z".
\b					Matches a word boundary, that is, the position between a word and a space. For example, "er\b" matches the "er" in "never" but not the "er" in "verb".
\B					Matches a non-word boundary. "ea*r\B" matches the "ear" in "never early".
\d					Matches a digit character. Equivalent to [0-9].
\D					Matches a non-digit character. Equivalent to [^0-9].
\f					Matches a form-feed character.
\k					A back-reference to a named group.
\n					Matches a newline character.
\r					Matches a carriage return character.
\s					Matches any white space including space, tab, form-feed, etc. Equivalent to "[ \f\n\r\t\v]".
\S					Matches any nonwhite space character. Equivalent to "[^ \f\n\r\t\v]".
\t					Matches a tab character.
\v					Matches a vertical tab character.
\w					Matches any word character including underscore. Equivalent to "[A-Za-z0-9_]".
\W					Matches any non-word character. Equivalent to "[^A-Za-z0-9_]".
\num				Matches num, where num is a positive integer. A reference back to remembered matches. For example, "(.)\1" matches two consecutive identical characters.
\n					Matches n, where n is an octal escape value. Octal escape values must be 1, 2, or 3 digits long. For example, "\11" and "\011" both match a tab character. "\0011" is the equivalent of "\001" & "1". Octal escape values must not exceed 256. If they do, only the first two digits comprise the expression. Allows ASCII codes to be used in regular expressions.
\xn					Matches n, where n is a hexadecimal escape value. Hexadecimal escape values must be exactly two digits long. For example, "\x41" matches "A". "\x041" is equivalent to "\x04" & "1". Allows ASCII codes to be used in regular expressions.
\un					Matches a Unicode character expressed in hexadecimal notation with exactly four numeric digits. "\u0200" matches a space character.
\A					Matches the position before the first character in a string. Not affected by the MultiLine setting
\Z					Matches the position after the last character of a string. Not affected by the MultiLine setting.
\G					Specifies that the matches must be consecutive, without any intervening non-matching characters.

*/