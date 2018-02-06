using System;
using System.Collections.Generic;
using System.Text;

namespace MegaCardGame2000_ClassLibrary.Characters
{
    public class NonPlayerCharacter : Character
    {
        public string EnemyType;

        //CONSTRUCTORS
        public NonPlayerCharacter(string enemyType, int maxHealth)
        {
            EnemyType = enemyType;
            MaxHealth = maxHealth;
        }
    }
}
 