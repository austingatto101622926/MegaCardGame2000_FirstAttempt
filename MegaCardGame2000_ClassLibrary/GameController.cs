using System;
using System.Collections.Generic;
using System.Text;
using MegaCardGame2000_ClassLibrary.Characters;
using MegaCardGame2000_ClassLibrary.Attacks;

namespace MegaCardGame2000_ClassLibrary
{
    public class GameController
    {
        public PlayerCharacter Player;
        public NonPlayerCharacter Enemy;
        public int EnemyCount;
        private List<NonPlayerCharacter> Deck;
        public GameState State = GameState.CharacterCreation;

        public enum GameState { CharacterCreation, PlayerTurn, EnemyTurn, Win, Lose };

        //METHODS
        public void CreateCharacter(string name, PlayerCharacter.Class Class)
        {
            switch (Class)
            {
                case PlayerCharacter.Class.Mage:
                    Player = new Mage(name);
                    break;
                case PlayerCharacter.Class.Thief:
                    Player = new Thief(name);
                    break;
                case PlayerCharacter.Class.Warrior:
                    Player = new Warrior(name);
                    break;
            }
        }

        public void CreateDeck()
        {
            Deck = new List<NonPlayerCharacter>();
            for (int i = 0; i < 10; i++)
            {
                Deck.Add(new NonPlayerCharacter("BAD GUY", RNG.IntInRange(10,25)));
            }
        }

        public void NextBattle()
        {
            if (Deck.Count == 0)
            {
                State = GameState.Win;
            }
            else
            {
                int selection = RNG.IntInRange(0, Deck.Count - 1);
                Enemy = Deck[selection];
                Deck.RemoveAt(selection);
                if (RNG.IntInRange(1, 2) == 1)
                {
                    State = GameState.EnemyTurn;
                }
                else
                {
                    State = GameState.PlayerTurn;
                }
                EnemyCount = Deck.Count;
            }
        }

        public void ResolveEnemyTurn()
        {
            Player.TakeDamage(Enemy.attack.Execute());
            if (Player.Health < 1)
            {
                State = GameState.Lose;
            }
            else
            {
                State = GameState.PlayerTurn;
            }
        }

        public void ResolvePlayerTurn(Attack attack)
        {
            Enemy.TakeDamage(attack.Execute());
        }
    }
}
