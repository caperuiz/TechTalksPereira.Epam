var builder = DistributedApplication.CreateBuilder(args);

var chat = builder.AddGitHubModel("chat", "openai/gpt-4o-mini");
builder.AddProject<Projects.AspireGitHubModelsDemo_WebApplication>("webapp")
    .WithReference(chat);

builder.Build().Run();