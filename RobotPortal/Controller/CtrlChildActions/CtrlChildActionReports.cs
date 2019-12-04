using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Net;
using System.Text;

namespace RobotPortal
{
    public class CtrlChildActionReports : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement FieldLogin;
        public IWebElement FieldPassword;
        public IWebElement ButtonEnter;
        public IWebElement FormLogin;


        public CtrlChildActionReports(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            FieldLogin = FindById("email");
            FieldPassword = FindById("password");
            ButtonEnter = FindByCss("#login_form > center > button");
        }

        //*Inicio dos metodos temporarios
        public void Login()
        {
            Initialize();

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste");
            SendKeys(FieldPassword, "bpPC9Qf9xSH2Z");
            Click(ButtonEnter);
        }
        
        //Fim dos metodos temporários
        
    }
}
