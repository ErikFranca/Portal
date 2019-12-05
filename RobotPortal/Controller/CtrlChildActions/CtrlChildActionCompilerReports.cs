using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace RobotPortal
{
    public class CtrlChildActionCompilerReports : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement TittleCompiler;
        public IWebElement FieldFilterID;
        public IWebElement FilterID;
        public IWebElement FieldTittle;
        public IWebElement FieldObs;
        public IWebElement FieldAnalist;
        public IWebElement FilterProfileType;
        public IWebElement ButtonGenerate;
        public IWebElement FieldManager;
        public IWebElement DoneMessage;
        public IWebElement OptManager;
        public IWebElement DropFilter;





        public CtrlChildActionCompilerReports(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            Thread.Sleep(3000);
            TittleCompiler = FindByCss("body > div > div.page-header > h3");
            FilterID = FindByCss("#user > div > form > div:nth-child(1) > div > div > button > div > div > div");
            FieldFilterID = FindByCss("#user > div > form > div:nth-child(1) > div > div > div > div.bs-searchbox > input");
            FieldTittle = FindById("titulo");
            FieldObs = FindById("obs");
            FieldAnalist = FindById("analyst");
            FilterProfileType = FindByCss("#user > div > form > div:nth-child(5) > div:nth-child(3) > div > button");
            ButtonGenerate = FindByCss("#user > div > form > div:nth-child(7) > div > button");
        }

        public void FilterTypeInitialize()
        {
            Thread.Sleep(5000);
            OptManager = FindByCss("#user > div > form > div:nth-child(5) > div:nth-child(3) > div > div.dropdown-menu.open > div.inner.open > ul > li:nth-child(2) > a");
            DropFilter = FindByCss("#user > div > form > div:nth-child(5) > div:nth-child(3) > div > div.dropdown-backdrop");
        }

        public void MessageInitialize()
        {
            Thread.Sleep(5000);
            DoneMessage = FindByCss("#results > h5:nth-child(1)");
        }


        public void CompileSimpleReport()
        {
            //SwitchFrame("iframe_opt");
            Initialize();

            AssertAreEqual("Compilação de Relatórios", TittleCompiler);
            Click(FilterID);
            SendKeys(FieldFilterID, "47" + Keys.Enter);
            Click(FilterProfileType);
            FilterTypeInitialize();
            Click(OptManager);
            Click(DropFilter);
            Click(ButtonGenerate);
            MessageInitialize();
            
        }
    }
}
