using Adapter.BusinessLogic;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Adapter
{
    //Class adapter - inherits the generic thing (it becomes that thing).
    //Inheritance means structure (when inheriting, many methods might need to
    //be implemented - lot of customization within the class adapter).
    public class ClassAdapter : SendGridClient, IUserNotificationService
    {
        public ClassAdapter(SendGridClientOptions options) : base(options)
        {
        }

        public Task NotifyUser(string userId, string message)
        {
            return SendEmailAsync(new SendGridMessage());
        }
    }
}
