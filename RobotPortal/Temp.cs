using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text;

namespace RobotPortal
{
    [TestFixture]
    public class Temp
    {
        //Parametros
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        public string PathChromeDriver = "";
        public string PathDoExecutavel = "";
        public static string PathDoProjeto = "";
        public CtrlDriverActions actions;

        [SetUp]
        public void Setup()
        {
            PathDoExecutavel = @System.Environment.CurrentDirectory.ToString();
            ChromeDriverService service = null;
            var options = new ChromeOptions();

            PathDoProjeto = Directory.GetCurrentDirectory();
            PathDoProjeto = PathDoProjeto.Substring(0, PathDoProjeto.IndexOf("RobotPortal"));
            PathChromeDriver = PathDoExecutavel;
            service = ChromeDriverService.CreateDefaultService(PathChromeDriver, "chromedriver.exe");

            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--touch-events=enabled");
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("http://192.168.137.1/portal");

            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.AreEqual("", verificationErrors.ToString());

        }

        [Test]
        public void TestFilterReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByName();
        }

        [Test]
        public void TestCompileReport()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionCompilerReports compiler = new CtrlChildActionCompilerReports(driver);

            security.Login();
            portal.AcessMenuCompile();
            compiler.CompileSimpleReport();

        }
    }
}