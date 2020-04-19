using System;

namespace CovarianceWithDelegatesEx1
{
    class Vehicle
    {
        public Vehicle ShowVehicle()
        {
            Vehicle myVehicle = new Vehicle();
            Console.WriteLine("Vehicle オブジェクトが１つ作成されました");
            return myVehicle;
        }
    }

    class Bus : Vehicle
    {
        public Bus ShowBus()
        {
            Bus myBus = new Bus();
            Console.WriteLine("Bus オブジェクトが１つ作成されました");
            return myBus;
        }
    }

    class Program
    {
        public delegate Vehicle ShowVehicleTypeDelegate();

        static void Main(string[] args)
        {
            Vehicle vehicle1 = new Vehicle();
            Bus bus1 = new Bus();

            Console.WriteLine("*** C# 2.0 以降で可能なデリゲートの共変性 ***");
            ShowVehicleTypeDelegate del1 = vehicle1.ShowVehicle;
            del1();

            ShowVehicleTypeDelegate del2 = bus1.ShowBus;
            del2();

            Console.ReadKey();
        }
    }
}
