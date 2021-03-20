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
            if(!string.IsNullOrWhiteSpace(uniqueUserId) && Guid.TryParse(uniqueUserId, out Guid gUniqueUserId))
            {
                responseMessage = ProcessVerbHelo(executionContext, gUniqueUserId);
            }
            break;


    }

    return new OkObjectResult(responseMessage);
}

private static string StorePath(ExecutionContext executionContext)
{
    var functionDirectory = executionContext.FunctionDirectory;
    return Directory.GetParent(functionDirectory).Name;
}

private static string ProcessVerbHelo(ExecutionContext executionContext, Guid uniqueUserID)
{
    /* is there any waiting semaphore? then join (except my own) */
    var sUniqueUserId = uniqueUserID.ToString("N").ToLowerInvariant();
    var storePath = StorePath(executionContext);
    if(File.Exists(Path.Combine(storePath, $"{ sUniqueUserId }.scorchgore.waitsema")))
    {
        return "waiting";
    }
    else if(File.Exists(Path.Combine(storePath, $"{ sUniqueUserId }.scorchgore.session")))
    {
        return "joined";
    }

    var waitSemaphores = Directory.GetFiles(storePath,"*.scorchgore.waitsema");
    var joinableSemaphore = waitSemaphores.FirstOrDefault();
    if(joinableSemaphore == null)
    {
        /* is there none, then create one.
         * initiating user id is the handle. */
        File.WriteAllText(Path.Combine(storePath, $@"{ sUniqueUserId }.scorchgore.waitsema"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        return $"heloed";
    }
    else
    {
        /* join the one where the other player-to-become is waiting */
        var waitFileName = Path.GetFileName(joinableSemaphore);
        var sPartnerId = Guid.Parse(waitFileName.Split('.')[0]).ToString("N").ToLowerInvariant();
        File.Move(joinableSemaphore, Path.Combine(storePath, $"{ sPartnerId }.scorchgore.session"));

        return $"joined,{ sPartnerId }";
    }
}
