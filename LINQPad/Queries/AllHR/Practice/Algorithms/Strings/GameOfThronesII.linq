<Query Kind="Program" />

void Main()
{
	GameOfThronesIIFS();
}

// Define other methods and classes here
void GameOfThronesIIFS()
{
	//string s = "aaabbbb"; //OUTPUT : 3
	//string s = "cdcdcdcdeeeef"; //OUTPUT : 90
	//OUTPUT : 998232506
	string s = "wklmxibigvaeqzigwbgysgfbvyvcqczmmnzlxatdxtjqvrwrucsmixpfvkhnniabxbnudizbejtzcpszrmlbkdihnrvczxezytvdbvgfgzgiobhhnvkzyuhnleqndwmbrhgucnckmitdlcmzzzyzthnfnfsqdgtunaospqcdbximcvlbwmbpvqulvobyuxskzieozgtagcoizclvooklehwzvaxsxrcwaimbofbwjrgitsfhiqvnzrmwrmqqfumhcaitilprdwcwqhgyzbnaucxoqnevitdktlddzvxcrzajigjkjxkgzjupxymhrprndxsespglqiwbpflacxgdhaugbhnuygjddchxtpkmygnpmarqxyweaqkdzzyaghdllljhcvtacgrqgjidjgkjzwpywnycwepirartwkwaqnqwyabhhntgkiggvhktlzdccuxyetyuhqsfswpzjihtqqbnxlgknkopelplfnfofavxwkzhsgbkyexxsghfsvwwjljoapehrzepkdwemxrmcqkuwtborznamwoonsvetbtfhqkvpdhtttpqnseertedqutfookhqfnzxzuncbgvvynkquoknsnfojlcxxlpcaoabipfmxdjvqtokhyabnfrwstwpgluhcwkmlqyktjijcwwluwmhddeyycphnlqrhaeuqefjopvslrefpqouwuswwkdmvtddujzmqgwevrwgkanbtevryqpxatjxoockacxqivwgosmyvczqgwjgmydotmoidqsdurvdmrlajzygbzyhwhqkitbbipllfgqaxlfmcsmnrnwtoucmesxooapwpdjwlzyimfuoxjdpwzkkwoxajwoxyftnkclvbmgptadrliijiuweitgrrwqpbjemlrjodpdzsisdranbwjhgenaxjqomasanlkcpzhqrqixjkmkgvrmbgbdhijklnpqtvwz";
	//OUTPUT : 105572520
	//string s = "bwppacsvnerimozykjrqccnktkcvnptpnkgqpalceemssnrexkuznikisodigwxtjfjygxcmbpfwcyabkvbzfnhxdlhjjedumosunxgpmnlqnluyixznkhnnuuxdbcynsshgppxdfiwsvqsenutzbgmvblaeparkvaqmrpqwxoruelatfusiagfdughliavdcnqucisbwjwcxwxcspnvxsytaifjkamnqejsmbwklsokqlmlazgaugtuoydbbsorwxllyhvlbkvuvkfyllafttaiufjvxzouyzhwjekmohimrnmfamkuhmebspwpomlmmukxzwlpeubxhpckbngjbkmtbjlpvydjtniukujqonnxcqjgfrrgbdacontknyvgmgayckqsxdrbtbhasyhwejaswwejucsiiuikgycfcthxwqyrrhnvqpnoluzgwtqeqzqwxscbnlbmdbduisrahhqvbpbxlrbbsrxqlbtaoumsvpofhgfrnvmonpnyiobbhytucmushjmcabikjpbylpmaezaopbpybiudxqyezkianskwknuvcixijxwaymazwuftldzmpkodcybmnyjpiixufuudivfgrkcepbrenfjqgletlqltyknggkjohqvyczdrawyobjgjwmfheqbfaqlhawxhnuiptljwhjmksuwpibynrbstsfcubccqwkiqxrogcasuuolcpmrinlehqicukgkhsszplnxnppklgxpvjhgxsmelugffopmgknvxaslrkxcqurngyvdthjecsjjgaxnmkikmdvdpuffowuuxqzqxjwbdhkjhhwwthgfmdibxninmekjulbuwxxzgkjnthjnqrseudhrsphewrpqcsmzrkaxwjnptycjqxokaxeunlbleqbglqhccicytpnonsafpqqrnwlchonlhptshdwjnyhipwxadejklmnsuvx";
	int mod7 = (int)(Math.Pow(10,9) + 7);
	int [] chars = new int[26];
	for(int i = 0; i < s.Length; i++) chars[s[i] - 'a']++;
	long num = s.Length/2, den = 1;
	for(int i = 0; i < chars.Length; i++)
	{
		if(chars[i] > 0)
		{
			int temp = chars[i]/2;
			long fact = Factorial(temp, mod7) % mod7;
			den = ((den % mod7) * (fact % mod7)) % mod7;
		}
	}
	long numFact = Factorial(num, mod7) % mod7;
	long output = DivisionModPrimeUsingFermentsLT(numFact, den, mod7) % mod7;
	Console.WriteLine(output);
}

