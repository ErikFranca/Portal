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
        public void TestFilterReportName()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByReportName();
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

        [Test]
        public void TestCompileReportAddProfile()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionCompilerReports compiler = new CtrlChildActionCompilerReports(driver);

            security.Login();
            portal.AcessMenuCompile();
            compiler.CompileReportAddProfile();

        }

        [Test]
        public void TestCompileReportMakeChanges()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionCompilerReports compiler = new CtrlChildActionCompilerReports(driver);

            security.Login();
            portal.AcessMenuCompile();
            compiler.CompileReportMakeChanges();

        }

        [Test]
        public void TesteFilterReportObs()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByObs();
        }

        [Test]
        public void TesteFilterReportStatus()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByStatus();

        }

        [Test]
        public void TesteFilterReportDataStart()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByDataStart();

        }

        [Test]
        public void TesteFilterReportDataEnd()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByDataEnd();

        }

        [Test]
        public void TesteFilterReportDataVoidResult()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByDataVoidResult();

        }

        [Test]
        public void TesteFilterReportOrderByOrder()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterOrderByOrder();

        }

        [Test]
        public void TesteFilterReportOrderByReportName()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterOrderByReportName();

        }

        [Test]
        public void TesteFilterReportOrderByDate()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterOrderByDate();

        }

        [Test]
        public void TesteFilterReportOrderByAnalist()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterOrderByAnalist();

        }

        [Test]
        public void TesteFilterReportOrderByObs()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterOrderByObs();

        }

        [Test]
        public void TesteFilterReportOrderByStatus()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterOrderByStatus();
        }

        [Test]
        public void TesteVisualizeReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.ViewReport();
        }

        [Test]
        public void TesteEditObsReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.EditInfoReport();
        }

        [Test]
        public void TesteAddProfileReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
        
            security.Login();
            portal.AcessMenuReport();
            reports.AddProfileReport();
        }

        [Test]
        public void TesteViewSuites()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.ViewSuiteReport();
        }

        [Test]
        public void TesteRemoveProfile()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.RemoveProfileReport();
        }

        [Test]
        public void TesteInativeProfile()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.InativeProfileReport();
        }

        [Test]
        public void TesteDeleteReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.DeletePostReport();
        }

        [Test]
        public void TesteDeletePostReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.DeleteReport();
        }

        [Test]
        public void TesteUnpubPostReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.UnpubPostReport();
        }

        [Test]
        public void TesteFilterClientNameReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.MenuReportFromHome();
            reports.FilterByClientName();
        }

        [Test]
        public void TesteFilterByClientReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.AcessMenuReport();
            reports.FilterByClientName();
        }

        [Test]
        public void TesteFilterByProfileTypeReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.MenuReportFromHome();
            reports.FilterByProfile();
        }

        [Test]
        public void TestePermissionReadUsers()
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            permission.ReadUser();
            
        }

        [Test]
        public void TestePermissionNewUser()
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionNewUser newuser = new CtrlChildActionNewUser(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newuser.TestNewUser();


        }

        [Test]
        public void TestePermissionDeleteUser()
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            permission.PermissionDeleteUser();


        }

        [Test]
        public void TestePermissionEditInfoUser()
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            permission.PermissionEditInfoUser();


        }

        [Test]
        public void TestePermissionViewProfileUser()
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            permission.PermissionViewProfileUser();

        }
        [Test]
        public void TesteInclusaoPerfilViaConsultaUsuario()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            User.TesteInclusaoPerfilViaConsultaUsuario();
        }
        [Test]
        public void TesteExclusaoPerfilViaConsultaUsuario()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            User.TesteExclusaoPerfilViaConsultaUsuario();
        }
        //[Test]
        //public void TesteExclusaoUsuario()
        //{
        //    CtrlChildActionUsers User = new CtrlChildActionUsers(driver);

        //    User.TesteExclusaoUsuario();
        //}
        [Test]
        public void TesteExclusaoUsuario()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            User.TesteExclusaoUsuario();
        }
        [Test]
        public void TesteTrocaEmail()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.LoginUserTest2();
            User.TesteTrocaEmail();
        }
        [Test]
        public void TesteTrocaSenha()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.LoginUserTest2();
            User.TesteTrocaSenha();
        }
        [Test]
        public void TesteAtualizacaoInformacoesUsuarioExistente()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuConsultUsers();
            User.TesteAtualizacaoInformacoesUsuarioExistente();
        }
        [Test]
        public void ValidarVisualizacaoPerfilUsuarios()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuConsultUsers();
            User.ValidarVisualizacaoPerfilUsuarios();
        }
        [Test]
        public void ValidarInativacaoPerfilConsultaUsuarios()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuConsultUsers();
            User.ValidarInativacaoPerfilConsultaUsuarios();
        }
        
            [Test]
        public void TesteAdicaoPermissaoPerfilConsultaUsuario()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            User.TesteAdicaoPermissaoPerfilConsultaUsuario();
        }
        [Test]
        public void TesteExclusaoPermissaoPerfilConsultaUsuario()
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuConsultUsers();
            User.TesteExclusaoPermissaoPerfilConsultaUsuario();
        }
        
            [Test]
        public void TesteInclusaoUsuarioCopiandoOutroUsuarioExistente()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCopiandoOutroUsuarioExistente();
        }
        
               [Test]
        public void TesteInclusaoUsuarioAtribuindoPerfilExistente()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioAtribuindoPerfilExistente();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilClienteEspecifico()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilClienteEspecifico();
        }
        
            [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodosClientes()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilTodosClientes();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserKroton();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfil1EquipeEspecifica()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfil1EquipeEspecifica();
        }
        [Test]
            public void TesteInclusaoUsuarioCriandoNovoPerfilTodasEquipes()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilTodasEquipes();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAdministradorPermissoesPadrao()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAdministradorPermissoesPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoOperadorPermissoesPadrao()

        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoOperadorPermissoesPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoGerentePermissoesPadrao()

        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoGerentePermissoesPadrao();
        }
        
            [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAnalistaPermissoesPadrao()

        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAnalistaPermissoesPadrao();
        }
        
                [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoTodos()

        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoTodos();
        }
        
                   [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilEspecifico()

        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilEspecifico();
        }
        
                      [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilValidarOpcoesPermissoesPadrao()

        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilValidarOpcoesPermissoesPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilPermissãoEspecifica()
                    {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilPermissãoEspecifica();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfil1ClienteEspecifico()
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileConsult();
            newUsers.TesteInclusaoUsuarioCriandoNovoPerfilPermissãoEspecifica();
        }
        
    }
}