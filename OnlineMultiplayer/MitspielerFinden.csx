#r "Newtonsoft.Json"

// portal.azure.com
// https://scorchgore.azurewebsites.net/api/MitspielerFinden?code=CODE/cOsj/fPNA==&name=Lukas

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, ExecutionContext executionContext)
{
    string name = req.Query["name"];
    var functionDirectory = executionContext.FunctionDirectory;
    var projectDirectory = Directory.GetParent(functionDirectory).Name;
    var sessionFile = Path.Combine(functionDirectory, "session1.txt");
    File.WriteAllText(sessionFile, "Test");
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    string responseMessage = string.IsNullOrEmpty(name)
        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
        : $@"Hello, {name} on ""{ functionDirectory }"" in ""{ sessionFile }"". This HTTP triggered function executed successfully.";

    return new OkObjectResult(responseMessage);
}
