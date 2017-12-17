﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WishList.ViewModels.Commands
{
    class BuyItemCommand : ICommand
    {
        //migth need to be put into itemviewmodel
        WishlistViewModel _wishViewModel;

        public BuyItemCommand(WishlistViewModel wvm)
        {
            _wishViewModel = wvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object item)
        {
            _wishViewModel.BuyItem();
        }
    }
}
