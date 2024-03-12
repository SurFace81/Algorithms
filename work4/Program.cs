using System;
using Random;

class TestClass
{
    static void Main(string[] args)
    {
        // int f0 = Convert.ToInt32(Console.ReadLine());
        // int f0 = 2363;
        int f0 = 3170;

        Random.Random rnd = new Random.Random();
        Console.WriteLine(rnd.randDouble(f0));
    }
}