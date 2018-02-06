using System;
using System.Collections.Generic;
using System.Text;

namespace MegaCardGame2000_ClassLibrary.Characters
{
    public class Warrior : PlayerCharacter
    {
        private class Beserk : SpecialAttack
        {
            public override int Execute()
            {
                if (RNG.IntInRange(1, 3) == 1)
                {
                    return _BaseDamage * 3;
                }
                else
                {
                    return 0;
                }
            }
        }

        //CONSTRUCTOR
        public Warrior(string name) : base(name) { specialAttack = new Beserk(); }
    }
}
