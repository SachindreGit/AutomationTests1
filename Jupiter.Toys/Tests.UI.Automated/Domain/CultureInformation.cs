namespace Tests.UI.Automated.Domain
{
    public class CultureInformation
    {
        public CultureInformation(CultureType cultureType, string cultureName)
        {
            CultureType = cultureType;
            CultureName = cultureName;
        }

        public CultureType CultureType { get; private set; }
        public string CultureName { get; private set; }
    }
}
