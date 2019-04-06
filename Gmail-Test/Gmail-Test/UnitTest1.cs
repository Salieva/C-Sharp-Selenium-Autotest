using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Gmail_Test
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url="http:\\gmail.com";
            IWebElement element = driver.FindElement(By.XPath("//input[@id='identifierId']"));
            element.SendKeys("oselenium");
            element = driver.FindElement(By.XPath("//div[@id='identifierNext']"));
            element.Click();
            element = driver.FindElement(By.XPath("//input[@name='password']"));
            element.SendKeys("Dennis_345");
            driver.FindElement(By.XPath("//div[@id='passwordNext']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@email='DENNIS.DIDULO@bd.com']")));
            element = driver.FindElement(By.XPath("//span[@email='DENNIS.DIDULO@bd.com']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
            By loc = (By.XPath("//p[contains(text(), 'done')]"));
            Assert.IsTrue(IsElementPresent(driver, loc));
            System.Threading.Thread.Sleep(5000);
            driver.Quit();

            bool IsElementPresent(IWebDriver drv, By locator)
            {
                try
                {
                    drv.FindElement(locator);
                    return true;
                }
                catch (NoSuchElementException ex)
                {
                    return false;
                }
            }


        }
    }
}
