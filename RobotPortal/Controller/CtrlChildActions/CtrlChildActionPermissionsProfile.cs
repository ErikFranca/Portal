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



        public CtrlChildActionPermissionsProfile(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            ButtonEditInfo = FindByName("create");
            ViewPermission = FindByName("cog");
            DeleteProfile = FindByName("trash");
            FieldStatus = FindByClassName("selectpicker");
            SaveEdit = FindByName("bookmark");
        }

        public void EditStatus()
        {
            Initialize();
        }

        public void InactiveProfilePermission()
        {
            Initialize();
        }

    }
}