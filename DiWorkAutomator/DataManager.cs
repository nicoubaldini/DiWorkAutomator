using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;

namespace DiWorkAutomator
{
    internal class DataManager
    {
        public string GetApiKey()
        {
            return ConfigurationManager.AppSettings["apikey"];
        }

        public string GetEndpointWorkItem()
        {
            return ConfigurationManager.AppSettings["endpointworkitem"];
        }

        public string GetUrlParent()
        {
            return ConfigurationManager.AppSettings["urlparent"];
        }
    }
}
