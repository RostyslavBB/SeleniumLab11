using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

[TestFixture]
[AllureNUnit]
[AllureSuite("Windows")]
[Parallelizable(ParallelScope.Fixtures)]
public class WindowsTests : BaseTest
{
    private WindowsPage _page = null!;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        _page = new WindowsPage(_driver);
        _page.Open();
    }

    [Test]
    [Retry(3)]
    [AllureName("Нова вкладка має заголовок New Window")]
    public void NewWindow_HasCorrectTitle()
    {
        var original = _page.GetOriginalWindow();
        _page.ClickHere();
        _page.SwitchToNewWindow(original);

        var h3 = _driver.FindElement(By.TagName("h3")).Text;
        Assert.That(h3, Is.EqualTo("New Window"));
    }

    [Test]
    [Retry(3)]
    [AllureName("Закрити нову вкладку і повернутись на оригінальну")]
    public void CloseNewWindow_ReturnToOriginal()
    {
        var original = _page.GetOriginalWindow();
        _page.ClickHere();
        _page.SwitchToNewWindow(original);
        _page.CloseCurrentWindow();
        _page.SwitchToWindow(original);

        Assert.That(
            _driver.FindElement(By.LinkText("Click Here")).Displayed,
            Is.True);
    }

    [Test]
    [Retry(3)]
    [AllureName("Відкрити 2 нові вкладки і перевірити кожну")]
    public void TwoNewWindows_AllHaveCorrectContent()
    {
        var original = _page.GetOriginalWindow();

        _page.ClickHere();
        _page.SwitchToNewWindow(original);
        Assert.That(_driver.FindElement(By.TagName("h3")).Text,
            Is.EqualTo("New Window"));

        _page.SwitchToWindow(original);
        _page.ClickHere();

        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.WindowHandles.Count >= 3);

        foreach (var handle in _driver.WindowHandles.Where(h => h != original))
        {
            _driver.SwitchTo().Window(handle);
            Assert.That(_driver.FindElement(By.TagName("h3")).Text,
                Is.EqualTo("New Window"));
        }
    }
}