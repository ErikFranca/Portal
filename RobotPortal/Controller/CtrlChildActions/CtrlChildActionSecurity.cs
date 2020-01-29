using OpenQA.Selenium;
using System.Threading;


namespace RobotPortal
{

    public class CtrlChildActionSecurity : CtrlDriverActions
    {

        public CtrlChildActionSecurity(IWebDriver driver) : base(driver)
        {
            driverAction = driver;
        }

        private IWebElement FieldLogin => FindById("email");
        private IWebElement FieldPassword => FindById("password");
        private IWebElement ButtonEnter => FindByCss("#login_form > center > button");
        private IWebElement Warning1 => FindByCss(".warnig_h6");
        private IWebElement FieldOldPassword => FindByXpath("//input[contains(@placeholder, 'Senha')]");
        private IWebElement FieldNewPassword => FindByXpath("//input[contains(@placeholder, 'Confirme a nova senha')]");
        private IWebElement Warning2 => FindById("senha-warning");
        private IWebElement Tittle => FindByXpath("//h4[contains(@style, 'font')]");


        public void SwitchFrameInitialize()
        {
            SwitchFrame("iframe_opt");
        }


        //*Inicio dos metodos temporarios
        public void LoginAdmin()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "admin");
            SendKeys(FieldPassword, "admin");
            Click(ButtonEnter);
        }
        public void LoginUserKroton()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "user.kroton");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
        }
        public void LoginUserTest2()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
        }
        public void Login(string Login = "admin", string Password = "admin", string client = "Todos", string equipe = "Todas", string perfil = "")
        {
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driverAction);

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, Login);
            SendKeys(FieldPassword, Password);
            Click(ButtonEnter);
            portal.ChooseAllClients(client);
            portal.ChooseTeam(equipe);
            Thread.Sleep(1000);

        }

        public void LoginCompiler()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "usercompiler");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
        }

        public void PermissionUserLogin()
        {


            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "permissionuser");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
        }
        public void PermissionProfileLogin()
        {


            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "permissionprofile");
            SendKeys(FieldPassword, "Starline123@");
            Click(ButtonEnter);
        }

        public void PermissionReportLogin()
        {


            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "testreport");
            SendKeys(FieldPassword, "Starline123@");
            Click(ButtonEnter);
        }

        public void LoginPortalUsuarioInativo()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "jose.maria");
            SendKeys(FieldPassword, "cnvOHX1+Dl&j%");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Usuário Inativo.", Warning1);
        }
        public void LoginPortalSenhaCorreta()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);


        }

        public void LoginPortalSenhaIncorreta()
        {


            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Senha inválida!", Warning1);

        }

        public void LoginPreparedReport()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "userreport");
            SendKeys(FieldPassword, "Starline123@");
            Click(ButtonEnter);
        }

        public void NovoLoginPortalTestSenha()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "leonardo.san");
            SendKeys(FieldPassword, "kqg*K7SN3e%cq");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Sua senha deve ser alterada!", Warning1);
            //Validation1();
            SendKeys(FieldPassword, "kqg*K7SN3e%cq");
            SendKeys(FieldNewPassword, "123456" + Keys.Tab);
            AssertAreEqual("Senha não atende aos requisitos mínimos: mínimo de 6 caracteres com letras maiúsculas e minúsculas, números e caractere especial.", Warning2);

        }

        public void NewLoginPrepareReport(string AlertText)
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "userreport");
            SendKeys(FieldPassword, AlertText);
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Sua senha deve ser alterada!", Warning1);
            SendKeys(FieldOldPassword, AlertText);
            SendKeys(FieldPassword, "Starline123@");
            SendKeys(FieldNewPassword, "Starline123@" + Keys.Tab);
            Click(ButtonEnter);
            SwitchParentFrame();
            IsElementDisplayed(Tittle);

        }
        public void TesteQuantidadeLoginsIncorretosExcedida()
        {

            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.1");
            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Senha inválida!", Warning1);

            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Senha inválida!", Warning1);

            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Senha inválida!", Warning1);

            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Senha inválida!", Warning1);

            SendKeys(FieldPassword, "123546");
            Click(ButtonEnter);
            //Validation();
            AssertAreEqual("Excedida a quantidade máxima de tentativas de login", Warning1);
            Thread.Sleep(60000);

            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
        }




    }

}

