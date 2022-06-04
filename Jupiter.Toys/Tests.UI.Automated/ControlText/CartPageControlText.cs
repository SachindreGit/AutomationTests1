
using Tests.UI.Automated.Domain;

namespace Tests.UI.Automated.ControlText
{
    public class CartPageControlText : Bases.ControlText
    {
        public CartPageControlText(PlatformType platformType, CultureInformation culture) : base(platformType, culture)
        {
            // No implementation
        }
        public string FunnyCowItemText => "Funny Cow";
        public string FluffyBunnyItemText => "Fluffy Bunny";
        public string StuffedFrogItemText => "Stuffed Frog";
        public string ValentineBearItemText => "Valentine Bear";
    }
}
