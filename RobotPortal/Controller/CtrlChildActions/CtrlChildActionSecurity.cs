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
        public IWebElement Warning1;
        public IWebElement Header;
        public IWebElement FieldPassword1;
        public IWebElement Warning2;
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
        public void Validation()
        {
            Warning1 = FindByCss(".warnig_h6");
        }
        public void Validation1()
        {
            FieldPassword = FindById("password");
            FieldPassword1 = FindById("senha");
            Warning2 = FindById("senha-warning");
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
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "jose.maria");
            SendKeys(FieldPassword, "cnvOHX1+Dl&j%");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Usuário Inativo.", Warning1);
        }
        public void LoginPortalSenhaCorreta()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);

            
        }
    
        public void LoginPortalSenhaIncorreta()
        {

            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Senha inválida!", Warning1);
            

        }

        public void NovoLoginPortalTestSenha()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "leonardo.san");
            SendKeys(FieldPassword, "kqg*K7SN3e%cq");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Sua senha deve ser alterada!", Warning1);
            Validation1();
            SendKeys(FieldPassword, "kqg*K7SN3e%cq");
            SendKeys(FieldPassword1, "123456" + Keys.Tab);
            AssertAreEqual("Senha não atende aos requisitos mínimos: mínimo de 6 caracteres com letras maiúsculas e minúsculas, números e caractere especial.", Warning2);
            
        }
        public void TesteQuantidadeLoginsIncorretosExcedida()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.1");
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Senha inválida!", Warning1);
            Initialize();
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Senha inválida!", Warning1);
            Initialize();
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Senha inválida!", Warning1);
            Initialize();
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Senha inválida!", Warning1);
            Initialize();
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            Validation();
            AssertAreEqual("Excedida a quantidade máxima de tentativas de login", Warning1);
            Thread.Sleep(60000);
            Initialize();
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
        }


        

    }

}

