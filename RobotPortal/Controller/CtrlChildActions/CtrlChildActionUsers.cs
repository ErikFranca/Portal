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
        public IWebElement addProfile;
        public IWebElement remUser;
        public IWebElement remProfile;
        public IWebElement selectProfile;
        public IWebElement selectAnalista;
        public CtrlChildActionUsers(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
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
        public void InitializeEditAndSeeUser()
        {
            Thread.Sleep(3000);
            editUser = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@href,'edit')]");
            seeUser = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@data-original-title,'Ver perfis')]");
            remUser = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@href,'del')]");
        }
        public void InitializeEditAndSeeUserTst2()
        {
            Thread.Sleep(3000);
            editUser = FindById("editIcon_180");
            seeUser = FindByCss("#tr_180 > td:nth-child(7) > a:nth-child(3)");
        }
        public void InitializePermissionScreen()
        {
            Thread.Sleep(3000);
            addPermission = FindByXpath("/html/body/div[1]/div/div[16]/div/div/div[2]/div/div/div/div/div[4]/table/tbody/tr[1]/td[2]/button");
            remPermission = FindByXpath("/html/body/div[1]/div/div[17]/div/div/div[2]/div/div/div/div/div[3]/table/tbody/tr/td[2]/button[2][contains(@data-original-title,'Excluir Perfil')]");
            inativePermission = FindByXpath("/html/body/div/div/div/div/div/div/div/div/div/div/div/table/tbody/tr/td/button[contains(@data-original-title,'Inativar Permissão')]");
        }
        public void SeeUserScreen()
        {
            Thread.Sleep(3000);
            userStatus = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/table/tbody/tr/td[5][contains(text(),'Ativo')]");
            seePermission = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/table/tbody/tr/td[6]/a[3][contains(@data-original-title,'Ver Permissões')]");
            addProfile = FindByXpath("/html/body/div/div/div/div/div/div/div/div/div/div/div/div/button[contains(text(),' Adicionar Perfil ')]");
            remProfile = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/table/tbody/tr/td[6]/a[4][contains(@data-original-title,'Excluir Perfil!')]");
            selectProfile = FindByXpath("/html/body/div[1]/div/div/div/div/div[2]/div/div/div/div/div/div[1]/form/div/div[2]/div/select[contains(@class, 'selectpicker')]");
            
        }
        public void SeeUserScreenTst2()
        {
            Thread.Sleep(3000);
            userStatus = FindById("status");

        }
        public void InitializeTypeProfile()
        {
            Thread.Sleep(3000);
            selectAnalista = FindByCss("body > div.bs-container.dropdown.bootstrap-select.show > div > div.inner.show > ul > li:nth-child(5) > a");
        }
        public void InicializeEditScreen()
        {
            Thread.Sleep(3000);
            editDate = FindById("date_180");
            saveIcon = FindById("saveIcon_180");
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
            AccessUserTags();
            Click(userAction);
            InitializeUserMenu();
            Click(EditProfile);

            //Troca de frame
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
            AccessUserTags();
            Click(userAction);
            InitializeUserMenu();
            Click(EditProfile);

            //Troca de frame
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
            //Troca de frame
            SwitchFrame("iframe_opt");
            InitializeEditAndSeeUserTst2();
            Click(editUser);
            InicializeEditScreen();
            Click(editDate);
            SendKeys(editDate, "2020-03-06");
            Click(saveIcon);

        }
        public void ValidarVisualizacaoPerfilUsuarios()
        {

            //Troca de frame
            SwitchFrame("iframe_opt");

            InitializeEditAndSeeUserTst2();

            Click(seeUser);
            
        }
        public void ValidarInativacaoPerfilConsultaUsuarios()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Visualizar Usuário
            InitializeEditAndSeeUserTst2();
            Click(seeUser);
            
            //Verifica se o Status do usuário está como Ativo
            SeeUserScreenTst2();
            AssertAreEqual("Ativo", userStatus);

        }
        public void TesteAdicaoPermissaoPerfilConsultaUsuario()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Visualizar Usuário
            InitializeEditAndSeeUser();
            Click(seeUser);

            //Clica no botão Visualizar Permissões
            SeeUserScreen();
            Click(seePermission);

            //Clica no botão Adicionar na tela de Permissões
            InitializePermissionScreen();
            Click(addPermission);


        }
        public void TesteExclusaoPermissaoPerfilConsultaUsuario()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Visualizar Usuário
            InitializeEditAndSeeUser();
            Click(seeUser);

            //Clica no botão Visualizar Permissões
            SeeUserScreen();
            Click(seePermission);

            //Clica no botão Remover na tela de Permissões
            InitializePermissionScreen();
            Click(remPermission);

        }
        public void TesteInclusaoPerfilViaConsultaUsuario()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Visualizar Usuário
            InitializeEditAndSeeUser();
            Click(seeUser);

            //Clica no botão Adicionar Perfil e Seleciona o Perfil que será adicionado
            SeeUserScreen();
            Click(addProfile);
            Click(selectProfile);
            
            //Seleciona o Tipo de Perfil Analista
            InitializeTypeProfile();
            Click(selectAnalista);

        }
        public void TesteExclusaoPerfilViaConsultaUsuario()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Visualizar Usuário
            InitializeEditAndSeeUser();
            Click(seeUser);

            //Clica no botão Remover Perfil
            SeeUserScreen();
            Click(remProfile);

        }
        public void TesteExclusaoUsuario()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Remover Usuário
            InitializeEditAndSeeUser();
            Click(remUser);

        }
    }
}
