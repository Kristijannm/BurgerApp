using BurgerApp;
using BurgerApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System;
using BurgerStoreApp.Models.ViewModels;
using BurgerStoreApp.Models.Mappers;

namespace BurgerStoreApp.Controllers
{
    public class OrderController : Controller
    {
        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //        return View("AnErrorOccurred");
        //    Order order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
        //    if (order == null)
        //        return View("AnErrorOccurred");
        //    return View(order);
        //}
        public IActionResult Orders()
        {
            List<Order> ordersFromDb = StaticDb.Orders;
            //ViewData["OrdersCount"] = ordersFromDb.Count;
            return View(ordersFromDb);
            //displays all orders
        }
        public IActionResult EditOrder(int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            Order orderEdit = StaticDb.Orders.FirstOrDefault(o => o.Id == id);

            if (orderEdit == null)
                return View("AnErrorOccurred");

            OrderViewModel viewModel = OrderMapper.ToOrderViewModel(orderEdit);

            ViewData["BurgerId"] = new SelectList(StaticDb.Burgers, "Id", "Name", orderEdit.BurgerId);

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult EditOrder(int id, [Bind("Id,FullName,BurgerId,Address,Location,IsDelivered")] OrderViewModel order)
        {
            ViewData["BurgerId"] = new SelectList(StaticDb.Burgers, "Id", "Name", order.BurgerId);

            if (!ModelState.IsValid)
                return View(order);

            Order orderUpdate = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderUpdate == null)
                return View("AnErrorOccurred");

            //updating the values for the chosen order
            orderUpdate.FullName = order.FullName;
            orderUpdate.BurgerId = order.BurgerId;
            orderUpdate.Address = order.Address;
            orderUpdate.Location = order.Location;
            orderUpdate.IsDelivered = order.IsDelivered;
            orderUpdate.Burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == order.BurgerId);

            return RedirectToAction("Orders");
            //return RedirectToAction("Details", orderUpdate.Id);
            
        }


        public IActionResult DeleteOrder(int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            var order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
                return View("AnErrorOccurred");
            
            StaticDb.Orders.Remove(order);
            return RedirectToAction("Orders");
        }
        public IActionResult CreateOrder()
        {
            var orderViewModel = new OrderViewModel();
            ViewData["BurgerId"] = new SelectList(StaticDb.Burgers, "Id", "Name");

            return View(orderViewModel);
        }
        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            ViewData["BurgerId"] = new SelectList(StaticDb.Burgers, "Id", "Name");

            if (!ModelState.IsValid)
                return View(order);

            Order newOrder = OrderMapper.ToOrder(order);
            newOrder.Id = (StaticDb.Orders.LastOrDefault()?.Id ?? 0) + 1;
            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("Orders");
        }
    }
}
