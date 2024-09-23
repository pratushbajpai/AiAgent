var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AIAgentAppSvc>("aiagentapp");

builder.Build().Run();
