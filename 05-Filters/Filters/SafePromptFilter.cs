using Microsoft.SemanticKernel;

namespace _05_Filters.Filters
{
    public class SafePromptFilter : IPromptRenderFilter
    {
        public async Task OnPromptRenderAsync(PromptRenderContext context, Func<PromptRenderContext, Task> next)
        {
            await next(context);

            // Modify prompt before submission
            if (context.RenderedPrompt.Length > 100)
            {
                context.RenderedPrompt = context.RenderedPrompt.Substring(0, 100);
            }
        }
    }
}
