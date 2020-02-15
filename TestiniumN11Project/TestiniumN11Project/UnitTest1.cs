using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestiniumN11Project
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        [TestMethod]
        public void TestMethod1()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.n11.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Giriş Yap")).Click();
            driver.FindElement(By.Id("contentWrapper")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("testiniumN11@gmail.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("TestTest1234");
            driver.FindElement(By.Id("loginButton")).Click();
            driver.FindElement(By.Id("searchData")).Click();
            driver.FindElement(By.Id("searchData")).Clear();
            driver.FindElement(By.Id("searchData")).SendKeys("Bilgisayar");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//header[@id='header']/div/div/div[2]/div/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", driver.FindElement(By.ClassName("pagination")));
            driver.FindElement(By.LinkText("2")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", driver.FindElement(By.ClassName("column")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//div[@id='p-372507725']/div/a/h3")).Click();

            driver.FindElement(By.LinkText("Sepete Ekle")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var newPrice = Convert.ToDecimal(driver.FindElement(By.ClassName("newPrice")).Text.Split(' ')[0]);
            driver.FindElement(By.ClassName("myBasket")).Click();
            var priceArea = Convert.ToDecimal(driver.FindElement(By.ClassName("priceArea")).Text.Split(' ')[0]);

            if (newPrice == priceArea)
            {
                driver.FindElement(By.XPath("//div[@id='newCheckout']/div/div/div[2]/div/section/table[2]/tbody/tr/td[3]/div/div/span")).Click();
                driver.FindElement(By.XPath("//div[@id='newCheckout']/div/div/div[2]/div/section/table[2]/tbody/tr/td/div[3]/div[2]/span")).Click();

            }
            else
            {
                driver.FindElement(By.XPath("//div[@id='newCheckout']/div/div/div[2]/div/section/table[2]/tbody/tr/td/div[3]/div[2]/span")).Click();

            }


            //driver.FindElement(By.LinkText("Çıkış Yap")).Click();
            driver.Quit();

        }
    }
}
