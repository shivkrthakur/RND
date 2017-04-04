<Query Kind="Program" />

void Main()
{
	//CaesarCiphar();
	//WeightedUniformString();
	//MarsExploration();
	//FunnyString();
	//Gemstones();
	//AlternatingCharacters();
	//TheLoveLetterMystery();
	//GameOfThronesI();
	//HackerrankInaString();
	//TwoStrings();
	//BeautifulBinaryString();
	//StringConstruction();
	//MakingAnagrams();
	//Anagram();
	//SeparateTheNumbers();
	//PalindromIndex();
	//TwoCharacters();

	//RichieRich();

	//SherlockandValidString();
	//BearAndSteadyGene();
	//CommonChild();

	//Needs optimization
	
	Stopwatch sw = new Stopwatch();
	sw.Start();
	DeterminingDNAHealth();
	//DeterminingDNAHealthSlow();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");

}

void DeterminingDNAHealth()
{
	Dictionary<String, HashSet<Tuple<int,long>>> map = new Dictionary<String, HashSet<Tuple<int,long>>>();
	int N = Convert.ToInt32("6");
	string [] genes = { "a", "b", "c", "aa", "d", "b" };
	long [] healths = { 1, 2, 3, 4, 5, 6 };
	int s = Convert.ToInt32("3");
	int [][] startEnd = { new int[]{ 1, 5 }, new int[]{ 0, 4 }, new int[]{ 2, 4 }};
	string [] d = { "caaab", "xyz", "bcdybc" };
	
	for (int i=0; i<N; i++)
	{
		string gene = genes[i];
		var t = new Tuple<int,long>(i, healths[i]);
		if (map.ContainsKey(gene))
		{
			var hs = map[gene];
			hs.Add(t);
			map[gene] = hs;
		}
		else
		{
			var hs = new HashSet<Tuple<int,long>>();
			hs.Add(t);
			map.Add(gene,hs);
		}
	}
	Console.WriteLine(map);
	long maxValue = Int64.MinValue;
	long minValue = Int64.MaxValue;
	for(int i = 0; i < s; i++)
	{
		int [] se = startEnd[i];
		int start = se[0], end = se[1];
		string geneStrand = d[i];
		//Console.WriteLine(geneStrand);
		long h = 0;
		int len = geneStrand.Length;
		Console.WriteLine($"geneStrand:{geneStrand}");
		for (int f = 0; f < len; f++)
		{
			string str = string.Empty;
			for (int j = f; j < len; j++)
			{
				str += geneStrand[j];
				Console.WriteLine($"str:{str}");
				if (map.ContainsKey(str)) 
				{
					HashSet<Tuple<int,long>> hs = map[str];
					//Console.WriteLine(hs);
					foreach(var t in hs)
					{
						if (t.Item1 >= start && t.Item1 <= end)
						{
							h += t.Item2;
						}
					}
				}
			}
			//Console.WriteLine();
		}
		Console.WriteLine($"h:{h} maxValue:{maxValue} minValue:{minValue}");
		Console.WriteLine();
		if (h > maxValue) maxValue = h;
		if (h < minValue) minValue = h;
	}
	Console.WriteLine($"{minValue} {maxValue}");
}

void DeterminingDNAHealthSlow()
{
	int N = Convert.ToInt32("6");
	string [] genes = { "a", "b", "c", "aa", "d", "b" };
	int [] gH = { 1, 2, 3, 4, 5, 6 };
	int s = Convert.ToInt32("3");
	int [][] startEnd = { new int[]{ 1, 5 }, new int[]{ 0, 4 }, new int[]{ 2, 4 }};
	string [] d = { "caaab", "xyz", "bcdybc" };
	int [] healths = new int[s];
	for(int i = 0; i < s; i++)
	{
		int [] se = startEnd[i];
		int S = se[0], E = se[1];
		string strand = d[i];
		int health = 0;
		while(S <= E)
		{
			string c = genes[S];
			int index = 0;
			int count = 0;
			while(index > -1) { index = strand.IndexOf(c,index); if(index > -1) { index++; count++; } }
			health += count * gH[S];
			//Console.WriteLine($"c:{c} strand:{strand} count:{count} value:{health} health:{gH[S]}");
			S++;
		}
		//Console.WriteLine($"value:{health}");
		healths[i] = health;
		//totalHealth += health;
	}
	//Console.WriteLine(healths);
	Console.WriteLine($"{healths.Min()} {healths.Max()}");
}


