using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected IWebDriver Driver;
    protected WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement Find(By locator)
        => Wait.Until(d => d.FindElement(locator));

    protected void Click(By locator)
    {
        Wait.Until(d =>
        {
            d.FindElement(locator).Click();
            return true;
        });
    }

    protected void Type(By locator, string text)
    {
        var el = Find(locator);
        el.Clear();
        el.SendKeys(text);
    }

    protected string GetText(By locator)
        => Find(locator).Text;
}