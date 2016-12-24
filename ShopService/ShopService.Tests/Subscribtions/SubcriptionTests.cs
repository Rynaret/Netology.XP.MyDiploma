using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Commands;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.CQS.Queries.Subscriptions;
using ShopService.Entities;

namespace ShopService.Tests.Subscribtions
{
    [TestFixture]
    public class SubcriptionTests
    {
        private Mock<IQueryBuilder> _queryBuilderMock;
        private Subscription _subscription;

        [SetUp]
        public void SetUp()
        {
            _queryBuilderMock = new Mock<IQueryBuilder>();
            _subscription = new Subscription
            {
                Products = new List<Product>()
            };
        }

        private void SetupMocks(Subscription subscription)
        {
            _queryBuilderMock.Setup(x => x.For<Subscription>()
                    .WithAsync(It.IsAny<SubscriptionWithProductsCriterion>()))
                .ReturnsAsync(subscription);
        }

        [TestCase(1)]
        [TestCase(10)]
        public async Task ShouldCalculateTotalPrice_WhenProductsInSubcriptionExists(int productsCount)
        {
            var random = new Randomizer();
            for (int i = 0; i < productsCount; i++)
            {
                _subscription.Products.Add(new Product() {Price = random.NextDouble()});
            }
            SetupMocks(_subscription);
            var criterion = new CalculateProductsSumInSubscriptionCriterion();
            var query = new CalculateProductsSumInSubscriptionQuery(_queryBuilderMock.Object);


            var queryResult = await query.AskAsync(criterion);


            Assert.AreEqual(queryResult, _subscription.Products.Sum(x => x.Price));
        }

        [Test]
        public async Task ShouldReturn0_WhenProductsInSubcriptionNoExists()
        {
            SetupMocks(_subscription);
            var criterion = new CalculateProductsSumInSubscriptionCriterion();
            var query = new CalculateProductsSumInSubscriptionQuery(_queryBuilderMock.Object);


            var queryResult = await query.AskAsync(criterion);

            
            Assert.AreEqual(queryResult, 0);
        }
    }
}