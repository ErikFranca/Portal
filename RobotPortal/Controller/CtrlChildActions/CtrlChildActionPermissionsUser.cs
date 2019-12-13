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
            Thread.Sleep(3000);
            SwitchFrame("iframe_opt");
        }

        public void PermissionReadInitialize()
        {
            Thread.Sleep(3000);
            Resultemail = FindById("email");
            IconDelete = FindByName("trash");
            IconInfo = FindByName("create");
            IconViewPermission = FindByName("cog");
            FieldInfo = FindByXpath("//*[@type='text'][contains(@id,'email')]");
            FieldStatus = FindByClassName("selectpicker");
            IconSaveInfo = FindByName("bookmark");
            IconViewProfile = FindByName("person");
            ViewProfile = FindByClassName("table-responsive");
        }

        public void ProfileTabInitialize()
        {
            Thread.Sleep(3000);
            IconAddProfile = FindByXpath("//*[@type='button'][contains(@class,'btn btn-outline-secondary float-right btn-lg')]");
            TypeProfileFilter = FindByXpath("//*[@class='selectpicker'][contains(@title,'Perfil')]");
            ButtonConfirm = FindByXpath("//*[@type='button'][contains(@class,'btn btn-outline-success float-right btn-lg')]");
        }

        public void ProfilePermissionTabInitialize()
        {
            Thread.Sleep(3000);
            TittlePermissions = FindByXpath("/html/body/div[1]/div/div/div/div/div[2]/div/div/div[contains(@id, 'permissao')]");
            DeletePermission = FindByXpath("/html/body/div[1]/div/div[4]/div/div/div[2]/div/div/div/div/div[3]/table/tbody/tr/td[2]/button[2]/ion-icon");
            AddPermission = FindByXpath("/html/body/div[1]/div/div[4]/div/div/div[2]/div/div/div/div/div[4]/table/tbody/tr/td/button");
        }

        public void ReadUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(Resultemail);
        }
        public void PermissionDeleteUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(IconDelete);
            Click(IconDelete);
            AcceptAlert();

        }

        public void PermissionEditInfoUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(IconInfo);
            Click(IconInfo);
            SendKeys(FieldInfo, Keys.Control + "a");
            SendKeys(FieldInfo, "teste@teste1.com.br");
            Click(IconSaveInfo);

        }
        public void PermissionViewProfileUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(IconViewProfile);
            Click(IconViewProfile);
            IsElementDisplayed(ViewProfile);

        }

        public void PermissionAddAndDeleteProfileUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(IconViewProfile);
            Click(IconViewProfile);
            IsElementDisplayed(ViewProfile);
            ProfileTabInitialize();
            Click(IconAddProfile);
            SelectByText(TypeProfileFilter, "Marisa | Testes Automatizados | Administrador");
            Click(ButtonConfirm);

        }

        public void PermissionEditStatusProfileUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(IconViewProfile);
            Click(IconInfo);
            SelectByText(FieldStatus, "Inativo");
            Click(IconSaveInfo);

        }

        public void PermissionViewPermissionProfileUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(IconViewProfile);
            Click(IconViewProfile);
            Click(IconViewPermission);
            ProfilePermissionTabInitialize();
            IsElementDisplayed(TittlePermissions);
        }

        public void PermissionAddAndDeletePermissionProfileUser()
        {
            SwitchFrameInitialize();
            PermissionReadInitialize();

            IsElementDisplayed(IconViewProfile);
            Click(IconViewProfile);
            Click(IconViewPermission);
            ProfilePermissionTabInitialize();
            IsElementDisplayed(TittlePermissions);
            Click(DeletePermission);
            IsElementDisplayed(AddPermission);
            Click(AddPermission);

        }
    }
}