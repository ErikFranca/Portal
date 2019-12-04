using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;


namespace RobotPortal
{

      public class CtrlChildActionSecurity : CtrlDriverActions
        {
        public static IWebDriver driverChildAction;

        public IWebElement FieldLogin;
        public IWebElement FieldPassword;
        public IWebElement ButtonEnter;
        public IWebElement FormLogin;
        public CtrlChildActionSecurity(IWebDriver driver) : base(driver)
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
        public void LoginPortalUsuarioInativo()
        {

            //action.SendKeys(By.Id("email"), "jose.maria");
            //action.SendKeys(By.Id("password"), "cnvOHX1+Dl&j%");
            //action.Click(By.CssSelector("#login_form > center > button"));
            //action.AssertAreEqual("Usuário Inativo.", By.CssSelector("body > div > div > center > h6"));

        }
        public void LoginPortalSenhaCorreta()
        {

            //action.SendKeys(By.Id("email"), "carlos.henrique");
            //action.SendKeys(By.Id("password"), "Starline@123");
            //action.Click(By.CssSelector("#login_form > center > button"));
            //action.AssertTitleAreEqual("Portal Starline");
        }
    
        public void LoginPortalSenhaIncorreta()
        {

            //action.SendKeys(By.Id("email"), "carlos.henrique");
            //action.SendKeys(By.Id("password"), "123546");
            //action.Click(By.CssSelector("#login_form > center > button"));
            //action.AssertAreEqual("Senha inválida!", By.CssSelector("body > div > div > center > h6"));

        }

        public void NovoLoginPortalTestSenha()
        {

            //action.SendKeys(By.Id("email"), "leonardo.san");
            //action.SendKeys(By.Id("password"), "kqg*K7SN3e%cq");
            //action.Click(By.CssSelector("#login_form > center > button"));
            //action.AssertAreEqual("Sua senha deve ser alterada!", By.CssSelector("body > div > div > center > h6"));
            //action.SendKeys(By.Id("password"), "kqg*K7SN3e%cq");
            //action.SendKeys(By.Id("senha"), "123456");
            //action.AssertAreEqual("Senha não atende aos requisitos mínimos: mínimo de 6 caracteres com letras maiúsculas e minúsculas, números e caractere especial.", By.Id("senha-warning"));
        }
    }

    }

