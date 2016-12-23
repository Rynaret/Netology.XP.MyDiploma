using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.CQS.Queries.Deliveries;
using ShopService.Entities;

namespace ShopService.Tests.DeliveryIntervals
{
    [TestFixture]
    public class DeliveryIntervalsTests
    {
        private Mock<IQueryBuilder> _queryBuilderMock;
        private List<DeliveryIntervalTemplate> _deliveryIntervalTemplates;

        [SetUp]
        public void SetUp()
        {
            _deliveryIntervalTemplates = new List<DeliveryIntervalTemplate>();
            _queryBuilderMock = new Mock<IQueryBuilder>();
        }

        private void SetupMocks(long? deliveryIntervalId)
        {
            _queryBuilderMock.Setup(x => x.For<long?>()
                    .WithAsync(It.IsAny<SubscriptionDeliveryIntervalIdCriterion>()))
                .ReturnsAsync(deliveryIntervalId);
        }

        [Test]
        public async Task ShouldReturnNothing_WhenDeliveryIntervalNotSetToSubscription()
        {
            SetupMocks(null);
            var criterion = new DeliveryIntervalWithTemplateForSubscriptionCriterion();
            var query = new DeliveryIntervalWithTemplateForSubscriptionQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);

            Assert.AreEqual(queryResult, null);
        }
    }
}