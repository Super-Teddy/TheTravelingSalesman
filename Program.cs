//The current route
int[] indices = new int[] { 1, 2, 3, 4, 5, 6, 7 };
void GenerateSolution(int[] indeces, int n)
{
    if (n == 1)
    {
        //End of route, check if the route is the best so far
        EvaluateSolution();
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            //Recursive stuff, Look at the next city
            GenerateSolution(indeces, n - 1);
            int swapIndex = (n % 2 == 0) ? i : 0;
            (indeces[swapIndex], indeces[n - 1]) = (indeces[n - 1], indeces[swapIndex]);
        }
    }
}
//How far the best rount is 
float bestTourDist = 99999;
//Stores the best route
int[] bestTourIndices = new int[] { 1, 2, 3, 4, 5, 6, 7 };

void EvaluateSolution()
{
    if (indices[0] < indices[^2])
    {
        //Add up all of the distances between points to find how far the route is.
        float tourDist = 0;
        for (int i = 0; i < indices.Length; i++)
        {
            int nextIndex = (i + 1) % indices.Length;
            //Add the distance between to points to the total distance
            tourDist += LookUpDistance(indices[i], indices[nextIndex]);
        }

        //If the current route is better that the stored rouste use the current route instead.
        if (tourDist < bestTourDist)
        {
            bestTourDist = tourDist;
            System.Array.Copy(indices, bestTourIndices, indices.Length);
        }
    }
}

//Stores distances between cities
Dictionary<(int, int), float> distances = new()
{
    //For example, the distance between city 1 and 2 is 12
    [(1, 2)] = 12,
    [(2, 4)] = 12,
    [(1, 7)] = 12,
    [(1, 3)] = 10,
    [(4, 6)] = 10,
    [(3, 4)] = 11,
    [(4, 5)] = 11,
    [(6, 7)] = 9,
    [(7, 3)] = 9,
    [(2, 3)] = 8,
    [(5, 7)] = 7,
    [(5, 6)] = 6,
    [(3, 5)] = 3,
};

//Returns the distance betwwen to citys using the Dictionary
float LookUpDistance(int i, int b)
{
    if (!distances.ContainsKey((i, b)))
    {
        if (!distances.ContainsKey((b, i)))
            return 9999;
        else
            return distances[(b, i)];
    }
    else
        return distances[(i, b)];
}

//Get the best route
GenerateSolution(indices, indices.Length - 1);

//Sort the route beacuse city #1 is not always first 
while(bestTourIndices[0] != 1)
{
    int first = bestTourIndices[0];
    for (int i = 1; i < bestTourIndices.Length; i++)
    {
        bestTourIndices[i - 1] = bestTourIndices[i];
    }
    bestTourIndices[^1] = first;
}

//Print the route
foreach (int item in bestTourIndices)
{
    Console.Write(item + " => ");
}

//Return to city #1
Console.Write("1");
