using System;

namespace Quiz1OnDelegate
{
    public delegate int Mydel1(int x, int y);
    public delegate int Mydel2(int x, int y, int z);

    class A
    {
        public int Sum(int a, int b) { return a + b; }
        public int Sum(int a, int b, int c) { return a + b + c; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** デリゲートの問題 ***");
            int a = 25, b = 37, c = 100;
            A obA1 = new A();

            Mydel1 del1 = obA1.Sum;
            Console.WriteLine("\n del1は Sum(int a, int b) を指しています：");
            Console.WriteLine("a と b の和は{0}", del1(a, b));

            Mydel2 del2 = obA1.Sum;
            Console.WriteLine("\n del2は Sum(int a, int b, int c) を指しています：");
            Console.WriteLine("a と b と c の和は{0}", del2(a, b, c));

            Console.ReadKey();
        }
    }
}
