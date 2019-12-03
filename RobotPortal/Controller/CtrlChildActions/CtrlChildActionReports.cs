using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RobotPortal
{
    class CtrlChildActionReports : CtrlActions
    {
        //Elementos
        [FindsBy(How = How.ClassName, Using = "name")]
        private IWebElement names;


    }
}
