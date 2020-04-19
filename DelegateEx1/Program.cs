using System;

namespace DelegateEx1
{
    public delegate int Mydel(int x, int y);

    class Program
    {
        public static int Sum(int a, int b) { return a + b; }

        static void Main(string[] args)
        {

            Console.WriteLine("*** デリゲートの例　その１：簡単なデリゲートのデモ ***");
            int a = 25, b = 37;
            
            Console.WriteLine("\n デリゲートを使わずに Sum(...) メソッドを呼び出します：");
            Console.WriteLine("a と b の和は{0}", Sum(a, b));

            Mydel del = new Mydel(Sum);
            Console.WriteLine("\n 今からデリゲートを使います：");
            Console.WriteLine("\n デリゲートを使ってに Sum(...) メソッドを呼び出します：");
            Console.WriteLine("a と b の和は{0}", del(a, b));

            Console.ReadKey();
        }
    }
}
