using Tests.UI.Automated.Domain;

namespace Tests.UI.Automated.ControlText
{
    // TODO: text content should be retrieved by resource files, so it can be tested with any culture.
    public class ContactPageControlText : Bases.ControlText
    {
        public ContactPageControlText(PlatformType platformType, CultureInformation culture) : base(platformType, culture) 
        { 
            // No implementation
        }

        public string ForenameRequiredErrorMessage => "Forename is required";
        public string EmailRequiredErrorMessage => "Email is required";
        public string MessageRequiredErrorMessage => "Message is required";
        public string SuccessfullySubmittedMessage => "Thanks {0}, we appreciate your feedback.";
    }
}
