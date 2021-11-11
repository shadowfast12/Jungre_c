using System;
using Jungre.attibut;

namespace Jungre.funct
{
    public class damage
    {
        //damage output with armor
        public double damg_put(string s, double ap, double ad, double ap_arm,
            double ad_arm, int ab_num)
        {
            double ap_ar = 1 - (ap_arm / 200);
            double ad_ar = 1 - (ad_arm / 200);
            double base_dm = monster.damg_base[(monster.id(s, monster.champs)
                                                * 3) - (4 - ab_num)];
            return (ap * (ap_ar)) + (ad * (ad_ar)) + (base_dm * (ap_ar)) + (base_dm * (ad_ar));
        }

        public double ability_out(string c, int abil, double a, double[] ar)
        {
            int id = (monster.id(c, monster.champs));
            return (ar[(id * 3) - (4 - abil)]) * a;
        }

        public static bool stunner(int id,int abil)
        {
            if (monster.stun[(id+1)*3-(4-abil)] >= ((double)random.randomize(1,10))/10)
            { 
                return true;
            }   
            return false;
        }
    }
}
