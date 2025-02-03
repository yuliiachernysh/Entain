
using Entain.ObjectRepositories;
using Microsoft.Playwright;

namespace Entain.Pages
{
    public class AZSportsPage
    {
        private readonly IPage _page;
        private readonly AZSportsPageRepository _aZSportsPageRepository;

        public AZSportsPage(IPage page)
        {
            _page = page;
            _aZSportsPageRepository = new AZSportsPageRepository(_page);
        }

        public async Task NavigateAZsportsTab()
        {
            await _aZSportsPageRepository.AZsportsTab.WaitForAsync();
            await _aZSportsPageRepository.AZsportsTab.ClickAsync();
        }

        public async Task ChooseSportType(string sportType)
        {
            await _aZSportsPageRepository.SportTypePicker(sportType).WaitForAsync();
            await _aZSportsPageRepository.SportTypePicker(sportType).ClickAsync();
        }

        public string GetCurrentUrl()
        {

            string url = _page.Url;
            return url;
        }

        public async Task<bool> IsCricketTabHighlighted()
        {
            var attibuteResult = await _aZSportsPageRepository.CricketTab.GetAttributeAsync("class");
            bool isCricketTabSelected = attibuteResult.Contains("active");
            return isCricketTabSelected;
        }
    }
}
