using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_TinhThuaKeVaDaHinh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuanLyDongVat ds = new QuanLyDongVat();
            ds.DocTuFile("C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\LAB7_TinhThuaKeVaDaHinh\\LAB7_TinhThuaKeVaDaHinh\\bin\\Debug\\data.txt");
            ds.PrintAnimals();
        }
    }
}
