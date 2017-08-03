using nyom.domain.Nyom.Notifications;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class NotificationRepository : RepositoryBase<Notification>,INotificationRepository
    {
	    public NotificationRepository(NyomContext context) : base(context)
	    {
	    }
    }
}
