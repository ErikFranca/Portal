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
        public IWebElement UnpublishIcon;
        public IWebElement UnpublishTemp;
        public IWebElement PublishIcon;
        public IWebElement FilterClientName;
        public IWebElement FilterProfile;
        public IWebElement FieldListProfile;
        public IWebElement IconCreateProfile;


        public CtrlChildActionReports(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            Thread.Sleep(3000);
            FieldClient = FindByXpath("//*/select[contains(@id, 'cst_id_list')]");
            FieldListProfile = FindByXpath("//*/select[contains(@id, 'profile_list')]");
        }
        public void ShowFilterInitialize()
        {
            Thread.Sleep(3000);
            FilterProfile = FindByXpath("//*/select[contains(@id, 'profile_list')]");
            FilterClientName = FindByXpath("//*/select[contains(@id, 'cst_id_list')]");
            ButtonShowFilter = FindByXpath("//*/button[contains(text(), 'Mostrar Filtros')]");
            ButtonFilter = FindByXpath("//*/button[contains(text(), 'Filtrar')]");
            FieldName = FindByXpath("//*/input[contains(@placeholder, 'Nome do Relatório')]");
            FieldObs = FindByXpath("//*/input[contains(@placeholder, 'Observação')]");
            FieldStatus = FindByXpath("//*/select[contains(@id, 'status')]");
            FieldSuites = FindByXpath("//*/select[contains(@id, 'Suite')]");
            FieldDataStart = FindByXpath("//*/input[contains(@id, 'dataIni')]");
            FieldDataEnd = FindByXpath("//*/input[contains(@id, 'dataFim')]");
            FieldOrder = FindByXpath("//*/select[contains(@id, 'order_list')]");
        }

        public void ResultInitialize()
        {
            Thread.Sleep(3000);
            FieldResultNameReport = FindByXpath("//*/th[1]/a/div[contains(text(), '')]");
            FieldResultObs = FindByXpath("//*/th[2]/div[1][contains(text(), '')]");
            FieldResultDataStart = FindByXpath("//*/td[3][contains(@id, 'compilado')]");
            FieldResultDataEnd = FindByXpath("//*/td[4][contains(text(), '0')]");
        }

        public void IconInitialize()
        {
            Thread.Sleep(3000);
            IconAcess = FindByXpath("//*/td[5]/a[1]/img[contains(@src, 'eye.svg')]");
            IconEdit = FindByXpath("//*/td[5]/a[2]/img[contains(@src, 'Create.svg')]");
            IconConfirmEdit = FindByXpath("//*/td[5]/a[3]/img[contains(@src, 'bookmark.svg')]");
            FieldEditObs = FindByXpath("/html/body/div/div/form/table/tbody/tr[1]/th[2]/div/input");
            IconViewProfile = FindByXpath("//*/td[5]/a[4]/img[contains(@src, 'person.svg')]");
            IconShowSuites = FindByXpath("//*/td[5]/a[5]/img[contains(@src, 'more.svg')]");
            IconDeleteReport = FindByXpath("//*/td[5]/a[6]/img[contains(@src, 'close.svg')]");
            IconDeletePost = FindByXpath("//*/td[5]/a[7]/img[contains(@src, 'trash.svg')]");
            TittleSuites = FindByXpath("/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div/div/table/thead/tr/td[1]");
        }

        public void IconPublishInitialize()
        {
            string Unpublish = "//*/td[5]/a[8][not(contains(@class, 'hide'))]/img[contains(@src, 'radio-button-on.svg')]";
            string Publish = "//*/td[5]/a[9][not(contains(@class, 'hide'))]/img[contains(@src, 'radio-button-off.svg')]";

            if ((driverChildAction.FindElements(By.XPath(Unpublish)).Count != 0) || (driverChildAction.FindElements(By.XPath(Publish)).Count == 0))
            {
                Thread.Sleep(1000);
                UnpublishTemp = FindByXpath(Unpublish);

                if (driverChildAction.FindElements(By.XPath(Unpublish)).Count >= 2)
                {
                    Click(UnpublishTemp);
                    PublishIcon = FindByXpath(Publish);
                }
                UnpublishIcon = FindByXpath(Unpublish);

            }
            else
            {
                UnpublishIcon = FindByXpath(Unpublish);
                Click(UnpublishIcon);
                UnpublishIcon = FindByXpath(Unpublish);
                PublishIcon = FindByXpath(Publish);
            }
            Thread.Sleep(5000);
        }

        public void ViewProfileInitialize()
        {
            Thread.Sleep(3000);
            IconAddProfile = FindByXpath("//*/div[contains(@class, 'modal fade show')]//button[contains(text(), 'Adicionar Perfil')]");
            FilterTypeProfile = FindByXpath("//*/div[contains(@class, 'modal fade show')]//select[contains(@id, 'listPrfs')]");
            IconRemoveProfile = FindByXpath("//*/div[contains(@class, 'modal fade show')]//img[contains(@src, 'trash.svg')]");
            IconCreateProfile = FindByXpath("//*/div[contains(@class, 'modal fade show')]//button[contains(text(), 'Cadastrar')]");
        }

        public void IconProfileInitialize()
        {
            string IconInactive = "//*/div[contains(@class, 'modal fade show')]//*/a[not(contains(@class, 'hide'))]/img[contains(@src, 'radio-button-on.svg')]";
            string IconActive = "//*/div[contains(@class, 'modal fade show')]//*/a[not(contains(@class, 'hide'))]/img[contains(@src, 'radio-button-off.svg')]";

            if ((driverChildAction.FindElements(By.XPath(IconActive)).Count != 0) || (driverChildAction.FindElements(By.XPath(IconInactive)).Count == 0))
            {
                Thread.Sleep(1000);
                IconActiveProfile = FindByXpath(IconActive);

                if (driverChildAction.FindElements(By.XPath(IconActive)).Count >= 2)
                {
                    Click(IconActiveProfile);
                    IconInativeProfile = FindByXpath(IconInactive);
                }
                IconInativeProfile = FindByXpath(IconInactive);
            }
            else
            {
                Click(IconInativeProfile);
                IconActiveProfile = FindByXpath(IconActive);
                IconInativeProfile = FindByXpath(IconInactive);
            }
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();
            Click(ButtonShowFilter);
            Click(FieldName);
            SendKeys(FieldName, "Teste");
            Click(ButtonFilter);
            SwitchFrameInitialize();
            ResultInitialize();
            Assert.IsTrue(driverAction.PageSource.Contains("Teste"));
        }


        public void FilterByClientName()
        {
            SwitchFrameInitialize();
            Initialize();

            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();
        }

        public void FilterByProfile()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            SelectByText(FieldListProfile, "Todos");
            ShowFilterInitialize();
        }

        public void FilterByObs()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SendKeys(FieldObs, "Teste3"+ Keys.Enter);
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.That(FieldResultObs.Text, Does.Contain("Teste3"));

        }

        public void FilterByStatus()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByText(FieldStatus, "Status");
            SwitchFrameInitialize();
            ResultInitialize();

        }

        public void FilterBySuites()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SelectByIndex(FieldSuites, 0);
            SwitchFrameInitialize();
            ResultInitialize();

        }



        public void FilterByDataStart()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SendKeys(FieldDataStart, "05122019");
            SwitchFrameInitialize();
            ResultInitialize();

            Assert.That(FieldResultDataStart.Text, Does.Contain("2019"));

        }

        public void FilterByDataEnd()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            SendKeys(FieldDataEnd, "20102020");
            Click(ButtonFilter);
            SwitchFrameInitialize();
            ResultInitialize();


            Assert.That(FieldResultDataEnd.Text, Does.Contain("2020"));

        }

        public void FilterByDataVoidResult()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconViewProfile);
            ViewProfileInitialize();
            Click(IconAddProfile);
            SelectByText(FilterTypeProfile, "Kroton | Testes Automatizados | Todos | Gerente");
            Click(IconConfirmEdit);

        }

        public void ViewSuiteReport()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconInitialize();
            Click(IconViewProfile);
            IconProfileInitialize();
            Click(IconInativeProfile);
            IsElementDisplayed(IconActiveProfile);

        }

        public void DeleteReport()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
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

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();

            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconPublishInitialize();
            Click(UnpublishIcon);

        }

        public void FilterByNameReport()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();
            Click(ButtonShowFilter);
            Click(ButtonFilter);
            SwitchFrameInitialize();
            IconPublishInitialize();
            Click(UnpublishIcon);

        }

        public void FilterByProfileReport()
        {
            SwitchFrameInitialize();

            Initialize();
            SelectByText(FieldClient, "Kroton");
            ShowFilterInitialize();
            SelectByText(FilterClientName, "Marisa");
            Click(ButtonShowFilter);
            Click(ButtonFilter);

        }

        public void PrepareCompile()
        {
            SwitchFrameInitialize();

            Initialize();

        }
        //Fim dos metodos temporários

    }
}
