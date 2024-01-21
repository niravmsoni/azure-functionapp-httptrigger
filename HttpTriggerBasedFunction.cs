using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HttpTrigger
{
    public class HttpTriggerBasedFunction
    {
        private readonly IMyService _service;

        public HttpTriggerBasedFunction(IMyService service)
        {
            _service = service;
        }

        [FunctionName(nameof(HttpTriggerBasedFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var responseMessage = await _service.GetMessage(req);
            return new OkObjectResult(responseMessage);
        }
    }
}
