using System;
using Jungre.attibut;

namespace Jungre.funct
{
    public class attack
    {
        private bool user_block,ai_block;
    damage d=new damage();
    input on=new input();

    private String insights(int i){
        String s="";
        for(int x=1;x<=3;x++){
            s+=("Ability "+x+" : "+monster.abilities[(monster.id(
                    user.inventory[i], monster.champs)*3)+(x-1)]+" : "+x*20+"\n");
        }
        return ("Name : "+user.inventory[i]+"\nHealth : "+user.health[i]+
                "/"+user.tot_health[i]+ "\nEnergy : "+user.energy[i]+"\n"+s);
    }
    private String ai_insights(int i){
        return("Name : "+ai_monst.inventory[i]+"\nHealth : "+ai_monst.health[i]+
                "\nEnergy : "+ai_monst.energy[i]+"\n");
    }

    private void u_ability(String uc,String mc,int a_num){
        double mult=1;
        if(ai_block){
            mult=0.5d;
        }

        if (damage.stunner(monster.id(uc,monster.champs),a_num))
        {
                ai_monst.stunned[monster.id(mc, ai_monst.inventory)] = true;
        }

        if (!user.stunned[monster.id(uc,user.inventory)])
        {
            double damage_dealt=(d.damg_put(uc,
                d.ability_out(uc,a_num,user.ap[monster.id(uc,user.inventory)],
                    monster.ap_d),d.ability_out(uc,a_num,user.ad[
                    monster.id(uc,user.inventory)], monster.ad_d),
                ai_monst.ap_ar[monster.id(mc,ai_monst.inventory)],
                ai_monst.ad_ar[monster.id(mc,ai_monst.inventory)],a_num))*mult;
            ai_monst.health[monster.id(mc,ai_monst.inventory)]-=damage_dealt;
            Console.WriteLine("You dealt "+damage_dealt +" damage");
            user.energy[monster.id(uc,user.inventory)]-=(a_num*20);
        }
        else
        {
            user.stunned[monster.id(uc, user.inventory)] = false;
            Console.WriteLine("You were stunned");
        }
    }
    private void ai_move(String uc,String mc){
        int m_id=monster.id(mc,ai_monst.inventory);
        int u_id=monster.id(uc, user.inventory);
        double mult=1;
        if(user_block){
            mult=0.5d;
            user_block=false;
        }
        for(int i=60;i>=20;i-=20){
            if(ai_monst.energy[m_id]>=i){
                if (damage.stunner(m_id,i/20))
                {
                    user.stunned[u_id] = true;
                }
                
                if (!ai_monst.stunned[m_id])
                {
                    double damage_dealt=(d.damg_put(mc,d.ability_out(mc,
                            i/20,ai_monst.ap[monster.id(mc,ai_monst.
                                inventory)],monster.ap_d),
                        d.ability_out(mc,
                            i/20,ai_monst.ad[monster.id(mc,
                                ai_monst.inventory)],monster.
                                ad_d), user.ad_ar[u_id],
                        user.ad_ar[u_id],i/20))*mult;
                    user.health[u_id]-=damage_dealt;
                    Console.WriteLine("Enemy dealt "+damage_dealt+" damage\n");
                    ai_monst.energy[m_id]-=i;
                }
                else
                {
                    ai_monst.stunned[m_id] = false;
                    Console.WriteLine("The Enemy was stunned.");
                }
                break;
            }
            else{
                ai_block=true;
            }
        }
    }
    private void p_move(String uc,String mc){
        string get=on.u_input("Action : ");
        if(get.Equals("1") && user.energy[monster.id(uc,user.inventory)]>=20){
            u_ability(uc,mc,1);
        }
        if(get.Equals("2") && user.energy[monster.id(uc,user.inventory)]>=40){
            u_ability(uc,mc,2);
        }
        if(get.Equals("3") && user.energy[monster.id(uc,user.inventory)]>=60){
            u_ability(uc,mc,3);
        }
        else{
            user_block=true;
        }
    }
    public void battle(String uc, String mc){
        user.energy[monster.id(uc,user.inventory)]=100;
        ai_monst.energy[monster.id(mc,ai_monst.inventory)]=100;
        while(true) {
            if(user.energy[monster.id(uc,user.inventory)]<=80){
                user.energy[monster.id(uc,user.inventory)]+=10;
            }
            if(ai_monst.energy[monster.id(mc,ai_monst.inventory)]<=80){
                ai_monst.energy[monster.id(mc,ai_monst.inventory)]+=10;
            }
            if (ai_monst.health[monster.id(mc, ai_monst.inventory)] <= 0 ||
                    user.health[monster.id(uc, user.inventory)] <= 0) {
                break;
            }

            Console.WriteLine(ai_insights(monster.id(mc, ai_monst.inventory)));
            Console.WriteLine(insights(monster.id(uc, user.inventory)));
            p_move(uc, mc);
            ai_move(uc, mc);
        }
    }

    }
}