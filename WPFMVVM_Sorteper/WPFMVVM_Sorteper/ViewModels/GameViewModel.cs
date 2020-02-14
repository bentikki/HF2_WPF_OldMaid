using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVM_Sorteper.Models;

namespace WPFMVVM_Sorteper.ViewModels
{
    class GameViewModel : BaseViewModel
    {
        private Game game;

        public GameViewModel()
        {
            this.game = new OldMaidGame();
            game.AddHumanPlayer("Player");
            game.DealCards();

            PlayerHand = game.HumanPlayer.Hand;
            PCHand = game.CPU.Hand;

        }

        private List<Card> playerHand;
        public List<Card> PlayerHand
        {
            get { return playerHand; }
            set { playerHand = value; }
        }

        private List<Card> pcHand;
        public List<Card> PCHand
        {
            get { return pcHand; }
            set { pcHand = value; }
        }

    }
}
