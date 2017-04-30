using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.ViewModels.Commands
{
   public class SetCategoryNameCommand:ICommand
    {
        public UserViewModel ViewModel { get; set; }

        public SetCategoryNameCommand(UserViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }
        public SetCategoryNameCommand() { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.SetCategoryName(parameter);
        }
    }
}
