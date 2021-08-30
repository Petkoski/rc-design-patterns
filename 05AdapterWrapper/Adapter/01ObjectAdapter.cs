//Adapter/Wrapper design pattern - take some kind of dependency (that might change in the future)
//and wrap it in your own logic to make it fit in your use case.
//Adapt generic dependency in your solution.

using Adapter.BusinessLogic;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Adapter
{
    //Object adapter - takes the adaptee (that generic thing) in the constructor.
    //Composition means flexibility (better approach than class adapter).
    public class ObjectAdapter : IUserNotificationService
    {
        //3rd party dependency (SendGridClient from SendGrid.dll):
        //Doesn't need to be 3rd party, it might be something from System namespace.
        private readonly SendGridClient client;

        public ObjectAdapter(SendGridClient client)
        {
            this.client = client;
        }

        public Task NotifyUser(string userId, string message)
        {
            return client.SendEmailAsync(new SendGridMessage());
        }
    }
}
