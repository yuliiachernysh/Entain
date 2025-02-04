using Entain.Pages;

namespace Entain.Tests
{
    [TestFixture]
    public class LiveBettingTestSuit : BaseTest
    {

        private LiveBettingPage _liveBettingPage;

        [SetUp]
        public async Task Init()
        {
            _liveBettingPage = new LiveBettingPage(page);
        }

        [Test]
        public async Task CheckHighlighteOptionForSelectedOdd()
        {
            //arraange
            await _liveBettingPage.NavigateToLiveBettingPageAsync();
            await _liveBettingPage.NavigateToEventsTabAsync();

            //act
            await _liveBettingPage.ChooseOddAsync();

            //asset
            bool isOddHighlighted = await _liveBettingPage.IsOddHighlightedAsync();
            Assert.IsTrue(isOddHighlighted);
        }

        [Test]
        public async Task CheckBetWasAddedIntoBetslip()
        {
            //arraange
            await _liveBettingPage.NavigateToLiveBettingPageAsync();
            await _liveBettingPage.NavigateToEventsTabAsync();

            //act
            await _liveBettingPage.ChooseOddAsync();

            //asset
            bool isBetAddedIntoBetslip = await _liveBettingPage.IsOddWasAddedIntoBetsSlipAsync();
            Assert.IsTrue(isBetAddedIntoBetslip);
        }
    }
}
