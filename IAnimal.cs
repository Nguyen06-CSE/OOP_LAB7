using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_TinhThuaKeVaDaHinh
{
    public interface IAnimal
    {
        int Age { get; set; }
        string Name {  get; set; }

        void Speak();
    }
}
