using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;

[TestFixture]
[AllureNUnit]
[AllureSuite("Checkboxes")]
[Parallelizable(ParallelScope.Fixtures)]
public class CheckboxesTests : BaseTest
{
    private CheckboxesPage _page = null!;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        _page = new CheckboxesPage(_driver);
        _page.Open();
    }

    [Test]
    [Retry(3)]
    [AllureName("Всі чекбокси мають бути увімкнені")]
    public void SelectAll_AllCheckboxesSelected()
    {
        _page.SelectAll();
        Assert.That(_page.AllSelected(), Is.True);
    }
}