using DataAccessLayer.Data;
using DataAccessLayer.Helpers;
using DataAccessLayer.Services;
using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMobilesService _mobilesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(IMobilesService mobilesService, ShoppingCart shoppingCart, IOrdersService ordersService, UserManager<ApplicationUser> userManager)
        {
            _mobilesService = mobilesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
            this.userManager = userManager;
        }

        // Get: Items in cart and get total price
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        // add item to shopping cart
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _mobilesService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        // remove item from shopping cart
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _mobilesService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        // proceed view
        public async Task<IActionResult> Proceed()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ProceedOrderViewModel()
            {
                ShoppingCart = _shoppingCart,
                Total = _shoppingCart.GetShoppingCartTotal(),
                Email = User.FindFirstValue(ClaimTypes.Email)
            };

            return View(response);
        }

        // insert order into database and send an e-mail to client
        public async Task<IActionResult> CompleteOrder(ProceedOrderViewModel viewModel)
        {
            // insert order into database
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);

            // send confirmation mail to client
            string content = "Name and Surname: " + viewModel.NameSurname
            + "<br>E-mail Address: " + viewModel.Email
            + "<br>Telephone Number : " + viewModel.Telephone
            + "<br>Address to deliver: " + viewModel.Address
            + "<br> Ordered product: "
            + "<ol>";
            foreach (var item in items)
            {
                content += "<li> " + item.Mobile.MobileName + " (" + item.Mobile.MobilePrice + ".00&euro;" + ")" + ", Amount: " + item.Amount + "</li>";
            }
            content += "</ol>"
            + "Your order costs: " + _shoppingCart.GetShoppingCartTotal() + ".00&euro;"
            + "<br><strong>Your order will be delivered to your home address within 2-3 business days, thank you for using our services!</strong>";

            if (MailHelper.Send("bojanfaks123@gmail.com", viewModel.Email, viewModel.Subject, content))
            {
                // update database depending on the quantity of the order
                await _mobilesService.UpdateQuantity(items);
                await _shoppingCart.ClearShoppingCartAsync();
                return View("OrderCompleted");
            }
            else
            {
                TempData["Error"] = "Your e-mail confirmation can't be send in this moment, but we've received your order!";
                return RedirectToAction("Index", "Mobile");
            }
        }
    }
}
