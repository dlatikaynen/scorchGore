#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, ExecutionContext executionContext)
{    
    var responseMessage = string.Empty;
    var verbCommand = req.Query["v"].ToString().ToLowerInvariant();
    switch(verbCommand)
    {
        case "helo":
            var uniqueUserId = req.Query["u"].ToString();
            var levelParameter=req.Query["lp"].ToString();
            if(!string.IsNullOrWhiteSpace(uniqueUserId) && Guid.TryParse(uniqueUserId, out Guid gUniqueUserId))
            {
                responseMessage = ProcessVerbHelo(executionContext, log, gUniqueUserId, levelParameter);
            }

            break;
    }

    return new OkObjectResult(responseMessage);
}

private static string StorePath(ExecutionContext executionContext)
{
    var functionDirectory = executionContext.FunctionDirectory;
    return new DirectoryInfo(functionDirectory).Parent.FullName;
}

private static string ProcessVerbHelo(ExecutionContext executionContext, ILogger log, Guid uniqueUserID, string levelParameter)
{
    /* is there any waiting semaphore? then join (except my own) */
    var sUniqueUserId = uniqueUserID.ToString("N").ToLowerInvariant();
    log.LogInformation($"uid={ sUniqueUserId }");
    var storePath = StorePath(executionContext);
    log.LogInformation($"storePath={storePath}");
    if(File.Exists(Path.Combine(storePath, $"{ sUniqueUserId }.scorchgore.waitsema")))
    {
        return "waiting";
    }
    else if(File.Exists(Path.Combine(storePath, $"{ sUniqueUserId }.scorchgore.session")))
    {
        return "allured";
    }

    var waitSemaphores = Directory.GetFiles(storePath,"*.scorchgore.waitsema");
    var joinableSemaphore = waitSemaphores.FirstOrDefault();
    if(joinableSemaphore == null)
    {
        /* is there none, then create one.
         * initiating user id is the handle. */
        File.WriteAllText(Path.Combine(storePath, $@"{ sUniqueUserId }.scorchgore.waitsema"), levelParameter);
        return $"heloed";
    }
    else
    {
        /* join the one where the other player-to-become is waiting */
        var waitFileName = Path.GetFileName(joinableSemaphore);
        var sPartnerId = Guid.Parse(waitFileName.Split('.')[0]).ToString("N").ToLowerInvariant();
        var sessionFile = Path.Combine(storePath, $"{ sPartnerId }.scorchgore.session");
        File.Move(joinableSemaphore, sessionFile);
        levelParameter=File.ReadAllText(sessionFile);
        return $"joined,{ sPartnerId },{ levelParameter }";
    }
}
