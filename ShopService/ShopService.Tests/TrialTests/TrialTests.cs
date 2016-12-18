using NUnit.Framework;

namespace ShopService.Tests.TrialTests
{
    [TestFixture]
    public class TrialTests
    {
        [Test]
        public void Execute_ShoudReturnTrue_WhenTrue()
        {
            var success = true;

            Assert.True(success);
        }
    }
}