void RichieRich()
{
	//string num = "3943"; int [] nk = Array.ConvertAll("4 1".Split(),Int32.Parse);
	string num = "092282"; int [] nk = Array.ConvertAll("6 3".Split(),Int32.Parse);
	//string num = "0010100"; int [] nk = Array.ConvertAll("7 6".Split(),Int32.Parse);
	char [] charNum = num.ToCharArray();
	int n = nk[0], k = nk[1], count = 0;
	if(k >= n) Console.WriteLine(string.Join("", Enumerable.Repeat(9,n).ToArray()));
	else
	{
		StringBuilder sb = new StringBuilder(num);
		bool np = false;
		//Console.WriteLine(sb.ToString());
		for(int i = 0; i < n/2; i++)
		{
			int j = n - 1 - i;
			int left = Convert.ToInt32(num[i].ToString());
			int right = Convert.ToInt32(num[j].ToString());
			if(left != right) 
			{
				if(k > 0)
				{
					//Console.WriteLine($"left:{left} right:{right} k:{k}");
					if(left < right)
					{
						sb.Remove(i,1);
						sb.Insert(i,right);
					}
					else
					{
						sb.Remove(j,1);
						sb.Insert(j,left);
					}
					k--;
					//Console.WriteLine($"sb:{sb.ToString()} k:{k}");
				}
				else { np = true; break; }
			}
			//Console.WriteLine($"i:{i} 	j:{j}	num:{num}	left:{left}		right:{right}		count:{count}");
		}
		//Console.WriteLine();
		Console.WriteLine($"sb:{sb.ToString()} k:{k}");
		if(np || ((k & 1) != 0)) Console.WriteLine(-1);
		else 
		{
			if(k == 0) Console.WriteLine(sb.ToString());
			else 
			{
				int j = 0;
				//Console.WriteLine("0 => " + sb.ToString());
				int sbLen = sb.Length;
				while(j < sbLen && k > 0)
				{
					char c = sb[j];
					if( c == '9') { j++; continue; }
					sb.Remove(j,1);
					sb.Insert(j,'9');
					//Console.WriteLine("1 => " + sb.ToString());
					sb.Remove(sbLen - 1 - j,1);
					sb.Insert(sbLen - 1 - j,'9');
					//Console.WriteLine("2 => " + sb.ToString());
					j++;
					k -= 2;
				}
				//Console.WriteLine(k);
				if(k > 0) Console.WriteLine(-1);
				else Console.WriteLine($"output:{sb.ToString()}");
			}
		}
	}
}

void BearAndSteadyGene()
{
	int N = Convert.ToInt32("4");
	int [] actg = new int[4];
	Dictionary<char,int> di;
	string [] S = { "GAAATAAA", "CTCA" };
	for(int i = 0; i < S.Length; i++)
	{
		di = new Dictionary<char,int>();
		di.Add('A',0);
		di.Add('C',0);
		di.Add('G',0);
		di.Add('T',0);

		string s = S[i];
		int n = s.Length;
		int tgVal = n / 4;
		for(int j = 0; j < n; j++)
		{
			if(di.ContainsKey(s[j])) di[s[j]]++;
			else di.Add(s[j], 1);
		}
		//Console.WriteLine(tgVal);
		Console.WriteLine(di);
		int missing = 0;
		missing = n - (n/4 * di.Count);
		foreach(var d in di)
		{
			if(d.Value < tgVal)
				missing += tgVal - d.Value;
		}
		Console.WriteLine(missing);
	}
	
}

