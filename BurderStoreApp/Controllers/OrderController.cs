using BurgerApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System;
using BurgerStoreApp.Models.ViewModels;
using BurgerStoreApp.Models.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BurgerStoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly BurgerDbContext _dbContext;

        public OrderController(BurgerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Orders()
        {
            List<Order> ordersFromDb = await _dbContext.Orders.Include(o => o.Burger).ToListAsync();
            return View(ordersFromDb);
        }

        public async Task<IActionResult> EditOrder(int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            Order orderEdit = await _dbContext.Orders.FindAsync(id);

            if (orderEdit == null)
                return View("AnErrorOccurred");

            OrderViewModel viewModel = OrderMapper.ToOrderViewModel(orderEdit);

            ViewData["BurgerId"] = new SelectList(_dbContext.Burgers, "Id", "Name", orderEdit.BurgerId);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(int id, [Bind("Id,FullName,BurgerId,Address,Location,IsDelivered")] OrderViewModel order)
        {
            ViewData["BurgerId"] = new SelectList(_dbContext.Burgers, "Id", "Name", order.BurgerId);

            if (!ModelState.IsValid)
                return View(order);

            Order orderUpdate = await _dbContext.Orders.FindAsync(id);
            if (orderUpdate == null)
                return View("AnErrorOccurred");

            //updating the values for the chosen order
            orderUpdate.FullName = order.FullName;
            orderUpdate.BurgerId = order.BurgerId;
            orderUpdate.Address = order.Address;
            orderUpdate.Location = order.Location;
            orderUpdate.IsDelivered = order.IsDelivered;
            orderUpdate.Burger = await _dbContext.Burgers.FindAsync(order.BurgerId);

            _dbContext.Update(orderUpdate);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Orders");
        }

        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
                return View("AnErrorOccurred");

            Order order = await _dbContext.Orders.FindAsync(id);

            if (order == null)
                return View("AnErrorOccurred");

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Orders");
        }

        public IActionResult CreateOrder()
        {
            var orderViewModel = new OrderViewModel();
            ViewData["BurgerId"] = new SelectList(_dbContext.Burgers, "Id", "Name");

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel order)
        {
            ViewData["BurgerId"] = new SelectList(_dbContext.Burgers, "Id", "Name");

            if (!ModelState.IsValid)
                return View(order);

            Order newOrder = OrderMapper.ToOrder(order);
            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Orders");
        }
    }

}
