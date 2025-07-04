using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel; // Core Semantic Kernel SDK
using Microsoft.SemanticKernel.PromptTemplates.Handlebars; // For Handlebars template support

const string HandlebarsTemplate = """
    <message role="system">You are an AI assistant designed to help with image recognition tasks.</message>
    <message role="user">
        <text>{{request}}</text>
        <image>{{imageData}}</image>
    </message>
    """;

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


// Create the prompt template configuration
var templateFactory = new HandlebarsPromptTemplateFactory();
var promptTemplateConfig = new PromptTemplateConfig()
{
    Template = HandlebarsTemplate,
    TemplateFormat = "handlebars",
    Name = "Vision_Chat_Prompt",
};

var arguments = new KernelArguments(new Dictionary<string, object?>
{
    {"request","Describe this image:"},
    {"imageData", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAAXNSR0IArs4c6QAAACVJREFUKFNj/KTO/J+BCMA4iBUyQX1A0I10VAizCj1oMdyISyEAFoQbHwTcuS8AAAAASUVORK5CYII="}
});

var response = await kernel.InvokeAsync(function, arguments);

Console.WriteLine(response);