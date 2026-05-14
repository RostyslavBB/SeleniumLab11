using OpenQA.Selenium;

public class LoginPage : BasePage
{
    private const string URL = "https://the-internet.herokuapp.com/login";

    private By UsernameField => By.Id("username");
    private By PasswordField => By.Id("password");
    private By LoginBtn => By.CssSelector("button[type='submit']");
    private By FlashMsg => By.Id("flash");

    public LoginPage(IWebDriver driver) : base(driver) { }

    public void Open() => Driver.Navigate().GoToUrl(URL);

    public void Login(string user, string pass)
    {
        Type(UsernameField, user);
        Type(PasswordField, pass);
        Click(LoginBtn);
    }

    public string GetFlashText() => GetText(FlashMsg);
}