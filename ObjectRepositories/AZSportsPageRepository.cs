using Microsoft.Playwright;

namespace Entain.ObjectRepositories
{
    public class AZSportsPageRepository
    {
        private readonly IPage _page;
        public AZSportsPageRepository(IPage page)
        {
            _page = page;
        }

        #region Sports
        public ILocator AZsportsTab { get => _page.Locator("xpath = .//*[@data-testid='all']"); }
        public ILocator SportTypePicker(string sportType) => _page.Locator($"xpath= .//span[(.)='{sportType}']");
        #endregion

        #region Tab
        public ILocator CricketTab { get => _page.Locator("xpath=.//*[@data-testid='22']/.."); }
        public ILocator CalendatTab { get => _page.Locator("xpath=.//a[(.)='Calendar']"); }
        #endregion
    }
}
