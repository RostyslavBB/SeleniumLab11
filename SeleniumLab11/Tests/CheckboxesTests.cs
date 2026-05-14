using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

[TestFixture]
[AllureNUnit]
[AllureSuite("Checkboxes")]
public class CheckboxesTests
{
    private IWebDriver _driver = null!;
    private CheckboxesPage _page = null!;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverSetup.GetDriver();
        _page = new CheckboxesPage(_driver);
        _page.Open();
    }

    [Test]
    [AllureName("Всі чекбокси мають бути увімкнені")]
    public void SelectAll_AllCheckboxesSelected()
    {
        _page.SelectAll();
        Assert.That(_page.AllSelected(), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}