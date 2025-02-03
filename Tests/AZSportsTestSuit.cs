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
            await _mainPage.GoToHomePage();

            //act
            await _page.NavigateAZsportsTab();
            await _page.ChooseSportType("Cricket");
            string currentUrl = _page.GetCurrentUrl();

            //assert
            //Assert.That(currentUrl, Is.EqualTo("https://sports.bwin.com/en/sports/cricket-22"));

            //act
            bool isCricketTabHighlighted = await _page.IsCricketTabHighlighted();

            //assert
            Assert.IsTrue(isCricketTabHighlighted);
        }
    }
}
