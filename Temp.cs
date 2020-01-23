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
            service.Dispose();

            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--touch-events=enabled");
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("http://192.168.137.1:20080/portal");

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
        public void Test0000_PrepareUserReport()
        {
            CtrlChildActionCompilerReports compile = new CtrlChildActionCompilerReports(driver);
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionNewUser newUser = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);

            security.Login();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuNewUsers();
            newUser.NewUserReport();
            portal.Logout();
            security.NewLoginPrepareReport(newUser.AlertText1);
            portal.ChooseAllClients();
            portal.AcessMenuCompile();
            compile.CompilePrepareReport();

        }

        [Test]
        public void Test0001_FilterByClientReport()
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByClientName();
        }

        [Test]
        public void Test0002_FilterByProfileTypeReport() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByProfile();
        }
        
        [Test]
        public void Test0003_FilterReportName() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByReportName();
        }

        [Test]
        public void TestCompileReport() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionCompilerReports compiler = new CtrlChildActionCompilerReports(driver);

            security.LoginCompiler();
            portal.AcessMenuCompile();
            compiler.CompileSimpleReport();

        }

        [Test]
        public void TestCompileReportAddProfile() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionCompilerReports compiler = new CtrlChildActionCompilerReports(driver);

            security.LoginCompiler();
            portal.AcessMenuCompile();
            compiler.CompileReportAddProfile();

        }

        [Test]
        public void TestCompileReportMakeChanges() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionCompilerReports compiler = new CtrlChildActionCompilerReports(driver);

            security.LoginCompiler();
            portal.AcessMenuCompile();
            compiler.CompileReportMakeChanges();

        }

        [Test]
        public void Test0004_FilterReportObs() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByObs();
        }

        [Test]
        public void Test0005_FilterReportStatus() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByStatus();

        }

        [Test]
        public void Test0006_FilterReportSuites() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterBySuites();

        }

        [Test]
        public void Test0007_FilterReportDataStart() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByDataStart();

        }

        [Test]
        public void Test0008_FilterReportDataEnd() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByDataEnd();

        }

        [Test]
        public void Test0009_FilterReportDataVoidResult() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterByDataVoidResult();

        }

        [Test]
        public void Test0010_FilterReportOrderByOrder() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterOrderByOrder();

        }

        [Test]
        public void Test0011_FilterReportOrderByReportName() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterOrderByReportName();

        }

        [Test]
        public void Test0012_FilterReportOrderByDate() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterOrderByDate();

        }

        [Test]
        public void Test0013_FilterReportOrderByAnalist() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterOrderByAnalist();

        }

        [Test]
        public void Test0014_FilterReportOrderByObs() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterOrderByObs();

        }

        [Test]
        public void Test0015_FilterReportOrderByStatus() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.FilterOrderByStatus();
        }

        [Test]
        public void Test0016_VisualizeReport() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.ViewReport();
        }

        [Test]
        public void Test0017_EditObsReport() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.EditInfoReport();
        }

        [Test]
        public void Test0018_AddProfileReport() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.AddProfileReport();
        }

        [Test]
        public void Test0019_ViewSuites() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.ViewSuiteReport();
        }

        [Test]
        public void Test0020_InativeProfile() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.InativeProfileReport();
        }


        [Test]
        public void Test0021_RemoveProfile() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.RemoveProfileReport();
        }

        [Test]
        public void Test0022_UnpubPostReport() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.UnpubPostReport();
        }

        [Test]
        public void Test0023_DeleteReport() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.DeleteReport();
        }

        [Test]
        public void Test0024_DeletePostReport() //OK
        {
            CtrlChildActionReports reports = new CtrlChildActionReports(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginPreparedReport();
            portal.ChooseAllClients();
            portal.AcessMenuReport();
            reports.DeletePostReport();
        }

        [Test]
        public void TestePermissionReadUsers() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.ReadUser();

        }

        [Test]
        public void TestePermissionNewUser() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionNewUser newuser = new CtrlChildActionNewUser(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuRegisterUsers();
            newuser.PermissionNewUser();

        }

        [Test]
        public void TestePermissionDeleteUser() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.PermissionDeleteUser();


        }

        [Test]
        public void TestePermissionEditInfoUser() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.PermissionEditInfoUser();


        }

        [Test]
        public void TestePermissionViewProfileUser() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.PermissionViewProfileUser();

        }

        [Test]
        public void TestePermissionAddAndDeleteProfileUser() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.PermissionAddAndDeleteProfileUser();

        }

        [Test]
        public void TestePermissionEditStatusProfileUser() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.PermissionEditStatusProfileUser();

        }

        [Test]
        public void TestePermissionViewPermissionsProfileUser() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.PermissionViewPermissionProfileUser();

        }


        [Test]
        public void TesteExclusaoPerfilViaConsultaUsuario() //OK
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
        public void TesteExclusaoUsuario() //OK
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
        public void TesteTrocaEmail() //OK 
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.LoginUserTest2();
            User.TesteTrocaEmail();
        }
        [Test]
        public void TesteTrocaSenha() //OK
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);

            security.LoginUserTest2();
            User.TesteTrocaSenha();
        }
        [Test]
        public void TesteAtualizacaoInformacoesUsuarioExistente() //OK
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuConsultUsers();
            User.TesteAtualizacaoInformacoesUsuarioExistente();
        }
        [Test]
        public void ValidarVisualizacaoPerfilUsuarios() //OK
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuConsultUsers();
            User.ValidarVisualizacaoPerfilUsuarios();
        }
        [Test]
        public void ValidarInativacaoPerfilConsultaUsuarios() //OK
        {
            CtrlChildActionUsers User = new CtrlChildActionUsers(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuConsultUsers();
            User.ValidarInativacaoPerfilConsultaUsuarios();
        }

        [Test]
        public void TesteAdicaoPermissaoPerfilConsultaUsuario() //OK
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
        public void TesteExclusaoPermissaoPerfilConsultaUsuario() //OK
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
        public void TesteInclusaoUsuarioCopiandoOutroUsuarioExistente() //OK
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioCopiandoOutroUsuarioExistente();
        }

        [Test]
        public void TesteInclusaoUsuarioAtribuindoPerfilExistente() //OK
        {
            CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginUserTest2();
            portal.AcessMenuNewUsers();
            newUsers.TesteInclusaoUsuarioAtribuindoPerfilExistente();
        }
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfilClienteEspecifico() //OK
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
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodosClientes() //OK
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
        //Descontinuado
        //[Test]
        //public void TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo() //OK
        //{
        //    CtrlChildActionNewUser newUsers = new CtrlChildActionNewUser(driver);
        //    CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
        //    CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

        //    security.LoginUserKroton();
        //    portal.AcessMenuNewUsers();
        //    newUsers.TesteInclusaoUsuarioCriandoNovoPerfilTentativaCriarClienteNaoPossuo();
        //}
        [Test]
        public void TesteInclusaoUsuarioCriandoNovoPerfil1EquipeEspecifica() //OK
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
        public void TesteInclusaoUsuarioCriandoNovoPerfilTodasEquipes() //OK
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
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAdministradorPermissoesPadrao() //OK
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
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoOperadorPermissoesPadrao() //OK

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
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoGerentePermissoesPadrao() //OK

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
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoAnalistaPermissoesPadrao() //OK

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
        public void TesteInclusaoUsuarioCriandoNovoPerfilCriarTipoTodos() //OK

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
        public void TesteInclusaoUsuarioCriandoNovoPerfilEspecifico() //OK

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
        public void TesteInclusaoUsuarioCriandoNovoPerfilValidarOpcoesPermissoesPadrao() //OK

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
        public void TesteInclusaoUsuarioCriandoNovoPerfilPermissãoEspecifica() //OK
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
        public void TesteInclusaoUsuarioNovoPerfil1ClienteEspecifico() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfil1ClienteEspecifico();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTodosClientes() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTodosClientes();
        }
        //Descontinuado
        //[Test]
        //public void TesteInclusaoUsuarioNovoPerfilClienteNaoPossuo() //OK
        //{
        //    CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
        //    CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
        //    CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

        //    security.LoginUserTest2();
        //    portal.AcessMenuProfileRegister();
        //    newProfile.TesteInclusaoUsuarioNovoPerfilClienteNaoPossuo();
        //}
        [Test]
        public void TesteInclusaoUsuarioNovoPerfil1EquipeEspecifica() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfil1EquipeEspecifica();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTodasEquipes()
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTodasEquipes();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTipoAdministradorPermissaoPadrao() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTipoAdministradorPermissaoPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTipoOperadorPermissaoPadrao() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTipoOperadorPermissaoPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTipoGerentePermissaoPadrao() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTipoGerentePermissaoPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTipoAnalistaPermissaoPadrao() //OK 
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTipoAnalistaPermissaoPadrao();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTipoTodosPerfis() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTipoTodosPerfis();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTipoPerfilEspecifico() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTipoPerfilEspecifico();
        }
        [Test]
        public void TesteInclusaoUsuarioNovoPerfilTipoValidaPermissaoPadrao() //OK
        {
            CtrlChildActionNewProfile newProfile = new CtrlChildActionNewProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileRegister();
            newProfile.TesteInclusaoUsuarioNovoPerfilTipoValidaPermissaoPadrao();
        }

        [Test]
        public void TesteAddAndDeleltePermissionProfileUser() //OK
        {
            CtrlChildActionPermissionsUser permission = new CtrlChildActionPermissionsUser(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionUserLogin();
            portal.PermissionAcessMenuConsultUsers();
            permission.PermissionAddAndDeletePermissionProfileUser();

        }

        [Test]
        public void TestePermissionInactiveProfile() //OK
        {
            CtrlChildActionPermissionsProfile permission = new CtrlChildActionPermissionsProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionProfileLogin();
            portal.PermissionAcessMenuProfileConsult();
            permission.InactiveProfilePermission();
        }

        [Test]
        public void TesteAdicaoPermissaoPerfilConsultaPerfil() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionProfiles profiles = new CtrlChildActionProfiles(driver);


            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileConsult();
            profiles.TesteAdicaoPermissaoPerfilConsultaPerfil();
        }
        [Test]
        public void TesteExclusaoPermissaoPerfilConsultaPerfil() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionProfiles profiles = new CtrlChildActionProfiles(driver);


            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileConsult();
            profiles.TesteExclusaoPermissaoPerfilConsultaPerfil();
        }
        [Test]
        public void TesteRemoverPerfil() //OK
        {
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);
            CtrlChildActionProfiles profiles = new CtrlChildActionProfiles(driver);


            security.LoginAdmin();
            portal.ChooseAllClients();
            portal.ChooseTeam();
            portal.AcessMenuProfileConsult();
            profiles.TesteRemoverPerfil();
        }

        [Test]
        public void TestePermissionViewProfile() //OK
        {
            CtrlChildActionPermissionsProfile permission = new CtrlChildActionPermissionsProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionProfileLogin();
            portal.PermissionAcessMenuProfileConsult();
            permission.PermissionViewProfile();
        }

        [Test]
        public void TestePermissionRegisterProfile() //OK
        {
            CtrlChildActionPermissionsProfile permission = new CtrlChildActionPermissionsProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionProfileLogin();
            portal.PermissionAcessMenuProfileRegister();
            permission.CreateProfile();
        }

        [Test]
        public void TestePermissionDeleteProfile() //OK
        {
            CtrlChildActionPermissionsProfile permission = new CtrlChildActionPermissionsProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionProfileLogin();
            portal.PermissionAcessMenuProfileConsult();
            permission.PermissionDeleteProfile();
        }

        [Test]
        public void TestePermissionViewPermissionProfile() //OK
        {
            CtrlChildActionPermissionsProfile permission = new CtrlChildActionPermissionsProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionProfileLogin();
            portal.PermissionAcessMenuProfileConsult();
            permission.PermissionViewPermissionsProfile();
        }

        [Test]
        public void TestePermissionAddAndDeleteProfile() //OK
        {
            CtrlChildActionPermissionsProfile permission = new CtrlChildActionPermissionsProfile(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionProfileLogin();
            portal.PermissionAcessMenuProfileConsult();
            permission.PermissionAddAndDeletePermissionProfile();
        }

        [Test]
        public void TestePermissionViewReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionViewReport();
        }

        [Test]
        public void TestePermissionDetailsReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionDetailsReport();
        }

        [Test]
        public void TestePermissionEditReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionEditReport();
        }

        [Test]
        public void TestePermissionUnpublishReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionUnpublishReport();
        }

        [Test]
        public void TestePermissionPublishReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionPublishReport();
        }

        [Test]
        public void TestePermissionViewProfileReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionDeViewProfileReport();
        }

        [Test]
        public void TestePermissionAddProfileReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionAddProfileReport();
        }

        [Test]
        public void TestePermissionDeleteProfileReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionDeleteProfileReport();
        }

        [Test]
        public void TestePermissionDeleteReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionDeleteReport();
        }

        [Test]
        public void TestePermissionDeletePublishReport() //OK
        {
            CtrlChildActionPermissionsReport permission = new CtrlChildActionPermissionsReport(driver);
            CtrlChildActionSecurity security = new CtrlChildActionSecurity(driver);
            CtrlCtrlPortalActions portal = new CtrlCtrlPortalActions(driver);

            security.PermissionReportLogin();
            portal.PermissionAcessMenuConsultReport();
            permission.PermissionDeletePublishReport();
        }




    }
}