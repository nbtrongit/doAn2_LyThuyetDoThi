using System;
using System.IO;    

namespace doAn2
{
    class Program
    {
        public static maTranKe maTran(string filename)
        {
            maTranKe AM;
            string[] a = File.ReadAllLines(filename);
            AM.n = int.Parse(a[0]);
            AM.maTran = new int[AM.n, AM.n];
            int b = 0;
            for (int i = 1; i < a.Length; i++)
            {
                string[] d = a[i].Split(' ');
                for (int j = 0; j < d.Length; j++)
                {
                    AM.maTran[b, j] = int.Parse(d[j]);
                }
                b++;
            }
            return AM;
        }
        public static void doiDau(maTranKe AM)
        {
            for (int i = 0; i < AM.n; i++)
            {
                for (int j = 0; j < AM.n; j++)
                {
                    AM.maTran[i, j] = -1 * AM.maTran[i, j];
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập vào đường dẫn file/tên file");
            string filename = Console.ReadLine();
            if (!File.Exists(filename))
            {
                Console.WriteLine("File không tồn tại");
            }
            else
            {
                maTranKe AM = maTran(filename);
                Canh[] cayKhung = ThuatToanKruskal.Kruskal(AM);
                int tong = 0;
                Console.WriteLine("Chi phí lắp đặt nhỏ nhất");
                for (int i = 0; i < cayKhung.Length; i++)
                {
                    Console.WriteLine($"{cayKhung[i].Dau} - {cayKhung[i].Cuoi}: {cayKhung[i].trongSo}");
                    tong += cayKhung[i].trongSo;
                }
                Console.WriteLine($"Tổng chi phí: {tong}");

                Console.WriteLine();
                doiDau(AM);
                cayKhung = ThuatToanKruskal.Kruskal(AM);
                Console.WriteLine("Chi phí lắp đặt lớn nhất");
                tong = 0;
                for (int i = 0; i < cayKhung.Length; i++)
                {
                    Console.WriteLine($"{cayKhung[i].Dau} - {cayKhung[i].Cuoi}: {-1 * cayKhung[i].trongSo}");
                    tong += -1 * cayKhung[i].trongSo;
                }
                Console.WriteLine($"Tổng chi phí: {tong}");
            }
        }
    }
}
