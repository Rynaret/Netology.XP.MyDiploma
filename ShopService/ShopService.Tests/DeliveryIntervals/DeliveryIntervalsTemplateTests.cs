using System;
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
    public class DeliveryIntervalsTemplateTests
    {
        private Mock<IQueryBuilder> _queryBuilderMock;
        private List<DeliveryIntervalTemplate> _deliveryIntervalTemplates;
        
        [SetUp]
        public void SetUp()
        {
            _deliveryIntervalTemplates = new List<DeliveryIntervalTemplate>();
            _queryBuilderMock = new Mock<IQueryBuilder>();
        }

        private void SetupMocks(List<DeliveryIntervalTemplate> deliveryIntervalTemplates)
        {
            _queryBuilderMock.Setup(x => x.For<List<DeliveryIntervalTemplate>>()
                    .WithAsync(It.IsAny<AllDeliveryIntervalTemplatesCriterion>()))
                .ReturnsAsync(deliveryIntervalTemplates);
        }

        [Test]
        public async Task ShouldReturnViewModelWithSelectedTemplateAsFirstElementOfTemplates_WhenTemplatesExists()
        {
            var random = new Randomizer();
            for (int i = 0; i < 10; i++)
            {
                _deliveryIntervalTemplates.Add(new DeliveryIntervalTemplate { Id = random.NextLong()});
            }
            SetupMocks(_deliveryIntervalTemplates);
            var criterion = new DeliveryIntervalTemplateViewModelCriterion(null);
            var query = new DeliveryIntervalTemplateViewModelQuery(_queryBuilderMock.Object);


            var queryResult = await query.AskAsync(criterion);
            var selectedElementId = queryResult.SelectedDeliveryIntervalTemplate.Id;

            Assert.AreEqual(selectedElementId, _deliveryIntervalTemplates.FirstOrDefault().Id);
        }

        [Test]
        public async Task ShouldReturnViewModelWithSelectedTemplateAsElementWithId_WhenIdPointed()
        {
            var pointedId = 5;
            for (int i = 0; i < 10; i++)
            {
                _deliveryIntervalTemplates.Add(new DeliveryIntervalTemplate { Id = i });
            }
            SetupMocks(_deliveryIntervalTemplates);
            var criterion = new DeliveryIntervalTemplateViewModelCriterion(pointedId);
            var query = new DeliveryIntervalTemplateViewModelQuery(_queryBuilderMock.Object);

            var queryResult = await query.AskAsync(criterion);
            var selectedElementId = queryResult.SelectedDeliveryIntervalTemplate.Id;

            Assert.AreEqual(selectedElementId, _deliveryIntervalTemplates.FirstOrDefault(x => x.Id == pointedId).Id);
        }

        [Test]
        public async Task ShouldReturnViewModelWithSelectedTemplateAsFirstElementOfTemplates_WhenIdPointedIncorect()
        {
            var random = new Randomizer();
            var incorectId = -1;
            for (int i = 0; i < 10; i++)
            {
                _deliveryIntervalTemplates.Add(new DeliveryIntervalTemplate { Id = random.NextLong(0, 100) });
            }
            SetupMocks(_deliveryIntervalTemplates);
            var criterion = new DeliveryIntervalTemplateViewModelCriterion(incorectId);
            var query = new DeliveryIntervalTemplateViewModelQuery(_queryBuilderMock.Object);


            var queryResult = await query.AskAsync(criterion);
            var selectedElementId = queryResult.SelectedDeliveryIntervalTemplate.Id;

            Assert.AreEqual(selectedElementId, _deliveryIntervalTemplates.FirstOrDefault().Id);
        }

        [Test]
        public void ShouldReturnException_WhenThereAreNoTemplates()
        {
            SetupMocks(_deliveryIntervalTemplates);
            var criterion = new DeliveryIntervalTemplateViewModelCriterion(null);
            var query = new DeliveryIntervalTemplateViewModelQuery(_queryBuilderMock.Object);

            Assert.ThrowsAsync<Exception>(async () => await query.AskAsync(criterion)
            , "В базе не найдено не одного шаблона доставки!");
        }
    }
}