void TwoCharacters()
{
	//string s = "beabeefeab";
	//string s = "a";
	//string s = "ezfnjymgqtjnmstbadgdsrxvntnacwljnkgchtjeaoivfcindgxipmrjuqmmcpntpotplodjhijxqpogjmzipygacfdjgmewechuebxvcbnakszzcxkozxwavzgmesrvysonomhvufezislfntgncspthcpneyminpbjildobozfirvcgdratdpmmpkujcywvtzkdytzyfejbytsobvudvutfueveevgrqnxjiwpkrvllsjxmqhotlnpgjxkjnobxfqodlyiqsisdeuwqmntxouzdtisgutdafostmwticvncjwldpknuodmfksusaqpsoosgpiveyxipfklmhypdxpdncpgaswpycoxsuxasqduojpblctcyvyxldcgzevedvxiwinfppkjbtifuuapickknwxxjmjmtxlpfalxdgepmekaxijuphqfafrnezyldokwcnzenhpibktlfuxjfmeqajmvopbhuslnnnlmkmoteceiwbytjhhxqnkuazevswrkaofggfrnapciuoexqogscugzspwuvzkyrdfkhixcaqctfwadewpqksxxvqiigvjjpagvqikuojlwhfyztu";
	string s = "czoczkotespkfjnkbgpfnmtgqhorrzdppcebyybhlcsplqcqogqaszjgorlsrppinhgpaweydclepyftywafupqsjrbkqakpygolyyfksvqetrfzrcmatlicxtcxulwgvlnslazpfpoqrgssfcrfvwbtxaagjfahcgxbjlltfpprpcjyivxu";
	if(s.Length < 2) Console.WriteLine(0);
	else
	{
		Dictionary<char,int> charsDict = new Dictionary<char,int>();
		for(int i = 0; i < s.Length; i++)
		{
			if(charsDict.ContainsKey(s[i])) 
			{ 
				if(charsDict[s[i]] != -1)
					charsDict[s[i]]++; 
				if(s[i] == s[i-1]) charsDict[s[i]] = -1;
			}
			else charsDict.Add(s[i], 1);
		}
		charsDict = charsDict.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
		Console.WriteLine(charsDict);
		//var tempCharsDict = charsDict;
		//return;
		string output = string.Empty; 
		foreach(var pair1 in charsDict)
		{
			string temp = s;
			Console.WriteLine(pair1);
			if(pair1.Value == -1) { continue; }
			var tempDict = new Dictionary<char,int>();
			//Console.WriteLine(temp);
			if(charsDict.ContainsValue(pair1.Value + 1))
			{
				foreach(var pair2 in charsDict)
				{
					//Console.WriteLine($"Pair2 Start pair1.Key:{pair1.Key} pair2.Key:{pair2.Key}  pair1.Value:{pair1.Value} pair2.Value:{pair2.Value}");
					//Console.WriteLine(pair2);
					if(pair1.Key == pair2.Key || ( pair1.Value + 1) == pair2.Value ) continue;
					temp = temp.Replace(pair2.Key.ToString(), string.Empty);
					//Console.WriteLine(temp);
				}
			}
			Console.WriteLine("temp:" + temp);
			bool flag = true;
			for(int l = 0; l < temp.Length - 2; l++)
			{
				if(temp[l] != temp[l+2]) { flag = false; break;  }
			}
			if(flag && temp.Length > output.Length) output = temp;
			//Console.WriteLine("output:" + output);
		}
		Console.WriteLine(output);
		Console.WriteLine(output.Length);
		//Console.WriteLine(charsDict);
	}
}

bool IsPalindrome(string s1)
{
	string s1R = Reverse(s1, 0);
	//Console.WriteLine($"s1:{s1} s1R:{s1R}");
	if(s1 == s1R) return true;
	return false;
}

string Reverse(string s1, int index)
{
	if(index == s1.Length) return string.Empty;
	return Reverse(s1, index + 1) + s1[index++].ToString();
}

void PalindromIndex()
{
/*
10
quyjjdcgsvvsgcdjjyq
hgygsvlfwcwnswtuhmyaljkqlqjjqlqkjlaymhutwsnwcflvsgygh
fgnfnidynhxebxxxfmxixhsruldhsaobhlcggchboashdlurshxixmfxxxbexhnydinfngf
bsyhvwfuesumsehmytqioswvpcbxyolapfywdxeacyuruybhbwxjmrrmjxwbhbyuruycaexdwyfpaloyxbcpwsoiqtymhesmuseufwvhysb
fvyqxqxynewuebtcuqdwyetyqqisappmunmnldmkttkmdlnmnumppasiqyteywdquctbeuwenyxqxqyvf
mmbiefhflbeckaecprwfgmqlydfroxrblulpasumubqhhbvlqpixvvxipqlvbhqbumusaplulbrxorfdylqmgfwrpceakceblfhfeibmm
tpqknkmbgasitnwqrqasvolmevkasccsakvemlosaqrqwntisagbmknkqpt
lhrxvssvxrhl
prcoitfiptvcxrvoalqmfpnqyhrubxspplrftomfehbbhefmotfrlppsxburhyqnpfmqlaorxcvtpiftiocrp
kjowoemiduaaxasnqghxbxkiccikxbxhgqnsaxaaudimeowojk


10
fyjwtatuieusvfqaeynaaiiaanyeaqfvsueutatwjyf
qaaiyrpadovfjrmgkildtkseysejdtrpltptujlxxljutptlprtdjesyeskdlikgmrjfvodapryiaaq
llhrxcreddwkcronujfkwbdswoowsdbwkfjunorckwdderxrhll
qasfhkfcojhntlfkaydtepsfsleipymwsopposwmypielsfspetdykfltnhjocfkhfsaq
broifqivnnvifiorb
bglgcwnmpobohqefrglsaaaaslgrfeqhobopmnwcglgb
bthvmywukfwrkslaiialskwfkuwymvhtb
uxxdlselxmwyiguugtpsypfudffswvwyswyyiiyywsywvsffdufpysptguugiywmxlesldxxu
rvscdpyljqglgmiktfndsmfnkgmubrruloqptgohsgneocoyyocoengshogtpqolurrbumgknfmsdntkimglgqjlypdcsvr
qmdpbsswvmqtyhkobqeijjieqbokhytqmvwssbdmq
*/
/*
8
20
5
16
5
-1
11
28
17
3
*/
	int T = Convert.ToInt32("3");
	string [] S = { "aaab", "baa", "aaa" };
	for(int t = 0; t < T; t++)
	{
		string s = S[t];
		if(IsPalindrome(s)) Console.WriteLine(-1);
		else 
		{
			int idx = 0; bool flag = false;
			for(int i = 0; i < s.Length/2; i++)
			{
				int right = s.Length - 1 - i;
				if(s[i] != s[right])
				{
					if(IsPalindrome(new StringBuilder(s).Remove(i,1).ToString())) 
					{
						idx = i; flag = true; break;
					}
					else if(IsPalindrome(new StringBuilder(s).Remove(right,1).ToString()))
					{
						idx = right; flag = true; break;
					}
				}
				/*
				if(IsPalindrome(new StringBuilder(s).Remove(i,1).ToString())) { idx = i; flag = true;  break; }
				*/
				
			}
			if(flag) Console.WriteLine(idx); else Console.WriteLine(-1);
		}
	}
}

