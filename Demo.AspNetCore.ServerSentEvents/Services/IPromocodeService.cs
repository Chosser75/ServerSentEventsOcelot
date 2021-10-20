using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    public interface IPromocodeService
    {
        Task CancelPromocodeAsync(string id, string requestId);
    }
}