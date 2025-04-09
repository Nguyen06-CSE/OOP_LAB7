using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_TinhThuaKeVaDaHinh
{
    public class Lion : IAnimal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public void Speak()
        {
            Console.WriteLine("lion speaking");
        }
        public override string ToString()
        {
            return $"Lion - Name: {Name}, Age: {Age}";
        }
    }
}
