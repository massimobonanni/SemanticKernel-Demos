using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Filters.Filters
{
    public sealed class LoggingFilter(ILogger<LoggingFilter> logger) : IFunctionInvocationFilter
    {
        public async Task OnFunctionInvocationAsync(FunctionInvocationContext context, Func<FunctionInvocationContext, Task> next)
        {
            logger.LogInformation("Invoking: {PluginName}.{FunctionName}", context.Function.PluginName, context.Function.Name);

            await next(context);
            
            logger.LogInformation("Executed: {PluginName}.{FunctionName}", context.Function.PluginName, context.Function.Name);
        }
    }
}
