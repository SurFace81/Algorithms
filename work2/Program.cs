using System;
using MathMatrix;

class TestClass
{
    static void Main(string[] args)
    {
        // Answer:
        //  [-1, 5][1, -1]
        Matrix matrixA = new Matrix(2, 2, new double[] { 3, 7, 2, 8 });
        Matrix matrixB = new Matrix(2, 2, new double[] { 4, 8, 6, 2 });
        printMatrix(matrixA.inv() * matrixB);
        Console.WriteLine();


        // Answer:
        //  [0.58, -1.06, 0.16][-3.14, -1.02, -2.28][3.06, 0.58, 2.12]
        Matrix matrixC = new Matrix(3, 3, new double[] { 2, 2, 2, 1, -3, 0, -4, -1, 3 });
        Matrix matrixD = new Matrix(3, 3, new double[] { 1, -3, 0, 10, 2, 7, 10, 7, 8 });
        printMatrix(matrixC.inv() * matrixD);
        Console.WriteLine();


        // Answer:
        //  [1, 2, 3][4, 5, 6]
        Matrix matrixE = new Matrix(2, 2, new double[] { 2, 3, 5, 4 });
        Matrix matrixF = new Matrix(2, 3, new double[] { 14, 19, 24, 21, 30, 39  });
        printMatrix(matrixE.inv() * matrixF);
    }

    static void printMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                //Console.Write(matrix[i, j]);
                Console.Write(Math.Round(matrix[i, j], 2).ToString().PadLeft(5));
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}