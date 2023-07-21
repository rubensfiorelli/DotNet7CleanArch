using TravelNet.Domain.Notifications;

namespace TravelNet.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> PassaporteIsOk(string passaporte, short maxlength, short minlength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(passaporte) || (passaporte.Length < minlength) || (passaporte.Length > maxlength))
                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
