using Entain.Pages;

namespace Entain.Tests
{
    public class ValidateLiveOddsUpdatesTestSuit : BaseTest
    {
        private LiveBettingPage _liveBettingPage;

        [SetUp]
        public async Task Init()
        {
            _liveBettingPage = new LiveBettingPage(page);
        }

        [Test]
        public async Task CheckIfOddsUpdatedWithoutPageRefresh()
        {
            //arrenga
            await _liveBettingPage.NavigateToLiveBettingPage();
            await _liveBettingPage.NavigateToOvewviewTab();
            await _liveBettingPage.NavigateToTableTennisTab();

            //act
            await _liveBettingPage.ChooseOvewviewOdd();
            (bool isOddUpdated, bool isIncreased) = await _liveBettingPage.IsOveriewOddUpdated();

            //assert
            Assert.True(isOddUpdated);

            //act
            bool isOddIndicatorUpdated = await _liveBettingPage.IsOddIndicatorUpdated(isIncreased);

            //assert
            Assert.True(isOddIndicatorUpdated);
        }
    }
}
