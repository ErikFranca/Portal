
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
        public IWebElement ClientSelectPicker;
        public IWebElement EquipSelectPicker;
        public IWebElement LoginTypeSelectPicker;
        public IWebElement FieldObs;
        public IWebElement BoxPermissionDefaut;
        public IWebElement ButtonNext;
        public IWebElement ButtonRegister;
        public string AlertText1;


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

        public void SwitchFrameInitialize()
        {
            SwitchFrame("iframe_opt");
        }

        public void TesteInitialize()
        {
            Thread.Sleep(3000);
            ClientSelectPicker = FindById("cst_id");
            EquipSelectPicker = FindById("area");
            LoginTypeSelectPicker = FindById("list-type_new");
            FieldObs = FindByName("perfil");
            ButtonNext = FindById("btn_prf");
            BoxPermissionDefaut = FindById("chk_default_pms");
            ButtonRegister = FindByCss("#formPermission > div:nth-child(2) > div > button");
        }

        public void PrepareUserInitialize()
        {
            Thread.Sleep(3000);
            ClientSelectPicker = FindById("cst_id");
            LoginTypeSelectPicker = FindById("list-type_new");
            ButtonNext = FindById("btn_prf");
            BoxPermissionDefaut = FindById("chk_default_pms");
            ButtonRegister = FindByCss("#formPermission > div:nth-child(2) > div > button");
        }

        public void permissionuserInitialize()
        {
            LoginTypeSelectPicker = FindById("list-type_new");
            FieldObs = FindByName("perfil");
            ButtonNext = FindById("btn_prf");
            BoxPermissionDefaut = FindById("chk_default_pms");
            ButtonRegister = FindByCss("#formPermission > div:nth-child(2) > div > button");
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
            allPermission = FindByXpath("//*/label[contains(text(), 'Selecionar todas as permissões')]");
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
        public void FillNewProfile()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");
            Data();
            SendKeys(newLogin, "teste" + DateTime.Now.ToString("HHmmss"));
            SendKeys(newEmail, "teste@teste.com");
            Click(next);
            Type();
            Click(setNew);
        }
        public void TesteInclusaoUsuarioCopiandoOutroUsuarioExistente()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");
            
            //Preenche o Perfil pré-existente que a cópia será feita
            Data();
            SendKeys(newLogin, "teste.5");
            SendKeys(newEmail, "teste@5.com");
            Click(next);
            
            //Clica em Copiar
            Type();
            Click(setCopy);

            //Clica em Usuário
            Copy();
            Click(setUser);

            //Preenche a base do Perfil que será copiado e registra
            ProfileTab();
            SendKeys(typeProfile, "Meu Usuário" + Keys.Enter);
            Click(btnRegister);

        }
        public void TesteInclusaoUsuarioAtribuindoPerfilExistente()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Preenche o Perfil pré-existente que a cópia será feita
            Data();
            SendKeys(newLogin, "teste.5");
            SendKeys(newEmail, "teste@5.com");
            Click(next);

            //Clica em Copiar
            Type();
            Click(setCopy);

            //Clica em Usuário
            Copy();
            Click(setProfile);

            //Preenche a base do Perfil que será copiado e registra
            ProfileTab();
            SendKeys(typeUser, "Operador" + Keys.Enter);
            Click(btnRegister);
            
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilClienteEspecifico()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Marisa");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
                      
           
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodosClientes()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo()
        {
            //Preenche Novo Perfil
            FillNewProfile();
            SelectCliente();
            Click(selectClient);
            ClientName();
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfil1EquipeEspecifica()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodasEquipes()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAdministradorPermissoesPadrao()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Administrador");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste");

            //Acessa Menu de Permissões
            SelectCliente();
            Click(nextforPermission);

            //Selciona as Permissões Padrão e Registra 
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoOperadorPermissoesPadrao()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Operador");

            //Acessa Menu de Permissões
            SelectCliente();
            Click(nextforPermission);

            //Selciona as Permissões Padrão e Registra 
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoGerentePermissoesPadrao()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Gerente");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);

            //Acessa Menu de Permissões
            SelectCliente();
            Click(nextforPermission);

            //Selciona as Permissões Padrão e Registra 
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAnalistaPermissoesPadrao()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste" + Keys.Tab);

            //Acessa Menu de Permissões
            SelectCliente();
            Click(nextforPermission);
            
            //Selciona as Permissões Padrão e Registra 
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoTodos()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Analista");

            //Acessa Menu de Permissões
            SelectCliente();
            Click(nextforPermission);
            
        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilEspecifico()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste perfil especifico" + Keys.Tab);

            //Acessa Menu de Permissões
            SelectCliente();
            Click(nextforPermission);

        }
        public void TesteInclusaoUsuarioCriandoNovoPerfilValidarOpcoesPermissoesPadrao()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            
            //Acessa Menu de Permissões
            SelectCliente();
            Click(nextforPermission);
            
            //Seleciona as Permissões Padrão
            SelectPermission();
            Click(defaultPermission);

            //Valida as Permissões de acordo com valores pré-selecionados
            NamePermission();

        }

        public void TesteInclusaoUsuarioCriandoNovoPerfilPermissãoEspecifica()
        {
            //Preenche Novo Perfil
            FillNewProfile();

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            SelectCliente();
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste perfil especifico" + Keys.Tab);
            
            //Acessa o Menu de Permissões
            SelectCliente();
            Click(nextforPermission);

        }

        public void TestNewUser()
        {
            FillNewProfile(); 
            
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Marisa");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Administrador");
            Click(ButtonNext);

            Click(BoxPermissionDefaut); 
            Click(ButtonRegister);
            AcceptAlert();

        }

        public void NewUserPermission()
        {
            SwitchFrameInitialize();
            Data();

            SendKeys(newLogin, "PermissionUserDefaut");
            SendKeys(newEmail, "teste@1.com.br");
            Click(next);

            Type();
            Click(setNew);

            TesteInitialize();
            SelectByText(ClientSelectPicker, "Marisa");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(ButtonNext);
            //SendKeys(FieldObs, "TestePermissão");

            SelectPermissions();
            Click(ButtonRegister);
            AcceptAlert();

        }

        public void NewUserReport()
        {
            SwitchFrameInitialize();
            Data();

            SendKeys(newLogin, "Userreport");
            SendKeys(newEmail, "teste@1.com.br");
            Click(next);

            Type();
            Click(setNew);

            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Administrador");
            SendKeys(FieldObs, "");
            Click(ButtonNext);

            SelectPermission();
            Click(allPermission);
            Click(ButtonRegister);
            AlertText1 = GetTextAlert();
            AcceptAlert();
        }

        public void PrepareNewUser()
        {
            SwitchFrameInitialize();
            Data();

            SendKeys(newLogin, "Prepareuser");
            SendKeys(newEmail, "teste@1teste1.com.br");
            Click(next);

            Type();
            Click(setNew);

            PrepareUserInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(LoginTypeSelectPicker, "Gerente");
            Click(ButtonNext);

            SelectPermission();
            Click(allPermission);
            Click(ButtonRegister);
            AcceptAlert();
        }
    }
}
