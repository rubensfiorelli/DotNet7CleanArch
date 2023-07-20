using TravelNet.Domain.Notifications;

namespace TravelNet.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> NomeIsOk(string nome, short maxlength, short minlength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(nome) || (nome.Length < minlength) || (nome.Length > maxlength))
                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
