using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Demo.Hasura.AzureFunctions;

public class HasuraDemoAction
{
    private readonly ILogger<HasuraDemoAction> logger;

    public HasuraDemoAction(
        ILogger<HasuraDemoAction> logger
    )
    {
        this.logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
    }

    [FunctionName("hasura-demo-action")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest request)
    {
        var jsonBody = await request.ReadAsStringAsync();

        var hasuraPayload = JsonConvert
            .DeserializeObject<HasuraActionPayload<HasuraDemoRequest>>(jsonBody);

        logger.LogInformation(
            $"{hasuraPayload.Input.Input.Username}: " +
            $"{hasuraPayload.Input.Input.Message}"
        );

        return new OkObjectResult(new Result(true, ""));
    }
}

internal record HasuraDemoRequest(HasuraDemoInput Input);

internal record HasuraDemoInput(string Username, string Message);

internal record Result(bool Success, string Message);