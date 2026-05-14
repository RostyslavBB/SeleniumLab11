using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;

[TestFixture]
[AllureNUnit]
[AllureSuite("Login")]
[Parallelizable(ParallelScope.Fixtures)]
public class LoginTests : BaseTest
{
    private LoginPage _page = null!;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        _page = new LoginPage(_driver);
        _page.Open();
    }

    [Test]
    [Retry(3)]
    [AllureName("Некоректний логін показує помилку")]
    public void InvalidLogin_ShowsError()
    {
        _page.Login("wrong", "wrong");
        StringAssert.Contains("invalid", _page.GetFlashText());
    }

    [Test]
    [Retry(3)]
    [AllureName("Коректний логін відкриває захищену зону")]
    public void ValidLogin_ShowsSuccess()
    {
        _page.Login("tomsmith", "SuperSecretPassword!");
        StringAssert.Contains("secure area", _page.GetFlashText());
    }

    private static readonly object[] LoginCases =
    {
        new object[] { "wrong",    "wrong",                "invalid"     },
        new object[] { "tomsmith", "SuperSecretPassword!", "secure area" },
    };

    [Test]
    [Retry(3)]
    [AllureName("Параметризований логін")]
    [TestCaseSource(nameof(LoginCases))]
    public void Login_Parametrized(string user, string pass, string expected)
    {
        _page.Login(user, pass);
        StringAssert.Contains(expected, _page.GetFlashText());
    }
}