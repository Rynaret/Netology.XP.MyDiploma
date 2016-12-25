using System;
using Moq;
using NUnit.Framework;
using ShopService.Conventions.CQS.Commands;
using ShopService.Conventions.CQS.Queries;
using ShopService.CQS.Commands;
using ShopService.CQS.Contexts;
using ShopService.CQS.Criterions.DeliveryIntervals;
using ShopService.Entities;

namespace ShopService.Tests.DeliveryIntervals
{
    [TestFixture]
    public class SaveDeliveryIntervalTests
    {
        private Mock<IQueryBuilder> _queryBuilderMock;
        private Mock<ICommandBuilder> _commandBuilderMock;

        [SetUp]
        public void SetUp()
        {
            _queryBuilderMock = new Mock<IQueryBuilder>();
            _commandBuilderMock = new Mock<ICommandBuilder>();
        }

        private void SetupMocks(DeliveryIntervalTemplate deliveryIntervalTemplate)
        {
            _queryBuilderMock.Setup(x => x.For<DeliveryIntervalTemplate>()
                    .WithAsync(It.IsAny<DeliveryIntervalTemplateByIdCriterion>()))
                .ReturnsAsync(deliveryIntervalTemplate);
        }

        [Test]
        public void ShouldReturnException_WhenThereIsNoDeliveryIntervalTemplateWithPointedId()
        {
            var templatePointedId = -1;
            SetupMocks(null);
            var template = new DeliveryIntervalTemplate {Id = templatePointedId };

            var context = new SaveDeliveryIntervalContext(template);
            var command = new SaveDeliveryIntervalCommand(_queryBuilderMock.Object, _commandBuilderMock.Object);

            Assert.ThrowsAsync<Exception>(async () => await command.ExecuteAsync(context)
                , "Шаблон доставки не найден!");
        }
    }
}