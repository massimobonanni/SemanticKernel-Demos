using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
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

builder.Plugins.AddFromType<TaskManagementPlugin>("TaskManagement");
builder.Plugins.AddFromType<WeatherPlugin>("WeatherPlugin");    

// Build the kernel
Kernel kernel = builder.Build();

OpenAIPromptExecutionSettings settings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

var history = new ChatHistory();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

Console.WriteLine("Chat started! Type 'exit' or 'quit' to end the conversation.");
Console.WriteLine();

while (true)
{
    Console.Write("User: ");
    var userMessage = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(userMessage) || 
        userMessage.ToLower() == "exit" || 
        userMessage.ToLower() == "quit")
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    history.AddUserMessage(userMessage);

    var result = await chatCompletionService.GetChatMessageContentAsync(
        history,
        executionSettings: settings,
        kernel: kernel);

    history.AddAssistantMessage(result.Content ?? "");
    Console.WriteLine("Assistant: " + result);
    Console.WriteLine();
}