using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;


namespace RobotPortal
{
    public class CtrlChildActionReports : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement ButtonShowFilter;
        public IWebElement FieldName;
        public IWebElement FieldObs;
        public IWebElement FieldStatus;
        public IWebElement FieldSuites;
        public IWebElement FieldDataStart;
        public IWebElement FieldDataEnd;
        public IWebElement FieldOrder;
        public IWebElement FieldResultNameReport;
        public IWebElement FieldClient;
        public IWebElement ButtonFilter;
        public IWebElement FieldResultObs;
        public IWebElement FieldResultDataStart;
        public IWebElement FieldResultDataEnd;
        public IWebElement IconAcess;
        public IWebElement IconEdit;
        public IWebElement IconConfirmEdit;
        public IWebElement FieldEditObs;
        public IWebElement IconShowAddProfile;
        public IWebElement IconViewProfile;
        public IWebElement IconAddProfile;
        public IWebElement IconShowSuites;
        public IWebElement FilterTypeProfile;
        public IWebElement TittleSuites;
        public IWebElement IconRemoveProfile;
        public IWebElement IconInativeProfile;
        public IWebElement IconActiveProfile;
        public IWebElement IconDeleteReport;
        public IWebElement IconDeletePost;
        public IWebElement IconUnpubReport;
        public IWebElement IconPubPost;
        public IWebElement FilterClientName;
        public IWebElement FilterProfile;
        public IWebElement FieldListProfile;


        public CtrlChildActionReports(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            Thread.Sleep(3000);
            FieldClient = FindById("cst_id_list");
            FieldListProfile = FindById("profile_list");
        }
        public void ShowFilterInitialize()
        {
            Thread.Sleep(3000);
            FilterProfile = FindByXpath("//*[@id='ctn']/div[1]/div[2]/div/button/div/div/div");
            FilterClientName = FindByXpath("//*[@id='ctn']/div[1]/div[1]/div/button/div/div/div");
            ButtonShowFilter = FindById("btn_show");
            ButtonFilter = FindByCss("#ctn > div:nth-child(6) > div > div:nth-child(4) > button");
            FieldName = FindById("nome_rel");
            FieldObs = FindById("obs");
            FieldStatus = FindById("status");
            FieldSuites = FindByCss("#ctn > div:nth-child(5) > div > div:nth-child(4) > div > button > div > div > div");
            FieldDataStart = FindById("dataIni");
            FieldDataEnd = FindById("dataFim");
            FieldOrder = FindById("order_list");
        }

        public void ResultInitialize()
        {
            Thread.Sleep(3000);
            FieldResultNameReport = FindById("rpt_name");
            FieldResultObs = FindById("obs");
            FieldResultDataStart = FindById("compilado_1");
            FieldResultDataEnd = FindById("tr_1");
        }

        public void IconInitialize()
        {
            Thread.Sleep(3000);
            IconAcess = FindByName("eye");
            IconEdit = FindByName("create");
            IconConfirmEdit = FindByName("bookmark");
            FieldEditObs = FindByXpath("/html/body/div/div/form/table/tbody/tr[1]/th[2]/div[2]/input");
            IconViewProfile = FindByName("person");
            IconShowSuites = FindByName("more");
            IconDeleteReport = FindByName("close");
            IconDeletePost = FindByName("trash");
            IconUnpubReport = FindByName("radio-button-on");
            IconPubPost = FindByXpath("/html/body/div/div/form/table/tbody/tr[1]/td[5]/a[9]/ion-icon");
            TittleSuites = FindByXpath("/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div/div/table/thead/tr/td[1]");
        }

        public void ViewProfileInitialize()
        {
            Thread.Sleep(3000);
            IconShowAddProfile = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/div/div[2]/button[1]");
            IconAddProfile = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/div/div[2]/button[2]");
            FilterTypeProfile = FindByClassName("selectpicker");
            IconRemoveProfile = FindByCss("td:nth-child(6) > a:nth-child(3) > ion-icon");
            IconInativeProfile = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/table/tbody/tr[1]/td[6]/a[2]/ion-icon");
            IconActiveProfile = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/table/tbody/tr[1]/td[6]/a[1]/ion-icon");
        }

        public void FalseInitialize()
        {
            AssertFalseResult("#tr_47 > td:nth-child(7)");
        }

        public void SwitchFrameInitialize()
        {
            Thread.Sleep(3000);
            SwitchFrame("iframe_opt");
        }


