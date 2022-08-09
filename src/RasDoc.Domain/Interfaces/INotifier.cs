using RasDoc.Domain.Notifications;

namespace RasDoc.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifations();
        void Handle(Notification notificacao);
    }
}