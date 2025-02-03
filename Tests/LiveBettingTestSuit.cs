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
            await _liveBettingPage.NavigateToLiveBettingPage();
            await _liveBettingPage.NavigateToEventsTab();

            //act
            await _liveBettingPage.ChooseOdd();

            //asset
            bool isOddHighlighted = await _liveBettingPage.IsOddHighlighted();
            Assert.IsTrue(isOddHighlighted);
        }

        [Test]
        public async Task CheckBetWasAddedIntoBetslip()
        {
            //arraange
            await _liveBettingPage.NavigateToLiveBettingPage();
            await _liveBettingPage.NavigateToEventsTab();

            //act
            await _liveBettingPage.ChooseOdd();

            //asset
            bool isBetAddedIntoBetslip = await _liveBettingPage.IsOddWasAddedIntoBetsSlip();
            Assert.IsTrue(isBetAddedIntoBetslip);
        }
    }
}
