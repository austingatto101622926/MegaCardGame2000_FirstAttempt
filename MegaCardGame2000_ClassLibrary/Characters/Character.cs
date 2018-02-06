using System;
using MegaCardGame2000_ClassLibrary.Attacks;

namespace MegaCardGame2000_ClassLibrary
{
    abstract public class Character
    {
        protected static int _BaseDamage = 10;
        private int _maxHealth;
        public int MaxHealth
        {
            protected set { _maxHealth = value; _CurrentHealth = value; }
            get { return _maxHealth; }
        }
        private int _CurrentHealth;
        public int Health
        {
            get { return _CurrentHealth; }
            private set { }
        }

        public Attack attack = new NormalAttack();

        class NormalAttack : Attack
        {
            public override int Execute()
            {
                return _BaseDamage;
            }
        }

        //METHODS
        public void TakeDamage(int damage)
        {
            _CurrentHealth -= damage;
        }
    }
}
