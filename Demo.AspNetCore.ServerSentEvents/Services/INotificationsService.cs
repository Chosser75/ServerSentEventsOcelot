using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    public interface INotificationsService
    {
        Task SendNotificationAsync(string notification, bool alert);
        List<string> GetClientsDetails();
    }
}
