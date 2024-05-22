using System;

namespace work11
{
    class TestClass
    {
        static int M = 41;
        public static void Main(string[] args)
        {
            string[] str = "This is a test str".Split(' ');
            foreach (string w in str)
            {
                Console.Write(hash(w) + " ");
            }
        }

        public static int hash(string val)
        {
            int h = 0;
            foreach (char ch in val)
            {
                h += hash(ch);
            }
            return h;
        }

        public static int hash(int val)
        {
            return val % M;
        }
    }
}