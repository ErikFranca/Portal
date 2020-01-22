using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;


namespace RobotPortal
{
    public class CtrlChildActionPermissionsUser : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement Resultemail;
        public IWebElement IconDelete;
        public IWebElement IconInfo;
        public IWebElement FieldInfo;
        public IWebElement IconSaveInfo;
        public IWebElement IconViewProfile;
        public IWebElement ViewProfile;
        public IWebElement IconAddProfile;
        public IWebElement TypeProfileFilter;
        public IWebElement ButtonConfirm;
        public IWebElement FieldStatus;
        public IWebElement IconViewPermission;
        public IWebElement TittlePermissions;
        public IWebElement DeletePermission;
        public IWebElement AddPermission;


        public CtrlChildActionPermissionsUser(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void SwitchFrameInitialize()
        {
            //Declaração de elementos
            Thread.Sleep(3000);
            SwitchFrame("iframe_opt");
        }

        public void PermissionReadInitialize()
        {
            //Declara de elementos
            Thread.Sleep(3000);
            Resultemail = FindById("email");
            IconDelete = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@href,'del')]");
            IconInfo = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@href,'del')]");
            IconViewPermission = FindByXpath("/html/body/div/div/div/div/div/div/div/div/div/div/table/tbody/tr/td/a[contains(@data-original-title,'Ver Permissões')]");
            FieldInfo = FindByXpath("//*[@type='text'][contains(@id,'email')]");
            FieldStatus = FindByClassName("selectpicker");
            IconSaveInfo = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@href,'save')]");
            IconViewProfile = FindByXpath("/html/body/div/div/form/table/tbody/tr/td/a[contains(@data-original-title,'Ver perfis')]");
            ViewProfile = FindByClassName("table-responsive");
        }

        public void ProfileTabInitialize()
        {
            //Declaração de elementos
            Thread.Sleep(3000);
            IconAddProfile = FindByXpath("//*[@type='button'][contains(@class,'btn btn-outline-secondary float-right btn-lg')]");
            TypeProfileFilter = FindByXpath("//*[@class='selectpicker'][contains(@title,'Perfil')]");
            ButtonConfirm = FindByXpath("//*[@type='button'][contains(@class,'btn btn-outline-success float-right btn-lg')]");
        }

        public void ProfilePermissionTabInitialize()
        {
            //Declaração de elementos
            Thread.Sleep(3000);
            TittlePermissions = FindByXpath("/html/body/div[1]/div/div/div/div/div[2]/div/div/div[contains(@id, 'permissao')]");
            DeletePermission = FindByXpath("/html/body/div/div/div/div/div/div/div/div/div/div/div/table/tbody/tr/td/button[contains(@data-original-title,'Excluir Perfil')]");
            AddPermission = FindByXpath("/html/body/div[1]/div/div/div/div/div[2]/div/div/div/div/div[4]/table/tbody/tr/td/button");
        }

        public void ReadUser()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos da tela
            PermissionReadInitialize();

            //Verifica se acessou a tela de usuário
            IsElementDisplayed(Resultemail);
        }
        public void PermissionDeleteUser()
        {
            //Troca de frame 
            SwitchFrameInitialize();
            
            //Chamada de elementos da tela
            PermissionReadInitialize();

            //Verifica se acessou a tela de usuário
            IsElementDisplayed(IconDelete);

            //Deleta algum usuário
            Click(IconDelete);
            AcceptAlert();

        }

        public void PermissionEditInfoUser()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada de elementos da tela
            PermissionReadInitialize();

            //Verifica se acessou a tela de usuário
            IsElementDisplayed(IconInfo);

            //Edita as informações do usuário e salva
            Click(IconInfo);
            SendKeys(FieldInfo, Keys.Control + "a");
            SendKeys(FieldInfo, "teste@teste1.com.br");
            Click(IconSaveInfo);

        }
        public void PermissionViewProfileUser()
        {
            //troca de frame 
            SwitchFrameInitialize();

            //Chamada dos elementos da tela
            PermissionReadInitialize();

            //Verifica se acessou a tela de usuário
            IsElementDisplayed(IconViewProfile);

            //Clica para acessar a tela de perfil de usuário
            Click(IconViewProfile);

            //Verifica se acessou a tela de perfil de usuário
            IsElementDisplayed(ViewProfile);

        }

        public void PermissionAddAndDeleteProfileUser()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada dos elementos da tela
            PermissionReadInitialize();

            //Clica para acessar a tela de perfil de usuário
            IsElementDisplayed(IconViewProfile);

            //Acessa a tela de perfil de usuário
            Click(IconViewProfile);

            //Verifica se acessou a tela corretamente
            IsElementDisplayed(ViewProfile);

            //Chamada de novos elementos da tela
            ProfileTabInitialize();

            //Adiciona um novo perfil de usuário
            Click(IconAddProfile);
            SelectByText(TypeProfileFilter, "Analista");
            Click(ButtonConfirm);

        }

        public void PermissionEditStatusProfileUser()
        {
            //Troca de frame 
            SwitchFrameInitialize();

            //Chamada de elementos da tela 
            PermissionReadInitialize();

            //Verifica se acessou a tela de perfis
            IsElementDisplayed(IconViewProfile);
            
            //Inativa algum perfil de usuário e clica em salvar
            Click(IconInfo);
            SelectByText(FieldStatus, "Inativo");
            Click(IconSaveInfo);

        }

        public void PermissionViewPermissionProfileUser()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada de elementos da tela
            PermissionReadInitialize();

            //Verifica se acessou a tela de perfis 
            IsElementDisplayed(IconViewProfile);

            //Acessa a tabela de permissões 
            Click(IconViewProfile);
            Click(IconViewPermission);

            //Chamada de elemento da tela de permissões
            ProfilePermissionTabInitialize();

            //Verifica se acessou a tela de permissões
            IsElementDisplayed(TittlePermissions);
        }

        public void PermissionAddAndDeletePermissionProfileUser()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada de elementos da tela
            PermissionReadInitialize();

            //Verifica se acessou a tela de perfis
            IsElementDisplayed(IconViewProfile);

            //Acessa a tela de permissões
            Click(IconViewProfile);
            Click(IconViewPermission);

              //Chamada de elementos da tela de permissões
            ProfilePermissionTabInitialize();

            //Verifica de acessou a tela de permissões
            IsElementDisplayed(TittlePermissions);

            //Remove uma permissão do perfil do usuário
            Click(DeletePermission);

            //Verifica se tem alguma permissão para ser adicionada
            IsElementDisplayed(AddPermission);

            //Adiciona uma permissão
            Click(AddPermission);

        }
    }
}