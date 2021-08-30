using System.Threading.Tasks;

namespace Adapter.BusinessLogic
{
    public interface IUserNotificationService
    {
        Task NotifyUser(string userId, string message);
    }
}
