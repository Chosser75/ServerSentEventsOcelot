using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    public class PromocodeService : IPromocodeService
    {
        private readonly INotificationsService _notificationsService;

        public PromocodeService(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        public async Task<string> CancelPromocodeAsync(string id)
        {
            await Task.Delay(5000);
            var message = $"Protocol {id} is cancelled. Notification sent to client(s): {_notificationsService.GetClientsDetails()}";
            try
            {
                await _notificationsService.SendNotificationAsync(message, false);
                Debug.WriteLine("Notification has been sent successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}. {ex.StackTrace}.");
            }
            
            return message;
        }
    }
}
