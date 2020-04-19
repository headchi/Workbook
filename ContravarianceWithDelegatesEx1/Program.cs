using System;

namespace ContravarianceWithDelegatesEx1
{
    class Vehicle
    {
        public void ShowVehicle(Vehicle myV)
        {
            Console.WriteLine("Vehicle.ShowVehicle");
        }
    }

    class Bus : Vehicle
    {
        public void ShowBus(Bus myB)
        {
            Console.WriteLine("Bus.ShowBus");
        }
    }

    class Program
    {
        public delegate void TakingDerivedTypeParameterDelegate(Bus v);

        static void Main(string[] args)
        {
            Vehicle vehicle1 = new Vehicle();
            Bus bus1 = new Bus();

            Console.WriteLine("*** C#のデリゲートで反変性を実験 ***");

            // 普通の使い方
            TakingDerivedTypeParameterDelegate del1 = bus1.ShowBus;
            del1(bus1);

            // 特殊な使い方
            // 反変性
            /*
             * デリゲートは派生型の bus オブジェクトのパラメータに
             * 受け取るメソッドを指すように定義されているが、
             * 基本型の Vehicle オブジェクトをパラメータにとるメソッドも
             * 指せる点に注目
             */
            TakingDerivedTypeParameterDelegate del2 = vehicle1.ShowVehicle;
            del2(bus1);
            // 注意：ここでは Vehicle オブジェクトをパラメータに取れない
            //del2(vehicle1); // これはエラー

            Console.ReadKey();
        }
    }
}
