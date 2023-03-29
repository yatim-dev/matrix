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
                Console.WriteLine(BuildingString(matrix, i));
        }

        private static string BuildingString(int[,] matrix, int i)
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
                    matrix[i, j] *= number;
                    
            return matrix;
        }
        
        public static int[,] AddMatrix(int[,] matrix, int[,] matrix1 )
        {
            var addMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            if ((matrix.GetLength(0) == matrix1.GetLength(0)) && (matrix.GetLength(1) == matrix1.GetLength(1)))
                for (var i = 0; i < addMatrix.GetLength(0); i++)
                    for (var j = 0; j < addMatrix.GetLength(1); j++)
                        addMatrix[i, j] = matrix[i, j] + matrix1[i, j];
            else
                throw new Exception("матрица разных размеров");

            return addMatrix;
        }

        public static void Main()
        {
            var matrix = CreateRandomMatrix(3,3);
            var matrix1 = CreateRandomMatrix(3, 3);   
            WriteMatrix(matrix);
            Console.WriteLine();
            WriteMatrix(matrix1);
            Console.WriteLine();
            WriteMatrix(AddMatrix(matrix, matrix1));
            Console.ReadLine();
        }
    }
}