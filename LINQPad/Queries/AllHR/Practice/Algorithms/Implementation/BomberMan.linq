<Query Kind="Program" />

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	BomberMan();
	sw.Stop();
	Console.WriteLine();
	Console.WriteLine($"ElapsedTime:{sw.Elapsed}");
}

// Define other methods and classes here
public static void BomberMan()
{
	int [] rcn = "3 3 1".Split().Select(Int32.Parse).ToArray();
	string [] inputStr = new string[] { "..O", "...", "..O" };
	//int [] rcn = "6 7 6".Split().Select(Int32.Parse).ToArray();
	//string [] inputStr = new string[] { ".......", "...O...", "....O..", ".......",  "OO.....", "OO....." };
	//int [] rcn = "1 199 181054341".Split().Select(Int32.Parse).ToArray();
	//string [] inputStr = new string[] { "O..OO........O..O........OO.O.OO.OO...O.....OOO...OO.O..OOOOO...O.O..O..O.O..OOO..O..O..O....O...O....O...O..O..O....O.O.O.O.....O.....OOOO..O......O.O.....OOO....OO....OO....O.O...O..OO....OO..O...O" };
	/*output: OOOOO........OOOO........OOOOOOOOOO...O.....OOO...OOOOOOOOOOO...OOOOOOOOOOOOOOOOOOOOOOOOO....O...O....O...OOOOOOO....OOOOOOO.....O.....OOOOOOO......OOO.....OOO....OO....OO....OOO...OOOOO....OOOOO...O */
	
	//int [] rcn = "1 10 7".Split().Select(Int32.Parse).ToArray();
	//string [] inputStr = new string[] { "O..OO....." };
	
	int r = rcn[0], c = rcn[1], n = rcn[2];
	string [] input = new string[r];
	char[][] baseOutput = new char[r][];
	for(int i = 0; i < r; i++)
	{
		input[i] = inputStr[i];
		//output[i] = new String('O',c).Select(x => (int)x).ToArray();
		baseOutput[i] = Enumerable.Repeat('O', c).ToArray();
	}
	if(n % 2 == 0) for(int j = 0; j < r; j++) { Console.WriteLine(new string(baseOutput[j])); }
	else
	{
		var output = baseOutput.Select(a => a.ToArray()).ToArray();
		for(int row = 0; row < r; row++)
		{
			for(int col = 0; col < c; col++)
			{
				//Console.WriteLine($"{row} {col}");
				if(input[row][col] == 'O')  
				{
					output[row][col] = '.';
					if(row > 0) output[row - 1][col] = '.';
					if(row < r - 1) output[row + 1][col] = '.';
					if(col > 0) output[row][col - 1] = '.';
					if(col < c - 1) output[row][col + 1] = '.';
				}

			}
		}
	
		if(n == 1) { Console.WriteLine(string.Join(Environment.NewLine,input)); }
		else if(((n/2) & 1) != 0)
		{
			for(int j = 0; j < r; j++) { Console.WriteLine(new string(output[j])); }
		}
		else
		{
		
			//var temp = new char[r][];
			var temp = baseOutput.Select(a => a.ToArray()).ToArray();
			//output.Select(a => a.ToArray()).ToArray();
			//Console.WriteLine(temp);
			//Console.WriteLine(output);

			for(int row = 0; row < r; row++)
			{
				for(int col = 0; col < c; col++)
				{
					//Console.WriteLine($"{row} {col}");
					if(output[row][col] == 'O')  
					{
						temp[row][col] = '.';
						if(row > 0) temp[row - 1][col] = '.';
						if(row < r - 1) temp[row + 1][col] = '.';
						if(col > 0) temp[row][col - 1] = '.';
						if(col < c - 1) temp[row][col + 1] = '.';
					}
	
				}
			}
			//Console.WriteLine(temp);
			//Console.WriteLine(output);
			for(int j = 0; j < r; j++) { Console.WriteLine(new string(temp[j])); }
			//Console.WriteLine(string.Join(" ",input));
		}
	}
}

public static void BomberMan1()
{
	int [] rcn = "6 7 0".Split().Select(Int32.Parse).ToArray();
	int r = rcn[0], c = rcn[1], n = rcn[2];
	string [] inputStr = new string[] { ".......", "...O...", "....O..", ".......",  "OO.....", "OO....." };
	char [,] input = new char[r,c];
	char[,] output = new char[r,c];
	for(int row = 0; row < r; row++)
	{
		for(int col = 0; col < c; col++)
		{
			output[row,col] = 'O';
			input[row,col] = inputStr[row][col];
		}
	}
	//char[,] output = (char[,])input.Clone();
	Console.WriteLine(input);
	Console.WriteLine(output);

	if(n % 3 == 2) 
	{
		Console.WriteLine(new int[r,c]);
	}
	else
	{
		//Console.WriteLine(input);
		for(int i = 2; i <= n; i += 3)
		{
			for(int row = 0; row < r; row++)
			{
				for(int col = 0; col < c; col++)
				{
					
					//Console.WriteLine($"row:{row} col:{col} input[row,col]:{input[row,col]}");
					if(input[row,col] == 'O')  
					{
						output[row,col] = '.';
						if(row > 0) output[row - 1,col] = '.';
						if(row < r - 1) output[row + 1,col] = '.';
						if(col > 0) output[row,col - 1] = '.';
						if(col < c - 1) output[row,col + 1] = '.';
					}
					//Console.WriteLine(output);
				}
			}
		}
		//Console.WriteLine();
		Console.WriteLine(output);
	}
}

