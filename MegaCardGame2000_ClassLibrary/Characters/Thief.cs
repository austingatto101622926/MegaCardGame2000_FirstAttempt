using System;
using System.Collections.Generic;
using System.Text;

namespace MegaCardGame2000_ClassLibrary.Characters
{
    public class Thief : PlayerCharacter
    {
        private class Backstab : SpecialAttack
        {
            public override int Execute()
            {
                if (RNG.IntInRange(1, 3) == 1)
                {
                    return _BaseDamage * 2;
                }
                else
                {
                    return _BaseDamage/2;
                }
            }
        }

        //CONSTRUCTOR
        public Thief(string name) : base(name) { specialAttack = new Backstab(); }
    }
}
