#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, ExecutionContext executionContext)
{
    var responseMessage = string.Empty;
    var verbCommand = req.Query["v"].ToString().ToLowerInvariant();
    var sessionID = Guid.Parse(req.Query["s"].ToString());
    var sSessionID = sessionID.ToString("N").ToLowerInvariant();
    var storePath = StorePath(executionContext);
    var schussFile = Path.Combine(storePath, $"{ sSessionID }.scorchgore.move");
    switch (verbCommand)
    {
        case "s":
            /* schuss einmelden */
            var sSchussParameter = req.Query["sp"].ToString();
            var tempID = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var tempFile = Path.Combine(storePath, tempID);
            File.WriteAllText(tempFile, sSchussParameter);
            try
            {
                if (File.Exists(schussFile))
                {
                    File.Delete(schussFile);
                }

                File.Move(tempFile, schussFile);
                responseMessage = "ok";
            }
            catch
            {
                responseMessage = "konflikt";
            }

            break;

        case "p":
            /* polling, warten auf naechste schusseingabe des anderen */
            if (File.Exists(schussFile))
            {
                responseMessage = File.ReadAllText(schussFile);
                File.Delete(schussFile);
            }
            else
            {
                responseMessage = "warten";
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
