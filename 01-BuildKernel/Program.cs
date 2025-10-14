using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Connectors.Ollama;

var hostBuilder = Host.CreateApplicationBuilder(args);
hostBuilder.Configuration.AddUserSecrets<Program>();

// Load configuration settings from configuration
string? apiKey = hostBuilder.Configuration["ApiKey"];
string? deploymentName = hostBuilder.Configuration["DeploymentName"];
string? endpoint = hostBuilder.Configuration["Endpoint"];

// Create a kernel with Azure OpenAI chat completion
#region "Azure OpenAI
var builder = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(deploymentName, endpoint, apiKey);
#endregion 

#region "Ollama local"
#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
//var builder = Kernel.CreateBuilder()
//    .AddOllamaChatCompletion("deepseek-r1:7b", new Uri("http://127.0.0.1:11434"));
#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#endregion

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