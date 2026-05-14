using OpenQA.Selenium;

public class AlertsPage : BasePage
{
    private const string URL = "https://the-internet.herokuapp.com/javascript_alerts";

    private By AlertBtn => By.XPath("//button[text()='Click for JS Alert']");
    private By ConfirmBtn => By.XPath("//button[text()='Click for JS Confirm']");
    private By PromptBtn => By.XPath("//button[text()='Click for JS Prompt']");
    private By Result => By.Id("result");

    public AlertsPage(IWebDriver driver) : base(driver) { }

    public void Open() => Driver.Navigate().GoToUrl(URL);

    public void ClickAlert() => Click(AlertBtn);
    public void ClickConfirm() => Click(ConfirmBtn);
    public void ClickPrompt() => Click(PromptBtn);

    public void AcceptAlert()
    {
        var alert = Wait.Until(d => d.SwitchTo().Alert());
        alert.Accept();
    }

    public void DismissAlert()
    {
        var alert = Wait.Until(d => d.SwitchTo().Alert());
        alert.Dismiss();
    }

    public void SendTextToAlert(string text)
    {
        var alert = Wait.Until(d => d.SwitchTo().Alert());
        alert.SendKeys(text);
        alert.Accept();
    }

    public string GetResultText() => GetText(Result);
}