using OpenQA.Selenium;

public class WindowsPage : BasePage
{
    private const string URL = "https://the-internet.herokuapp.com/windows";
    private By ClickHereLink => By.LinkText("Click Here");

    public WindowsPage(IWebDriver driver) : base(driver) { }

    public void Open() => Driver.Navigate().GoToUrl(URL);

    public string GetOriginalWindow() => Driver.CurrentWindowHandle;

    public void ClickHere() => Click(ClickHereLink);

    // Чекаємо нову вкладку і переходимо — БЕЗ індексів
    public string SwitchToNewWindow(string originalWindow)
    {
        Wait.Until(d => d.WindowHandles.Count > 1);
        var newWindow = Driver.WindowHandles.First(w => w != originalWindow);
        Driver.SwitchTo().Window(newWindow);
        return newWindow;
    }

    public void SwitchToWindow(string handle)
        => Driver.SwitchTo().Window(handle);

    public void CloseCurrentWindow() => Driver.Close();
}