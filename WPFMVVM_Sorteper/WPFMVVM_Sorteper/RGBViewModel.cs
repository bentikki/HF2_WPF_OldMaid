using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RGB
{
    class RGBViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double red;

        public double Red
        {
            get { return red; }
            set {
                red = value;
                OnPropertyChanged();
                Background = new SolidColorBrush(Color.FromRgb((byte)Red, (byte)Green, (byte)Blue));
               
                Debug.WriteLine("RED CHANGES");
            }
        }

        private double blue;

        public double Blue
        {
            get { return blue; }
            set
            {
                blue = value;
                OnPropertyChanged();
                Background = new SolidColorBrush(Color.FromRgb((byte)Red, (byte)Green, (byte)Blue));

                Debug.WriteLine("Blue CHANGES");
            }
        }

        private double green;

        public double Green
        {
            get { return green; }
            set
            {
                green = value;
                OnPropertyChanged();
                Background = new SolidColorBrush(Color.FromRgb((byte)Red, (byte)Green, (byte)Blue));
            }
        }

        //det er denne metode der kaldes, når der skal kastes en event
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RGBColor CurrentRGB 
        {
            get { return currentRGB; }
            set {
                currentRGB = value;

            }
        }

        RGBColor currentRGB = new RGBColor();
        public RGBViewModel()
        {

          //  currentRGB.Blue = 30;
            //currentRGB.Red = 150;
            //currentRGB.Green = 20;



            background = new SolidColorBrush(Color.FromRgb((byte)currentRGB.Red, (byte)currentRGB.Green, (byte)currentRGB.Blue));
       
        }


        private SolidColorBrush background;

        public SolidColorBrush Background 
        {
            get { return background; }
            set { background = value;

                OnPropertyChanged();
            }
        }


    }
}
