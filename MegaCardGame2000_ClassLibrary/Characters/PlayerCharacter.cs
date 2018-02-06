using System;
using System.Collections.Generic;
using System.Text;
using MegaCardGame2000_ClassLibrary.Attacks;

namespace MegaCardGame2000_ClassLibrary
{
    abstract public class PlayerCharacter : Character
    {
        public string Name;

        public enum Class { Mage, Thief, Warrior };
        public SpecialAttack specialAttack { get; protected set; }

        public abstract class SpecialAttack : Attack { }

        //CONSTRUCUTORS
        public PlayerCharacter(string name)
        {
            Name = name;
            MaxHealth = 50;
        }
    }
}
