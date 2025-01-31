﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InvSysUI.Models
{
    public class CartItemDisplayModel : INotifyPropertyChanged
    {
        public ProductDisplayModel Product { get; set; }

        private int _quantityInCart;

        public int QuantityInCart
        {
            get { return _quantityInCart; }
            set {
                _quantityInCart = value;
                CallPropertyChanged(nameof(QuantityInCart));
                CallPropertyChanged(nameof(DisplayText));
            }
        }

     
        public string DisplayText
        {
            get
            {
                return $"{Product.ProductName}({ QuantityInCart})";
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CallPropertyChanged(string property) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
