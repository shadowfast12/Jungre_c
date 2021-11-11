
using System;

namespace Jungre.attibut
{
    public class monster
    {
        public static string[] champs, abilities;

        public static double[] ap_d,
            ad_d,
            health,
            damg_base,
            ap_ar,
            ad_ar,
            stun;
        public monster()
        { 
            champs = new string[] {"Drago", "Yargo", "Electroid",
                "Gaswart"};
            abilities=new string[]
            {"Punch","Fire Spit","Fire Dash",
                "Kick","Rock Clap","Ground Slam",
                "Punch","Spark","Thunderbolt",
                "Expand","Cough","Atomic Burst"};
            health = new double[] {50,43,45,38};
            ap_d = new double[] {.1,1,.8,.1,.7,.2,.1,.8,.9,0,.8,1};
            ad_d = new double[] {.9,0,.2,.9,.3,.8,.9,.2,.1,0,.2,0};
            stun = new double[] {.3,0,0,0,0,.8,.3,.4,.7,0,.4,0};
            damg_base = new double[] {6,8,13,7,9,11,6,10,15,0,7,12};
            //out of base 200 armor ap/ad
            ap_ar = new double[] { 18,22,16,16};
            ad_ar = new double[] { 24,24,17,20};
        }
        //id finder
        public static int id(string s, string[] ar)
        { 
            for (int i=0;i<ar.Length;i++)
            {
                if (ar[i].Equals(s))
                {
                    return i;
                }
            }
            return -1;
        }

        public static string[] DtoStringarr(double[] arr)
        {
            string[] narr = new string[arr.Length];
            for (int i=0;i<narr.Length;i++)
            {
                narr[i] = arr[i].ToString();
            }
            return narr;
        }

        public static string[] ItoStringarr(int[] arr)
        {
            string[] narr = new string[arr.Length];
            for (int i=0;i<narr.Length;i++)
            {
                narr[i] = arr[i].ToString();
            }

            return narr;
        }
    }
}