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
        public IWebElement seeProfile;
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
            editProfile = FindById("editIcon_139");
            seeProfile = FindByCss("#tr_139 > td:nth-child(7) > a:nth-child(3)");
            removeProfile = FindByCss("#tr_139 > td:nth-child(7) > a:nth-child(4)");
            statusProfile = FindById("status_139");
        }
        
        public void InitializePermission()
        {
            Thread.Sleep(3000);
            addPermission = FindByCss("#tb_pms_others_139 > tbody > tr:nth-child(1) > td:nth-child(2) > button");
            removePermission = FindByCss("#tb_pms_139 > tbody > tr:nth-child(1) > td:nth-child(2) > button:nth-child(2)");
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
            Click(seeProfile);

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
            Click(seeProfile);

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
