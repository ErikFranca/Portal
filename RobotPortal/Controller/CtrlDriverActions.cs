using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RobotPortal
{
    public class CtrlDriverActions
    {
        public IWebDriver driverAction;

        public CtrlDriverActions(IWebDriver driver)
        {
            this.driverAction = driver;
        }

        public void AssertFalseResult(string element)
        {
            Assert.IsFalse(IsElementPresent(By.CssSelector(element)));
        }

        public IWebElement FindById(string id)
        {
            return driverAction.FindElement(By.Id(id));

        }
        public IWebElement FindByClassName(string element)
        {
            return driverAction.FindElement(By.ClassName(element));
        }

        public IWebElement FindByLinkText(string element)
        {
            return driverAction.FindElement(By.LinkText(element));
        }

        public void SwitchTab()
        {
            Thread.Sleep(1000);
            var browserTabs = driverAction.WindowHandles;
            driverAction.SwitchTo().Window(browserTabs[1]);
        }

        public void AcceptAlert()
        {
            Thread.Sleep(1000);
            driverAction.SwitchTo().Alert().Accept();
        }
        public IWebElement FindByCss(string Css)
        {
            return driverAction.FindElement(By.CssSelector(Css));
        }
        public IWebElement FindByXpath(string xpath)
        {
            return driverAction.FindElement(By.XPath(xpath));
        }
        public IWebElement FindByName(string Name)
        {
            return driverAction.FindElement(By.Name(Name));
        }

        public void SwitchFrame(string Frame)
        {
            Thread.Sleep(1000);
            driverAction.SwitchTo().Frame(Frame);
        }
        public void SendKeys(IWebElement element, string content)
        {
            Thread.Sleep(1000);
            element.SendKeys(content);
        }

        

        public void WaitForPageToLoad(IWebDriver driver)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                    "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }        

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driverAction;
            executor.ExecuteScript("arguments[0].click();", element);
        }


        public void Clear(IWebElement elemento)
        {
            Thread.Sleep(1000);
            elemento.Clear();
            
        }

        public void Wait(By elemento)
        {
            WebDriverWait Wait = new WebDriverWait(driverAction, TimeSpan.FromSeconds(60));
            Wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
            Thread.Sleep(3000);
        }


        public void Click(IWebElement element)
        {
            Thread.Sleep(1000);
            element.Click();
        }

        public IWebElement GetElement(By element)
        {
            return driverAction.FindElement(element);
        }

        public IList<IWebElement> ListElements(By element, By elementoFilho)
        {
            IWebElement webElement = GetElement(element);
            IList<IWebElement> listaWeb = webElement.FindElements(elementoFilho);
            return listaWeb;
        }


        public void SelectByText(IWebElement element, string conteudo)
        {
            Thread.Sleep(1000);
            new SelectElement(element).SelectByText(conteudo);
        }


        public string GetElementText(IWebElement element)
        {
            return element.ToString();
        }


        public void Load(By element)
        {
            WebDriverWait Load = new WebDriverWait(driverAction, TimeSpan.FromSeconds(60));
            Load.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
        }


        public bool IsElementPresent(By by)
        {
            try
            {
                driverAction.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            Thread.Sleep(1000);
            return element.Displayed;
        }



        public void AssertTitleAreEqual(string validacao)
        {
            Assert.AreEqual(validacao, driverAction.Title);
        }

        public void AssertAreEqual(string validate, IWebElement element)
        {
            Thread.Sleep(1000);
            Assert.AreEqual(validate, element.Text.ToString());
        }

        public void AssertIsTrue(By by)
        {
            Assert.IsTrue(IsElementPresent(by));
        }


    }
}
