using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;

var hostBuilder = Host.CreateApplicationBuilder(args);
hostBuilder.Configuration.AddUserSecrets<Program>();

// Load configuration settings from configuration
string? apiKey = hostBuilder.Configuration["ApiKey"];
string? deploymentName = hostBuilder.Configuration["DeploymentName"];
string? endpoint = hostBuilder.Configuration["Endpoint"];

// Create a kernel with Azure OpenAI chat completion
var builder = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(deploymentName, endpoint, apiKey);

// Build the kernel
Kernel kernel = builder.Build();

#region Text prompt
//Console.Write("Give me the city: ");
//string? city = Console.ReadLine();

//var template = "I'm visiting {{$city}}. What are some activities I should do today?";

//var activitiesFunction = kernel.CreateFunctionFromPrompt(template);
//var arguments = new KernelArguments { ["city"] = city };

////InvokeAsync on the KernelFunction object
//var result = await activitiesFunction.InvokeAsync(kernel, arguments);
//Console.WriteLine(result);
//Console.WriteLine("---------------------------------------------------");

////InvokeAsync on the kernel object
//result = await kernel.InvokeAsync(activitiesFunction, arguments);
//Console.WriteLine(result);
//Console.WriteLine("---------------------------------------------------");
#endregion

#region File prompt
//// Load prompts
//var prompts = kernel.CreatePluginFromPromptDirectory("./../../../Prompts");

//Console.Write("What is your name : ");
//string userName = Console.ReadLine()!;

//Console.Write("What is your request : ");
//string userInput = Console.ReadLine()!;

//var chatResult = kernel.InvokeStreamingAsync<StreamingChatMessageContent>(
//  prompts["Complaint"],
//  new()
//  {
//   { "customerName", userName },
//   { "request", userInput }
//  }
//);

//string message = "";

//await foreach (var chunk in chatResult)
//{
//    if (chunk.Role.HasValue)
//    {
//        Console.Write(chunk.Role + " > ");
//    }
//    message += chunk;
//    Console.Write(chunk);
//}

//Console.WriteLine();
#endregion