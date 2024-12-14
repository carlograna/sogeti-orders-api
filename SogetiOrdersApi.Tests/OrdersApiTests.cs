using Microsoft.AspNetCore.Mvc;
using SogetiOrdersApi.Controllers;
using System.Net;

namespace SogetiOrdersApi.Tests
{
    public class OrdersApiTests
    {
        [Fact]
        public async Task CreateOrder_Should_Succeed()
        {
            var controller = new OrdersController(new Data.OrdersContext());

            var response = await controller.PostOrder(
                new Models.Order
                { CustomerId = 1, ProductId = 10, Quantity = 100 });


            var result = response.Result as OkObjectResult;
            
            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
            
        }

        [Fact]
        public async Task GetOrders_ShouldReturn_AllOrdersByCustomerId()
        {
            var controller = new OrdersController(new Data.OrdersContext());

            var response = await controller.GetOrders(1);

            var result = response.Result as OkObjectResult;

            var orders = result.Value as IEnumerable<Models.Order>;

            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
            Assert.True(orders?.Any());
        }

        [Fact]
        public async Task UpdateOrder_Should_Succeed()
        {
            var controller = new OrdersController(new Data.OrdersContext());

            var response = await controller.UpdateOrder(
                1,
                new Models.Order { Id = 1, CustomerId = 9, ProductId = 99, Quantity = 999 });

            var result = response as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(204, result?.StatusCode);
        }

        [Fact]
        public async Task CancelOrder_ShouldRemove()
        {
            var controller = new OrdersController(new Data.OrdersContext());

            var response = await controller.CancelOrder(1);

            var result = response as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(204, result?.StatusCode);
        }
    }
}