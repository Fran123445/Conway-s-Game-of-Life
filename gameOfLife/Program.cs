using System;

namespace gameOfLife
{
    class Program
    {

        static void showCells(int[,] cells)
        {
            Console.SetCursorPosition(0, 0);
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


        static int countCells(int[,] cells, int[] cellPosition)
        {
            int count = 0;
            int[] steps = { -1, 0, 1 };
            
            foreach (var row in steps)
            {
                foreach (var column in steps)
                {
                    try
                    {
                        count += cells[cellPosition[0] + row, cellPosition[1] + column];
                    } catch (IndexOutOfRangeException) {
                        continue;
                    }
                }
            }

            return count;
        }

        static void step(int[,] cells)
        {
            int[,] originalState = new int[cells.GetLength(0), cells.GetLength(1)];
            int count;
            Array.Copy(cells, originalState, cells.Length);

            for (int i = 0;i < originalState.GetLength(0);i++)
            {
                for (int j = 0;j < originalState.GetLength(1);j++)
                {
                    count = countCells(originalState, new int[] { i, j });

                    if (originalState[i,j] != 0)
                    {
                        if (count-1 < 2 || count-1 > 3) // so it doesn't count itself
                        {
                            cells[i, j] = 0;
                        }
                    } else
                    {
                        if (count == 3)
                        {
                            cells[i, j] = 1;
                        }
                    }
                }
            }

        }

        static void Main()
        {
            int[,] cells = new int[10, 10];

            while (true)
            {
                showCells(cells);
                step(cells);
                System.Threading.Thread.Sleep(100);
            }

        }
    }
}
