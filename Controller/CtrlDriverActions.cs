using NUnit.Framework;
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

        public IWebElement checkbox;
        public CtrlDriverActions(IWebDriver driver)
        {
            this.driverAction = driver;
        }

        public void AssertFalseResult(string element)
        {
            Assert.IsFalse(IsElementPresent(By.CssSelector(element)));
        }

        public bool AssertFalseXpath(string element)
        {
            Assert.IsFalse(IsElementPresent(By.XPath(element)));
            return true;
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
        public string GetTextAlert()
        {
            Thread.Sleep(1000);
            string AlertText = driverAction.SwitchTo().Alert().Text.ToString();
            string AlertText1 = AlertText.Replace("Senha do usuário: ", "");
           
            return AlertText1;
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

        public void NamePermission()
        {
            IList<IWebElement> listPermission = driverAction.FindElements(By.XPath("//*[@id='formPermission']/div[1]/div/table/tbody/tr/td[2]"));
            int count = listPermission.Count();
            List<string> list = new List<string>();
            IList<IWebElement> oRadioButton = driverAction.FindElements(By.XPath("/html/body/div/div[2]/div[1]/div[3]/div/form/div[1]/div/table/tbody/tr/td[1]/center/div/input"));
            int count1 = oRadioButton.Count();
                
            for (int i = 1; i <= count; i++)
            {
                var permission = driverAction.FindElement(By.CssSelector("tbody > tr:nth-child(" + (i) + ") > td:nth-child(2)")).Text;
                while (i <= count1)
                {
                    bool bValue = false;
                    checkbox = FindByXpath("/html/body/div/div[2]/div[1]/div[3]/div/form/div[1]/div/table/tbody/tr[" + (i) + "]/td[1]/center/div/input");

                    //checkbox = driverAction.FindElements(By.XPath("/html/body/div/div[2]/div[1]/div[3]/div/form/div[1]/div/table/tbody/tr["+(j)+"]/td[1]/center/div/input"));
                    bValue = checkbox.Selected;
                    if (bValue == true && permission.Contains("Ler relatórios de teste"))
                    {
                        list.Add(permission);
                        break;
                    }
                    if (bValue == false && permission.Contains("Ler relatórios de teste"))
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        break;
                    }

                }



            }

        }

        public void SelectPermissions()
        {
            List<string> permissions = new List<string>();
            permissions.Add("Ler usuários");
            permissions.Add("Criar usuário");
            permissions.Add("Excluir usuário");
            permissions.Add("Editar dados do usuário");
            permissions.Add("Ler perfis do usuário");
            permissions.Add("Add/Excluir perfil  d usuário");
            permissions.Add("Editar status dos perfis do usuário");
            permissions.Add("Ler permissões dos usuários");
            permissions.Add("Add/Excluir permissões de perfis");
            int num = permissions.Count();

            for (int i = 0; i < num; i++)
            {
                string namepermission = permissions.ElementAt(i);
                IWebElement Box = FindByXpath("/html/body/div/div[2]/div[1]/div[3]/div/form/div[1]/div/table/tbody/tr[contains(string(), '"+(namepermission) +"')]/td/center/div/input");
                Click(Box);
            }

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
        public void SelectByIndex(IWebElement element, int conteudo)
        {
            Thread.Sleep(1000);
            new SelectElement(element).SelectByIndex(conteudo);
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
            Thread.Sleep(3000);
            return element.Displayed;
        }
        public bool IsElementNotDisplayed(IWebElement element)
        {
            Thread.Sleep(1000);
            if (element.Displayed)
            {
                return false;
            }
            else
            {
                return true;
            }
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
