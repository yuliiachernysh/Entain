using Microsoft.Playwright;

namespace Entain.Pages
{
    public class MainPage
    {
        private readonly IPage _page;

        public MainPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToHomePage()
        {
            await _page.GotoAsync("https://sports.bwin.com/en/sports");
        }
    }
}
