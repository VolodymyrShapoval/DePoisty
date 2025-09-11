using DePoisty.ParserService.Infrastructure.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DePoisty.ParserService.Infrastructure.Selenium
{
    public class SeleniumWrapper : IDisposable
    {
        private readonly IWebDriver _driver;

        public SeleniumWrapper(bool headless = true)
        {
            var options = new ChromeOptions();
            if (headless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--window-size=1920,1080");
            }

            _driver = new ChromeDriver(options);
        }

        public IWebDriver Driver => _driver;

        public void Navigate(string url) => _driver.Navigate().GoToUrl(url);

        public string GetPageSource() => _driver.PageSource;

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        public bool IsElementVisible(string locator)
        {
            try
            {
                var element = _driver.FindElement(By.XPath(locator));
                return element?.Displayed ?? false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void AssertElementIsVisible(string locator)
        {
            for (int second = 0; second < Constants.TimeoutSeconds; second++)
            {
                if (IsElementVisible(locator))
                {
                    return;
                }

                Thread.Sleep(1000);
            }

            throw new SeleniumParsingException("Element is not visible");
        }
        public void Click(string locator)
        {
            try
            {
                AssertElementIsVisible(locator);
                _driver.FindElement(By.XPath(locator))?.Click();
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case SeleniumParsingException _:
                        throw new SeleniumParsingException($"Couldn't click on the element `{locator}`! Error message: {ex.Message}");
                    default:
                        throw new Exception($"Couldn't click on the element `{locator}`! Unknown error with message: {ex.Message}");
                }
            }
        }
        public void Select(string selectLocator, string optionText)
        {
            try
            {
                AssertElementIsVisible(selectLocator);
                var selectElement = new SelectElement(_driver.FindElement(By.XPath(selectLocator)));
                selectElement.SelectByText(optionText);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case SeleniumParsingException _:
                        throw new SeleniumParsingException($"Couldn't select the element `{selectLocator}` with option '{optionText}'! Error message: {ex.Message}");
                    default:
                        throw new Exception($"Couldn't select the element `{selectLocator}` with option '{optionText}'! Unknown error with message: {ex.Message}");
                }
            }
        }
        public void SelectCustom(string dropdownLocator, string optionLocator)
        {
            try
            {

                AssertElementIsVisible(dropdownLocator);
                _driver.FindElement(By.XPath(dropdownLocator)).Click();

                AssertElementIsVisible(optionLocator);
                _driver.FindElement(By.XPath(optionLocator)).Click();
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case SeleniumParsingException _:
                        throw new SeleniumParsingException($"Couldn't execute custom selection on the element `{dropdownLocator}` with option locator '{optionLocator}'! Error message: {ex.Message}");
                    default:
                        throw new Exception($"Couldn't execute custom selection on the element `{dropdownLocator}` with option locator '{optionLocator}'! Unknown error with message: {ex.Message}");
                }
            }
        }
        public void ScrollToElement(string locator)
        {
            try
            {
                AssertElementIsVisible(locator);
                var element = _driver.FindElement(By.XPath(locator));
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    default:
                        throw new Exception($"Couldn't scroll to the element `{locator}`! Unknown error with message: {ex.Message}");
                }
            }
        }

    }
}