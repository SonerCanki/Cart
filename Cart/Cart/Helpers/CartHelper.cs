using Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Helpers
{
    public class CartHelper
    {
        public List<ProductVM> CartList;

        public CartHelper()
        {
            CartList = new List<ProductVM>();
        }


        public void AddCart(ProductVM item)
        {
            if (!CartList.Any(x => x.Id == item.Id))
                CartList.Add(item);
            else
                this.IncreaseCart(item.Id);

        }


        public void IncreaseCart(int id)
        {
            ProductVM productVM = CartList.Find(x => x.Id == id);
            productVM.Quantity++;
        }


        public void DecreaseCart(int id)
        {
            ProductVM productVM = CartList.Find(x => x.Id == id);
            productVM.Quantity--;
            if (productVM.Quantity <= 0)
                this.RemoveCart(id);
        }


        public void RemoveCart(int id) => CartList.Remove(CartList.Find(x => x.Id == id));

    }
}
