using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Net;
using System.Text;

namespace RobotPortal
{
    public class CtrlCtrlPortalActions : CtrlDriverActions
    {
        public static IWebDriver driverPortalAction;
        public IWebElement ArrowMenu;
        public IWebElement ReportMenu;
        public IWebElement ReportConsultMenu;
        public IWebElement ReportCompileMenu;
        public IWebElement ButtonAllClients;
        public IWebElement ButtonAllTeams;
        public IWebElement ButtonMarisaClient;
        public IWebElement UserMenu;
        public IWebElement UserConsultMenu;
        public IWebElement ArrowCloseMenu;
        public IWebElement UserRegisterMenu;
        public IWebElement ProfileMenu;
        public IWebElement ProfileConsultMenu;
        public IWebElement ProfileRegisterMenu;
        public IWebElement QuitTab;
        public IWebElement Quit;


        public CtrlCtrlPortalActions(IWebDriver driver) : base(driver)
        {
            driverPortalAction = driver;
        }

        public void Initialize()
        {
            Thread.Sleep(3000);

            ArrowCloseMenu = FindById("close-nav");
            ArrowMenu = FindByCss("#open-nav > a");
            ReportMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/a/b[contains(text(),'Relatórios ')]");
            ReportConsultMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'reports')]");
            ReportCompileMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'create_report')]");
            UserMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/a/b[contains(text(),'Usuários ')]");
            UserConsultMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'users')]");
            UserRegisterMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'create_user')]");
            ProfileMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/a/b[contains(text(),'Perfis ')]");
            ProfileConsultMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'profiles')]");
            ProfileRegisterMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'create_profile')]");
        }

        public void InitializePermissionReport()
        {
            Thread.Sleep(3000);

            ArrowCloseMenu = FindById("close-nav");
            ArrowMenu = FindByCss("#open-nav > a");
            ReportMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/a/b[contains(text(),'Relatórios ')]");
            ReportConsultMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'reports')]");
            ReportCompileMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'create_report')]");
        }

        public void InitializePermissionUser()
        {
            Thread.Sleep(3000);

            ArrowCloseMenu = FindById("close-nav");
            ArrowMenu = FindByCss("#open-nav > a");
            UserMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/a/b[contains(text(),'Usuários ')]");
            UserConsultMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'users')]");
            UserRegisterMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'create_user')]");
        }

        public void InitializePermissionProfile()
        {
            Thread.Sleep(3000);

            ArrowCloseMenu = FindById("close-nav");
            ArrowMenu = FindByCss("#open-nav");
            ProfileMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/a/b[contains(text(),'Perfis ')]");
            ProfileConsultMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'profiles')]");
            ProfileRegisterMenu = FindByXpath("/html/body/main/div/nav/div/ul/li/ul/li/a[contains(@href,'create_profile')]");
        }

        public void SelectClientInitialize()
        {
            Thread.Sleep(3000);
            ButtonAllClients = FindByCss("body > div > div > div:nth-child(2) > div > a > img");
            ButtonMarisaClient = FindByXpath("//*[@class='card-img '][contains(@src,'marisa.png')]");
        }

        public void QuitInitialize()
        {
            QuitTab = FindByXpath("//*/li[4][contains(@class, 'dropdown')]");
            Quit = FindByXpath("//a[contains(@href, 'disconnect.php')]");
        }

        public void SelectTeamInitialize()
        {
            Thread.Sleep(3000);
            ButtonAllTeams = FindByCss("body > div > div > div:nth-child(2) > div > a > img");
        }

        public void Logout()
        {
            driverAction.SwitchTo().ParentFrame();
            QuitInitialize();
            Click(QuitTab);
            Click(Quit);
        }

        public void AcessMenuReport()
        {
            Initialize();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ReportMenu);
            Click(ReportConsultMenu);
        }

        public void MenuReportFromHome()
        {
            Initialize();

            Click(ReportMenu);
            Click(ReportConsultMenu);
        }

        public void AcessMenuCompile()
        {
            Initialize();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ReportMenu);
            Click(ReportCompileMenu);
        }

        public void ChooseAllClients()
        {
            SwitchFrame("iframe_opt");
            SelectClientInitialize();
            Click(ButtonAllClients);
        }

        public void ChooseMarisaClient()
        {
            SwitchFrame("iframe_opt");
            SelectClientInitialize();
            Click(ButtonAllClients);
        }

        public void ChooseTeam()
        {
            SelectTeamInitialize();
            Click(ButtonAllTeams);

        }

        public void AcessMenuConsultUsers()
        {
            
            Initialize();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(UserMenu);
            Click(UserConsultMenu);
        }
        public void PermissionAcessMenuConsultUsers()
        {
            InitializePermissionUser();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(UserMenu);
            Click(UserConsultMenu);
        }

        public void PermissionAcessMenuRegisterUsers()
        {
            InitializePermissionUser();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(UserMenu);
            Click(UserRegisterMenu);
        }

        public void AcessMenuNewUsers()
        {
            Initialize();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(UserMenu);
            Click(UserRegisterMenu);
        }

        public void AcessMenuProfileConsult()
        {
            Initialize();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ProfileMenu);
            Click(ProfileConsultMenu);
        }

        public void AcessMenuProfileRegister()
        {
            Initialize();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ProfileMenu);
            Click(ProfileRegisterMenu);
        }

        public void PermissionAcessMenuProfileConsult()
        {
            InitializePermissionProfile();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ProfileMenu);
            Click(ProfileConsultMenu);
        }

        public void PermissionAcessMenuProfileRegister()
        {
            InitializePermissionProfile();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ProfileMenu);
            Click(ProfileRegisterMenu);
        }

        public void PermissionAcessMenuConsultReport()
        {
            InitializePermissionReport();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ReportMenu);
            Click(ReportConsultMenu);
        }

        public void PermissionAcessMenuCompileReport()
        {
            InitializePermissionReport();

            if (!ArrowCloseMenu.Displayed)
            {
                Click(ArrowMenu);
            }
            Click(ReportMenu);
            Click(ReportCompileMenu);
        }

    }
}
