using OpenQA.Selenium;

public class CheckboxesPage : BasePage
{
    private const string URL = "https://the-internet.herokuapp.com/checkboxes";
    private By Checkboxes => By.CssSelector("input[type='checkbox']");

    public CheckboxesPage(IWebDriver driver) : base(driver) { }

    public void Open() => Driver.Navigate().GoToUrl(URL);

    public void SelectAll()
    {
        var boxes = Driver.FindElements(Checkboxes);
        foreach (var cb in boxes)
            if (!cb.Selected) cb.Click();
    }

    public bool AllSelected()
    {
        var boxes = Driver.FindElements(Checkboxes);
        return boxes.All(cb => cb.Selected);
    }
}