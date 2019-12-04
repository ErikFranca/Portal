using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;


namespace RobotPortal
{

      public class CtrlChildActionSecurity : CtrlActions
        {
        public CtrlActions ctrlActions = null;
        public CtrlChildActionSecurity()
        {
            ctrlActions = new CtrlActions();
        }
        
        public void LoginPortalUsuarioInativo()
        {
            CtrlActions action = new CtrlActions();

            action.SendKeys(By.Id("email"), "jose.maria");
            action.SendKeys(By.Id("password"), "cnvOHX1+Dl&j%");
            action.Click(By.CssSelector("#login_form > center > button"));
            action.AssertAreEqual("Usuário Inativo.", By.CssSelector("body > div > div > center > h6"));

        }
        public void LoginPortalSenhaCorreta()
        {
            CtrlActions action = new CtrlActions();

            action.SendKeys(By.Id("email"), "carlos.henrique");
            action.SendKeys(By.Id("password"), "Starline@123");
            action.Click(By.CssSelector("#login_form > center > button"));
            action.AssertTitleAreEqual("Portal Starline");
        }
    
        public void LoginPortalSenhaIncorreta()
        {
            CtrlActions action = new CtrlActions();

            action.SendKeys(By.Id("email"), "carlos.henrique");
            action.SendKeys(By.Id("password"), "123546");
            action.Click(By.CssSelector("#login_form > center > button"));
            action.AssertAreEqual("Senha inválida!", By.CssSelector("body > div > div > center > h6"));

        }

        public void NovoLoginPortalTestSenha()
        {
            CtrlActions action = new CtrlActions();

            action.SendKeys(By.Id("email"), "leonardo.san");
            action.SendKeys(By.Id("password"), "kqg*K7SN3e%cq");
            action.Click(By.CssSelector("#login_form > center > button"));
            action.AssertAreEqual("Sua senha deve ser alterada!", By.CssSelector("body > div > div > center > h6"));
            action.SendKeys(By.Id("password"), "kqg*K7SN3e%cq");
            action.SendKeys(By.Id("senha"), "123456");
            action.AssertAreEqual("Senha não atende aos requisitos mínimos: mínimo de 6 caracteres com letras maiúsculas e minúsculas, números e caractere especial.", By.Id("senha-warning"));
        }
    }

    }

