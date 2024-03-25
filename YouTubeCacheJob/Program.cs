using YouTubeCacheJob;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StarterData>();
builder.Services.AddHostedService<BackgroundRefresh>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/resources", (StarterData data) => data.Data.Order());
 

app.Run();
