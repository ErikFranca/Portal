using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace RobotPortal
{
    public class CtrlChildActionNewProfile : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;
        public IWebElement ClientSelectPicker;
        public IWebElement EquipSelectPicker;
        public IWebElement LoginTypeSelectPicker;
        public IWebElement ButtonNext;
        public IWebElement BoxPermissionDefaut;
        public IWebElement ButtonRegister;
        public IWebElement FieldObs;
        public IWebElement newLogin;
        public IWebElement newEmail;
        public IWebElement next;
        public IWebElement setCopy;
        public IWebElement setNew;
        public IWebElement allPermission;
        public IWebElement defaultPermission;
        public IWebElement registerPermission;
        public IWebElement selectProfileText;
        public void Type()
        {
            Thread.Sleep(3000);
            setCopy = FindById("radio_cp");
            setNew = FindById("radio_cr");
        }
        public CtrlChildActionNewProfile(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }
        public void Data()
        {
            Thread.Sleep(3000);
            newLogin = FindById("login");
            newEmail = FindById("email");
            next = FindByCss(".btn-info");

        }
        public void SelectPermission()
        {
            Thread.Sleep(3000);
            defaultPermission = FindById("chk_default_pms");
            allPermission = FindById("chk_pms");
            registerPermission = FindByCss("#formPermission > div:nth-child(2) > div > button");
        }
        public void TesteInitialize()
        {
            Thread.Sleep(3000);
            ClientSelectPicker = FindById("cst_id");
            EquipSelectPicker = FindById("area");
            LoginTypeSelectPicker = FindById("list-type_new");
            selectProfileText = FindById("text-perfil");
            FieldObs = FindByName("perfil");
            ButtonNext = FindByCss("#perfil > div > form > div:nth-child(2) > div > center > button");
            BoxPermissionDefaut = FindById("chk_default_pms");
            ButtonRegister = FindByCss("#formPermission > div:nth-child(2) > div > button");
        }

        public void TesteInclusaoUsuarioNovoPerfil1ClienteEspecifico()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Marisa");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");        
            Click(ButtonNext);
        }
        public void TesteInclusaoUsuarioNovoPerfil1EquipeEspecifica()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(ButtonNext);
        }
        public void TesteInclusaoUsuarioNovoPerfilTodasEquipes()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(ButtonNext);
        }
        public void TesteInclusaoUsuarioNovoPerfilTipoAdministradorPermissaoPadrao()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Administrador");
            Click(ButtonNext);
            
            //Seleciona as Permissões Padrão e Registrar
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioNovoPerfilTipoOperadorPermissaoPadrao()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Operador");
            Click(ButtonNext);

            //Seleciona as Permissões Padrão e Registrar
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioNovoPerfilTipoGerentePermissaoPadrao()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Gerente");
            Click(ButtonNext);
            
            //Seleciona as Permissões Padrão e Registrar
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioNovoPerfilTipoAnalistaPermissaoPadrao()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(ButtonNext);

            //Seleciona as Permissões Padrão e Registrar
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioNovoPerfilTipoValidaPermissaoPadrao()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(ButtonNext);
            
            //Seleciona as Permissões Padrão e Registrar
            SelectPermission();
            Click(defaultPermission);

            //Verifica as Permissões de acordo com um Padrão pré-estabelecido
            NamePermission();

            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioNovoPerfilTipoTodosPerfis()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(ButtonNext);

            //Seleciona as Permissões Padrão e Registrar
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioNovoPerfilTipoPerfilEspecifico()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Todas");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(selectProfileText);
            SendKeys(selectProfileText, "teste perfil especifico");
            Click(ButtonNext);
            
            //Clica nas Permissões Padrão e Registrar
            SelectPermission();
            Click(defaultPermission);
            Click(registerPermission);
        }
        public void TesteInclusaoUsuarioNovoPerfilTodosClientes()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");
            
            //Seleciona Cliente, Equipe e Tipo do Usuário
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Todos");
            SelectByText(EquipSelectPicker, "Testes Automatizados");
            SelectByText(LoginTypeSelectPicker, "Analista");
            Click(ButtonNext);
        }
        public void TesteInclusaoUsuarioNovoPerfilClienteNaoPossuo()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Seleciona Cliente que não possuo
            TesteInitialize();
            SelectByText(ClientSelectPicker, "Marisa");
        }
    }
}
