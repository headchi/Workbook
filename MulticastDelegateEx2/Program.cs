using System;

namespace MulticastDelegateEx2
{
    public delegate int MultiDel(int a, int b);

    class Program
    {
        public static int Sum(int a, int b)
        {
            Console.Write("Program.Sum->\t");
            Console.WriteLine("和は{0}", a + b);
            return a + b;
        }

        public static int Difference(int a, int b)
        {
            Console.Write("Program.Difference->\t");
            Console.WriteLine("差は{0}", a - b);
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            Console.Write("Program.Multiply>\t");
            Console.WriteLine("積は{0}", a * b);
            return a * b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*** マルチキャストデリゲートのテスト ***");
            MultiDel md = Sum;
            md += Difference;
            md += Multiply;
            int c = md(10, 5);

            Console.WriteLine("c の値を解析");
            Console.WriteLine("c={0}", c);
            Console.ReadKey();
        }
    }
}
