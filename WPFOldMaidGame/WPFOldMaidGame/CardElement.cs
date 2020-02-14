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

namespace WPFOldMaidGame
{
    class CardElement : Image
    {
        private string suitImage;
        public CardElement(Card card, double parentHeight)
        {
            this.suitImage = @"pack://application:,,,/Content/Images/Cards/" + card.Suit + ".png";
            this.Source = new BitmapImage(new Uri(suitImage));
            this.Height = parentHeight;
            this.Width = this.Height - 20;
            Thickness m = this.Margin;
            m.Left = 5;
            m.Right = 5;
            this.Margin = m;
        }

        public void OppenentCard()
        {
            this.Source = new BitmapImage(new Uri(@"pack://application:,,,/Content/Images/Cards/B1.png"));
        }

    }
}
