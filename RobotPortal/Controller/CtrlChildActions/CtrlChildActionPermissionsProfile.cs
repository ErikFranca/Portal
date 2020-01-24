using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;


namespace RobotPortal
{
    public class CtrlChildActionPermissionsProfile : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;
        public IWebElement ButtonEditInfo;
        public IWebElement ViewPermission;
        public IWebElement DeleteProfile;
        public IWebElement FieldStatus;
        public IWebElement SaveEdit;
        public IWebElement TittleProfile;
        public IWebElement FieldClient;
        public IWebElement FieldTeam;
        public IWebElement FieldTypeProfile;
        public IWebElement BoxPermissionsDefaut;
        public IWebElement ConfirmRegister;
        public IWebElement TittleRegisterProfile;
        public IWebElement ButtonNext;
        public IWebElement FieldTextDefaut;
        public IWebElement TittlePermissionsProfile;
        public IWebElement DeletePermission;
        public IWebElement AddPermission;


        public CtrlChildActionPermissionsProfile(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            //Declaração de elementos
            Thread.Sleep(3000);
            TittleProfile = FindByXpath("/html/body/div/center/h3");
            ButtonEditInfo = FindByName("create");
            ViewPermission = FindByName("cog");
            DeleteProfile = FindByName("trash");
            FieldStatus = FindByClassName("selectpicker");
            SaveEdit = FindByName("bookmark");
        }

        public void SwitchFrameInitialize()
        {
            //Declaração de elementos 
            Thread.Sleep(3000);
            SwitchFrame("iframe_opt");
        }
        
        public void RegisterProfileInitialize()
        {
            //Declaração de elementos 
            Thread.Sleep(3000);          
            FieldTypeProfile = FindById("list-type_new");
            BoxPermissionsDefaut = FindById("chk_default_pms");
            ConfirmRegister = FindByCss(".btn-success");
            TittleRegisterProfile = FindByCss(".page-header > h3:nth-child(1)");
            ButtonNext = FindByCss(".btn-info");
            FieldTextDefaut = FindById("lbl_default_pms");
        }

        public void PermissionTabInitialize()
        {
            //Declaração de elementos 
            Thread.Sleep(3000);
            TittlePermissionsProfile = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div[contains(@id, 'permissao')]");
            DeletePermission = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/div[3]/table/tbody/tr[1]/td[2]/button[2]/ion-icon");
        }
        
        public void AddPermissionInitialize()
        {
            //Declaração de elementos 
            AddPermission = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/div[4]/table/tbody/tr/td/button");
        }

        public void InactiveProfilePermission()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada de elementos da tela
            Initialize();

            //Verifica se acessou corretamento a tela de perfis
            AssertAreEqual("Perfis", TittleProfile);

            //Edita as informações e salva
            Click(ButtonEditInfo);
            SelectByText(FieldStatus, "Inativo");
            Click(SaveEdit);
        }

        public void PermissionViewProfile()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos da tela
            Initialize();

            //Verifica se acessou corretamento a tela de perfis
            AssertAreEqual("Perfis", TittleProfile);
        }

        public void CreateProfile()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada de elementos da tela
            RegisterProfileInitialize();

            //Verifica se acessou a tela de cadastrar perfil
            AssertAreEqual("Cadastrar Perfil", TittleRegisterProfile);

            //Seleciona o tipo de perfil
            SelectByText(FieldTypeProfile, "Analista");

            //Segue para a proxima pagina
            Click(ButtonNext);

            //Verifica se seguiu corretamento para a proxima tela
            AssertAreEqual("Selecionar permissões padrão", FieldTextDefaut);

            //Seleciona as permisssões e clica em confirmar
            Click(BoxPermissionsDefaut);
            Click(ConfirmRegister);
        }

        public void PermissionDeleteProfile()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada de elementos da tela
            Initialize();

            //Verifica se acessou a tela de perfis
            AssertAreEqual("Perfis", TittleProfile);

            //Deleta um perfil
            Click(DeleteProfile);
            AcceptAlert();
        }

        public void PermissionViewPermissionsProfile()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos da tela
            Initialize();

            //Verifica se acessou a tela perfis
            AssertAreEqual("Perfis", TittleProfile);
            
            //Acessa a tela de permissões
            Click(ViewPermission);
        }

        public void PermissionAddAndDeletePermissionProfile()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos da tela
            Initialize();

            //Verifica se acessou a tela de perfis
            AssertAreEqual("Perfis", TittleProfile);
            
            //Acessa a tela de permissões 
            Click(ViewPermission);
            
            //Chamada de novos elementos da tela
            PermissionTabInitialize();
            
            //Remove uma permissão
            Click(DeletePermission);

            //Chamada de novos elementos da tela
            AddPermissionInitialize();

            //Verifica se tem algum permissão para ser adicionada
            IsElementDisplayed(AddPermission);

            //Adiciona uma permissão
            Click(AddPermission);

        }








    }
}