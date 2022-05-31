using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doAn2
{
    class ThuatToanKruskal
    {
        public static int soLuongCanh(maTranKe AM)
        {
            int Dem = 0;
            for (int i = 0; i < AM.n; i++)
            {
                for (int j = i + 1; j < AM.n; j++)
                {
                    if (AM.maTran[i, j] != 0)
                    {
                        Dem++;
                    }
                }
            }
            return Dem;
        }
        public static Canh[] dsTapCanh(maTranKe AM)
        {
            Canh[] tapCanh = new Canh[soLuongCanh(AM)];
            int indextapCanh = 0;
            for (int i = 0; i < AM.n; i++)
            {
                for (int j = i + 1; j < AM.n; j++)
                {
                    if (AM.maTran[i, j] != 0)
                    {
                        tapCanh[indextapCanh].Dau = i;
                        tapCanh[indextapCanh].Cuoi = j;
                        tapCanh[indextapCanh].trongSo = AM.maTran[i, j];
                        indextapCanh++;
                    }
                }
            }
            for (int i = 0; i <= tapCanh.Length - 2; i++)
            {
                for (int j = 0; j <= tapCanh.Length - 2; j++)
                {
                    if (tapCanh[j].trongSo > tapCanh[j + 1].trongSo)
                    {
                        Canh trungGian = tapCanh[j + 1];
                        tapCanh[j + 1] = tapCanh[j];
                        tapCanh[j] = trungGian;
                    }
                }
            }
            return tapCanh;
        }
        public static bool kiemTraChuTrinh(Canh[] tapCanh, int index, int[] Nhan)
        {
            if (Nhan[tapCanh[index].Dau] == Nhan[tapCanh[index].Cuoi])
            {
                return true;
            }
            return false;
        }
        public static int[] doiNhan(int a, int b, int[] Nhan)
        {
            int[] nhanMoi = Nhan;
            for (int i = 0; i < nhanMoi.Length; i++)
            {
                if (nhanMoi[i] == a)
                {
                    nhanMoi[i] = b;
                }
            }
            return nhanMoi;
        }
        public static Canh[] Kruskal(maTranKe AM)
        {
            Canh[] dsCanh = dsTapCanh(AM);
            Canh[] cayKhung = new Canh[AM.n - 1];
            int indexT = 0;
            int[] Nhan = new int[AM.n];
            int indexCanhMin = 0;
            for (int i = 0; i < Nhan.Length; i++)
            {
                Nhan[i] = i;
            }
            while (indexT < AM.n - 1)
            {
                if (kiemTraChuTrinh(dsCanh, indexCanhMin, Nhan) == false)
                {
                    Nhan = doiNhan(Nhan[dsCanh[indexCanhMin].Cuoi], Nhan[dsCanh[indexCanhMin].Dau], Nhan);
                    cayKhung[indexT] = dsCanh[indexCanhMin];
                    indexCanhMin++;
                    indexT++;
                }
                else
                {
                    indexCanhMin++;
                    continue;
                }
            }
            return cayKhung;
        }
    }
}
