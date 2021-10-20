using Demo.AspNetCore.ServerSentEvents.Model;
using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
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

        public async Task CancelPromocodeAsync(string id, string requestId)
        {
            await Task.Delay(5000);
            
            var result = new SseResponseModel
            {
                RequestId = requestId,
                Message = $"Protocol {id} is cancelled."
            };

            try
            {
                await _notificationsService.SendNotificationAsync(JsonSerializer.Serialize(result), false);
                Debug.WriteLine("----------------- Notification has been sent successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}. {ex.StackTrace}.");
            }
        }
    }
}
