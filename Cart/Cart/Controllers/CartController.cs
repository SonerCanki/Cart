using Cart.Data.DataContext;
using Cart.Data.Entities;
using Cart.Helpers;
using Cart.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult CartListViewComponent()
        {
            return View("CartList");
        }

        public JsonResult List()
        {
            if (SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart");
                List<ProductVM> ProList = cart.CartList.Select(x => new ProductVM
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock
                }).ToList();

                return Json(ProList);
            }
            return Json(new List<ProductVM>());
        }


        public IActionResult Add(int id)
        {
            Product p = _context.Products.Find(id);
            ProductVM productVM = new ProductVM()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                Quantity = 1
            };

            if (SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart");
                cart.AddCart(productVM);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {

                CartHelper cart = new CartHelper();
                cart.AddCart(productVM);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return Json("Empty");
        }

        public JsonResult IncreaseItem(int id)
        {
            
           
            if (SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart");
                cart.IncreaseCart(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return Json("");
        }


        public JsonResult DecreaseItem(int id)
        {
            if (SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart");
                cart.DecreaseCart(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return Json("Empty");
        }

        public JsonResult RemoveItem(int id)
        {
            if (SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjetAsJson<CartHelper>(HttpContext.Session, "cart");
                cart.RemoveCart(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return Json("Empty");
        }
    }
}