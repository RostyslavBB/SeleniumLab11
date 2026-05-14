using OpenQA.Selenium;

public class NestedFramesPage : BasePage
{
    private const string URL = "https://the-internet.herokuapp.com/nested_frames";

    public NestedFramesPage(IWebDriver driver) : base(driver) { }

    public void Open() => Driver.Navigate().GoToUrl(URL);

    public void SwitchToDefault() => Driver.SwitchTo().DefaultContent();
    public void SwitchToTop() => Driver.SwitchTo().Frame("frame-top");
    public void SwitchToLeft() => Driver.SwitchTo().Frame("frame-left");
    public void SwitchToMiddle() => Driver.SwitchTo().Frame("frame-middle");
    public void SwitchToRight() => Driver.SwitchTo().Frame("frame-right");
    public void SwitchToBottom() => Driver.SwitchTo().Frame("frame-bottom");

    public string GetBodyText()
        => Driver.FindElement(By.TagName("body")).Text.Trim();
}