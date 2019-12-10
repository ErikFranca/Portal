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
        public IWebElement Arrow;
        public IWebElement Users;
        public IWebElement Register;
        public IWebElement newLogin;
        public IWebElement newEmail;
        public IWebElement next;
        public IWebElement setCopy;
        public IWebElement setUser;
        public IWebElement typeUser;
        public IWebElement btnRegister;
        public IWebElement setNew;
        public IWebElement typeProfile;
        public IWebElement setProfile;
        public IWebElement selectClient;
        public IWebElement marisa;
        public IWebElement AllTeams;
        public IWebElement AllClients;
        public IWebElement selectProfileText;
        public IWebElement selectProfileType;
        public IWebElement selectTeam;
        public IWebElement monitoring;
        public IWebElement profileAllTeams;
        public IWebElement teste;
        public IWebElement analista;
        public IWebElement all;
        public IWebElement admin;
        public IWebElement Profile;
        public IWebElement RegisterProfile;
        public IWebElement profileMarisa;
        public IWebElement clientProfile;
        public IWebElement nextforPermission;
        public IWebElement allPermission;
        public IWebElement defaultPermission;
        public IWebElement registerPermission;
        public IWebElement operador;
        public IWebElement gerente;
        public CtrlChildActionNewUser(IWebDriver driver) : base(driver)
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
        public void UserTab()
        {
            Thread.Sleep(3000);
            Arrow = FindByCss("#open-nav > .close-open-btn");
            Users = FindByCss("#navBar-lateral > li:nth-child(1) > a");
            Register = FindByCss("#submenu-user > li:nth-child(2) > a");
            Profile = FindByCss("#navBar-lateral > li:nth-child(2) > a");
            RegisterProfile = FindByCss("#submenu-profile > li:nth-child(2) > a");
        }
        public void Data()
        {
            Thread.Sleep(3000);
            newLogin = FindById("login");
            newEmail = FindById("email");
            next = FindByCss(".btn-info");

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
        public void Type()
        {
            Thread.Sleep(3000);
            setCopy = FindById("radio_cp");
            setNew = FindById("radio_cr");
        }
        public void Copy()
        {
            Thread.Sleep(3000);
            setUser = FindByCss("center > .dropdown:nth-child(1) .filter-option-inner");
            setProfile = FindByCss(".dropdown:nth-child(3) .filter-option-inner-inner");
        }
        public void ProfileTab()
        {
            Thread.Sleep(3000);
            typeProfile = FindByCss(".open > .dropdown-menu .form-control");
            typeUser = FindByCss("#copiar > div > center > div.dropdown.bootstrap-select.open > div.dropdown-menu.open > div.bs-searchbox > input");
            btnRegister = FindById("btn_prf");
        }
        public void SelectCliente()
        {
            Thread.Sleep(3000);
            selectClient = FindByCss(".row:nth-child(1) > .col-sm-offset-3 .filter-option-inner-inner");
            selectTeam = FindByCss(".col-sm-3:nth-child(2) .filter-option-inner-inner");
            selectProfileText = FindById("text-perfil");
            selectProfileType = FindByCss(".row:nth-child(3) .filter-option-inner-inner");
            nextforPermission = FindById("btn_prf");
        }
        public void SelectPermission()
        {
            Thread.Sleep(3000);
            defaultPermission = FindById("chk_default_pms");
            allPermission = FindById("chk_pms");
            registerPermission = FindByCss("#formPermission > div:nth-child(2) > div > button");
        }
        public void ClientName()
        {
            Thread.Sleep(3000);
            marisa = FindByCss(".col-sm-offset-3 .optgroup-1:nth-child(5) .text");
            all = FindByCss(".col-sm-offset-3 .optgroup-1:nth-child(2) .text");
        }
        public void ProfileTeam()
        {
            Thread.Sleep(3000);
            profileAllTeams = FindByCss(".col-sm-3:nth-child(2) .optgroup-1:nth-child(2) .text");   
            teste = FindByCss(".col-sm-3:nth-child(2) .optgroup-1:nth-child(3) .text");
            monitoring = FindByCss(".col-sm-3:nth-child(2) .optgroup-1:nth-child(5) .text");
        }
        public void ProfileType()
        {
            Thread.Sleep(3000);
            admin = FindByCss(".row:nth-child(3) .optgroup-1:nth-child(2) .text");
            analista = FindByCss(".row:nth-child(3) .optgroup-1:nth-child(5) > .opt");
            operador = FindByCss(".row:nth-child(3) .optgroup-1:nth-child(3) > .opt");
            gerente = FindByCss(".row:nth-child(3) .optgroup-1:nth-child(4) > .opt");
        }
        public void CreateProfile()
        {
            Thread.Sleep(3000);
            clientProfile = FindByCss(".open .filter-option-inner-inner");
        }
        public void CreateProfileClient()
        {
            Thread.Sleep(3000);
            profileMarisa = FindByCss(".optgroup-1:nth-child(5) .");
        }
        public void TesteInclusaoUsuarioCopiandoOutroUsuarioExistente()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            UserTab();
            Click(Arrow);
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.5");
            SendKeys(newEmail, "teste@5.com");
            Click(next);
            Type();
            Click(setCopy);
            Copy();
            Click(setUser);
            ProfileTab();
            SendKeys(typeProfile, "Meu Usuário" + Keys.Enter);
            Click(btnRegister);

        }
        public void TesteInclusaoUsuarioAtribuindoPerfilExistente()
        {
            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "teste.2");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            UserTab();
            Click(Arrow);
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.5");
            SendKeys(newEmail, "teste@5.com");
            Click(next);
            Type();
            Click(setCopy);
            Copy();
            Click(setProfile);
            ProfileTab();
            SendKeys(typeUser, "Operador" + Keys.Enter);
            Click(btnRegister);
            
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilClienteEspecifico()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.6");
            SendKeys(newEmail, "teste@6.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(marisa);
            Click(selectTeam);
            ProfileTeam();
            Click(monitoring);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(analista);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodosClientes()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.7");
            SendKeys(newEmail, "teste@7.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(monitoring);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(analista);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo()
        {

            Initialize();
            AssertAreEqual("Entrar", ButtonEnter);
            SendKeys(FieldLogin, "user.kroton");
            SendKeys(FieldPassword, "Starline@123");
            Click(ButtonEnter);
            //SwitchFrame("iframe_opt");
            UserTab();
            Click(Arrow);
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.8");
            SendKeys(newEmail, "teste@8.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfil1EquipeEspecifica()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.9");
            SendKeys(newEmail, "teste@9.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(teste);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(analista);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodasEquipes()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.10");
            SendKeys(newEmail, "teste@10.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(profileAllTeams);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(analista);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAdministradorPermissoesPadrao()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.11");
            SendKeys(newEmail, "teste@11.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(monitoring);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(admin);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);
            SelectCliente();
            Click(nextforPermission);
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoOperadorPermissoesPadrao()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.12");
            SendKeys(newEmail, "teste@12.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(monitoring);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(operador);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);
            SelectCliente();
            Click(nextforPermission);
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoGerentePermissoesPadrao()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.13");
            SendKeys(newEmail, "teste@13.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(monitoring);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(gerente);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);
            SelectCliente();
            Click(nextforPermission);
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAnalistaPermissoesPadrao()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.13");
            SendKeys(newEmail, "teste@13.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(monitoring);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(analista);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);
            SelectCliente();
            Click(nextforPermission);
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoTodos()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.15");
            SendKeys(newEmail, "teste@15.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(profileAllTeams);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);
            SelectCliente();
            Click(nextforPermission);
            
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilEspecifico()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.15");
            SendKeys(newEmail, "teste@15.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(monitoring);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste perfil especifico" + Keys.Tab);
            SelectCliente();
            Click(nextforPermission);

        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilValidarOpcoesPermissoesPadrao()
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
            UserTab();
            Click(Users);
            Click(Register);
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste.15");
            SendKeys(newEmail, "teste@15.com");
            Click(next);
            Type();
            Click(setNew);
            SelectCliente();
            Click(selectClient);
            ClientName();
            Click(all);
            Click(selectTeam);
            ProfileTeam();
            Click(profileAllTeams);
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);
            SelectCliente();
            Click(selectProfileType);
            ProfileType();
            Click(analista);
            Click(nextforPermission);
            SelectPermission();
            Click(defaultPermission);
            NamePermission();

        }
    }
}