void SeparateTheNumbers()
{
	int q = Convert.ToInt32("7");
	//string [] S = { "1234", "91011", "99100", "101103", "010203", "13", "1" };
	string [] S = { "00000000000000000000000000000000", "11111111111111111111111111111111", "22222222222222222222222222222222"
				  , "33333333333333333333333333333333", "44444444444444444444444444444444", "55555555555555555555555555555555"
				  , "66666666666666666666666666666666", "77777777777777777777777777777777", "88888888888888888888888888888888"
				  , "10001001100210031004100510061007"
				  //, "1" 
				  };
/*	10
00000000000000000000000000000000
11111111111111111111111111111111
22222222222222222222222222222222
33333333333333333333333333333333
44444444444444444444444444444444
55555555555555555555555555555555
66666666666666666666666666666666
77777777777777777777777777777777
88888888888888888888888888888888
10001001100210031004100510061007
*/
	for(int i = 0; i < S.Length; i++)
	{
		bool yes = false;
		string s = S[i];
		//Console.WriteLine($"s:{s}");
		int len = s.Length;
		string tBk = string.Empty;
		for(int j = 0; j < len/2; j++)
		{
			tBk += s[j];
			string temp = tBk;
			int ind = 0, tInd = 0;
			//Console.WriteLine($"tBk:{tBk} temp:{tBk} ind:{ind} tInd:{tInd}");
			while((ind) > -1 && (tInd == ind) && (ind += temp.Length) < len)// && temp.Length <= len/2)
			{
				//((tInd + temp.Length) == ind) && 
				//ind += temp.Length;
				tInd = ind;
				//Console.WriteLine(temp);
				long intVal = Convert.ToInt64(temp);
				temp = (intVal+1).ToString();
				//Console.WriteLine($"intVal:{intVal} temp:{temp} tInd:{tInd}");
				ind = s.IndexOf(temp, ind);
				//Console.WriteLine($"intVal:{intVal} temp:{temp} ind:{ind}");
			}
			//Console.WriteLine($"ind:{ind} temp:{temp} temp.Length:{temp.Length}");
			if((ind) >= len) { yes = true; break; }
		}
		if(yes) Console.WriteLine($"YES {tBk}"); 
		else Console.WriteLine("NO");
		//Console.WriteLine();
	}
}

void BeautifulBinaryString()
{
	string zeroOnezero = "010";
	int n = Convert.ToInt32("10");
	string s = "0100101010";//"0101010";
	int steps = 0;
	int index = 0, prevIndex=0;
	if(s.IndexOf("010") == -1) Console.WriteLine(steps);
	else
	{
		Console.WriteLine($"s:{s}");
		s = s.Replace(zeroOnezero, "");
		Console.WriteLine($"s:{s}");
		
//		while(s.Contains(zeroOnezero))
//		{
//			Console.WriteLine($"s:{s}");
//			s = s.Replace(zeroOnezero, "");
//			Console.WriteLine($"s:{s}");
//			Console.WriteLine($"s:{s}");
//			index = s.IndexOf(zeroOnezero, index);
//			s = s.Replace(zeroOnezero, "");
//			Console.WriteLine($"s:{s}");
//			if((index - prevIndex) == 2) steps++;
//			prevIndex = index;
//			//Console.WriteLine($"index:{index}");
//			if(index != -1) { index++; }
//		}
		//Console.WriteLine(steps);
	}
}

