using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    public interface IPromocodeService
    {
        Task<string> CancelPromocodeAsync(string id);
    }
}