<Query Kind="Program" />

void Main()
{
	HardHomework();
}

// Define other methods and classes here
void HardHomework()
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
    int n = Convert.ToInt32("3".Trim());
    double output = 0.0;
    for(int x = 1; x <= n; x++)
    {
        for(int y = x; y >= x && y <= n; y++)
        {
            for(int z = y; z >= y && z <= n; z++)
            {
                //Console.WriteLine($"x: {x} y: {y} z: {z} -->Sum:{x + y + z} --->>Math.Sin(x):{Math.Sin(x)}  Math.Sin(y):{Math.Sin(y)}  Math.Sin(z):{Math.Sin(z)} ==>SUM:{Math.Sin(x) + Math.Sin(y) + Math.Sin(z)}");
                if( n == x + y + z)
                {
                    //Console.WriteLine($"####x: {x} y: {y} z: {z} ->Sum:{x + y + z} ->>Math.Sin(x):{Math.Sin(x)} Math.Sin(y):{Math.Sin(y)} Math.Sin(z):{Math.Sin(z)} =>SUM:{Math.Sin(x) + Math.Sin(y) + Math.Sin(z)}");
                    if(output < (Math.Sin(x) + Math.Sin(y) + Math.Sin(z)))
                    {
                        output = Math.Sin(x) + Math.Sin(y) + Math.Sin(z);   
                        //Console.WriteLine($"x: {x}  y: {y}  z: {z} --> {output}");
                    }
                }
            }
        }
    }
    //Console.WriteLine($"{output}");
    Console.WriteLine($"{Math.Round(output,9).ToString("0.000000000")}");
}
