using System;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Common.Interfaces.Services;
using Xunit;

namespace BETShop.Application.Tests.Initialize
{
    public class TestFixture : IDisposable
    {
        public IEmailService EmailService;
        public ICartService CartService;
        public IOrderRepository OrderRespository;
        public IProductRepository ProductRespository;

        public TestFixture()
        {
            EmailService = new TestEmailService();
            CartService = new TestCartService();
            OrderRespository = new TestOrderRespository();
            ProductRespository = new TestProductRespository();
        }

        public void Dispose()
        {
            EmailService = null;
            CartService = null;
            OrderRespository = null;
            ProductRespository = null;
        }
    }

    [CollectionDefinition("Providers For Tests")]
    public class QueryCollection : ICollectionFixture<TestFixture>
    {
    }
}
