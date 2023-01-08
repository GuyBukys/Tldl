using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Tldl.VoiceToTextService.ChatGpt.Interfaces;
using Tldl.VoiceToTextService.ChatGpt.Models;

namespace Tldl.VoiceToTextService.ChatGpt;

public class ChatGptApi : IChatGptApi
{
    private readonly HttpClient _httpClient;
    private readonly ChatGptConfiguration _configuration;

    public ChatGptApi(HttpClient httpClient, IOptions<ChatGptConfiguration> configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration.Value;
    }

    public async Task<CompletionResponse> Completion(CompletionRequest completionRequest)
    {
        using HttpRequestMessage httpReq = new(HttpMethod.Post, ApiConstants.CompletionUri);
        httpReq.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "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");
        httpReq.Content = new StringContent(
            JsonSerializer.Serialize(completionRequest),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        using var httpResponse = await _httpClient.SendAsync(httpReq);
        var responseString = await httpResponse.Content.ReadAsStringAsync();

        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"{responseString}");
        }

        var completionResponse = JsonSerializer.Deserialize<CompletionResponse>(responseString);
        return completionResponse!;
    }
}