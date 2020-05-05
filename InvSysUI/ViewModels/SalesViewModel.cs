using Caliburn.Micro;
using InvSysUI.Library.Api;
using InvSysUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

        private ProductModel _selectedProducts;

        public ProductModel SelectedProduct
        {
            get { return _selectedProducts; }
            set 
            { 
                _selectedProducts = value;
                NotifyOfPropertyChange(() => SelectedProduct);
            }
        }

        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set 
            { 
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }



        private int _itemQuantity = 1;

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set {
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
			}
		}


        public string SubTotal
        {
            get 
            {
                decimal subTotal = 0;
                foreach (var item in Cart)
                {
                    subTotal += (item.Product.RetailPrice * item.QuantityInCart);
                }
                return subTotal.ToString("C", CultureInfo.CreateSpecificCulture("ng-NG")); 
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
                if(ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity) 
                {
                    output = true;
                }
       
                return output;
            }

        }

        public async Task AddToCart()
        {
            CartItemModel existingItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            if(existingItem != null) 
            {
                existingItem.QuantityInCart += ItemQuantity;
                //Hack  - There should be a better way of refreshing the cart display
                Cart.Remove(existingItem);
                Cart.Add(existingItem);
               
            }
            else
            {
                CartItemModel item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };

                Cart.Add(item);
            }
           
            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Cart);
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
            NotifyOfPropertyChange(() => SubTotal);
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
