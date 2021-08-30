using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Adapter.BusinessLogic
{
    public class BitcoinEvent
    {
        private readonly IUserNotificationService userNF;

        public BitcoinEvent(IUserNotificationService userNF)
        {
            this.userNF = userNF;
        }

        public Task Execute()
        {
            // other work here
            return userNF.NotifyUser("", "");
        }
    }
}
