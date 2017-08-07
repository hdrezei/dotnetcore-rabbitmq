using nyom.domain.core.Models;

namespace nyom.domain.Crm.Notifications
{
    public class NotificationService : ServiceBaseCrm<Notification> ,INotificationService
    {
	    private readonly INotificationRepository _notificationRepository;

	    public NotificationService(INotificationRepository notificationRepository) : base(notificationRepository)
	    {
		    _notificationRepository = notificationRepository;
	    }
    }
}
