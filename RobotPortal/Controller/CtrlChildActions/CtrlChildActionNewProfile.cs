﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace RobotPortal
{
    public class CtrlChildActionNewProfile : CtrlDriverActions
    {
        public static IWebDriver driverChildAction;
        public IWebElement FieldLogin;
        public IWebElement FieldPassword;
        public IWebElement ButtonEnter;
        public CtrlChildActionNewProfile(IWebDriver driver) : base(driver)
        {
            driverChildAction = driver;
        }

        
    }
}
