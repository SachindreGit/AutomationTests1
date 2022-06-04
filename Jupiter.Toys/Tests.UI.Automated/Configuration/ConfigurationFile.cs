using System;
using System.Configuration;
using Tests.UI.Automated.Domain;

namespace Tests.UI.Automated.Configuration
{
    public class ConfigurationFile : IConfigurationFile
    {
        private static readonly AppSettingsReader AppSettingsReader = new AppSettingsReader();

        public TimeSpan ImplicitWaitTimeOut
        {
            get
            {
                var seconds = GetInt("ImplicitWaitTimeOutSecs");
                return TimeSpan.FromSeconds(seconds);
            }
        }
        public TimeSpan FluentWaitTimeOut
        {
            get
            {
                var seconds = GetInt("FluentWaitTimeOutSecs");
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan FluentWaitPollingInterval
        {
            get
            {
                var seconds = GetInt("FluentWaitPollingIntervalSecs");
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public BrowserType BrowserType
        {
            get
            {
                return GetBrowserType("BrowserType");
            }
        }        

        public Uri ApplicatinUrl
        {
            get
            {
                return GetUri("ApplicatinUrl");
            }
        }

        private static Uri GetUri(string key)
        {
            try
            {
                var value = GetString(key);
                return new Uri(value);
            }
            catch
            {
                var message = string.Format("Could not convert key {0} to type Uri", key);
                throw new ConfigurationErrorsException(message);
            }
        }

        private static int GetInt(string key)
        {
            try
            {
                var value = GetString(key);
                return int.Parse(value);
            }
            catch
            {
                var message = string.Format("Could not convert key {0} to type int", key);
                throw new ConfigurationErrorsException(message);
            }
        }

        private static string GetString(string key)
        {
            try
            {
                return (string)AppSettingsReader.GetValue(key, typeof(string));
            }
            catch
            {
                var message = string.Format("Could not read key {0}", key);
                throw new ConfigurationErrorsException(message);
            }
        }

        private static BrowserType GetBrowserType(string key)
        {
            try
            {
                var value = GetString(key);
                return (BrowserType)Enum.Parse(typeof(BrowserType), value);
            }
            catch
            {
                var message = string.Format("Could not convert key {0} to type BrowserType", key);
                throw new ConfigurationErrorsException(message);
            }
        }
    }
}
