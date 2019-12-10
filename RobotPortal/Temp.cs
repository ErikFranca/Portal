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
        public void LoginPortalUsuarioInativo()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.LoginPortalUsuarioInativo();
        }
        [Test]
        public void LoginPortalSenhaCorreta()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.LoginPortalSenhaCorreta();
        }
        [Test]
        public void LoginPortalSenhaIncorreta()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.LoginPortalSenhaIncorreta();
        }
        [Test]
        public void NovoLoginPortalTestSenha()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.NovoLoginPortalTestSenha();
        }
        [Test]
        public void TesteQuantidadeLoginsIncorretosExcedida()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.TesteQuantidadeLoginsIncorretosExcedida();
        }
        [Test]
        public void TesteInclusaoUsuarioCopiandoOutroUsuarioExistente()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCopiandoOutroUsuarioExistente();
        }
        [Test]
        public void TesteInclusaoUsuarioAtribuindoPerfilExistente()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioAtribuindoPerfilExistente();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilClienteEspecifico()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilClienteEspecifico();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodosClientes()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilTodosClientes();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfil1EquipeEspecifica()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfil1EquipeEspecifica();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodasEquipes()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilTodasEquipes();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAdministradorPermissoesPadrao()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAdministradorPermissoesPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoOperadorPermissoesPadrao()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoOperadorPermissoesPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoGerentePermissoesPadrao()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoGerentePermissoesPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAnalistaPermissoesPadrao()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAnalistaPermissoesPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoTodos()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoTodos();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilEspecifico()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilEspecifico();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilValidarOpcoesPermissoesPadrao()
        {
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);

            newUser.TesteInclusaoUsuarioCriandoNovoPerfilValidarOpcoesPermissoesPadrao();
        }
        [Test]
        public void TesteTrocaSenha()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);

            User.TesteTrocaSenha();
        }
        [Test]
        public void TesteTrocaEmail()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);

            User.TesteTrocaEmail();
        }
        [Test]
        public void TesteAtualizacaoInformacoesUsuarioExistente()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);

            User.TesteAtualizacaoInformacoesUsuarioExistente();
        }
        [Test]
        public void ValidarVisualizacaoPerfilUsuarios()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);

            User.ValidarVisualizacaoPerfilUsuarios();
        }
        [Test]
        public void ValidarInativacaoPerfilConsultaUsuarios()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);

            User.ValidarInativacaoPerfilConsultaUsuarios();
        }
        [Test]
        public void TesteAdicaoPermissaoPerfilConsultaUsuario()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);

            User.TesteAdicaoPermissaoPerfilConsultaUsuario();
        }
    }
}