        public void FilterByReportName()
        {
            //Initializes
            SwitchFrameInitialize();

            ShowFilterInitialize();
            Click(ButtonShowFilter);
            Click(FieldName);
            SendKeys(FieldName, "NETCORE");
            Click(ButtonFilter);
            SwitchFrameInitialize();
            ResultInitialize();
            AssertAreEqual("Relatório de exemplo NETCORE", FieldResultNameReport);
        }


        public void FilterByClientName()
        {
            SwitchFrameInitialize();
            Initialize();

            SelectByText(FieldClient, "Marisa");
            ShowFilterInitialize();
        }

        public void FilterByProfile()
        {
            SwitchFrameInitialize();
            Initialize();

            SelectByText(FieldListProfile, "Compiler");
            ShowFilterInitialize();
        }

        public void FilterByObs()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SendKeys(FieldObs, "Starline" + Keys.Enter);
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.That(FieldResultObs.Text, Does.Contain("Starline"));

        }

        public void FilterByStatus()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByText(FieldStatus, "Status");
            SwitchFrameInitialize();
            ResultInitialize();

        }



        public void FilterByDataStart()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SendKeys(FieldDataStart, "05122019");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.That(FieldResultDataStart.Text, Does.Contain("2019-12-05"));

        }

        public void FilterByDataEnd()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SendKeys(FieldDataEnd, "08102019");
            SwitchFrameInitialize();
            ResultInitialize();


            Assert.That(FieldResultDataEnd.Text, Does.Contain("2019-10-07"));

        }

        public void FilterByDataVoidResult()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SendKeys(FieldDataStart, "10102020");
            SendKeys(FieldDataEnd, "10102020");
            Click(ButtonFilter);
            SwitchFrameInitialize();
            FalseInitialize();

        }

        public void FilterOrderByOrder()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByText(FieldOrder, "Ordenar");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.IsNotNull(FieldResultNameReport);
        }

        public void FilterOrderByReportName()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();


            Click(ButtonShowFilter);
            SelectByText(FieldOrder, "Nome do Relatório");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.IsNotNull(FieldResultNameReport);
        }

        public void FilterOrderByDate()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByText(FieldOrder, "Data de Publicação");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.IsNotNull(FieldResultNameReport);
        }

        public void FilterOrderByAnalist()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByText(FieldOrder, "Analista Responsável");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.IsNotNull(FieldResultNameReport);
        }

        public void FilterOrderByObs()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByText(FieldOrder, "Observação");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.IsNotNull(FieldResultNameReport);
        }

        public void FilterOrderByStatus()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByText(FieldOrder, "Status");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.IsNotNull(FieldResultNameReport);
        }

        public void ViewReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconAcess);
            SwitchTab();
        }
        public void EditInfoReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconEdit);
            Clear(FieldEditObs);
            SendKeys(FieldEditObs, "Gerar - Relatório - Teste");
            Click(IconConfirmEdit);
        }

        public void AddProfileReport()
        {
            WaitForPageToLoad(driverChildAction);
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconViewProfile);
            ViewProfileInitialize();
            Click(IconShowAddProfile);
            SelectByText(FilterTypeProfile, "Marisa | Testes Automatizados | Teste | Operador");
            Click(IconAddProfile);

        }

        public void ViewSuiteReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconShowSuites);
            AssertAreEqual("Suítes & Cenários", TittleSuites);

        }

        public void RemoveProfileReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconViewProfile);
            ViewProfileInitialize();
            Click(IconRemoveProfile);
            AcceptAlert();


        }

        public void InativeProfileReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconViewProfile);
            Click(IconInativeProfile);
            IsElementDisplayed(IconActiveProfile);

        }

        public void DeleteReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconDeleteReport);
            AcceptAlert();

        }

        public void DeletePostReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconDeletePost);
            AcceptAlert();

        }

        public void UnpubPostReport()
        {
            SwitchFrameInitialize();
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconUnpubReport);

        }

        public void FilterByNameReport()
        {

            SwitchFrameInitialize();
            ShowFilterInitialize();
            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconUnpubReport);

        }

        public void FilterByProfileReport()
        {

            SwitchFrameInitialize();
            ShowFilterInitialize();
            SelectByText(FilterClientName, "Marisa");
            Click(ButtonShowFilter);
            Click(ButtonFilter);

        }
        //Fim dos metodos temporários

    }
}
