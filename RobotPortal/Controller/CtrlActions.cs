using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace RobotPortal
{
    public class CtrlActions
    {
        public static IWebDriver driver;


        public void SendKeys(By elemento, string conteudo)
        {
            driver.FindElement(elemento).SendKeys(conteudo);
        }

        public void WaitLoad(By by)
        {
            if (!IsElementDisplayed(by))
            {
                Load(by);
            }
        }

        public void WaitLoadC()
        {
            if (IsElementDisplayed(By.Id("loader")))
            {
                Load(By.Id("loader"));
            }
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }


        public void Clear(By elemento)
        {
            driver.FindElement(elemento).Clear();
        }

        public void Wait(By elemento)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            Wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
            Thread.Sleep(4000);
        }


        public void Click(By elemento)
        {
            driver.FindElement(elemento).Click();
        }

        public IWebElement GetElement(By elemento)
        {
            return driver.FindElement(elemento);
        }

        public IList<IWebElement> ListElements(By elemento, By elementoFilho)
        {
            IWebElement webElement = GetElement(elemento);
            IList<IWebElement> listaWeb = webElement.FindElements(elementoFilho);
            return listaWeb;
        }


        public void SelectByText(By elemento, string conteudo)
        {
            new SelectElement(driver.FindElement(elemento)).SelectByText(conteudo);
        }


        public string GetElementText(By elemento)
        {
            return driver.FindElement(elemento).Text;
        }

        public void Load(By elemento)
        {
            WebDriverWait Load = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            Load.Until(ExpectedConditions.InvisibilityOfElementLocated(elemento));
        }


        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayed(By by)
        {
            return driver.FindElement(by).Displayed;
        }

        public void AssertIsElementPresent(By by)
        {
            Assert.IsTrue(IsElementPresent(by));
        }

        public void AssertTitleAreEqual(string validacao)
        {
            Assert.AreEqual(validacao, driver.Title);
        }

        public void AssertAreEqual(string validacao, By by)
        {
            Assert.AreEqual(validacao, driver.FindElement(by).Text.ToString());
        }

        public void AssertIsTrue(By by)
        {
            Assert.IsTrue(IsElementPresent(by));
        }
    }
}
