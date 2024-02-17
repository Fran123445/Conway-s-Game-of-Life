using System;

namespace gameOfLife
{
    class Program
    {

        static void showCells(int[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i,j] != 0)
                    {
                        Console.Write("*");
                    } else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }

        static void Main()
        {
            int[,] cells = new int[11, 11];
        }
    }
}
