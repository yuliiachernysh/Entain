using Microsoft.Playwright;

namespace Entain.ObjectRepositories
{
    public class LiveBettingPageRepository
    {
        private readonly IPage _page;


        public LiveBettingPageRepository(IPage page)
        {
            _page = page;
        }

        public ILocator EventViewTab { get => _page.Locator("xpath=.//*[@id='ds-tab-id-1-2']"); }
        public ILocator OverviewTab { get => _page.Locator("xpath=.//div[@class='ds-tab-item']/a[text()=' Overview ']"); }

        #region OverviewGames
        public ILocator OverviewTableTennisGame { get => _page.Locator("xpath=.//*[@class='slot slot-multi slot-inner-navigation']//span[text()=' Table Tennis ']"); }
        //{ get => _page.Locator("xpath=(.//a[contains(@class, 'tab-vertical-content')])[9]"); }
        public ILocator FirtsOverviewOddValue { get => _page.Locator("xpath = (.//*[@class='grid-option-selectable'])[1]//div[contains(@class,  'option-indicator')]/div[contains(@class,  'option-value')]"); }
        public ILocator FirtsOverviewOdd { get => _page.Locator("xpath=(.//*[@class='grid-option-selectable'])[1]//div[contains(@class,  'option-indicator')]"); }
        #endregion

        #region EventBetTabs
        public ILocator AllEventTab { get => _page.Locator("xpath=.//span[@data-menu-item-id='-1']"); }
        public ILocator MainEventTab { get => _page.Locator("xpath=.//span[@data-menu-item-id='-1']"); }
        #endregion

        #region OddsValue
        public ILocator FirstOddValue { get => _page.Locator("xpath=(.//*[@class='option-pick']/*[contains(@class, 'option-indicator')])[1]"); }
        #endregion

        #region ChosenBets
        public ILocator BetSlips { get => _page.Locator("xpath=.//li[@id='ds-tab-id-3-0']"); }
        public ILocator ChosenOddValue { get => _page.Locator("xpath=.//div[contains(@class, 'betslip-pick-odds__value')]"); }
        public ILocator BetSlipSummary { get => _page.Locator("xpath=.//div[@class='linear-single-bet-pick-summary']"); }
        #endregion


    }
}
