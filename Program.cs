int[] indices = new int[] {1, 2, 3, 4, 5, 6, 7};
void GenerateSolution(int[] indeces, int n)
{
    if (n == 1)
    {
        EvaluateSolution();
    } else
    {
        for(int i = 0; i < n; i++)
        {
            GenerateSolution(indeces, n - 1);
            int swapIndex = (n % 2 == 0) ? i : 0;
            (indeces[swapIndex], indeces[n-1]) = (indeces[n-1], indeces[swapIndex]);
        }
    }
}
float bestTourDist = 99999;
int[] bestTourIndices = new int[] { 1, 2, 3, 4, 5, 6, 7 };
void EvaluateSolution()
{
    if (indices[0] < indices[^2])
    {
        float tourDist = 0;
        for(int i = 0; i < indices.Length; i++)
        {
            int nextIndex = (i + 1) % indices.Length;
            tourDist += LookUpDistance(indices[i], indices[nextIndex]);
        }

        if (tourDist < bestTourDist)
        {
            bestTourDist = tourDist;
            System.Array.Copy(indices, bestTourIndices, indices.Length);
        }
    }
}

Dictionary<(int, int), float> distances = new()
{
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

float LookUpDistance(int i, int b)
{
    if (!distances.ContainsKey((i, b)))
    {
        if (!distances.ContainsKey((b, i)))
            return 9999;
        else
            return distances[(b, i)];
    } else 
        return distances[(i, b)];
}
GenerateSolution(indices, indices.Length - 1);

foreach (int item in bestTourIndices)
{
    Console.Write(item + " => ");
}