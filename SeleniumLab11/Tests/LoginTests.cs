using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

[TestFixture]
[AllureNUnit]
[AllureSuite("Login")]
public class LoginTests
{
    private IWebDriver _driver = null!;
    private LoginPage _page = null!;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverSetup.GetDriver();
        _page = new LoginPage(_driver);
        _page.Open();
    }

    [Test]
    [AllureName("Некоректний логін показує помилку")]
    public void InvalidLogin_ShowsError()
    {
        // Arrange — вже в SetUp
        // Act
        _page.Login("wrong", "wrong");
        // Assert
        StringAssert.Contains("invalid", _page.GetFlashText());
    }

    [Test]
    [AllureName("Коректний логін відкриває захищену зону")]
    public void ValidLogin_ShowsSuccess()
    {
        _page.Login("tomsmith", "SuperSecretPassword!");
        StringAssert.Contains("secure area", _page.GetFlashText());
    }

    // Параметризований тест (High level)
    private static readonly object[] LoginCases =
    {
        new object[] { "wrong",    "wrong",                "invalid"     },
        new object[] { "tomsmith", "SuperSecretPassword!", "secure area" },
    };

    [Test]
    [AllureName("Параметризований логін")]
    [TestCaseSource(nameof(LoginCases))]
    public void Login_Parametrized(string user, string pass, string expected)
    {
        _page.Login(user, pass);
        StringAssert.Contains(expected, _page.GetFlashText());
    }

    [TearDown]
    public void TearDown()
    {
        // Автоскріншот при падінні
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var path = $"screenshot_{TestContext.CurrentContext.Test.Name}.png";
            screenshot.SaveAsFile(path);
        }
        _driver.Quit();
        _driver?.Dispose();
    }
}