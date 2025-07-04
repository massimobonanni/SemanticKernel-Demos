# SemanticKernel-Demos

## Introduction

SemanticKernel-Demos is a collection of .NET 9 console applications that demonstrate various features and integration patterns of the [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel) SDK. Each project in this solution focuses on a specific aspect of building, prompting, templating, extending, and filtering AI-powered applications using Semantic Kernel and Azure OpenAI.

## Projects Overview

### 01-BuildKernel

Demonstrates how to configure and build a Semantic Kernel instance using Azure OpenAI chat completion. It shows basic prompt invocation and how to adjust prompt execution settings such as temperature and max tokens.

### 02-Prompts

Explores different ways to create and use prompts with Semantic Kernel. It includes examples of both inline text prompts and file-based prompts, illustrating how to pass variables and stream results from the kernel.

### 03-HandlebarsPrompts

Showcases the use of Handlebars templates for prompt creation. This project demonstrates how to integrate the `Microsoft.SemanticKernel.PromptTemplates.Handlebars` package to build dynamic prompts, including support for image data and advanced templating scenarios.

### 04-Plugins

Demonstrates how to extend the Semantic Kernel with custom plugins. The example includes adding a `WeatherPlugin` and using it within a chat scenario to answer user queries about the weather, leveraging the kernel's plugin system.

### 05-Filters

Focuses on advanced kernel customization using filters. It shows how to add function invocation filters, prompt render filters, and early termination logic. The project also demonstrates logging and safe prompt handling for robust AI workflows.

---

Each project is self-contained and can be run independently. Configuration is managed via user secrets for secure handling of API keys and endpoints.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Azure OpenAI resource and credentials
- (Optional) Visual Studio 2022 for development and debugging

## Getting Started

1. Clone the repository.
2. Set up user secrets for each project with your Azure OpenAI credentials.

```json
{
    "ApiKey": "",
    "DeploymentName": "",
    "Endpoint": ""
}
```
3. Build and run the desired project.

For more details on each demo, refer to the respective project folders.