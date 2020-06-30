using System;

namespace Strawberry
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string lineRowsColsDays = Console.ReadLine();
            string rottenStrawberryOne = Console.ReadLine();
            string rottenStrawberryTwo = Console.ReadLine();

            string[] splitRowsColsDays = lineRowsColsDays.Split(new char[] { ' ' });
            int K = int.Parse(splitRowsColsDays[0]);
            int L = int.Parse(splitRowsColsDays[1]);
            int R = int.Parse(splitRowsColsDays[2]);

            string[] splitCoordStrawbOne = rottenStrawberryOne.Split(new char[] { ' ' });
            int RowRottenStrawberryOne = int.Parse(splitCoordStrawbOne[0]);
            int ColRottenStrawberryOne = int.Parse(splitCoordStrawbOne[1]);

            string[] splitCoordStrawbTwo = rottenStrawberryTwo.Split(new char[] { ' ' });
            int RowRottenStrawberryTwo = int.Parse(splitCoordStrawbTwo[0]);
            int ColRottenStrawberryTwo = int.Parse(splitCoordStrawbTwo[1]);


            int[,] strawberryGarden = new int[K, L];
            strawberryGarden[strawberryGarden.GetLength(0) - RowRottenStrawberryOne, ColRottenStrawberryOne - 1] = 1;
            strawberryGarden[strawberryGarden.GetLength(0) - RowRottenStrawberryTwo, ColRottenStrawberryTwo - 1] = 1;

            for (int i = 0; i < strawberryGarden.GetLength(0); i++)
            {
                for (int j = 0; j < strawberryGarden.GetLength(1); j++)
                {
                    if (strawberryGarden[i, j].Equals(null))
                        strawberryGarden[i, j] = 0;
                }
            }

            int tempVal = 1;
            for (int days = 1; days <= R; days++)
            {
                for (int r = 0; r < strawberryGarden.GetLength(0); r++)
                {
                    for (int c = 0; c < strawberryGarden.GetLength(1); c++)
                    {
                        if (strawberryGarden[r, c] == tempVal)
                        {
                            if ((r - 1 >= 0 && r + 1 <= strawberryGarden.GetLength(0) - 1)
                                && (c - 1 >= 0 && c + 1 <= strawberryGarden.GetLength(1) - 1))
                            {
                                if (strawberryGarden[r + 1, c] == 0) strawberryGarden[r + 1, c] = tempVal + 1;
                                if (strawberryGarden[r, c + 1] == 0) strawberryGarden[r, c + 1] = tempVal + 1;
                                if (strawberryGarden[r, c - 1] == 0) strawberryGarden[r, c - 1] = tempVal + 1;
                                if (strawberryGarden[r - 1, c] == 0) strawberryGarden[r - 1, c] = tempVal + 1;
                            }
                        }
                    }
                }
                tempVal++;
            }

            int counter = 0;
            for (int r = 0; r < strawberryGarden.GetLength(0); r++)
            {
                for (int c = 0; c < strawberryGarden.GetLength(1); c++)
                {
                    if (strawberryGarden[r, c] == 0) counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
