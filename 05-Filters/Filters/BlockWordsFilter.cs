using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Filters.Filters
{
    public class BlockWordsFilter : IPromptRenderFilter
    {
        private readonly HashSet<string> _blockedWords;

        public BlockWordsFilter(IEnumerable<string> blockedWords)
        {
            _blockedWords = new HashSet<string>(blockedWords, StringComparer.OrdinalIgnoreCase);
        }

        public async Task OnPromptRenderAsync(PromptRenderContext context, Func<PromptRenderContext, Task> next)
        {
            await next(context);

            string prompt = context.RenderedPrompt;

            foreach (var word in _blockedWords)
            {
                if (prompt.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException($"Prompt contains blocked word: '{word}'");
                }
            }
        }
    }
}
