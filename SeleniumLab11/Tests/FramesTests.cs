using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

[TestFixture]
[AllureNUnit]
[AllureSuite("Frames")]
[Parallelizable(ParallelScope.Fixtures)]
public class FramesTests : BaseTest
{
    private NestedFramesPage _page = null!;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        _page = new NestedFramesPage(_driver);
        _page.Open();
    }

    [Test]
    [Retry(3)]
    [AllureName("frame-middle містить текст MIDDLE")]
    public void MiddleFrame_HasCorrectText()
    {
        _page.SwitchToTop();
        _page.SwitchToMiddle();
        Assert.That(_page.GetBodyText(), Is.EqualTo("MIDDLE"));
    }

    [Test]
    [Retry(3)]
    [AllureName("frame-top містить 3 вкладені фрейми")]
    public void TopFrame_HasThreeNestedFrames()
    {
        _page.SwitchToTop();
        var frames = _driver.FindElements(By.CssSelector("frame"));
        Assert.That(frames.Count, Is.EqualTo(3));
    }

    [Test]
    [Retry(3)]
    [AllureName("frame-left і frame-right мають правильний текст")]
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
    [Retry(3)]
    [AllureName("frame-bottom містить BOTTOM")]
    public void BottomFrame_HasCorrectText()
    {
        _page.SwitchToDefault();
        _page.SwitchToBottom();
        Assert.That(_page.GetBodyText(), Is.EqualTo("BOTTOM"));
    }
}