using BETShop.Application.Common.Interfaces.Configuration;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Infrastructure.Repositories.Models;
using MongoDB.Driver;

namespace BETShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> orders;

        public OrderRepository(IDatabaseConfiguration settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            orders = database.GetCollection<Order>(settings.CollectionName);
        }

        public void CreateOrder(Domain.Models.Order order)
        {
            orders.InsertOne(new Order
            {
                UserId = order.UserId,
                Date = order.Date,
                Cart = order.Cart
            });
        }
    }
}
