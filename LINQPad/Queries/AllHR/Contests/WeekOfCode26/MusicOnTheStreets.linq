<Query Kind="Program" />

void Main()
{
	MusicOnTheStreets();
}

// Define other methods and classes here
static void MusicOnTheStreets() 
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
    int n = Convert.ToInt32("2");
    int[] coordinatesArr = Array.ConvertAll("1 3".Split(), Int32.Parse);
    int[] inputArr2 = Array.ConvertAll("7 2 3".Split(), Int32.Parse);
    int totalMilesToTravel = inputArr2[0], minHour = inputArr2[1], maxHour = inputArr2[2];
    int milesLeftToTravel = 0,totalCoordinatesMiles = 0, output = 0, startIndexer = 0, endIndexer = -1;

        for (int x = 0; x < n; x++)
        {
            int curNo = coordinatesArr[x];
            if (x != n-1)
            {
                int nextNo = coordinatesArr[x + 1];
                if ((nextNo - curNo < minHour) || (nextNo - curNo > maxHour))
                {
                    if (totalCoordinatesMiles >= totalMilesToTravel)
                    {
                        endIndexer = x;
                        break;
                    }
                    startIndexer = x + 1;
                    totalCoordinatesMiles = 0;
                    continue;
                }
                totalCoordinatesMiles += (nextNo - curNo);
            }
        }

        if(endIndexer != -1)
        {
            milesLeftToTravel = totalCoordinatesMiles - totalMilesToTravel;
            if(milesLeftToTravel > 0)
            {
                if(coordinatesArr[endIndexer+1] - coordinatesArr[endIndexer] > maxHour)
                {
                    output = coordinatesArr[0];
                }
                else
                {
                    output = coordinatesArr[0] - milesLeftToTravel;
                }
            }
            else
                output = coordinatesArr[startIndexer];
        }
        else //if(startIndexer != -1)
        {
            milesLeftToTravel = totalMilesToTravel - totalCoordinatesMiles;
            if (milesLeftToTravel < minHour) output = coordinatesArr[0];
            else output = coordinatesArr[startIndexer] - minHour;
        }
    
    /*
    for (int x = n-1; x >= 0; x--)
    {
        int curNo = coordinatesArr[x];
        if (x != 0)
        {
            int prevNo = coordinatesArr[x - 1];
            if ((curNo - prevNo < minHour) || (curNo - prevNo > maxHour))
            {
                continue;
            }
            totalCoordinatesMiles += (curNo - prevNo);
        }
    }
    milesLeftToTravel = Math.Abs(totalMilesToTravel - totalCoordinatesMiles);
    if(milesLeftToTravel < minHour) output = milesLeftToTravel;
    else output = coordinatesArr[0] - minHour;
    */


    Console.WriteLine(output);
}
