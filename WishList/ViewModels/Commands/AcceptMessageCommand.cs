﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WishList.ViewModels.Commands
{
    class AcceptMessageCommand : ICommand
    {
        //migth need to be put into itemviewmodel
        ContactViewModel _contactViewModel;

        public AcceptMessageCommand(ContactViewModel cvm)
        {
            _contactViewModel = cvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object item)
        {
            _contactViewModel.AcceptRequest();
        }
    }
}
