using System;
using Jungre.attibut;

namespace Jungre.funct
{
    public class altern
    {
        //set user variables
        public void set_inven(int id,string s){
            user.inventory[id]=s;
        }
        public void set_health(int id,double h){
            user.health[id]=h;
        }
        public void set_tot_health(int id,double h){
            user.tot_health[id]=h;
        }
        public void set_level(int id,int l){
            user.level[id]=l;
        }
        public void set_exp(int id,double e){
            user.exp[id]=e;
        }
        public void set_ap(int id,double a){
            user.ap[id]=a;
        }
        public void set_ad(int id,double a){
            user.ad[id]=a;
        }
        public void set_ap_ar(int id,double a){
            user.ap_ar[id]=a;
        }
        public void set_ad_ar(int id, double a){
            user.ad_ar[id]=a;
        }

        //add monster to user inventory
        public void add(int id,String s){
            set_inven(id,s);
            set_health(id,monster.health[monster.id(s,monster.champs)]);
            set_tot_health(id,monster.health[monster.id(s,monster.champs)]);
            set_level(id,1);
            set_exp(id,0);
            set_ap(id,0);
            set_ad(id,0);
            set_ad_ar(id,monster.ad_ar[monster.id(s,monster.champs)]);
            set_ap_ar(id,monster.ap_ar[monster.id(s,monster.champs)]);
        }   
        public void level_up(int id){
            set_tot_health(id,user.health[id]+5);
            set_level(id,user.level[id]+1);
            set_exp(id,0);
            set_ap(id,user.ap[id]+3);
            set_ad(id,user.ad[id]+3);
        }

    }
}