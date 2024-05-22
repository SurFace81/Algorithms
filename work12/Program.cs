using System;

namespace work12
{
    internal class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    class TestClass
    {
        static void Main(string[] args)
        {
            Point[] points = new Point[10];

            Random rand = new Random();
            for (int i = 0; i < points.Length; i++)
            { 
                points[i] = new Point() { X = rand.NextDouble(), Y = rand.NextDouble() };
            }

            List<int> res = Grahamscan(points);
        }

        static double Rotate(Point A, Point B, Point C)
        {
            return (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
        }

        static List<int> Grahamscan(Point[] pnts)
        {
            int len = pnts.Length;

            int[] p = new int[len];
            for (int i = 0; i < len; i++)
                p[i] = i;

            for (int i = 0; i < len; i++)
            {
                if (pnts[p[i]].X < pnts[p[0]].X)
                {
                    (p[i], p[0]) = (p[0], p[i]);
                }
            }

            for (int i = 2; i < len; i++)
            {
                int j = i;
                while (j > i && Rotate(pnts[p[0]], pnts[p[j - 1]], pnts[p[j]]) < 0)
                {
                    (p[j], p[j - 1]) = (p[j - 1], p[j]);
                    j -= 1;
                }
            }

            List<int> result = new List<int>();
            result.Add(p[0]);
            result.Add(p[1]);

            return result;
        }
    }
}