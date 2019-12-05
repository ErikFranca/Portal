﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Net;
using System.Text;

namespace RobotPortal
{
    public class CtrlDriverActions
    {
        public IWebDriver driverAction;

        public CtrlDriverActions(IWebDriver driver)
        {
            this.driverAction = driver;
        }

        public IWebElement FindById(string id)
        {
            return driverAction.FindElement(By.Id(id));
        }
        public IWebElement FindByCss(string Css)
        {
            return driverAction.FindElement(By.CssSelector(Css));
        }
        public IWebElement FindByClass(string Class)
        {
            return driverAction.FindElement(By.ClassName(Class));
        }
        public void SendKeys(IWebElement element, string content)
        {
            element.SendKeys(content);
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
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driverAction;
            executor.ExecuteScript("arguments[0].click();", element);
        }


        public void Clear(By elemento)
        {
            driverAction.FindElement(elemento).Clear();
        }

        public void Wait(By elemento)
        {
            WebDriverWait Wait = new WebDriverWait(driverAction, TimeSpan.FromSeconds(60));
            Wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
            Thread.Sleep(3000);
        }


        public void Click(IWebElement element)
        {
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


        public void SelectByText(By elemento, string conteudo)
        {
            new SelectElement(driverAction.FindElement(elemento)).SelectByText(conteudo);
        }


        public string GetElementText(By elemento)
        {
            return driverAction.FindElement(elemento).Text;
        }

        public void Load(By elemento)
        {
            WebDriverWait Load = new WebDriverWait(driverAction, TimeSpan.FromSeconds(60));
            Load.Until(ExpectedConditions.InvisibilityOfElementLocated(elemento));
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

        public bool IsElementDisplayed(By by)
        {
            return driverAction.FindElement(by).Displayed;
        }

   

        public void AssertTitleAreEqual(string validacao)
        {
            Assert.AreEqual(validacao, driverAction.Title);
        }

        public void AssertAreEqual(string validate, IWebElement element)
        {
            Assert.AreEqual(validate, element.Text.ToString());

        }

        public void AssertIsTrue(By by)
        {
            Assert.IsTrue(IsElementPresent(by));
        }


    }
}
