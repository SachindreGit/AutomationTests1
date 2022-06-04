using Tests.UI.Automated.Domain;

namespace Tests.UI.Automated.ControlText
{
    public class ShopPageControlText:Bases.ControlText
    {
        public ShopPageControlText(PlatformType platformType, CultureInformation culture) : base(platformType, culture)
        {
            // No implementation
        }

        public string ItemBuyButton => "Buy";
        public string FunnyCowItemHeader => "Funny Cow";
        public string FluffyBunnyItemHeader => "Fluffy Bunny";
        public string StuffedFrogItemHeader => "Stuffed Frog";
        public string ValentineBearItemHeader => "Valentine Bear";

    }
}
