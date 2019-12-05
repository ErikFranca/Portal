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

        public CtrlCtrlPortalActions(IWebDriver driver) : base(driver)
        {
            driverPortalAction = driver;
        }

        public void Initialize()
        {
            ArrowMenu = FindByCss("#open-nav > a");
            ReportMenu = FindByCss("#navBar-lateral > li:nth-child(3) > a");
            ReportConsultMenu = FindByCss("#submenu-report > li:nth-child(1) > a");
            ReportCompileMenu = FindByCss("#submenu-report > li:nth-child(2) > a");
        }

        public void AcessMenuReport()
        {
            Thread.Sleep(3000);
            Initialize();

            
            Click(ArrowMenu);
            Click(ReportMenu);
            Click(ReportConsultMenu);
        }

        public void AcessMenuCompile()
        {
            Thread.Sleep(3000);
            Initialize();


            Click(ArrowMenu);
            Click(ReportMenu);
            Click(ReportCompileMenu);
        }

    }
}
