using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;


namespace RobotPortal
{
    public class CtrlChildActionNewUser : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement FieldLogin;
        public IWebElement FieldPassword;
        public IWebElement ButtonEnter;
        public IWebElement FormLogin;
        public IWebElement AllTeams;
        public CtrlChildActionNewUser(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }
        public void Initialize()
        {
            FieldLogin = FindById("email");
            FieldPassword = FindById("password");
            ButtonEnter = FindByCss("#login_form > center > button");

        }
        public void Team()
        {
            AllTeams = FindByCss("body > div > div > div:nth-child(2) > div > a");
        }
        public void TesteInclusaoUsuarioCopiandoOutroUsuarioExistente()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "helena.pera");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            Team();
            Click(AllTeams);
        }
    }
}
