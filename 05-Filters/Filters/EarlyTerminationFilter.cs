using Microsoft.SemanticKernel;

namespace _05_Filters.Filters
{
    public sealed class EarlyTerminationFilter : IAutoFunctionInvocationFilter
    {
        public async Task OnAutoFunctionInvocationAsync(AutoFunctionInvocationContext context, Func<AutoFunctionInvocationContext, Task> next)
        {
            await next(context);

            if (context.Result.ValueType == typeof(string))
            {
                var result = context.Result.GetValue<string>();
                if (result == "desired result")
                {
                    context.Terminate = true;
                }
            }
        }
    }
}
