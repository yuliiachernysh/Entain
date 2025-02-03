using Entain.Configuration;
using Microsoft.Playwright;

namespace Entain.Tests
{
    public class BaseTest
    {
        protected IPlaywright playwright;

        protected IBrowserContext browser;

        protected IPage page;

        [SetUp]
        public async Task BeforeTests()
        {
            page = await browser.NewPageAsync();
        }

        [TearDown]
        public async Task AfterTest()
        {
            await page.CloseAsync();
        }

        [OneTimeSetUp]
        public async Task Init()
        {
            var config = ConfigReader.LoadConfig();

            playwright = await Playwright.CreateAsync();
            var chromium = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var (width, height) = config.GetViewportSize(config.GetDevice());
            browser = await chromium.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = width, Height = height }
            });
        }

        [OneTimeTearDown]
        public async Task Close()
        {
            await browser.DisposeAsync();
            playwright?.Dispose();
        }
    }
}
