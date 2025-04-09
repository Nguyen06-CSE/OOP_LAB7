using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_TinhThuaKeVaDaHinh
{
    public class Bird : IAnimal, IFlyable
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public void Fly()
        {
            Console.WriteLine("bird flying");
        }
        public void Speak()
        {
            Console.WriteLine("bird speaking");
        }
        public override string ToString()
        {
            return $"Bird - Name: {Name}, Age: {Age}";
        }
    }
}
