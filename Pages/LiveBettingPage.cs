using Entain.ObjectRepositories;
using Microsoft.Playwright;

namespace Entain.Pages
{
    public class LiveBettingPage
    {
        private readonly IPage _page;
        private readonly LiveBettingPageRepository _liveBettingPageRepository;


        public LiveBettingPage(IPage page)
        {
            _page = page;
            _liveBettingPageRepository = new LiveBettingPageRepository(page);
        }

        public async Task NavigateToLiveBettingPage()
        {
            await _page.GotoAsync("https://sports.bwin.com/en/sports/live/betting");
        }

        public async Task NavigateToEventsTab()
        {
            await _liveBettingPageRepository.EventViewTab.WaitForAsync();
            await _liveBettingPageRepository.EventViewTab.ClickAsync();
        }

        public async Task NavigateToOvewviewTab()
        {
            await _liveBettingPageRepository.OverviewTab.WaitForAsync();
            await _liveBettingPageRepository.OverviewTab.ClickAsync();
        }

        public async Task NavigateToTableTennisTab()
        {
            await _liveBettingPageRepository.OverviewTableTennisGame.WaitForAsync();
            await _liveBettingPageRepository.OverviewTableTennisGame.ClickAsync();
        }

        public async Task ChooseOdd()
        {
            await _liveBettingPageRepository.AllEventTab.IsVisibleAsync();
            await _liveBettingPageRepository.AllEventTab.ClickAsync();

            await _liveBettingPageRepository.FirstOddValue.ClickAsync();
        }

        public async Task ChooseOvewviewOdd()
        {
            await _liveBettingPageRepository.FirtsOverviewOddValue.WaitForAsync();
            await _liveBettingPageRepository.FirtsOverviewOddValue.ClickAsync();
        }

        public async Task<(bool isUpdated, bool isIncreased)> IsOveriewOddUpdated()
        {
            string? previousOdd = await _liveBettingPageRepository.FirtsOverviewOddValue.TextContentAsync();
            bool isUpdated = false;
            string updatedOdd = null;
            for (int i = 0; i < 60; i++)
            {
                updatedOdd = await _liveBettingPageRepository.FirtsOverviewOddValue.TextContentAsync();
                if (updatedOdd != previousOdd)
                {
                    isUpdated = true;
                    break;
                }
                await Task.Delay(500);
            }

            var convertedUpdatedOdd = Convert.ToDecimal(updatedOdd);
            var convertedPreviousOdd = Convert.ToDecimal(previousOdd);
            bool isIncreased = convertedUpdatedOdd > convertedPreviousOdd;

            return (isUpdated, isIncreased);
        }

        public async Task<bool> IsOddIndicatorUpdated(bool isIncreased)
        {
            bool isOddIndicatorUpdated = false;
            var indicatorResult = await _liveBettingPageRepository.FirstOddValue.GetAttributeAsync("class");
            if (isIncreased)
            {
                isOddIndicatorUpdated = indicatorResult.Contains("increased");
            }
            isOddIndicatorUpdated = indicatorResult.Contains("decreased")
            return isOddIndicatorUpdated;
        }

        public async Task<bool> IsOddHighlighted()
        {
            var attibuteResult = await _liveBettingPageRepository.FirstOddValue.GetAttributeAsync("class");
            bool isOddSelected = attibuteResult.Equals("option-indicator selected");
            return isOddSelected;
        }

        public async Task<bool> IsOddWasAddedIntoBetsSlip()
        {
            var isOddIsDisplayedIntoBetsSlip = await _liveBettingPageRepository.BetSlipSummary.IsVisibleAsync();
            return isOddIsDisplayedIntoBetsSlip;
        }
    }
}
