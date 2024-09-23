using AIAgent.ServiceDefaults;
using Microsoft.SemanticKernel;
using static System.Net.WebRequestMethods;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Semantic Kernel
//Read key from Env Variable
var azureOpenAIKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY");
if (azureOpenAIKey == null ) throw new ArgumentNullException(nameof(azureOpenAIKey), "Can not be null");

string chatCompletionDeployment = builder.Configuration["AzureAI.chatCompletiondeployment"] ?? "gpt-4o";
string embeddeingsDeployment = builder.Configuration["AzureAI.embeddeingsDeployment"] ?? "text-embedding-ada-002";
var endpoint = builder.Configuration["AzureAI.endpoint"] ?? "https://connectmyai-openai.openai.azure.com/";

builder.Services.AddKernel();
builder.Services.AddAzureOpenAIChatCompletion(chatCompletionDeployment, endpoint, azureOpenAIKey);
#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services.AddAzureOpenAITextEmbeddingGeneration(embeddeingsDeployment, endpoint, azureOpenAIKey);
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
