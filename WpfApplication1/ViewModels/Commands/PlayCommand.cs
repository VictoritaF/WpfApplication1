﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.ViewModels.Commands
{
    public class PlayCommand : ICommand
    {
        public UserViewModel ViewModel { get; set; }

        public PlayCommand(UserViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }
        public PlayCommand() { }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.OpenWindowOnPlay();
        }
    }
}

