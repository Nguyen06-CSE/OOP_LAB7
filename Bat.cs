using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_TinhThuaKeVaDaHinh
{
    public class Bat : IAnimal, IFlyable
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public void Fly()
        {
            Console.WriteLine("bat flying");
        }
        public void Speak()
        {
            Console.WriteLine("bat speaking");
        }
        public override string ToString()
        {
            return $"Bat - Name: {Name}, Age: {Age}";
        }
    }
}
