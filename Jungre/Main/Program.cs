using System;
using Jungre.attibut;
using Jungre.funct;

namespace Jungre
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            monster m= new monster();
            user u= new user();
            altern a=new altern();
            attack at=new attack();
            ai_monst ai=new ai_monst();

            a.add(0,"Yargo");
            ai.set(0,"Electroid",1);
            at.battle("Yargo","Electroid");

        }
    }
}