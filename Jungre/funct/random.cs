using System;

namespace Jungre.funct
{
    public class random
    {
        static Random r = new Random();
        public static int randomize(int min, int max)
        {
            return r.Next(min,max);
        }
    }
}