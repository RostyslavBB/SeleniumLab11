using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

[TestFixture]
[AllureNUnit]
[AllureSuite("Alerts")]
public class AlertsTests
{
    private IWebDriver _driver = null!;
    private AlertsPage _page = null!;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverSetup.GetDriver();
        _page = new AlertsPage(_driver);
        _page.Open();
    }

    [Test]
    [AllureName("JS Alert — прийняти")]
    public void Alert_Accept_ShowsOk()
    {
        _page.ClickAlert();
        _page.AcceptAlert();
        StringAssert.Contains("You successfuly", _page.GetResultText());
    }

    [Test]
    [AllureName("JS Confirm — OK")]
    public void Confirm_OK_ShowsOk()
    {
        _page.ClickConfirm();
        _page.AcceptAlert();
        StringAssert.Contains("Ok", _page.GetResultText());
    }

    [Test]
    [AllureName("JS Confirm — Cancel")]
    public void Confirm_Cancel_ShowsCancel()
    {
        _page.ClickConfirm();
        _page.DismissAlert();
        StringAssert.Contains("Cancel", _page.GetResultText());
    }

    [Test]
    [AllureName("JS Prompt — введення та перевірка тексту")]
    public void Prompt_EnterText_ShowsText()
    {
        _page.ClickPrompt();
        _page.SendTextToAlert("Hello Selenium");
        StringAssert.Contains("Hello Selenium", _page.GetResultText());
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}