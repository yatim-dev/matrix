using System;

namespace matrix
{
    class Program
    {
        public static int[] WriteNums(int cols)
        {
            int[] result = new int[cols];
            var stringNums = Console.ReadLine().Split(' ');
            for (int i = 0; i < cols; i++)
            {
                result[i] = int.Parse(stringNums[i]);

            }
            return result;
        }
        public static int[,] CreateMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] nums = WriteNums(cols);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }
            return matrix;
        }
        public static int[,] CreateRandomMatrix(int rows, int cols)
        {
            var random = new Random();
            var matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(0, 100);
                }
            }
            return matrix;
        }

        public static int[,] CreateUnitMatrix(int rows)
        {
            var random = new Random();
            var matrix = new int[rows, rows];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return matrix;
        }

        public static (int rows, int cols) ReadMatrixParams()
        {
            var words = Console.ReadLine().Split(' ');

            return (int.Parse(words[0]), int.Parse(words[1]));
        }
        private static void WriteMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)

            {

                Console.Write("|");
                Console.Write(" ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
        }


        public static void Main()
        {
            //           var matrixParams = ReadMatrixParams();
            var matrix = CreateUnitMatrix(3);
            WriteMatrix(matrix);
            Console.ReadLine();

        }


    }
}