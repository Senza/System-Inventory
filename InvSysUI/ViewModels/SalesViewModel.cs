using Caliburn.Micro;
using InvSysUI.Library.Api;
using InvSysUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSysUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        IProductEndpoint _productEndPoint;

        public SalesViewModel(IProductEndpoint productEndPoint)
        {
            _productEndPoint = productEndPoint;
           
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadPrducts();

        }

        private async Task LoadPrducts() 
        {
            var productList = await _productEndPoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

		private BindingList<ProductModel> _products;

		public BindingList<ProductModel> Products
		{
			get { return _products; }
			set 
            {
				_products = value;
				NotifyOfPropertyChange(() => Products);
			}
		}
        private BindingList<ProductModel> _cart;

        public BindingList<ProductModel> Cart
        {
            get { return _cart; }
            set 
            { 
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }



        private int _itemQuantity;

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set {
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
			}
		}


        public string SubTotal
        {
            get 
            { 
                //Todo replace with calculation
                return "₦0.00"; 
            }
          
        }
        public string Tax
        {
            get
            {
                //Todo replace with calculation
                return "₦0.00";
            }

        }
        public string Total
        {
            get
            {
                //Todo replace with calculation
                return "₦0.00";
            }

        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                //make sure something is selected
                //Make sure there is an item quantity
       
                return output;
            }

        }

        public async Task AddToCart()
        {
           
        }

        public bool CanRemoveFromCart
        { 
            get
            {
                bool output = false;
                //make sure something is selected

                return output;
            }

        }

        public async Task RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                //make sure something is in the cart

                return output;
            }

        }

        public async Task CheckOut()
        {

        }

    }
}
