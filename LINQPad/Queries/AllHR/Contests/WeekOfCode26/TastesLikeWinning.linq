<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{
	TastesLikeWinning();
}

// Define other methods and classes here
static void TastesLikeWinning() 
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
    int [] inputArr = Array.ConvertAll("2 2".Trim().Split(), Int32.Parse);
    int n = inputArr[0];
    int m = inputArr[1];
    long stones = (long)Math.Pow(2,m);
    List<int> stonesList = new List<int>();
    for(int x = 1; x < stones; x++)
    {
        stonesList.Add(x);
    }
    
    int counter = 0;
    if(n <= stones)
    {
        IEnumerable<IList<int>> _result = GetAllPermutations(stonesList,n);
        foreach(var listItem in _result)
        {
            int xorSum = 0;
            if(listItem.ToList().Distinct().Count() == n)
            {
                //Console.Write("(");
                foreach(var item in listItem)
                {
                   //Console.Write(item + ",");
                   xorSum ^= item;         
                }
                //Console.Write(")");
                //Console.WriteLine();
            }

            if(xorSum != 0)
                counter++;
            
            /*
            Console.Write("List Sum: " + listItem.Sum() + " ==> ( ");
            foreach(var item in listItem)
            {
                Console.Write(item + ",");
            }
            Console.Write(")");
            Console.WriteLine();
            //*/
        }

        //Console.WriteLine("Total Count: " + _result.Count());
        //Console.WriteLine("Counter: " + counter);
        Console.WriteLine(counter);

        /*        
        _result.ToList().ForEach(x => {
           if(x.ToList().Distinct().Count() == 1)
           {
               int init = x[0];
               Console.WriteLine("init: " + init);
               if(((init * n)  % 2 == 0) && ((n % 2 == 0) || (init % 2 != 0)))
                   continue;
           }
                
            x.ToList().ForEach(y => {
                Console.Write(y + " ");
            });
            Console.WriteLine();
        });
        //*/
    }
}

public static IEnumerable<IList<T>> GetAllPermutations<T>(IList<T> list, int length)
{
    if (list == null || list.Count == 0 || length <= 0)
    {
        yield break;
    }

    for (int i = 0; i < list.Count; i++)
    {
        var item = list[i];
        var initial = new[] { item };
        if (length == 1)
        {
            yield return initial;
        }
        else
        {
            foreach (var variation in GetAllPermutations(list.ToList(), length - 1))
            {
                int vari = Convert.ToInt32(variation[0]);
                int init = Convert.ToInt32(initial[0]);
                
                if((vari == init))
                    continue;
                
                yield return initial.Concat(variation).ToList();
            }
        }
    }
}
