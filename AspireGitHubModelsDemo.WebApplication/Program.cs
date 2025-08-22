using AspireApp1.ServiceDefaults;
using AspireGitHubModelsDemo.WebApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddServiceDefaults();
builder.AddAzureChatCompletionsClient("chat").AddChatClient();
;
builder.Services.AddScoped<StoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getpromptfromgithubmodels", async (string prompt, StoryService storyService) =>
    {
        var response = await storyService.GenerateStoryAsync(prompt);

        return response;
    })
    .WithName("GetPromptFromGitHubModels")
    .WithOpenApi();

app.Run();