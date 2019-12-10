using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace RobotPortal
{
    class CtrlChildActionUsers : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;
        public IWebElement FieldLogin;
        public IWebElement FieldPassword;
        public IWebElement ButtonEnter;
        public IWebElement userAction;
        public IWebElement Logout;
        public IWebElement EditProfile;
        public IWebElement email;
        public IWebElement oldPassword;
        public IWebElement newPassword;
        public IWebElement confirmPassword;
        public IWebElement att;
        public IWebElement Arrow;
        public IWebElement Users;
        public IWebElement Register;
        public IWebElement Consult;
        public IWebElement editUser;
        public IWebElement seeUser;
        public IWebElement editDate;
        public IWebElement saveIcon;
        public IWebElement userStatus;
        public IWebElement seePermission;
        public IWebElement AllTeams;
        public IWebElement AllClients;
        public IWebElement addPermission;
        public IWebElement remPermission;
        public IWebElement inativePermission;
        public IWebElement Profile;
        public IWebElement RegisterProfile;
        public CtrlChildActionUsers(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }
        public void Initialize()
        {
            Thread.Sleep(3000);
            FieldLogin = FindById("email");
            FieldPassword = FindById("password");
            ButtonEnter = FindByCss("#login_form > center > button");

        }
        public void AdminAccessClient()
        {
            Thread.Sleep(3000);
            AllClients = FindByCss(".col-auto:nth-child(2) .card-img");
        }
        public void AdminAccessTeam()
        {
            Thread.Sleep(3000);
            AllTeams = FindByCss(".col-auto:nth-child(2) .card-img-top");
        }
        public void AccessUserTags()
        {
            Thread.Sleep(3000);
            userAction = FindByCss(".dropdown-toggle");
        }
        public void InitializeUserMenu()
        {
            Thread.Sleep(3000);
            Logout = FindByCss(".dropdown-menu > li:nth-child(3) > a");
            EditProfile = FindByCss(".dropdown-menu > li:nth-child(1) > a");
        }
        
        public void InitializeUserTab()
        {
            Thread.Sleep(3000);
            Consult = FindByCss("#submenu-user > li:nth-child(1) > a");
            Arrow = FindByCss("#open-nav > .close-open-btn");
            Users = FindByCss("#navBar-lateral > li:nth-child(1) > a");
            Register = FindByCss("#submenu-user > li:nth-child(2) > a");
            Profile = FindByCss("#navBar-lateral > li:nth-child(2) > a");
            RegisterProfile = FindByCss("#submenu-profile > li:nth-child(2) > a");
        }
        public void InitializeEditAndSeeUser()
        {
            Thread.Sleep(3000);
            editUser = FindById("editIcon_160");
            seeUser = FindByCss("#tr_160 a:nth-child(3) > .md");

        }
        public void InitializePermissionScreen()
        {
            Thread.Sleep(3000);
            addPermission = FindByCss("tr:nth-child(1) .btn-sm");
            remPermission = FindByCss("tr:nth-child(1) .btn:nth-child(2) > .md");
            inativePermission = FindByCss("tr:nth-child(4) .btn:nth-child(1) > .md");
        }
        public void SeeUserScreen()
        {
            Thread.Sleep(3000);
            userStatus = FindById("statusPrf_167");
            seePermission = FindByCss("#tr_prf_167160 > td:nth-child(6) > a:nth-child(3)");
        }
        public void InicializeEditScreen()
        {
            Thread.Sleep(3000);
            editDate = FindById("date_171");
            saveIcon = FindByCss("#saveIcon_171 > .md");
        }
        public void InitializeChangePassword()
        {
            Thread.Sleep(3000);
            email = FindById("email");
            oldPassword = FindById("senhaAtual");
            newPassword = FindById("senha");
            confirmPassword = FindById("senha2");
            att = FindByCss(".btn");
        }
        public void TesteTrocaEmail()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            AccessUserTags();
            Click(userAction);
            InitializeUserMenu();
            Click(EditProfile);
            SwitchFrame("iframe_opt");
            InitializeChangePassword();
            SendKeys(email, "teste@3.com");
            SendKeys(oldPassword, "Starline@123");
            SendKeys(newPassword, "Starline@1234");
            SendKeys(confirmPassword, "Starline@1234");
            Click(att);
        }

        public void TesteTrocaSenha()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            AccessUserTags();
            Click(userAction);
            InitializeUserMenu();
            Click(EditProfile);
            SwitchFrame("iframe_opt");
            InitializeChangePassword();
            SendKeys(email, "teste@2.com");
            SendKeys(oldPassword, "Starline@123");
            SendKeys(newPassword, "Starline@1234");
            SendKeys(confirmPassword, "Starline@1234");
            Click(att);
        }
        public void TesteAtualizacaoInformacoesUsuarioExistente()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            InitializeUserTab();
            Click(Arrow);
            Click(Users);
            Click(Consult);
            SwitchFrame("iframe_opt");
            InitializeEditAndSeeUser();
            Click(editUser);
            InicializeEditScreen();
            Click(editDate);
            SendKeys(editDate, "2020-03-06");
            Click(saveIcon);

        }
        public void ValidarVisualizacaoPerfilUsuarios()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            InitializeUserTab();
            Click(Arrow);
            Click(Users);
            Click(Consult);
            SwitchFrame("iframe_opt");
            InitializeEditAndSeeUser();
            Click(seeUser);
            
        }
        public void ValidarInativacaoPerfilConsultaUsuarios()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            InitializeUserTab();
            Click(Arrow);
            Click(Users);
            Click(Consult);
            SwitchFrame("iframe_opt");
            InitializeEditAndSeeUser();
            Click(seeUser);
            SeeUserScreen();
            AssertAreEqual("Ativo", userStatus);

        }
        public void TesteAdicaoPermissaoPerfilConsultaUsuario()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "admin");
            SendKeys(FieldPassword, "admin");
            Click(ButtonEnter);
            SwitchFrame("iframe_opt");
            AdminAccessClient();
            Click(AllClients);
            AdminAccessTeam();
            Click(AllTeams);
            InitializeUserTab();
            Click(Users);
            Click(Consult);
            SwitchFrame("iframe_opt");
            InitializeEditAndSeeUser();
            Click(seeUser);
            SeeUserScreen();
            Click(seePermission);
            InitializePermissionScreen();
            Click(addPermission);

        }
    }
}
