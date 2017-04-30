﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.ViewModels.Commands
{
    public class SelectCategoryCommand: ICommand
    {
        public UserViewModel ViewModel { get; set; }

        public SelectCategoryCommand(UserViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }
        public SelectCategoryCommand() { }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //this.ViewModel.SelectACategory();
        }
    }
}
