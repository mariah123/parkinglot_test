using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestUsingSelenium.Test;

public class CheckInTest
{
    [Fact]
    public void CheckInSuccessful()
    {
        string URL = "https://localhost:7217/";
        ChromeDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(URL);

        IWebElement textTagName = driver.FindElement(By.Id("tagNumber"));

        textTagName.SendKeys("test350");

        IWebElement btnCheckIn = driver.FindElement(By.Id("btnCheckIn"));

        btnCheckIn.Click();

        WebDriverWait wait = new WebDriverWait(driver, new System.TimeSpan(0, 0, 10));
        wait.Until(w => w.FindElement(By.Id("toast-container")));

        IWebElement tableFirstColumn = driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div[2]/div/div[4]/table/tbody/tr[1]/td[1]"));
        
        Assert.Equal("test350", tableFirstColumn.Text);

    }
}