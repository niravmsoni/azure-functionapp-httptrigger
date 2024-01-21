using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HttpTrigger
{
    public interface IMyService
    {
        Task<string> GetMessage(HttpRequest req);
    }
}