void GameOfThronesII()
{
	//string s = "aaabbbb"; //OUTPUT : 3
	//string s = "cdcdcdcdeeeef"; //OUTPUT : 90
	//OUTPUT : 998232506
	//string s = "wklmxibigvaeqzigwbgysgfbvyvcqczmmnzlxatdxtjqvrwrucsmixpfvkhnniabxbnudizbejtzcpszrmlbkdihnrvczxezytvdbvgfgzgiobhhnvkzyuhnleqndwmbrhgucnckmitdlcmzzzyzthnfnfsqdgtunaospqcdbximcvlbwmbpvqulvobyuxskzieozgtagcoizclvooklehwzvaxsxrcwaimbofbwjrgitsfhiqvnzrmwrmqqfumhcaitilprdwcwqhgyzbnaucxoqnevitdktlddzvxcrzajigjkjxkgzjupxymhrprndxsespglqiwbpflacxgdhaugbhnuygjddchxtpkmygnpmarqxyweaqkdzzyaghdllljhcvtacgrqgjidjgkjzwpywnycwepirartwkwaqnqwyabhhntgkiggvhktlzdccuxyetyuhqsfswpzjihtqqbnxlgknkopelplfnfofavxwkzhsgbkyexxsghfsvwwjljoapehrzepkdwemxrmcqkuwtborznamwoonsvetbtfhqkvpdhtttpqnseertedqutfookhqfnzxzuncbgvvynkquoknsnfojlcxxlpcaoabipfmxdjvqtokhyabnfrwstwpgluhcwkmlqyktjijcwwluwmhddeyycphnlqrhaeuqefjopvslrefpqouwuswwkdmvtddujzmqgwevrwgkanbtevryqpxatjxoockacxqivwgosmyvczqgwjgmydotmoidqsdurvdmrlajzygbzyhwhqkitbbipllfgqaxlfmcsmnrnwtoucmesxooapwpdjwlzyimfuoxjdpwzkkwoxajwoxyftnkclvbmgptadrliijiuweitgrrwqpbjemlrjodpdzsisdranbwjhgenaxjqomasanlkcpzhqrqixjkmkgvrmbgbdhijklnpqtvwz";
	//OUTPUT : 105572520
	string s = "bwppacsvnerimozykjrqccnktkcvnptpnkgqpalceemssnrexkuznikisodigwxtjfjygxcmbpfwcyabkvbzfnhxdlhjjedumosunxgpmnlqnluyixznkhnnuuxdbcynsshgppxdfiwsvqsenutzbgmvblaeparkvaqmrpqwxoruelatfusiagfdughliavdcnqucisbwjwcxwxcspnvxsytaifjkamnqejsmbwklsokqlmlazgaugtuoydbbsorwxllyhvlbkvuvkfyllafttaiufjvxzouyzhwjekmohimrnmfamkuhmebspwpomlmmukxzwlpeubxhpckbngjbkmtbjlpvydjtniukujqonnxcqjgfrrgbdacontknyvgmgayckqsxdrbtbhasyhwejaswwejucsiiuikgycfcthxwqyrrhnvqpnoluzgwtqeqzqwxscbnlbmdbduisrahhqvbpbxlrbbsrxqlbtaoumsvpofhgfrnvmonpnyiobbhytucmushjmcabikjpbylpmaezaopbpybiudxqyezkianskwknuvcixijxwaymazwuftldzmpkodcybmnyjpiixufuudivfgrkcepbrenfjqgletlqltyknggkjohqvyczdrawyobjgjwmfheqbfaqlhawxhnuiptljwhjmksuwpibynrbstsfcubccqwkiqxrogcasuuolcpmrinlehqicukgkhsszplnxnppklgxpvjhgxsmelugffopmgknvxaslrkxcqurngyvdthjecsjjgaxnmkikmdvdpuffowuuxqzqxjwbdhkjhhwwthgfmdibxninmekjulbuwxxzgkjnthjnqrseudhrsphewrpqcsmzrkaxwjnptycjqxokaxeunlbleqbglqhccicytpnonsafpqqrnwlchonlhptshdwjnyhipwxadejklmnsuvx";

	int mod7 = (int)(Math.Pow(10,9) + 7);
	long [] factorials = Factorials((s.Length/2) + 1, mod7);

	Console.WriteLine($"s.Length:{s.Length} mod7:{mod7}");
	int [] chars = new int[26];
	for(int i = 0; i < s.Length; i++)
	{
		chars[s[i] - 'a']++;
	}
	Console.WriteLine(string.Join(" ",chars));
	///*
	long num = s.Length/2, den = 1;
	for(int i = 0; i < chars.Length; i++)
	{
		if(chars[i] > 0)
		{
			int temp = chars[i]/2;
			long fact = Factorial(temp, mod7) % mod7;
			den = ((den % mod7) * (fact % mod7)) % mod7;
			if(fact != factorials[temp])
				Console.WriteLine($"temp:{temp} fact:{fact} fact2:{factorials[temp]} den:{den}");
			//Console.WriteLine($"chars[i]:{chars[i]} temp:{temp} fact:{fact} fact2:{Factorial(temp) % mod7}");
			//den = ((den % mod7) * (temp % mod7)) % mod7;
		}
	}
	long numFact = Factorial(num, mod7) % mod7;
	long output = DivisionModPrimeUsingFermentsLT(numFact, den, mod7) % mod7;
	Console.WriteLine($"num:{num} numFact:{numFact} numFact2:{factorials[num]} den:{den} output:{output}");
	Console.WriteLine(output);
	//*/
}

long DivisionModPrimeUsingFermentsLT(long num, long den, int mod)
{
	long answer = num * (ModularExponentiations(den, (mod - 2), mod));
	return answer;
}

long ModularExponentiations(long x, long y, int p)
{
	long result = 1;
	x = x % p;
	
	while(y > 0)
	{
		if((y & 1) > 0) result = (result * x) % p;
		y >>= 1;
		x = (x * x) % p;
	}
	return result;
}

long [] Factorials(int num, int mod7)
{
	long [] factorials = new long[num];
	factorials[0] = 1;
	for(int i = 1; i < num; i++)
		factorials[i] = ((i % mod7) * (factorials[i-1] % mod7)) % mod7; 
	
	return factorials;
}

long Factorial(long num)
{
	if(num == 0) return 1;
	return num * Factorial(num - 1);
}

long Factorial(long num, int mod7)
{
	if(num == 0) return 1;
	long temp = Factorial(num - 1, mod7) % mod7;
	return ((num % mod7) * (temp % mod7)) % mod7;
}
