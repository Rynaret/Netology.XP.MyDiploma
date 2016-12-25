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
    public class DeliveryDatesTests
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
        public async Task ShouldReturnEmptyList_WhenSubscriptionDatesAreNotExist()
        {
            var today = DateTime.Today;
            var showUntil = DateTime.Today.AddMonths(3);
            SetupMocks(new List<SubscriptionDate>());
            var criterion = new DeliveryDatesCriterion(today, showUntil);
            var query = new DeliveryDatesQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult, new List<DateTime>());
        }

        [Test]
        public async Task ShouldReturnEmptyList_WhenLastSubscriptionDateIsTypeOfSuspend()
        {
            var today = DateTime.Today;
            var showUntil = DateTime.Today.AddMonths(3);
            var subscriptionDates = new List<SubscriptionDate>
            {
                new SubscriptionDate
                {
                    Date = today,
                    Type = SubscriptionDateType.Suspend
                }
            };
            SetupMocks(subscriptionDates);
            var criterion = new DeliveryDatesCriterion(today, showUntil);
            var query = new DeliveryDatesQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult, new List<DateTime>());
        }

        [TestCase(3)]
        [TestCase(2)]
        public async Task ShouldReturnDeliveryDatesForInterval_WhenSubscrsiptionIntervalIsEveryMonthAt5And8DaysOfMonth(int suspendDateMonthValueAdd)
        {
            var monthsAhead = 3;
            var today = DateTime.Today;
            var showUntil = DateTime.Today.AddMonths(monthsAhead);
            var subscriptionDates = new List<SubscriptionDate>
            {
                new SubscriptionDate
                {
                    Date = today.AddYears(-1),
                    Type = SubscriptionDateType.Start
                },
                new SubscriptionDate
                {
                    Date = today.AddMonths(suspendDateMonthValueAdd),
                    Type = SubscriptionDateType.Suspend
                }
            };
            var frequencyInMonth = 2;
            var deliveryInterval = new DeliveryInterval
            {
                CronString = "0 0 0 8,5 12/1 *"
            };
            SetupMocks(subscriptionDates, deliveryInterval);
            var criterion = new DeliveryDatesCriterion(today, showUntil);
            var query = new DeliveryDatesQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult.Count, frequencyInMonth * suspendDateMonthValueAdd);
        }

        [Test]
        public async Task ShouldReturnDeliveryDatesForInterval_WhenSubscrsiptionIntervalIsEveryMonthAt5And8DaysOfMonth()
        {
            var monthsAhead = 3;
            var today = DateTime.Today;
            var showUntil = DateTime.Today.AddMonths(monthsAhead);
            var subscriptionDates = new List<SubscriptionDate>
            {
                new SubscriptionDate
                {
                    Date = today.AddYears(-1),
                    Type = SubscriptionDateType.Start
                },
            };
            var frequencyInMonth = 2;
            var deliveryInterval = new DeliveryInterval
            {
                CronString = "0 0 0 8,5 12/1 *"
            };
            SetupMocks(subscriptionDates, deliveryInterval);
            var criterion = new DeliveryDatesCriterion(today, showUntil);
            var query = new DeliveryDatesQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult.Count, frequencyInMonth * monthsAhead);
        }
    }
}