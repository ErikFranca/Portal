using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System;
using OpenQA.Selenium.Support.UI;

namespace RobotPortal
{
    public class CtrlChildActionCompilerReports : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement TittleCompiler;
        public IWebElement FieldFilterID;
        public IWebElement FilterClient;
        public IWebElement FilterID;
        public IWebElement FieldTittle;
        public IWebElement FieldObs;
        public IWebElement FieldAnalist;
        public IWebElement FilterProfileType;
        public IWebElement ButtonGenerate;
        public IWebElement FieldManager;
        public IWebElement DoneMessage;
        public IWebElement ProfilePicker;
        public IWebElement ProfileFilter;
        public IWebElement ResultCompile;
        public IWebElement FilterIdClient;





        public CtrlChildActionCompilerReports(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            Thread.Sleep(3000);
            TittleCompiler = FindByXpath("//h3[contains(text(), 'Compilação de Relatórios')]");
            FilterIdClient = FindByXpath("//select[contains(@id, 'cst_id')]");
            FilterID = FindByXpath("//select[contains(@id, 'report_id')]");
            FieldTittle = FindByXpath("//input[contains(@id, 'titulo')]");
            FieldObs = FindByXpath("//input[contains(@id, 'obs')]");
            FieldAnalist = FindByXpath("//input[contains(@id, 'analyst')]");
            FilterProfileType = FindByCss("#user > div > form > div:nth-child(5) > div:nth-child(3) > div > button");
            ButtonGenerate = FindByCss("#user > div > form > div:nth-child(7) > div > button");
        }

        public void PrepareInitialize()
        {
            Thread.Sleep(3000);
            TittleCompiler = FindByXpath("//h3[contains(text(), 'Compilação de Relatórios')]");
            FilterID = FindByXpath("//select[contains(@id, 'report_id')]");
            FieldTittle = FindByXpath("//input[contains(@id, 'titulo')]");
            FieldObs = FindByXpath("//input[contains(@id, 'obs')]");
            FieldAnalist = FindByXpath("//input[contains(@id, 'analyst')]");
            ButtonGenerate = FindByXpath("//button[contains(text(), 'Gerar')]");
            ResultCompile = FindByXpath("//h5[contains(text(), '[Done]')]");
        }

        public void FilterTypeInitialize()
        {
            Thread.Sleep(3000);
            ProfilePicker = FindByXpath("//*/select[contains(@id, 'perfil')]");
            ProfileFilter = FindByXpath("//*/select[contains(@id, 'list-type')]");            
        }

        public void MessageInitialize()
        {
            Thread.Sleep(5000);
            DoneMessage = FindById("results");
        }


        public void CompileSimpleReport()
        {
            SwitchFrame("iframe_opt");
            Initialize();

            AssertAreEqual("Compilação de Relatórios", TittleCompiler);
            SelectByText(FilterIdClient, "Kroton");
            SelectByIndex(FilterID, 1);
            Click(FilterProfileType);
            FilterTypeInitialize();
            Click(ButtonGenerate);
            MessageInitialize();
            
        }

        public void CompilePrepareReport()
        {
            SwitchFrame("iframe_opt");
            Initialize();

            
            for (int i = 0; i < 5; i++)
            {
                AssertAreEqual("Compilação de Relatórios", TittleCompiler);
                SelectByText(FilterIdClient, "Kroton");
                SelectByIndex(FilterID, i);
                SendKeys(FieldTittle, "Teste");
                SendKeys(FieldObs, "Teste" + i);
                SendKeys(FieldAnalist, "Teste");
                FilterTypeInitialize();
                SelectByText(ProfilePicker, "Teste");
                SelectByText(ProfileFilter, "Gerente");
                Click(ButtonGenerate);
                MessageInitialize();
            }
            
        }

        public void CompileReportAddProfile()
        {
            SwitchFrame("iframe_opt");
            Initialize();

            AssertAreEqual("Compilação de Relatórios", TittleCompiler);
            SelectByText(FilterIdClient, "Kroton");
            SelectByIndex(FilterID, 1);
            Click(FilterProfileType);
            FilterTypeInitialize();
            SelectByText(ProfileFilter, "Gerente");
            SelectByText(ProfileFilter, "Analista");
            Click(ButtonGenerate);
            MessageInitialize();

        }

        public void CompileReportMakeChanges()
        {
            SwitchFrame("iframe_opt");
            Initialize();

            AssertAreEqual("Compilação de Relatórios", TittleCompiler);
            SelectByText(FilterIdClient, "Kroton");
            SelectByIndex(FilterID, 1); 
            Click(FilterProfileType);
            FilterTypeInitialize();
            SelectByText(ProfileFilter, "Gerente");
            SendKeys(FieldObs, "Teste");
            Click(ButtonGenerate);
            MessageInitialize();

        }

        public void PrepareCompileReports()
        {
            PrepareInitialize();
            IsElementDisplayed(ResultCompile);

            for (int i = 0; i <= 4; i++)
            {
                SelectByText(FilterClient, "Kroton");
                SelectByText(FilterID, "1");

            }
        }

    }
}
