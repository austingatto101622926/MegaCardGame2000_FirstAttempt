using System;
using System.Collections.Generic;
using System.Text;

namespace MegaCardGame2000_ClassLibrary
{
    public static class RNG
    {
        private static Random random = new Random();

        public static int IntInRange(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
