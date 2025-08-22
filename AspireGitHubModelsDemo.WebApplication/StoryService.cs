using Microsoft.Extensions.AI;

namespace AspireGitHubModelsDemo.WebApplication;

public class StoryService(IChatClient chatClient)
{
    public async Task<string> GenerateStoryAsync(string prompt)
    {
        var response = await chatClient.GetResponseAsync(prompt);

        return response.Text;
    }
}