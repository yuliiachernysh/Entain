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
            await _liveBettingPage.NavigateToLiveBettingPageAsync();
            await _liveBettingPage.NavigateToOvewviewTabAsync();
            await _liveBettingPage.NavigateToTableTennisTabAsync();

            //act
            await _liveBettingPage.ChooseOvewviewOddAsync();
            (bool isOddUpdated, bool isIncreased) = await _liveBettingPage.IsOveriewOddUpdatedAsync();

            //assert
            Assert.True(isOddUpdated);

            //act
            bool isOddIndicatorUpdated = await _liveBettingPage.IsOddIndicatorUpdatedAsync(isIncreased);

            //assert
            Assert.True(isOddIndicatorUpdated);
        }
    }
}
