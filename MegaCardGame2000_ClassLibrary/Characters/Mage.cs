using System;
using System.Collections.Generic;
using System.Text;

namespace MegaCardGame2000_ClassLibrary.Characters
{
    public class Mage : PlayerCharacter
    {
        private class Fireball : SpecialAttack
        {
            Mage Caster;
            public Fireball(Mage caster)
            {
                Caster = caster;
            }

            public override int Execute()
            {
                if (RNG.IntInRange(1,2) == 1)
                {
                    return _BaseDamage * 4;
                }
                else
                {
                    Caster.TakeDamage(_BaseDamage);
                    return 0;
                }
            }
        }

        //CONSTRUCTOR
        public Mage(string name) : base(name) { specialAttack = new Fireball(this); }
    }
}
