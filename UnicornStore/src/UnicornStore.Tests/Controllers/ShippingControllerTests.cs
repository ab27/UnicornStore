using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using UnicornStore.AspNet.Controllers;
using UnicornStore.AspNet.Models.UnicornStore;
using Xunit;

namespace UnicornStore.Tests.Controllers
{
    public class ShippingControllerTests
    {
        [Fact]
        public void GetPendingOrders()
        {
            // TODO Target an in-memory database for testing

            using (var context = new UnicornStoreContext())
            {
                var orders = new List<Order>
                {
                    new Order { State = OrderState.CheckingOut, ShippingDetails = new OrderShippingDetails() },
                    new Order { State = OrderState.Placed, ShippingDetails = new OrderShippingDetails() },
                    new Order { State = OrderState.Filling, ShippingDetails = new OrderShippingDetails() },
                    new Order { State = OrderState.ReadyToShip, ShippingDetails = new OrderShippingDetails() },
                    new Order { State = OrderState.Shipped, ShippingDetails = new OrderShippingDetails() },
                    new Order { State = OrderState.Delivered, ShippingDetails = new OrderShippingDetails() },
                    new Order { State = OrderState.Cancelled, ShippingDetails = new OrderShippingDetails() },
                };

                context.AddRange(orders);
                context.AddRange(orders.Select(o => o.ShippingDetails));
                context.SaveChanges();
            }

            using (var context = new UnicornStoreContext())
            {
                var controller = new ShippingController(context);
                var pendingOrders = controller.PendingOrders();
                Assert.Equal(1, pendingOrders.Count());
            }
        }
    }
}
