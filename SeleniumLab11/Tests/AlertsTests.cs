using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;

[TestFixture]
[AllureNUnit]
[AllureSuite("Alerts")]
[Parallelizable(ParallelScope.Fixtures)]
public class AlertsTests : BaseTest
{
    private AlertsPage _page = null!;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        _page = new AlertsPage(_driver);
        _page.Open();
    }

    [Test]
    [Retry(3)]
    [AllureName("JS Alert — прийняти")]
    public void Alert_Accept_ShowsOk()
    {
        _page.ClickAlert();
        _page.AcceptAlert();
        StringAssert.Contains("You successfuly", _page.GetResultText());
    }

    [Test]
    [Retry(3)]
    [AllureName("JS Confirm — OK")]
    public void Confirm_OK_ShowsOk()
    {
        _page.ClickConfirm();
        _page.AcceptAlert();
        StringAssert.Contains("Ok", _page.GetResultText());
    }

    [Test]
    [Retry(3)]
    [AllureName("JS Confirm — Cancel")]
    public void Confirm_Cancel_ShowsCancel()
    {
        _page.ClickConfirm();
        _page.DismissAlert();
        StringAssert.Contains("Cancel", _page.GetResultText());
    }

    [Test]
    [Retry(3)]
    [AllureName("JS Prompt — введення та перевірка тексту")]
    public void Prompt_EnterText_ShowsText()
    {
        _page.ClickPrompt();
        _page.SendTextToAlert("Hello Selenium");
        StringAssert.Contains("Hello Selenium", _page.GetResultText());
    }
}