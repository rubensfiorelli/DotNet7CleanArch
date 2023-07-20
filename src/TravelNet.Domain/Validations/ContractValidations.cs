using TravelNet.Domain.Notifications;
using TravelNet.Domain.Validations.Interfaces;

namespace TravelNet.Domain.Validations
{
    public partial class ContractValidations<T> where T : IContract
    {
        private List<Notification> _notifications;

        public ContractValidations()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool IsValid()
        {
            return _notifications.Any();
        }

    }
}
