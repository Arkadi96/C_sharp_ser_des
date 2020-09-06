using System;
using System.Collections.Generic;
using System.Text;

namespace serialization
{
    class Tumo
    {
        private readonly string Address;
        private readonly long PhoneNumber;

        public Tumo()
        {
            this.Address = "Halabyan St., 16 Building";
            this.PhoneNumber = 37410398413;
        }
       
        public void CinemaStar()
        {
            Console.WriteLine("Cinema Works!");
        }

        public void ReferenceRooms()
        {
            Console.WriteLine("Reference rooms are open");
        }

        public void PrintInfo()
        {
            Console.WriteLine("\nAddress: {0}, Phone number: {1}", Address, PhoneNumber);
        }
    }
}
