using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFMVVM_Sorteper.ViewModels
{
    class StartViewModel : BaseViewModel
    {

        private string btnValue = "Play";

        public string BtnValue
        {
            get { return btnValue; }
            set { btnValue = value; }
        }

        private string mainVisibility = "Visible";
        public string MainVisibility
        {
            get { return mainVisibility; }
            set
            {
                mainVisibility = value;
                OnPropertyChanged();
            }
        }

        private string gameVisibility = "Collapsed";
        public string GameVisibility
        {
            get { return gameVisibility; }
            set
            {
                gameVisibility = value;
                OnPropertyChanged();
            }
        }

        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }
        public StartViewModel()
        {
            ButtonCommand = new RelayCommand(new Action<object>(ShowMessage));
        }
        public void ShowMessage(object obj)
        {
            MainVisibility = "Collapsed";
            GameVisibility = "Visible";
        }
    }
}
