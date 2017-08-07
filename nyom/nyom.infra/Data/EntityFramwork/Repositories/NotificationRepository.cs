using nyom.domain.Crm.Notifications;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class NotificationRepository : RepositoryBaseCrm<Notification>,INotificationRepository
    {
	    public NotificationRepository(CrmContext context) : base(context)
	    {
	    }
    }
}