void CommonChild()
{	
	string [][] S = {
			new string[] { "HARRY", "SALLY" }
		,	new string[] { "AA", "BB" }
		,	new string[] { "SHINCHAN", "NOHARAAA" }
		,	new string[] { "ABCDEF", "FBDAMN" }
		,	new string[] { "ABCDEFTIO", "FBDAMNDGE" }
	};
	string op = string.Empty;
	for(int i = 0; i < S.Length; i++)
	{
		string [] s = S[i];
		string s1 = s[0], s2 = s[1];
		char [] ch = new char[s1.Length];
		HashSet<int> hs = new HashSet<int>();
		HashSet<char> hsChar = new HashSet<char>();
		int [] pch = new int[s1.Length];
		if(string.Equals(s1, s2)) op = s1;
		else
		{
			Console.WriteLine($"s1:{s1} s2:{s2}");
			while(!string.Equals(s1, s2))
			{
				int l1 = s1.Length;
				int k = 0;
				string ss1 = string.Empty, ss2 = string.Empty;
				while(k < l1)
				{
					char c = s1[k];
					if(s2.IndexOf(c) > -1) { ss1 += c; }
					c = s2[k];
					if(s1.IndexOf(c) > -1) { ss2 += c; }
					k++;
				}
				Console.WriteLine($"ss1:{ss1} ss2:{ss2}");
				s1 = ss1;
				s2 = ss2;
			}
			Console.WriteLine();
		}
	}
}

void SherlockAndAnagrams()
{
	
}

void SherlockandValidString()
{
	string s = "aabbcd";
	//string s = "dfgdfgh";
	int len = s.Length;
	Dictionary<char,int> dict = new Dictionary<char,int>();
	for(int i = 0; i < len; i++)
	{
		if(dict.ContainsKey(s[i])) dict[s[i]]++;
		else dict.Add(s[i], 1);
	}
	int dc = dict.Count;
	Console.WriteLine(dict);
	Console.WriteLine($"len:{len}	dc:{dc}");
	
	if(len % dc <= 1)
	{
		if(len % dc == 0)
		{
			
		}
		else Console.WriteLine("YES");
	}
	else 
	{
		Console.WriteLine("NO");
	}
	
	/*
	return;
	bool [] chars = new bool[26];
	for(int i = 0; i < s.Length; i++)
	{
		chars[(int)s[i] - 96] = true;
	}
	int uCount = 0;
	for(int j = 0; j < chars.Length; j++)
	{
		if(chars[j]) 
		{
			uCount++;
			int index = -1, k = -1, charCount = 0;
			while(k < s.Length && s.IndexOf((char)(j+ 96), ++k) != -1) 
			{
				k = s.IndexOf((char)(j+ 96), k);
				if(k == -1) break;
				charCount++;
			}
			Console.WriteLine($"j:{j} (char)j:{(char)(j+ 96)} charCount:{charCount}");
		}
	}
	int len = s.Length, f = 1;
	while(len >  (uCount * f++));
	Console.WriteLine(uCount);
	if(Math.Abs(s.Length - (uCount * uCount)) <= 1) Console.WriteLine("YES");
	else Console.WriteLine("NO");
	*/
}

void StringConstruction()
{
	int n = Convert.ToInt32("4");
	string [] S = { "abcd", "abab", "abcdabcdabcdabcdabcd", "abcdeabcdfabcdgabcd" };
	
	for(int i = 0; i < n; i++)
	{
		string s = S[i];
		HashSet<char> set = new HashSet<char>();
		//Console.WriteLine($"s:{s}");
		int k = 0;
		while(k < s.Length)
			set.Add(s[k++]);
		
		string p = s[0].ToString();
		int ops = 1;
		for(int t = 1; t < s.Length; t++)
		{
			//Console.WriteLine($"s[t]:{s[t]} p:{p} s.IndexOf(p,t):{s.IndexOf(p,t)}");
			if(p.IndexOf(s[t]) == -1) 
				ops++;
			p += s[t];
		}
		//Console.WriteLine($"p:{p}");
		//Console.WriteLine();
		Console.WriteLine($"ops:{ops} set.Count:{set.Count}");
	}
}

