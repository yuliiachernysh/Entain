using Microsoft.Playwright;

namespace Entain.ObjectRepositories
{
    public class MainPageRepository
    {
        private readonly IPage _page;

        public MainPageRepository(IPage page)
        {
            _page = page;
        }

        public ILocator LiveCasinoTab { get => _page.Locator(".//a[@title='Live Casino']"); }
        public ILocator LiveBettingTab { get => _page.Locator(".//a[@href='https://sports.bwin.com/en/sports/live/betting']/*[@data-testid='live']"); }
        public ILocator AZSportsTab { get => _page.Locator(".//*[@data-testid='all']"); }
    }
}
