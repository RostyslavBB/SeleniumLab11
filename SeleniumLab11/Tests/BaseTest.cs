using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Allure.Net.Commons;

public abstract class BaseTest
{
    protected IWebDriver _driver = null!;

    [SetUp]
    public virtual void SetUp()
    {
        _driver = DriverSetup.GetDriver();
    }

    [TearDown]
    public virtual void TearDown()
    {
        // Автоскріншот при падінні + прикріплення до Allure
        if (TestContext.CurrentContext.Result.Outcome.Status ==
            NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var bytes = screenshot.AsByteArray;
                AllureApi.AddAttachment(
                    "Screenshot on failure",
                    "image/png",
                    bytes,
                    "png"
                );
            }
            catch { /* драйвер міг вже закритись */ }
        }

        _driver?.Quit();
        _driver?.Dispose();
    }
}