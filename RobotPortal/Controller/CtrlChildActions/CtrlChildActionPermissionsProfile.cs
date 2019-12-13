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
        public IWebElement TittleProfile;
        public IWebElement FieldClient;
        public IWebElement FieldTeam;
        public IWebElement FieldTypeProfile;
        public IWebElement BoxPermissionsDefaut;
        public IWebElement ConfirmRegister;
        public IWebElement TittleRegisterProfile;
        public IWebElement ButtonNext;
        public IWebElement FieldTextDefaut;


        public CtrlChildActionPermissionsProfile(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            Thread.Sleep(3000);
            TittleProfile = FindByXpath("/html/body/div/center/h3");
            ButtonEditInfo = FindByName("create");
            ViewPermission = FindByName("cog");
            DeleteProfile = FindByName("trash");
            FieldStatus = FindByClassName("selectpicker");
            SaveEdit = FindByName("bookmark");
        }

        public void SwitchFrameInitialize()
        {
            Thread.Sleep(3000);
            SwitchFrame("iframe_opt");
        }

        public void PermissionViewProfile()
        {
            SwitchFrameInitialize();
            Initialize();

            AssertAreEqual("Perfis", TittleProfile);
        }
        
        public void RegisterProfileInitialize()
        {
            Thread.Sleep(3000);
            FieldClient = FindById("cst_id");
            FieldTeam = FindById("area");
            FieldTypeProfile = FindById("list-type_new");
            BoxPermissionsDefaut = FindById("chk_default_pms");
            ConfirmRegister = FindByCss(".btn-success");
            TittleRegisterProfile = FindByCss(".page-header > h3:nth-child(1)");
            ButtonNext = FindByCss(".btn-info");
            FieldTextDefaut = FindById("lbl_default_pms");
        }

        public void InactiveProfilePermission()
        {
            SwitchFrameInitialize();
            Initialize();

            AssertAreEqual("Perfis", TittleProfile);
            Click(ButtonEditInfo);
            SelectByText(FieldStatus, "Inativo");
            Click(SaveEdit);
        }

        public void CreateProfile()
        {
            SwitchFrameInitialize();
            RegisterProfileInitialize();

            AssertAreEqual("Cadastrar Perfil", TittleRegisterProfile);

            SelectByText(FieldClient, "Ituran");
            SelectByText(FieldTeam, "Testes Automatizados");
            SelectByText(FieldTypeProfile, "Analista");

            Click(ButtonNext);

            AssertAreEqual("Selecionar permissões padrão", FieldTextDefaut);
            Click(BoxPermissionsDefaut);
            Click(ConfirmRegister);
        }



       


    }
}