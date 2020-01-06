using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;


namespace RobotPortal
{
    public class CtrlChildActionPermissionsReport : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;

        public IWebElement TableReport;
        public IWebElement ViewReport;
        public IWebElement EditReport;
        public IWebElement FieldObs;
        public IWebElement SaveEdit;
        public IWebElement Unpublish;
        public IWebElement Publish;
        public IWebElement ClientFilter;
        public IWebElement ViewProfile;
        public IWebElement IconAddProfile;
        public IWebElement TypeProfileFilter;
        public IWebElement ButtonConfirm;
        public IWebElement DeleteProfileReport;
        public IWebElement DeleteReport;
        public IWebElement DeletePublish;



        public CtrlChildActionPermissionsReport(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        public void Initialize()
        {
            TableReport = FindByXpath("//*[@id='iframe_opt']");
        }

        public void TableInitialize()
        {
            Thread.Sleep(3000);
            //Declaração de elementos
            ViewReport = FindByName("eye");
            EditReport = FindByName("create");
            FieldObs = FindByXpath("/html/body/div/div/form/table/tbody/tr/th[2]/div/input[contains(@type, 'text')]");
            SaveEdit = FindByName("bookmark");
            Unpublish = FindByName("radio-button-on");
            Publish = FindByName("radio-button-off");
            ViewProfile = FindByName("person");
            IconAddProfile = FindByXpath("//*[@type='button'][contains(@class,'btn btn-outline-secondary float-right btn-lg')]");
            TypeProfileFilter = FindByXpath("//*[@class='selectpicker'][contains(@title,'Perfil')]");
            ButtonConfirm = FindByXpath("//*[@type='button'][contains(@class,'btn btn-outline-success float-right btn-lg')]");
            DeleteProfileReport = FindByXpath("/html/body/div[1]/div/div[1]/div/div/div[2]/div/div/div/div/table/tbody/tr/td[6]/a[3]/ion-icon");
            DeleteReport = FindByName("close");
            DeletePublish = FindByName("trash");
        }

        public void CompileInitialize()
        {
            //Declaração de elementos
            ClientFilter = FindById("cst_id");
        }

        public void SwitchFrameInitialize()
        {
            ////Declaração de elementos da troca de frame
            Thread.Sleep(3000);
            SwitchFrame("iframe_opt");
        }

        public void PermissionViewReport()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada dos elementos
            Initialize();

            //Verifica se o elemento está presente na tela
            IsElementDisplayed(TableReport);
        }

        public void PermissionDetailsReport()
        {
            //Troca de frame
            SwitchFrameInitialize();

            //Chamada dos elementos iniciais da tela
            Initialize();

            //Verifica se o elemento está presenta na tela
            IsElementDisplayed(TableReport);

            //Troca de frame
            SwitchFrameInitialize();

            //Declaração de novos elementos na tela
            TableInitialize();
            
            //Click e troca de tela para a nova aba
            Click(ViewReport);
            SwitchTab();
        }

        public void PermissionEditReport()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada dos elementos iniciais da tela
            Initialize();

            //Verifica se o elemento
            IsElementDisplayed(TableReport);
            
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de novos elementos da tela
            TableInitialize();
            
            //Edit as informações e Salva
            Click(EditReport);
            SendKeys(FieldObs, "Teste1");
            Click(SaveEdit);
        }

        public void PermissionUnpublishReport()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos iniciais da tela
            Initialize();

            //Verifica se o elemento está presente na tela
            IsElementDisplayed(TableReport);
            
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos novos na tela
            TableInitialize();
            
            //Clica no botão de despublicar
            Click(Unpublish);
        }

        public void PermissionPublishReport()
        {
            //Troca de frame    
            SwitchFrameInitialize();
            
            //Chamada dos elementos iniciais da tela
            Initialize();
            
            //Verifica se o elemento está presente na tela
            IsElementDisplayed(TableReport);
            
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de novos elementos na tela
            TableInitialize();
            
            //Clica no botão de publicar relatório
            Click(Publish);
        }

        public void PermissionDeViewProfileReport()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos na tela
            Initialize();

            //Verifica se o elemento está presente na tela
            IsElementDisplayed(TableReport);
            
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de novos elementos na tela
            TableInitialize();

            //Abre a aba de perfis de relatório
            Click(ViewProfile);
            IsElementDisplayed(IconAddProfile);

        }

        public void PermissionAddProfileReport()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos da tela
            Initialize();

            //Verifica se o elemento está presente na tela
            IsElementDisplayed(TableReport);

            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de novos elementos da tela
            TableInitialize();
            
            //Adiciona um novo perfil de relatório
            Click(ViewProfile);
            IsElementDisplayed(IconAddProfile);
            Click(IconAddProfile);
            SelectByText(TypeProfileFilter, "Kroton | Testes Automatizados | Teste relatórios | Administrador");
            Click(ButtonConfirm);

        }

        public void PermissionDeleteProfileReport()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos 
            Initialize();

            //Verifica se o elemento está presente na tela
            IsElementDisplayed(TableReport);
            
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de novos elementos da tela
            TableInitialize();
            
            //Delete um perfil de relatório
            Click(ViewProfile);
            IsElementDisplayed(IconAddProfile);
            Click(DeleteProfileReport);
            AcceptAlert();

        }

        public void PermissionDeleteReport()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de elementos da tela
            Initialize();

            //Verifica se o elemento está presenta na tela
            IsElementDisplayed(TableReport);

            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de novos frames da tela
            TableInitialize();

            //Delete um relatório
            Click(DeleteReport);
            AcceptAlert();
        }

        public void PermissionDeletePublishReport()
        {
            //Troca de frame
            SwitchFrameInitialize();
            
            //Chama de elementos iniciais da tela
            Initialize();
            
            //Verifica se o elemento está presente na tela
            IsElementDisplayed(TableReport);

            //Troca de frame
            SwitchFrameInitialize();
            
            //Chamada de novos elementos da tela
            TableInitialize();

            //Deletar uma publicação
            Click(DeletePublish);
            AcceptAlert();

        }

    }
}
