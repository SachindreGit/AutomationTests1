using System.Globalization;
using System.Threading;
using Tests.UI.Automated.Domain;

namespace Tests.UI.Automated.ControlText.Bases
{
    public class ControlText
    {
        protected PlatformType PlatformType { get; private set; }
        public ControlText(PlatformType platformType, CultureInformation culture) 
        {
            PlatformType = platformType;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.CultureName);
        }
    }
}
