using System;
using System.Collections.Generic;
using System.Text;

namespace serialization
{
    [Serializable]
    class PakShuka
    {
        private readonly string Address;
        private readonly long PhoneNumber;

        public PakShuka()
        {
            this.Address = "Mesrop Mashtots Ave, Yerevan";
            this.PhoneNumber = 37411999022;
        }

        public void ATMs() 
        {
            Console.WriteLine("All ATMs are ready except for VTB");
        }

        public void YerevanCitySup() 
        {
            Console.WriteLine("YerevanCity is ready");
        }

        public void PrintInfo()
        {
            Console.WriteLine("\nAddress: {0}, Phone number: {1}", Address, PhoneNumber);
        }

    }
}
