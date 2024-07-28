using BurgerApp;
using BurgerApp.Models.Domain;
using BurgerStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Net;

namespace BurgerStoreApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(Order order)
        {
            if (order == null)
                throw new Exception("Order has no value");
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Id = order.Id,
                FullName = order.FullName,
                BurgerId = order.BurgerId,
                Address = order.Address,
                Location = order.Location,
                IsDelivered = order.IsDelivered

            };
            return orderViewModel;

        }
        public static Order ToOrder(OrderViewModel orderViewModel)
        {
            Order order = new Order()
            {
                Id = orderViewModel.Id,
                FullName = orderViewModel.FullName,
                BurgerId = orderViewModel.BurgerId,
                Address = orderViewModel.Address,
                Location = orderViewModel.Location,
                IsDelivered = orderViewModel.IsDelivered,
                Burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == orderViewModel.BurgerId)
            };
            return order;
        }
    }
}
