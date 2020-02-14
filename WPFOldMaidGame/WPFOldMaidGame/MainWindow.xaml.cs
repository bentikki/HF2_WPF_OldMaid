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
using Sorteper.Classes;
using System.Threading;

namespace WPFOldMaidGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            this.StartGame();
        }

        private void StartGame()
        {
            //Initializes the Game object.
            this.game = new OldMaidGame();

            //To test
            MenuGrid.Visibility = Visibility.Visible;
            PlayGameGrid.Visibility = Visibility.Collapsed;
        }

        private void btnPlayGame_Click(object sender, RoutedEventArgs e)
        {
            //Checks if the textbox is empty.
            //If empty: Adds a red border to input field.
            if (!String.IsNullOrEmpty(MenuNameTextBox.Text))
            {
                //Change page to GamePlayWindow.
                MenuGrid.Visibility = Visibility.Collapsed;
                PlayGameGrid.Visibility = Visibility.Visible;

                //Adds the player.
                game.AddHumanPlayer(MenuNameTextBox.Text);
                this.DataContext = game;
            }
            else
            {
                MenuNameTextBox.BorderBrush = Brushes.Red;
            }
            
        }

        private void MenuNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.BorderBrush = Brushes.Black;
        }

        private void PlayGameGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            game.DealCards();
            this.UpdateHands();

        }

        private void UpdateHands()
        {
            game.HumanPlayer.RemoveDuplicates();
            game.CPU.RemoveDuplicates();

            StackPanel PlayerPanel = PlayerHandPanel;
            StackPanel CpuPanel = CpuHandPanel;
            PlayerPanel.Children.Clear();
            CpuPanel.Children.Clear();

            //Displays cards in players hand.
            for (int i = 0; i < game.HumanPlayer.Hand.Count; i++)
            {
                Image imageCard = new CardElement(game.HumanPlayer.Hand[i], PlayerPanel.Height - 10);

                imageCard.MouseEnter += new MouseEventHandler(imageCard_MouseEnter);
                imageCard.MouseLeave += new MouseEventHandler(imageCard_MouseLeave);
                PlayerPanel.Children.Insert(i, imageCard);
            }

            //Displays cards in CPU hand.
            for (int i = 0; i < game.CPU.Hand.Count; i++)
            {
                Image imageCard = new CardElement(game.CPU.Hand[i], CpuPanel.Height - 10);

                imageCard.MouseEnter += new MouseEventHandler(imageCard_MouseEnter);
                imageCard.MouseLeave += new MouseEventHandler(imageCard_MouseLeave);
                imageCard.MouseLeftButtonUp += new MouseButtonEventHandler(imageCard_MouseLeftButtonUp);
                CpuPanel.Children.Insert(i, imageCard);
            }
        }

        private void imageCard_MouseEnter(object sender, MouseEventArgs e)
        {
            Image selectedCard = ((Image)sender);
            selectedCard.Width = selectedCard.Width + 20;
            selectedCard.Height = selectedCard.Height + 20;
        }

        private void imageCard_MouseLeave(object sender, MouseEventArgs e)
        {
            Image selectedCard = ((Image)sender);
            selectedCard.Width = selectedCard.Width - 20;
            selectedCard.Height = selectedCard.Height - 20;
        }

        private void imageCard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image selectedCard = ((Image)sender);
            int handIndex = CpuHandPanel.Children.IndexOf(selectedCard);
            CpuHandPanel.Children.RemoveAt(handIndex);
            game.HumanPlayer.TakeCard(game.CPU, Convert.ToByte(handIndex));
            this.UpdateHands();


            int takenHandIndex = Convert.ToInt16( game.TakeCPUTurn() );
            PlayerHandPanel.Children.RemoveAt(takenHandIndex);
            this.UpdateHands();

            if (!game.NewRound())
            {
                StartGame();
            }
        }

        private void Ellipse_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;

            double diameter = MenuGrid.ActualHeight - 100;
            ellipse.Height = diameter;
            ellipse.Width = diameter;
        }
    }
}
