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

        public CtrlCtrlPortalActions(IWebDriver driver) : base(driver)
        {
            driverPortalAction = driver;
        }



    }
}
