using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class UserCartController : Controller
    {
        private readonly DataManager _dataManager;

        public UserCartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_dataManager.CartItems.GetCartItems().Where(c => c.UserId == new Guid(userId)));
        }

        //[HttpPost]
        //public IActionResult AddToCart(Guid id)
        //{
            
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult DeleteFromCart(Guid id)
        {
           
            return RedirectToAction("Index");
        }

        private int IsExists(Guid id)
        {
            List<CartItem> productsCart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < productsCart.Count; i++)
            {
                if (productsCart[i].ProductId == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }

    //    public IActionResult Index()
    //    {
    //        var cart = SessionHelper.GetObjectFromJson<List<ProductsCartItem>>(HttpContext.Session, "cart");
    //        ViewBag.cart = cart;
    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult AddToCart(Guid id)
    //    {
    //        if (SessionHelper.GetObjectFromJson<List<ProductsCartItem>>(HttpContext.Session, "cart") == null)
    //        {
    //            List<ProductsCartItem> productsCart = new List<ProductsCartItem>();
    //            productsCart.Add(new ProductsCartItem { Id = Guid.NewGuid(), Product = _dataManager.Products.GetProductById(id), Quantity = 1 });
    //            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", productsCart);
    //        }
    //        else
    //        {
    //            List<ProductsCartItem> productsCart = SessionHelper.GetObjectFromJson<List<ProductsCartItem>>(HttpContext.Session, "cart");
    //            int index = IsExists(id);
    //            if (index != -1)
    //            {
    //                productsCart[index].Quantity++; 
    //            }
    //            else
    //            {
    //                productsCart.Add(new ProductsCartItem { Product = _dataManager.Products.GetProductById(id), Quantity = 1 });
    //            }

    //            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", productsCart);
    //        }
    //        return RedirectToAction("Index");
    //    }

    //    [HttpPost]
    //    public IActionResult DeleteFromCart(Guid id)
    //    {
    //        List<ProductsCartItem> productsCart = SessionHelper.GetObjectFromJson<List<ProductsCartItem>>(HttpContext.Session, "cart");
    //        int index = IsExists(id);
    //        productsCart.RemoveAt(index);
    //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", productsCart);
    //        return RedirectToAction("Index");
    //    }

    //    private int IsExists(Guid id)
    //    {
    //        List<ProductsCartItem> productsCart = SessionHelper.GetObjectFromJson<List<ProductsCartItem>>(HttpContext.Session, "cart");
    //        for (int i = 0; i < productsCart.Count; i++)
    //        {
    //            if (productsCart[i].ProductId == id)
    //            {
    //                return i;
    //            }
    //        }

    //        return -1;
    //    }
    //}
}
