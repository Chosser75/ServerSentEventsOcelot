using System;
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
            var message = $"Protocol {id} is cancelled.";
            try
            {
                await _notificationsService.SendNotificationAsync(message, false);
            }
            catch (Exception ex)
            {
                message = $"Failed to cancel promocode {id}.";
            }
            return message;
        }
    }
}
