using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MegaCardGame2000_ClassLibrary;

namespace MegaCardGame2000_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Battle.xaml
    /// </summary>
    public partial class Battle : Page
    {
        public GameController GameController;
        public Battle(GameController gameController)
        {
            InitializeComponent();

            GameController = gameController;
            GameController.CreateDeck();
            NextBattle();
        }

        void NextBattle()
        {
            GameController.NextBattle();
            if (GameController.State == GameController.GameState.Win) NavigationService.Navigate(new Win());//NAVIGATE TO WIN SCREEN
            UpdateDisplay();
            if (GameController.State == GameController.GameState.EnemyTurn) EnemyTurn();
        }

        void UpdateDisplay()
        {
            OutputTurn.Text = "State: " + GameController.State.ToString();
            OutputEnemyCount.Text = GameController.EnemyCount + " Enemies Left";

            OutputPlayerName.Text = GameController.Player.Name;
            OutputPlayerHealth.Text = "(" + GameController.Player.Health + "/" + GameController.Player.MaxHealth + ")";

            OutputEnemyType.Text = GameController.Enemy.EnemyType;
            OutputEnemyHealth.Text = "(" + GameController.Enemy.Health + "/" + GameController.Enemy.MaxHealth + ")";
        }

        void EnemyTurn()
        {
            GameController.ResolveEnemyTurn();
            UpdateDisplay();
            if (GameController.State == GameController.GameState.Lose) NavigationService.Navigate(new Lose());//NAVIGATE TO LOSE SCREEN
        }

        void PlayerTurn()
        {
            UpdateDisplay();
            if (GameController.Enemy.Health < 1)
            {
                NextBattle();
            }
            else
            {
                EnemyTurn();
            }
        }

        private void NormalAttack_Click(object sender, RoutedEventArgs e)
        {
            if (GameController.State == GameController.GameState.PlayerTurn)
            {
                GameController.ResolvePlayerTurn(GameController.Player.attack);
                PlayerTurn();
            }
        }

        private void SpecialAttack_Click(object sender, RoutedEventArgs e)
        {
            if (GameController.State == GameController.GameState.PlayerTurn)
            {
                GameController.ResolvePlayerTurn(GameController.Player.specialAttack);
                PlayerTurn();
            }
        }
    }
}
