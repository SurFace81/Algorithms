using System;

namespace Random
{
    internal class Random
    {
        public double randDouble(int seed)
        {
            seed *= seed;
            string f0 = seed.ToString().Substring(2, 4);

            if (f0[0] == '0')
            {
                var temp = seed.ToString();
                int f1 = Convert.ToInt32(leftShift(temp));
                int f2 = Convert.ToInt32(rightShift(temp));
                seed = f1 + f2;
            }

            seed = Convert.ToInt32(seed.ToString().Substring(2, 4));

            return Convert.ToDouble("0," + seed.ToString());
        }

        private string rightShift(string str)
        {
            string temp = str.Substring(0, 2);
            str = str.Remove(0, 2);
            return str.Insert(str.Length, temp);
        }

        private string leftShift(string str)
        {
            string temp = str.Substring(str.Length - 2);
            str = str.Remove(str.Length - 2);
            return temp + str;
        }
    }
}
