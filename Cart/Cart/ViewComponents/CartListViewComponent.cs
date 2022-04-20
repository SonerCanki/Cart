using Cart.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.ViewComponents
{
    public class CartListViewComponent : ViewComponent
    {
        private readonly CartHelper _cartHelper;
        public CartListViewComponent(CartHelper cartHelper)
        {
            _cartHelper = cartHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View( _cartHelper.CartList);
        }
    }
}
