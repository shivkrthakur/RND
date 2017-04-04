<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	CavityMap();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void CavityMap()
{
	//int n = Convert.ToInt32("4");
	//string [] inputArray = new string[] {"1112", "1912", "1892", "1234"};
	int n = Convert.ToInt32("7");
	string [] inputArray = new string[] {"2476387", "1485738", "6591334", "9589583", "6827769", "2559498", "1822388"};
	string [] outputArray = (string[])inputArray.Clone();//new string[n];
	
	/*
	int n = Convert.ToInt32(Console.ReadLine());
	string [] inputArray = new string[n]; 

  	for(int x = 0; x < n; x++)
	{
       inputArray[x] = Console.ReadLine();
	}*/
    
	Console.WriteLine(inputArray);
	for(int i = 0; i < n; i++)
	{
		string inputStr = inputArray[i];
		
        if(i == 0 || i == n - 1) continue;
        for(int k = 0; k < inputArray[i].Length; k++)
        {
            if(k == 0 || k == inputStr.Length - 1) continue;
            //int src = Convert.ToInt32(inputStr[k]);
			int src = Convert.ToInt32(inputStr[k].ToString());
			string o1 = inputArray[i][k-1].ToString();
			string p1 = inputArray[i][k+1].ToString();
			string q1 = inputArray[i-1][k].ToString();
			string r1 = inputArray[i+1][k].ToString();
			
			if(o1 == "X" || p1== "X" || q1 == "X" || r1 == "X") continue;
            
			int o = Convert.ToInt32(inputArray[i][k-1].ToString());
            int p = Convert.ToInt32(inputArray[i][k+1].ToString());
            int q = Convert.ToInt32(inputArray[i-1][k].ToString());
            int r = Convert.ToInt32(inputArray[i+1][k].ToString());

            //Console.WriteLine($"i:{i} k:{k} src:{src} o:{o} p:{p} q:{q} r:{r}");
            if(src > Convert.ToInt32(inputStr[k-1].ToString()) && src > Convert.ToInt32(inputStr[k+1].ToString()) && src > Convert.ToInt32(inputArray[i-1][k].ToString()) && src > Convert.ToInt32(inputArray[i+1][k].ToString()))
            {
            	//Console.WriteLine($"i:{i} k:{k} src:{src} inputStr:{inputStr} 		o:{o} p:{p} q:{q} r:{r} o1:{o1} p1:{p1} q1:{q1} r1:{r1}");
                //Console.WriteLine(inputArray[i][k]);			
               	StringBuilder tgt = new StringBuilder(inputArray[i]);
				tgt[k] = 'X';
                //tgt = tgt.Replace(src.ToString(), "X");
                inputArray[i] = tgt.ToString();
				//outputArray[i] = tgt;
				//Console.WriteLine($"src:{src} src:{(char)src}	 	inputArray[i]: {inputArray[i]} tgt:{tgt}");
				
            }
        }
        //Console.WriteLine(string.Join(Environment.NewLine,inputArray));
    }
		
	Console.WriteLine(string.Join(Environment.NewLine,inputArray));
}