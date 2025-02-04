using Entain.Pages;

namespace Entain.Tests
{
    [TestFixture]
    public class AZSportsTestSuit : BaseTest
    {
        private AZSportsPage _page;
        private MainPage _mainPage;

        [SetUp]
        public async Task Init()
        {
            _page = new AZSportsPage(page);
            _mainPage = new MainPage(page);
        }

        [Test]
        public async Task CheckNavigationForSportsType()
        {
            //arrange
            await _mainPage.GoToHomePageAsync();

            //act
            await _page.NavigateAZsportsTabAsync();
            await _page.ChooseSportTypeAsync("Cricket");
            string currentUrl = await _page.GetCurrentUrl();

            //assert
            Assert.That(currentUrl, Is.EqualTo("https://sports.bwin.com/en/sports/cricket-22"));

            //act
            bool isCricketTabHighlighted = await _page.IsCricketTabHighlightedAsync();

            //assert
            Assert.IsTrue(isCricketTabHighlighted);
        }
    }
}