void TwoStrings()
{
/*

10
dapkqnowwvdrknfvcmanjuroumppajrzklucroxvpfmcsclqa
ivtnjtgiogmwhqybjaxlktqbwsdhqrwovoavetymkpcco
hrtybirxncuiailznohfawjwipdtupnxnisbwcplozwrzt
ngdmqotxkpnuhmpfmajthzdtnztrqyugendiublcwp
rmpwlddwttapjzhdldjmuhmgruufltzszprzdcziigc
bbvvkeqkqekqqennyxqxkxnyxnyqnnybnbvnyqqe
annbjookwtqkoivcgbqckqtvgvktobctktgkkjiac
zsspfhmzpurrrlurdsdlrfldzyldfhudfedrszdpmsudh
yuuuydwovzawzamvydaaadkakukpynwfmpnmuaazokxkmjxawo
rqiqbhgscsetgihrrrgsqrlqgcbcbrettlehbeistbiqbisie
ibvmfltfdvlmentbfdemebbnvllfneeefnaamtblt
gukzzrqruyxsrqhyuggkrjujkwjhqhqsrqgkrkqxpszrzk
nakqzfroqouhgunxqvqbxwtibfodsvoilqrpvhtgzoholxd
bqluorjgkkrvmiptnxegxwlhrstiiafbfoxodzyguhdwi
oyvgelovlyevhhedoeolyhdevcvhgceydcdehgvoc
wsqswjnjpiarszzzxpmptrquwbnbzqiqqtzqnbajnpsjfaxr
hvkmgwawagozzabgmdmdvbbaxadawmbazvxohxzv
sfiltrslqepytjpfffqlrpejiueftrnisnnppnlpuficrjys
nvsovybaljmzenkfgayfoxzcjantbdidxflbkhbixgzk
qdphnbrjmznztnphhutkdbwjzmjwugtxggxchzcidngplj

YES
YES
NO
NO
NO
NO
YES
NO
NO
YES
*/
//	int t = Convert.ToInt32("2");
//	string [][] S = {
//		  new string[] { "hello", "world" }
//		, new string[] { "hi", "world" }
//	};

	int t = Convert.ToInt32("10");
	string [][] S = {
		  new string[] { "dapkqnowwvdrknfvcmanjuroumppajrzklucroxvpfmcsclqa","ivtnjtgiogmwhqybjaxlktqbwsdhqrwovoavetymkpcco" }
		, new string[] { "hrtybirxncuiailznohfawjwipdtupnxnisbwcplozwrzt","ngdmqotxkpnuhmpfmajthzdtnztrqyugendiublcwp" }
		, new string[] { "rmpwlddwttapjzhdldjmuhmgruufltzszprzdcziigc","bbvvkeqkqekqqennyxqxkxnyxnyqnnybnbvnyqqe" }
		, new string[] { "annbjookwtqkoivcgbqckqtvgvktobctktgkkjiac","zsspfhmzpurrrlurdsdlrfldzyldfhudfedrszdpmsudh" }
		, new string[] { "yuuuydwovzawzamvydaaadkakukpynwfmpnmuaazokxkmjxawo","rqiqbhgscsetgihrrrgsqrlqgcbcbrettlehbeistbiqbisie" }
		, new string[] { "ibvmfltfdvlmentbfdemebbnvllfneeefnaamtblt","gukzzrqruyxsrqhyuggkrjujkwjhqhqsrqgkrkqxpszrzk" }
		, new string[] { "nakqzfroqouhgunxqvqbxwtibfodsvoilqrpvhtgzoholxd","bqluorjgkkrvmiptnxegxwlhrstiiafbfoxodzyguhdwi" }
		, new string[] { "oyvgelovlyevhhedoeolyhdevcvhgceydcdehgvoc","wsqswjnjpiarszzzxpmptrquwbnbzqiqqtzqnbajnpsjfaxr" }
		, new string[] { "hvkmgwawagozzabgmdmdvbbaxadawmbazvxohxzv","sfiltrslqepytjpfffqlrpejiueftrnisnnppnlpuficrjys" }
		, new string[] { "nvsovybaljmzenkfgayfoxzcjantbdidxflbkhbixgzk","qdphnbrjmznztnphhutkdbwjzmjwugtxggxchzcidngplj" }
	};
	
	for(int i = 0; i < S.Length; i++)
	{
		char [] allChars = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
		bool yes = false;
		string [] s = S[i];
		//Console.WriteLine($"s[0].Length:{s[0].Length} s[1].Length:{s[1].Length}");
		string s1 = s[0], s2 = s[1];
		int j = 0;
		while(j < allChars.Length)
		{ 
			if(s1.IndexOf(allChars[j]) != -1 && s2.IndexOf(allChars[j]) != -1) { yes = true; break; }
			j++;
		}
		if(yes) Console.WriteLine("YES"); else Console.WriteLine("NO");
	}
	
}

void GameOfThronesI()
{
	string [] S = { "aaabbbb", "cdefghmnopqrstuvw", "cdcdcdcdeeeef" };
	for(int t = 0; t < S.Length; t++)
	{
		string s = S[t];
		int len = s.Length;
		int [] chars = new int[26];
		for(int i = 0; i < len; i++)
		{
			chars[(int)s[i] - 97]++;
		}
		//Console.WriteLine(chars);
		int count = 0;
		bool yes = true;
		for(int j = 0; j < chars.Length; j++)
		{
			//count += chars[j] & 1;
			if((len & 1) == 0 && (chars[j] & 1) != 0)
			{
				yes = false;								
				break;
			}
			else if((chars[j] & 1) != 0 && (chars[j] & 1) != 0) 
			{ 
				count++; 
				if(count == 2) { yes = false; break; }
			}
		}
		//Console.WriteLine(count);
		if(yes) Console.WriteLine("YES");
		else Console.WriteLine("NO");
	}
}

