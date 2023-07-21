using TravelNet.Domain.Notifications;

namespace TravelNet.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> SobrenomeIsOk(string sobrenome, short maxlength, short minlength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(sobrenome) || (sobrenome.Length < minlength) || (sobrenome.Length > maxlength))
                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
