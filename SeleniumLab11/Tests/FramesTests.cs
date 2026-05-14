using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

[TestFixture]
[AllureNUnit]
[AllureSuite("Frames")]
public class FramesTests
{
    private IWebDriver _driver = null!;
    private NestedFramesPage _page = null!;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverSetup.GetDriver();
        _page = new NestedFramesPage(_driver);
        _page.Open();
    }

    [Test]
    [AllureName("frame-middle містить текст MIDDLE")]
    public void MiddleFrame_HasCorrectText()
    {
        _page.SwitchToTop();
        _page.SwitchToMiddle();
        Assert.That(_page.GetBodyText(), Is.EqualTo("MIDDLE"));
    }

    [Test]
    [AllureName("frame-top містить 3 вкладені фрейми")]
    public void TopFrame_HasThreeNestedFrames()
    {
        _page.SwitchToTop();
        var frames = _driver.FindElements(By.CssSelector("frame"));
        Assert.That(frames.Count, Is.EqualTo(3));
    }

    [Test]
    [AllureName("frame-left містить LEFT, frame-right містить RIGHT")]
    public void LeftAndRightFrames_HaveCorrectText()
    {
        _page.SwitchToTop();
        _page.SwitchToLeft();
        Assert.That(_page.GetBodyText(), Is.EqualTo("LEFT"));

        _page.SwitchToDefault();
        _page.SwitchToTop();
        _page.SwitchToRight();
        Assert.That(_page.GetBodyText(), Is.EqualTo("RIGHT"));
    }

    [Test]
    [AllureName("frame-bottom містить BOTTOM")]
    public void BottomFrame_HasCorrectText()
    {
        _page.SwitchToDefault();
        _page.SwitchToBottom();
        Assert.That(_page.GetBodyText(), Is.EqualTo("BOTTOM"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}