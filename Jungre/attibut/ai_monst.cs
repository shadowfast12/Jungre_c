namespace Jungre.attibut
{
    public class ai_monst
    {
        public static string[] inventory;
        public static int[] level, energy;
        public static double[] health, ap, ad, ap_ar, ad_ar;
        public static int curr_id;

        public ai_monst()
        {
            inventory = new string[4];
            health = new double[4];
            level = new int[4];
            ad = new double[4];
            ap = new double[4];
            ad_ar = new double[4];
            ap_ar = new double[4];
            energy = new int[4];
            curr_id = 0;
        }

        public void set(int id, string s, int l)
        {
            inventory[id] = s;
            health[id] = monster.health[monster.id(s, monster.champs)];
            level[id] = l;
            ap[id] = l * 3;
            ad[id] = l * 3;
            ad_ar[id] = monster.ad_ar[monster.id(s, monster.champs)];
            ap_ar[id] = monster.ap_ar[monster.id(s, monster.champs)];
        }
    }
}