void MakingAnagrams()
{
	string atoz = "abcdefghijklmnopqrstuvwxyz";
	string str1 = "cde", str2 = "abc";
    
	int [] A = new int[26];
	int [] B = new int[26];
	int i = 0;
    for(i=0 ; i< 26 ; i++)
        A[i] = B[i] = 0;
    for(i = 0 ; i< str1.Length; i++)
        A[(int)(str1[i] - 'a')]++;
    for(i = 0 ; i< str2.Length; i++)
        B[(int)(str2[i] - 'a')]++;	
    int outp = 0;
    for(i=0 ; i< 26 ; i++)
    {
        outp = outp + A[i] + B[i] - 2* Math.Min(A[i],B[i]);
    }

	Console.WriteLine(outp);
	
	/*
	int cArr[]=new int[26];
	for(int i=0;i<s1.length();i++)cArr[s1.charAt(i)-97]++;
	for(int i=0;i<s2.length();i++)cArr[s2.charAt(i)-97]--;
	int count=0;
	for(int i=0;i<26;i++)count+=Math.abs(cArr[i]);
	System.out.println(count);
	*/
}

void Anagram()
{
	int t = Convert.ToInt32("6");
	string [] s = new string[] { "csgokgibmftzeozyadcofpouaerckbbpwhdg" };//"aaabbb", "ab", "abc", "mnop", "xyyx" , "xaxbbbxx" };
	for(int i = 0; i < s.Length; i++)
	{
		string input = s[i];
		//Console.WriteLine(input);
		int length = input.Length;
		if((length & 1) != 0) Console.WriteLine("-1");
		else
		{
			int change = 0;
			string s2 = input.Substring(0, length/2);
			string s1 = input.Substring(length/2, length/2);
			Dictionary<char,int> dict = new Dictionary<char,int>();
			int f = -1;
			while(++f < s1.Length) 
			{
				if(dict.ContainsKey(s1[f]))
				{
					dict[s1[f]]++;
				}
				else dict.Add(s1[f], 1);	
			}
			//Console.WriteLine(dict);			
			f= -1;
			while(++f < s2.Length) 
			{
				if(dict.ContainsKey(s2[f]))
				{
					dict[s2[f]]--;
					if(dict[s2[f]] == 0) dict.Remove(s2[f]);
				}
				else change++;
				//else dict.Add(s2[f], 1);	
			}
			
			Console.WriteLine(change);			
//			char [] s1Char = s1.ToCharArray();
//			Console.WriteLine($"s1:{String.Concat(s1.OrderBy(x => x))} {Environment.NewLine} s2:{String.Concat(s2.OrderBy(x => x))}");
//			//Console.WriteLine(s2);
//			Console.WriteLine(s1Char);
//			for(int a = 0; a < length/2; a++)
//			{
//				int index = s1Char.ToString().IndexOf(s2[a]);
//				if( index == -1) 
//				{
//					change++;
//				}
//				else s1Char[index] = ' ';
//			}
////			Console.WriteLine(s1Char);
//			//Console.WriteLine($"{string.Concat(s1Char.ToString().OrderBy(x => x))} ");
//			Console.WriteLine(change);
		}
	}
}
// Define other methods and classes here
void TheLoveLetterMystery()
{
	int T = Convert.ToInt32("4");
	string [] S = { "abc", "abcba", "abcd", "cba" };
	for(int t = 0; t < T; t++)
	{
		string s = S[t];
		int len = s.Length;
		int count = 0;
		//Console.WriteLine($"s:{s}");
		for(int i = 0, j = len-1; i <= len/2 && j >= len/2; i++, j--)
		{
			char left = s[i];
			char right = s[j];
			if(left == right) continue;
			if(left < right) count += right - left;
			else count += left - right;
			//Console.WriteLine($"i:{i} left:{left} j:{j} right:{right} count:{count}");
		}
		Console.WriteLine(count);
	}
}


void AlternatingCharacters()
{
	int T = Convert.ToInt32("5");
	string [] S = { "AAAA", "BBBBB", "ABABABAB", "BABABA", "AAABBB" };
	for(int t = 0; t < T; t++)
	{
		string s = S[t];
		int len = s.Length;
		int deletes = 0;
		if((s.IndexOf('A') == -1) || (s.IndexOf('B') == -1)) { deletes = len - 1; Console.WriteLine(deletes); continue;}
		char prevChar = (char)0;
		for(int i = 0; i < len; i++)
		{
			char curChar = s[i];
			if(curChar == prevChar) { deletes++; }
			prevChar = curChar;
		}
		Console.WriteLine(deletes);
	}
}

