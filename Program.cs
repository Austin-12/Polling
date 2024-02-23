using System;

class Program
{
    static void Main(string[] args)
    {
        string[] topics = { "Climate Change", "Poverty", "War", "Racial Injustice", "Access to Education" };
        int[,] responses = new int[5, 10];
        int[] totalPoints = new int[5];
        int[] numberOfRatings = new int[5];

        // Polling loop
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < topics.Length; i++)
            {
                Console.WriteLine($"Rate the importance of '{topics[i]}' from 1 to 10 (Rating {j + 1}):");
                int rating = int.Parse(Console.ReadLine());
                responses[i, j] = rating;
                totalPoints[i] += rating;
                numberOfRatings[i]++;
            }
            Console.WriteLine();
        }

        // Display summary
        Console.WriteLine("Summary of Survey Responses:");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Topic                 | Ratings         | Average Rating");
        Console.WriteLine("----------------------------------------------------------");
        for (int i = 0; i < topics.Length; i++)
        {
            Console.Write($"{topics[i],-20} | ");
            for (int j = 0; j < 10; j++)
            {
                Console.Write($"{responses[i, j]} ");
            }
            double averageRating = (double)totalPoints[i] / numberOfRatings[i];
            Console.WriteLine($"| {averageRating:F2}");
        }
        Console.WriteLine("----------------------------------------------------------");

        // Find highest and lowest point total
        int highestTotal = totalPoints[0];
        int lowestTotal = totalPoints[0];
        int highestIndex = 0;
        int lowestIndex = 0;
        for (int i = 1; i < totalPoints.Length; i++)
        {
            if (totalPoints[i] > highestTotal)
            {
                highestTotal = totalPoints[i];
                highestIndex = i;
            }
            if (totalPoints[i] < lowestTotal)
            {
                lowestTotal = totalPoints[i];
                lowestIndex = i;
            }
        }

        Console.WriteLine($"The issue with the highest point total is '{topics[highestIndex]}' with {highestTotal} points.");
        Console.WriteLine($"The issue with the lowest point total is '{topics[lowestIndex]}' with {lowestTotal} points.");
    }
}
