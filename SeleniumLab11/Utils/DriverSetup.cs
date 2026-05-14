using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class DriverSetup
{
    public static IWebDriver GetDriver()
    {
        var options = new ChromeOptions();

        bool headless = Environment.GetEnvironmentVariable("HEADLESS") == "true";
        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }

        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");

        var driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
        return driver;
    }
}