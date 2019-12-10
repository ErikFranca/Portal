using OpenQA.Selenium;
using System.Threading;


namespace RobotPortal
{
    public class CtrlChildActionReports : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement ButtonFilter;
        public IWebElement FieldName;
        public IWebElement FieldObs;
        public IWebElement FieldStatus;
        public IWebElement FieldSuites;
        public IWebElement FieldDataStart;
        public IWebElement FieldDataEnd;
        public IWebElement FieldOrder;
        public IWebElement FieldResult;
        public IWebElement FilterFrame;

        public CtrlChildActionReports(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }
         public void Initialize()
        {
            ButtonFilter = FindById("btn_show");
            FieldName = FindById("nome_rel");
            FieldObs = FindById("obs");
            FieldStatus = FindByCss("#ctn > div:nth-child(5) > div > div:nth-child(3) > div > button > div > div > div");
            FieldSuites = FindByCss("#ctn > div:nth-child(5) > div > div:nth-child(4) > div > button > div > div > div");
            FieldDataStart = FindById("dataIni");
            FieldDataEnd = FindById("dataFim");
            FieldOrder = FindByCss("#ctn > div:nth-child(6) > div > div:nth-child(3) > div > button > div > div > div");
        }


        public void InitializeFilterBox()
        {
            FieldResult = FindByName("inf_86");
        }

        public void FilterByName()
        {
            Thread.Sleep(3000);
            //Initializes      
            Initialize();
            InitializeFilterBox();
            
            Click(ButtonFilter);
            Click(FieldName);
            SendKeys(FieldName, "Relatório de exemplo NETCORE ");
            AssertAreEqual("Relatório de exemplo NETCORE", FieldResult);
        }

        
        
        //Fim dos metodos temporários
        
    }
}
