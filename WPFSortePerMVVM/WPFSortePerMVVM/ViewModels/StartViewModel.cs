using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFSortePerMVVM.Commands;
using WPFSortePerMVVM.ViewModels;

namespace WPFSortePerMVVM.ViewModels
{
    class StartViewModel : BaseViewModel
    {
        public StartViewModel()
        {
            //SelectedViewModel = this;
            PlayGameClick = new RelayCommand(new Action<object>(ChangeToPlayView));
            
        }

        private string testString = "Play";

        public string TestString
        {
            get { return testString; }
            set { testString = value; }
        }

        private ICommand m_ButtonCommand;
        public ICommand PlayGameClick
        {
            get { return m_ButtonCommand; }
            set { m_ButtonCommand = value; }
        }

        public void ChangeToPlayView(object obj)
        {
            this.SelectedViewModel = new GameViewModel();
        }
    }
}
