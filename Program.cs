using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_TinhThuaKeVaDaHinh
{
    internal class Program
    {
        public enum ThucDon
        {
            NhapTuFile = 1,
            ThemVaoDanhSach,
            ToStringDanhSach,
            DemSoDongVatTheoLoai,
            DemSoDongVatBietBayVaKhong,
            DemSoDongVatBietBayTheoTenTuoi,
            TimDongVatCoSoLuongItNhatNhieuNhat,
            TimDongVatTheoLoai,
            TimDongVatTenDaiNhatVaNganNhat,
            TimDongVatTuoiLonNhatVaNhoNhat,
            TimDongVatTenDaiNhatNganNhatTheoLoai,
            TimDongVatTuoiLonNhatNhoNhatTheoLoai,
            DanhSachKhongBietBay,
            DanhSachBietBay,
            SapXepTheoTenTuoi,
            XoaTheoLoai,
            XoaBietBay,
            XoaKhongBietBay,
            XoaKhongBietBayTheoTenTuoi,
            XoaTheoLoaiCoTuoiNhoNhatLonNhat,
            XoaDongVatTrongDanhSach,
            XoaDongVatTaiViTriX,
            TinhTongTuoiTheoLoai,
            TinhTongTuoiBietBayVaKhong,
            ThemDongVatVaoViTriNaoDo,
            SapXepGiamDanTenTuoi,
            XepThanhNhom,
            XuatMoiNhom,
            Thoat
        }



        static void Main(string[] args)
        {
            QuanLyDongVat ds = new QuanLyDongVat();
            string tenFile = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\LAB7_TinhThuaKeVaDaHinh\\LAB7_TinhThuaKeVaDaHinh\\bin\\Debug\\data.txt";
            ds.DocTuFile(tenFile);
            ds.PrintAnimals();


            while (true)
            {
                string name;
                int age, location;
                Console.Clear();
                Console.WriteLine("Chon chuc nang:");
                foreach (var item in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)item}. {item}");
                }

                Console.Write("Nhap lua chon: ");
                ThucDon chon = (ThucDon)int.Parse(Console.ReadLine());

                switch (chon)
                {
                    
                    case ThucDon.NhapTuFile:
                        ds.DocTuFile(tenFile);
                        break;
                    case ThucDon.ThemVaoDanhSach:
                        ds.AddAnimal();
                        break;
                    case ThucDon.ToStringDanhSach:
                        break;
                    case ThucDon.DemSoDongVatTheoLoai:
                        Console.WriteLine($"so luong loai Bat, Lion, Bird lan luot la" + ds.CountBat() + " " + ds.CountLiom() + " " + ds.CountBird());
                        break;
                    case ThucDon.DemSoDongVatBietBayVaKhong:
                        Console.WriteLine($"so luong dong vat biet bay va khong biet bay lan luot la: " + ds.CountFly() + " " + ds.CountNonFly());
                        break;
                    case ThucDon.DemSoDongVatBietBayTheoTenTuoi:
                        Console.WriteLine("nhap ten dong vat ban muon dem: ");
                        name = Console.ReadLine();
                        Console.WriteLine("nhap tuoi dong vat ban muon dem: ");
                        age = int.Parse(Console.ReadLine());

                        Console.WriteLine($"so luong dong vat bet bay theo ten tuoi la: " + ds.CountFlyWithAgeAndName(name, age));
                        Console.WriteLine($"so luong dong vat khong biet bay theo ten tuoi la: " + ds.CountNonFlyWithAgeAndName(name, age));
                        break;
                    case ThucDon.TimDongVatCoSoLuongItNhatNhieuNhat:
                        Console.WriteLine($"dong vat co so luong nhieu nhat la: " + ds.FindHighestAnimal());
                        Console.WriteLine($"dong vat co so luong it nhat la: " + ds.FindLeastAnimal());
                        break;
                    case ThucDon.TimDongVatTheoLoai:

                        Console.WriteLine("cac dong vat thuoc loai Bat la:");
                        List<string> bat = new List<string>(ds.FindBreedOfBat());
                        ds.PrintArrayString(bat);

                        Console.WriteLine("cac dong vat thuoc loai Lion la:");
                        List<string> lion = new List<string>(ds.FindBreedOfLion());
                        ds.PrintArrayString(lion);

                        Console.WriteLine("cac dong vat thuoc loai Bird la:");
                        List<string> bird = new List<string>(ds.FindBreedOfBird());
                        ds.PrintArrayString(bird);
                        break;
                    case ThucDon.TimDongVatTenDaiNhatVaNganNhat:
                        Console.WriteLine($"dong vat co ten dai nhat va ngan nhat lan luot la: " + ds.FindTheLongestName() + " " + ds.FindTheLeastName());
                        break;
                    case ThucDon.TimDongVatTuoiLonNhatVaNhoNhat:
                        Console.WriteLine($"dong vat co tuoi lon nhat va nho nhat lan luot la:" + ds.FindTheOldest() + " " + ds.FindTheYoungest());
                        break;
                    case ThucDon.TimDongVatTenDaiNhatNganNhatTheoLoai:

                        Console.WriteLine($"dong vat co ten dai nhat theo loai la: ");
                        List<string> longName = new List<string>(ds.FindTheLengestOfNameByBreed());
                        ds.PrintArrayString( longName );

                        Console.WriteLine($"dong vat co ten ngan nhat theo loai la: ");
                        List<string> shortName = new List<string>(ds.FindTheShortestOfNameByBreed());
                        ds.PrintArrayString(shortName);
                        break;
                    case ThucDon.TimDongVatTuoiLonNhatNhoNhatTheoLoai:
                        Console.WriteLine($"dong vat co tuoi nho nhat va lon nhat lan luot la: " + ds.FindTheOldest() + " " + ds.FindTheYoungest());
                        break;
                    case ThucDon.DanhSachKhongBietBay:
                        Console.WriteLine("danh sach dong vat khong biet bay la");
                        List<IAnimal> animalCanNotFly = new List<IAnimal>(ds.FindCanNotFlyingAnimals());
                        foreach(var item in animalCanNotFly)
                        {
                            Console.WriteLine(item);
                        }
                        
                        break;
                    case ThucDon.DanhSachBietBay:
                        Console.WriteLine("danh sach dong vat biet bay la");
                        List<IAnimal> animalCanFly = new List<IAnimal>(ds.FindFlyingAnimals());
                        foreach (var item in animalCanFly)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case ThucDon.SapXepTheoTenTuoi:
                        Console.WriteLine("danh sach sau khi sap xep tang theo ten la: ");
                        ds.SortByNameAscending();
                        ds.PrintAnimals();
                        Console.WriteLine("danh sach sau khi sap xep giam theo ten la: ");
                        ds.SortByNameDescending();
                        ds.PrintAnimals();

                        Console.WriteLine("danh sach sau khi sap xep tang theo tuoi la: ");
                        ds.SortByAgeAscending();
                        ds.PrintAnimals();
                        Console.WriteLine("danh sach sau khi sap xep giam theo tuoi la: ");
                        ds.SortByAgeDescending();
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XoaTheoLoai:
                        Console.WriteLine("nhap loai ban muon xoa tat ca dong vat");
                        string loai = Console.ReadLine();
                        ds.RemoveAnimalsByType(loai);
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XoaBietBay:
                        Console.WriteLine("danh sach sau khi da xoa dong vat biet bay");
                        ds.RemoveAnimalsCanFly();
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XoaKhongBietBay:
                            Console.WriteLine("danh sach sau khi da xoa dong vat khong biet bay");
                            ds.RemoveAnimalsCanNotFly();
                            ds.PrintAnimals();
                        
                        break;
                    case ThucDon.XoaKhongBietBayTheoTenTuoi:
                        Console.WriteLine("nhap ten dong vat ban muon dem: ");
                        name = Console.ReadLine();
                        Console.WriteLine("nhap tuoi dong vat ban muon dem: ");
                        age = int.Parse(Console.ReadLine());
                        ds.RemoveAnimalsCanNotFlyByNameAndAge(age, name);
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XoaTheoLoaiCoTuoiNhoNhatLonNhat:
                        Console.WriteLine("danh sach sau khi da xoa tat ca dong vat co tuoi nho nhat");
                        ds.EraseAllAnimalsYoungest();
                        ds.PrintAnimals();
                        Console.WriteLine("danh sach sau khi da xoa tat ca dong vat co tuoi lon nhat");
                        ds.EraseAllAnimalsOldest();
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XoaDongVatTrongDanhSach:
                        Console.WriteLine("danh sach sau khi xoa dong vat la: ");
                        ds.EreaseAnimals();
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XoaDongVatTaiViTriX:
                        Console.WriteLine("nhap vi tri ban muon xoa");
                        location = int.Parse(Console.ReadLine());
                        ds.EreaseAtPositionX(location);
                        ds.PrintAnimals();
                        break;
                    case ThucDon.TinhTongTuoiTheoLoai:
                        Console.WriteLine("tong tuoi cua tung loai lan luot la: ");

                        List<(int, string)> results = new List<(int, string)>(ds.CaculateTheTotalAgeBySpecie());
                        foreach (var result in results)
                        {
                            Console.WriteLine($"{result.Item2}: {result.Item1}");
                        }
                        break;
                    case ThucDon.TinhTongTuoiBietBayVaKhong:
                        Console.WriteLine($"tong tuoi cua dong vat biet bay la: " + ds.CaculateTheTotalAgeCanFly());
                        Console.WriteLine($"tong tuoi cua dong vat khong biet bay la: " + ds.CaculateTheTotalAgeCanNotFly());
                        break;
                    case ThucDon.ThemDongVatVaoViTriNaoDo:
                        Console.WriteLine("nhap vi tri ban muon chen vao: ");
                        location = int.Parse(Console.ReadLine());
                        ds.AddAnimalAtPosition( location );
                        ds.PrintAnimals();
                        break;
                    case ThucDon.SapXepGiamDanTenTuoi:
                        Console.WriteLine("danh sach sau khi sap xeo tang theo ten");
                        ds.SortByNameAscending();
                        ds.PrintAnimals();
                        Console.WriteLine("danh sach sau khi sap xeo giam theo ten");
                        ds.SortByNameDescending();
                        ds.PrintAnimals();

                        Console.WriteLine("danh sach sau khi sap xeo tang theo tuoi");
                        ds.SortByAgeAscending();
                        ds.PrintAnimals();
                        Console.WriteLine("danh sach sau khi sap xeo giam theo tuoi");
                        ds.SortByAgeDescending();
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XepThanhNhom:
                        //ds.DisplayAnimalsGrouped();
                        ds.GetSortedByGroup();
                        ds.PrintAnimals();
                        break;
                    case ThucDon.XuatMoiNhom:
                        Console.WriteLine("sap xep giam theo tuoi");
                        ds.DisplayAnimalsGrouped_AscendingByAge();
                        Console.WriteLine("sap xep tang theo tuoi");
                        ds.DisplayAnimalsGrouped_DecendingByAge();
                        Console.WriteLine("sap xep tang theo ten");
                        ds.DisplayAnimalsGrouped_AscendingByName();
                        Console.WriteLine("sap xep giam theo ten");
                        ds.DisplayAnimalsGrouped_DecendingByName();
                        break;
                    case ThucDon.Thoat:
                        return;
                }

                Console.WriteLine("\nNhan Enter de tiep tuc...");
                Console.ReadLine();
            }

        }
    }
}