void Gemstones()
{
	int n = Convert.ToInt32("3");
	string [] S = { "abcdde", "baccd", "eeabg" };
	int gemStones = 0;
	string s = S[0];
	
	for(int j = 0; j < s.Length; j++)
	{
		int count = 1;
		char c = s[j];
		for(int i = 1; i < n; i++)
		{
			if(S[i].IndexOf(c) > -1) count++;
		}
		if(count >= n)
		{
			gemStones++;
		}
	}
	Console.WriteLine(gemStones);
}

void FunnyString()
{
	int T = Convert.ToInt32("2");
	string [] S = { "acxz", "bcxz" };
	for(int t = 0; t < T; t++)
	{
		bool Funny = true;
		string s = S[t];
		int [] c = s.Select(x => (int)x).ToArray();
		int len = c.Length;
		for(int i = 1, j = len - 2; i < len && j >= 0; i++, j--)
		{
			int eq1 = Math.Abs(c[i] - c[i-1]);
			int eq2 = Math.Abs(c[j] - c[j+1]);
			if(eq1 != eq2) { Funny = false; break; }
		}
		//Console.WriteLine(s);
		if(Funny) Console.WriteLine(nameof(Funny));
		else Console.WriteLine($"NOT {nameof(Funny)}");
	}
}

void MarsExploration()
{
	string sos = "SOS";
	string s = "SOSSPSSQSSOR";//"SOSSOT";//
	int count = 0;
	for(int i = 0; i < s.Length; i++)
	{
		if(s[i] != sos[i%3]) count++;
		/*
		string sub = s.Substring(i,3);
		//Console.WriteLine(sub);
		if(string.Equals(sub, sos))
		{
			continue;
		}
		else 
		{
			for(int j = 0; j < 3; j++)
			{
				if(sub[j] != sos[j]) count++;
			}
		}
		*/
	}
	Console.WriteLine(count);
}

void WeightedUniformString()
{
	string s = "abccddde";
	int t = Convert.ToInt32("6");
	int [] weights = { 1, 3, 12, 5, 9, 10};
	int len = s.Length;
	HashSet<int> hs = new HashSet<int>();
	int count = 1;
	int prevtCInt = 0;
	for(int i = 0; i < len; i++)
	{
		char c = s[i];
		int cInt = (int)c;
		int tCInt = cInt - 96;
		if(prevtCInt == cInt) count++;
		else { prevtCInt = cInt; count = 1; }
		//Console.WriteLine($"c:{c} cInt:{cInt} tCInt:{tCInt} prevtCInt:{prevtCInt} count:{count} count*tCInt:{count*tCInt}");
		hs.Add(count * tCInt);
	}
	for(int j = 0; j < weights.Length; j++)
	{
		if(hs.Contains(weights[j])) Console.WriteLine("Yes");
		else Console.WriteLine("No");
	}
	//Console.WriteLine(hs);
}

private static void CaesarCiphar()
{
	int n = Convert.ToInt32("11");
    string s = "middle-Outz";//"www.abc.xy";
    int [] input = s.ToCharArray().Select(x => (int)x).ToArray();
    int k = Convert.ToInt32("2");
    int a = (int)'a', z = (int)'z', A = (int)'A', Z = (int)'Z';
    //Console.WriteLine($"s:{s} a:{a} z:{z} A:{A} Z:{Z}");
	k = k % 26;
    for(int i = 0; i < n; i++)
    {
       int c = input[i];
       int sum = 0;
       //Console.WriteLine($"{(char)c} c:{c} k:{k} c+k:{c+k} {(char)(c + k)}");
       if(c >= a && c <= z)
       {
          c = (c + k);
          if(c > z){ c = a - 1 + (c % z); }
       }
       if(c >= A && c <= Z)
       {
          c = (c + k);
          if(c > Z) { c = A - 1 + (c % Z); }
       }
       input[i] = c;
    }
    Console.WriteLine(string.Join("", input.Select(x => (char)x).ToArray()));
		
}

void HackerrankInaString()
{
	string hr = "hackerrank";
	int q = Convert.ToInt32("2");
	string [] S = { "hereiamstackerrank", "hackerworld" };
	for(int i = 0; i < q; i++)
	{
		string s = S[i];
		int index = 0, j = 0;
		while(j < hr.Length && index < s.Length && s.IndexOf(hr[j],index) != -1) 
		{
			index = s.IndexOf(hr[j],index);
			//Console.WriteLine($"index:{index} hr[j]:{hr[j]} s:{s} j:{j}");
			index++;
			j++;
		}
		if(j == 10) Console.WriteLine("YES");
		else Console.WriteLine("NO");
	}
}