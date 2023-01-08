using Microsoft.Extensions.DependencyInjection;
using Tldl.VoiceToTextService.ChatGpt.Interfaces;

namespace Tldl.VoiceToTextService.ChatGpt;

public static class DependencyInjection
{
    public static IServiceCollection AddChatGptApi(this IServiceCollection services)
    {
        services.AddScoped<IChatGptApi, ChatGptApi>();
        return services;
    }
}