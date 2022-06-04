using System;
using Tests.UI.Automated.Domain;

namespace Tests.UI.Automated.Configuration
{
    public interface IConfigurationFile
    {
        TimeSpan ImplicitWaitTimeOut { get; }
        TimeSpan FluentWaitTimeOut { get; }
        TimeSpan FluentWaitPollingInterval { get; }
        BrowserType BrowserType { get; }
        Uri ApplicatinUrl { get; }
    }
}
