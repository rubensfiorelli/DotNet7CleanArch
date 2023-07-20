using TravelNet.Domain.Notifications;

namespace TravelNet.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> GuidIsValid(object guid, string message, string propertyName)
        {
            if (guid is not Guid)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}