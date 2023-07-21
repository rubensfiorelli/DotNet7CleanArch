using TravelNet.Domain.Notifications;

namespace TravelNet.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> WhatsAppIsOk(string whatsApp, short maxlength, short minlength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(whatsApp) || (whatsApp.Length < minlength) || (whatsApp.Length > maxlength))
                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
