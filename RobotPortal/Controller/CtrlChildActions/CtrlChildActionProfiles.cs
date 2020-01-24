using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace RobotPortal
{
    public class CtrlChildActionProfiles : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;
        public IWebElement editProfile;
        public IWebElement seeProfilePermissions;
        public IWebElement inativeProfile;
        public IWebElement removeProfile;
        public IWebElement statusProfile;
        public IWebElement addPermission;
        public IWebElement removePermission;
        public CtrlChildActionProfiles(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }
        public void InitializeEditAndSeeProfilePermission()
        {
            Thread.Sleep(3000);
            editProfile = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@data-original-title,'Editar perfil')]");
            seeProfilePermissions = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@data-original-title,'Ver permissões')]");
            removeProfile = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@data-original-title,'Excluir perfil')]");
            //statusProfile = FindById("status_139");
        }
        
        public void InitializePermission()
        {
            Thread.Sleep(3000);
            addPermission = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/div[4]/table/tbody/tr/td/button[contains(text(),'Adicionar')]");
            removePermission = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/div[3]/table/tbody/tr/td/button[contains(@data-original-title,'Excluir Perfil')]");
        }
        public void TesteInativarPerfil()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");
            
            //Clica no botão Editar Perfil e Selecionar o texto Inativo
            InitializeEditAndSeeProfilePermission();
            Click(editProfile);
            SelectByText(statusProfile, "Inativo");
        }
        public void TesteAdicaoPermissaoPerfilConsultaPerfil()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Ver Perfil
            InitializeEditAndSeeProfilePermission();
            Click(seeProfilePermissions);

            //Clica no botão Adicionar Permissão 
            InitializePermission();
            Click(addPermission);
        }
        public void TesteExclusaoPermissaoPerfilConsultaPerfil()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Ver Perfil
            InitializeEditAndSeeProfilePermission();
            Click(seeProfilePermissions);

            //Clica no botão Excluir Permissão
            InitializePermission();
            Click(removePermission);
        }
        public void TesteRemoverPerfil()
        {
            //Troca de frame
            SwitchFrame("iframe_opt");

            //Clica no botão Excluir Perfil
            InitializeEditAndSeeProfilePermission();
            Click(removeProfile);
        }
    }
    
}
