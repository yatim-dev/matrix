using System;
using System.Numerics;
using System.Text;

namespace matrix
{
    class Program
    {
        public static int[] WriteNums(int cols)
        {
            var result = new int[cols];
            var stringNums = Console.ReadLine().Split(' ');
            for (var i = 0; i < cols; i++) 
                result[i] = int.Parse(stringNums[i]);
            return result;
        }

        public static int[,] CreateMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var nums = WriteNums(cols);
                for (var j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = nums[j];
            }
            return matrix;
        }

        public static int[,] CreateRandomMatrix(int rows, int cols, int minArg = 0, int maxArg = 100)
        {
            var random = new Random();
            var matrix = new int[rows, cols];

            for (var i = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(minArg, maxArg);
            return matrix;
        }

        public static int[,] CreateUnitMatrix(int rows)
        {
            var matrix = new int[rows, rows];

            for (var i = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < matrix.GetLength(1); j++)
                    _ = i == j ? matrix[i, j] = 1 : matrix[i, j] = 0;
            return matrix;
        }

        public static (int rows, int cols) ReadMatrixParams()
        {
            var words = Console.ReadLine().Split(' ');
            return (int.Parse(words[0]), int.Parse(words[1]));
        }

        private static void WriteMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(BildingString(matrix, i));
            }
        }
        private static string BildingString(int[,] matrix, int i)
        {
            var stringBuilder = new StringBuilder("| ");
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                stringBuilder.Append(matrix[i, j]);
                stringBuilder.Append(" ");
            }
            stringBuilder.Append("|");
            return stringBuilder.ToString();
        }

        public static int[,] NumMul(int[,] matrix, int number)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = matrix[i,j] * number;
            return matrix;
        }

        public static void Main()
        {
            //           var matrixParams = ReadMatrixParams();
            var matrix = CreateRandomMatrix(3,3);
            WriteMatrix(matrix);
            WriteMatrix(NumMul(matrix,3)) ;
            Console.ReadLine();
        }
    }
}
