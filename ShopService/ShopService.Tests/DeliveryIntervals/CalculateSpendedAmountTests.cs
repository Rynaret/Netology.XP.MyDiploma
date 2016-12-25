using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.CQS.Queries.Deliveries;
using ShopService.Entities;

namespace ShopService.Tests.DeliveryIntervals
{
    [TestFixture]
    public class CalculateSpendedAmountTests
    {
        private Mock<IQueryBuilder> _queryBuilderMock;

        [SetUp]
        public void SetUp()
        {
            _queryBuilderMock = new Mock<IQueryBuilder>();
        }

        private void SetupMocks(List<SubscriptionDate> subscriptionDates)
        {
            _queryBuilderMock.Setup(x => x.For<List<SubscriptionDate>>()
                    .WithAsync(It.IsAny<SubscriptionDatesForSubscriptionCriterion>()))
                .ReturnsAsync(subscriptionDates);
        }

        [Test]
        public async Task ShouldReturn0_WhenSubscriptionDatesAreNotExist()
        {
            SetupMocks(new List<SubscriptionDate>());
            var criterion = new CalculateSpendedAmountCriterion(DateTime.Today);
            var query = new CalculateSpendedAmountQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult, 0);
        }
    }
}