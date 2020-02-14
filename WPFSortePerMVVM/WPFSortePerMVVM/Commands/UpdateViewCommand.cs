using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFSortePerMVVM.ViewModels;

namespace WPFSortePerMVVM.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private BaseViewModel viewModel;

        public UpdateViewCommand(BaseViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "Start")
            {
                viewModel.SelectedViewModel = new StartViewModel();
            }
            else if(parameter.ToString() == "Game")
            {
                viewModel.SelectedViewModel = new GameViewModel();
            }
        }
    }
}
