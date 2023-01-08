using MediatR;
using Tldl.VoiceToTextService.Application.GetTextFromVoice;
using Tldl.VoiceToTextService.ChatGpt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(Program).Assembly, typeof(SummarizeTextRequestHandler).Assembly);
builder.Services.AddHttpClient<ChatGptApi>(x => x.BaseAddress = new Uri(ApiConstants.ChatGptApiUri));
builder.Services.AddOptions<ChatGptConfiguration>();
builder.Services.AddChatGptApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();