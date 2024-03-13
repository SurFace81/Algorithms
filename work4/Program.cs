using System;
using Random;

class TestClass
{
    static void Main(string[] args)
    {
        // int f0 = Convert.ToInt32(Console.ReadLine());
        // int f0 = 2363;
        Random.Random rnd = new Random.Random();
        double sum = 0;
        for (int i = 3170; i < 3170 + 128; i++)
        {
            double temp = rnd.randDouble(i);
            sum += temp;
            Console.WriteLine(temp);
        }

        Console.WriteLine("\n");
        double mr = sum / 128;
        Console.WriteLine(mr);

        sum = 0;
        for (int i = 3170; i < 3170 + 128; i++)
        {
            double temp = rnd.randDouble(i);
            sum += (temp - mr) * (temp - mr);
        }
        double D = sum / 128;
        Console.WriteLine(D);
        Console.WriteLine(Math.Sqrt(D));
    }
}