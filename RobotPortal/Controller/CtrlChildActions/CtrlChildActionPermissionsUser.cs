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


        public CtrlChildActionPermissionsUser(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void SwitchFrameInitialize()
        {
            SwitchFrame("iframe_opt");
        }

        public void PermissionReadInitialize()
        {
            Resultemail = FindById("email");
            IconDelete = FindByName("trash");
            IconInfo = FindByName("create");
            FieldInfo = FindByXpath("//*[@type='text'][contains(@id,'email')]");
            IconSaveInfo = FindByName("bookmark");
            IconViewProfile = FindByName("person");
            ViewProfile = FindByClassName("table-responsive");
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
    }
}