using System;
using System.IO;
using Jungre.attibut;

namespace Jungre.funct
{
    public class savload
    {
        private string[] save = new string[45];
        public void add(int curr,string[] arr)
        {
            for (int i=0;i<4;i++)
            {
                save[(curr*5)+i] = arr[i];
            }
        }
        public void saveln(string file)
        {
            add(0,user.inventory);
            add(1,monster.DtoStringarr(user.health));
            add(2,monster.DtoStringarr(user.tot_health));
            add(3,monster.ItoStringarr(user.level));
            add(4,monster.DtoStringarr(user.exp));
            add(5,monster.DtoStringarr(user.ad));
            add(6,monster.DtoStringarr(user.ap));
            add(7,monster.DtoStringarr(user.ap_ar));
            add(8,monster.DtoStringarr(user.ad_ar));
            File.WriteAllLines(file,save);
        }
    }
}