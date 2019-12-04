using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text;

namespace RobotPortal
{
    
    public class Temp
    {
        //Parametros
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        //CtrlActions actions = new CtrlActions();
        public string PathChromeDriver = "";
        public string PathDoExecutavel = "";
        public static string PathDoProjeto = "";
        public CtrlChildActionSecurity security;
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

            verificationErrors = new StringBuilder();

            security = new CtrlChildActionSecurity();

            driver.Navigate().GoToUrl("http://192.168.137.1/portal/login/");
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
        public void TesteLoginComUsuarioInativo()
        {

            security.LoginPortalUsuarioInativo();
        }
        [Test]
        public void TesteLoginComSenhaIncorreta()
        {

            security.LoginPortalSenhaIncorreta();
        }
        [Test]
        public void TesteLoginComSenhaCorreta()
        {

            security.LoginPortalSenhaCorreta();
        }
        [Test]
        public void TesteRegrasTipoSenha()
        {

            security.NovoLoginPortalTestSenha();
        }
    }
}