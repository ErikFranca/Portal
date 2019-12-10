using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;


namespace RobotPortal
{
    public class CtrlChildActionPermissionsUser : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement ResultUser;


        public CtrlChildActionPermissionsUser(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void SwitchFrameInitialize()
        {
            SwitchFrame("iframe_opt");
        }

        public void PermissionRead()
        {
            ResultUser = FindById("email");
        }

        public void ReadUser()
        {
            SwitchFrameInitialize();

            Assert.IsNotNull(ResultUser);
        }

    }
}