using System.Text.RegularExpressions;
using TravelNet.Domain.Notifications;

namespace TravelNet.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> EmailIsValid(string email, string message, string propertyName)
        {

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
