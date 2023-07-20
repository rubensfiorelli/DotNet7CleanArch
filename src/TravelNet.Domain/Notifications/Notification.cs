using System.ComponentModel.DataAnnotations.Schema;
using TravelNet.Domain.Notifications.Interfaces;

namespace TravelNet.Domain.Notifications
{
    [NotMapped]
    public class Notification : INotification
    {

        public Notification(string message, string propertyName)
        {
            Message = message;
            PropertyName = propertyName;
        }

        public string Message { get; private set; }
        public string PropertyName { get; private set; }
    }
}
