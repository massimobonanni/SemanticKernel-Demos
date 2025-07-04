﻿using _05_Filters.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
});

builder.Services.AddSingleton<IFunctionInvocationFilter, LoggingFilter>();

builder.Plugins.AddFromType<TaskManagementPlugin>("TaskManagement");

// Build the kernel
Kernel kernel = builder.Build();

kernel.AutoFunctionInvocationFilters.Add(new EarlyTerminationFilter());
kernel.PromptRenderFilters.Add(new SafePromptFilter());

#region Text prompt
//Console.Write("Give me the city: ");
//string? city = Console.ReadLine();

//var template = "I'm visiting {{$city}}. What are some activities I should do today?";

//var activitiesFunction = kernel.CreateFunctionFromPrompt(template);
//var arguments = new KernelArguments { ["city"] = city };

////InvokeAsync on the KernelFunction object
//var result = await activitiesFunction.InvokeAsync(kernel, arguments);
//Console.WriteLine(result);
#endregion

#region PlugInInvocation
//OpenAIPromptExecutionSettings settings = new()
//{
//    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
//};

//var history = new ChatHistory();
//var userMessage = "What are all of the critical tasks?";
//history.AddUserMessage(userMessage);
//Console.WriteLine("User: " + userMessage);

//var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

//var result = await chatCompletionService.GetChatMessageContentAsync(
//    history,
//    executionSettings: settings,
//    kernel: kernel);

//Console.WriteLine("Assistant: " + result);
#endregion PlugInInvocation