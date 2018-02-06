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
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Page
    {
        public GameController GameController;
        public CharacterCreation(GameController gameController)
        {
            InitializeComponent();

            GameController = gameController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)InputClassWarrior.IsChecked)
            {
                GameController.CreateCharacter(InputName.Text, PlayerCharacter.Class.Warrior);
            }
            else if ((bool)InputClassThief.IsChecked)
            {
                GameController.CreateCharacter(InputName.Text, PlayerCharacter.Class.Thief);
            }
            else if ((bool)InputClassMage.IsChecked)
            {
                GameController.CreateCharacter(InputName.Text, PlayerCharacter.Class.Mage);
            }
            else
            {
                return;
            }
            NavigationService.Navigate(new Battle(GameController));
        }
    }
}
