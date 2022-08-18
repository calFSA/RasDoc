using RasDoc.Domain.Notifications;

namespace RasDoc.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotifications();
        IList<Notification> GetNotifations();
        void Handle(Notification notification);
    }
}