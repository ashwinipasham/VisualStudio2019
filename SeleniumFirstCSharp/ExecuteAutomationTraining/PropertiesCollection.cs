using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExecuteAutomationTraining
{
    //Auto-implemented property

    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CSSName,
        ClassName,
    }

    class PropertiesCollection
    {

        public static IWebDriver driver { get; set; }

    }
}
