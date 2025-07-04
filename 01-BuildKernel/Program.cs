using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

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

var prompt = "Hi, tell me something about Rome";

Console.WriteLine("Invoking prompt: " + prompt);
var response = await kernel.InvokePromptAsync(prompt);
Console.WriteLine(response);

Console.WriteLine("---------------------------------------------------");
Console.WriteLine();

var settings = new OpenAIPromptExecutionSettings
{
    Temperature = 0.0, 
    MaxTokens = 100
};

Console.WriteLine("Invoking prompt with settings: " + prompt);
response = await kernel.InvokePromptAsync(prompt, new KernelArguments(settings));
Console.WriteLine(response);