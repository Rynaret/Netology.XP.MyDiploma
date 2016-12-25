using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ShopService.Conventions.CQS.Queries;
using ShopService.Conventions.Enums;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.CQS.Criterions.Subscriptions;
using ShopService.CQS.Queries.Deliveries;
using ShopService.Entities;

namespace ShopService.Tests.DeliveryIntervals
{
    [TestFixture]
    public class CalculateSpentAmountTests
    {
        private Mock<IQueryBuilder> _queryBuilderMock;

        [SetUp]
        public void SetUp()
        {
            _queryBuilderMock = new Mock<IQueryBuilder>();
        }

        private void SetupMocks(List<SubscriptionDate> subscriptionDates, DeliveryInterval deliveryInterval = null)
        {
            _queryBuilderMock.Setup(x => x.For<List<SubscriptionDate>>()
                    .WithAsync(It.IsAny<SubscriptionDatesForSubscriptionCriterion>()))
                .ReturnsAsync(subscriptionDates);

            _queryBuilderMock.Setup(x => x.For<DeliveryInterval>()
                   .WithAsync(It.IsAny<DeliveryIntervalWithTemplateForSubscriptionCriterion>()))
               .ReturnsAsync(deliveryInterval);
        }

        [Test]
        public async Task ShouldReturn0_WhenSubscriptionDatesAreNotExist()
        {
            SetupMocks(new List<SubscriptionDate>());
            var criterion = new CalculateSpentAmountCriterion(DateTime.Today, 0);
            var query = new CalculateSpentAmountQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult, 0);
        }

        [Test]
        public async Task ShouldReturn0_WhenFirstSubscriptionDateIsTheSameAsToday()
        {
            var today = DateTime.Today;
            var subscriptionDates = new List<SubscriptionDate>
            {
                new SubscriptionDate
                {
                    Date = today,
                    Type = SubscriptionDateType.Start
                }
            };
            SetupMocks(subscriptionDates);
            var criterion = new CalculateSpentAmountCriterion(today, 0);
            var query = new CalculateSpentAmountQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult, 0);
        }

        [Test]
        public async Task ShouldReturnSpentSumOfSubscriptedProductsBetweenDates_WhenSubscrsiptionIntervalIsEveryMonthAt5And8DaysOfMonth()
        {
            var today = DateTime.Today;
            var sumOfProductsInSubscription = 10;
            var subscriptionDates = new List<SubscriptionDate>
            {
                new SubscriptionDate
                {
                    Date = today.AddYears(-1),
                    Type = SubscriptionDateType.Start
                },
                new SubscriptionDate
                {
                    Date = today,
                    Type = SubscriptionDateType.Suspend
                }
            };
            var countOfMonths = 12;
            var frequencyInMonth = 2;
            var deliveryInterval = new DeliveryInterval
            {
                CronString = "0 0 0 8,5 12/1 *"
            };
            SetupMocks(subscriptionDates, deliveryInterval);
            var criterion = new CalculateSpentAmountCriterion(today, sumOfProductsInSubscription);
            var query = new CalculateSpentAmountQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult, sumOfProductsInSubscription * countOfMonths * frequencyInMonth);
        }
    }
}