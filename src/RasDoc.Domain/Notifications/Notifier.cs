using RasDoc.Domain.Interfaces;

namespace RasDoc.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private readonly IList<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public IList<Notification> GetNotifations()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}