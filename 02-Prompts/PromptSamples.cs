using Azure.Core;

namespace _02_Prompts
{
    internal static class PromptSamples
    {
        public static string GetZeroShotLearning()
        {
            return """
                Instructions: What is the intent of this request?
                If you don't know the intent, don't guess; instead respond with "Unknown".
                Choices: SendEmail, SendMessage, CompleteTask, CreateDocument, Unknown.
                User Input: {{ $userRequest }}
                Intent: 
                """;
        }

        public static string GetFewShotLearning()
        {
            return """
                Instructions: What is the intent of this request?
                If you don't know the intent, don't guess; instead respond with "Unknown".
                Choices: SendEmail, SendMessage, CompleteTask, CreateDocument, Unknown.

                User Input: Can you send a very quick approval to the marketing team?
                Intent: SendMessage

                User Input: Can you send the full update to the marketing team?
                Intent: SendEmail

                User Input: {{ $userRequest }}
                Intent:
                """;
        }

        public static string GetUsePersonas()
        {
            return $"""
                You are a highly experienced software engineer. Explain the concept of asynchronous programming to a beginner.
                """;
        }

        public static string GetChainOfThought()
        {
            return $"""
                A farmer has 150 apples and wants to sell them in baskets. Each basket can hold 12 apples. If any apples remain after filling as many baskets as possible, the farmer will eat them. How many apples will the farmer eat?
                Instructions: Explain your reasoning step by step before providing the answer.
                """;
        }
    }
}
