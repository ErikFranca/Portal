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


        public CtrlCtrlPortalActions(IWebDriver driver) : base(driver)
        {
            driverPortalAction = driver;
        }

        public void Initialize()
        {
            Thread.Sleep(3000);

            ArrowCloseMenu = FindById("close-nav");
            ArrowMenu = FindByCss("#open-nav > a");
            ReportMenu = FindByCss("#navBar-lateral > li:nth-child(3) > a");
            ReportConsultMenu = FindByCss("#submenu-report > li:nth-child(1) > a");
            ReportCompileMenu = FindByCss("#submenu-report > li:nth-child(2) > a");
            UserMenu = FindByCss("#navBar-lateral > li:nth-child(1) > a > b");
            UserConsultMenu = FindByCss("#submenu-user > li:nth-child(1) > a");
            UserRegisterMenu = FindByCss("#submenu-user > li:nth-child(2) > a");
            ProfileMenu = FindByCss("#navBar-lateral > li:nth-child(2) > a");
            ProfileConsultMenu = FindByCss("#submenu-profile > li:nth-child(1) > a:nth-child(1)");
            ProfileRegisterMenu = FindByCss("#submenu-profile > li:nth-child(2) > a:nth-child(1)");
        }

        public void SelectClientInitialize()
        {
            Thread.Sleep(3000);
            ButtonAllClients = FindByCss("body > div > div > div:nth-child(2) > div > a > img");
            ButtonMarisaClient = FindByXpath("//*[@class='card-img '][contains(@src,'marisa.png')]");
        }

        public void SelectTeamInitialize()
        {
            Thread.Sleep(3000);
            ButtonAllTeams = FindByCss("body > div > div > div:nth-child(2) > div > a > img");
        }

        public void AcessMenuReport()
        {
            Initialize();

            
            Click(ArrowMenu);
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

    }
}
