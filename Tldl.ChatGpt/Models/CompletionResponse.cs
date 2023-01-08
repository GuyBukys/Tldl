using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Tldl.VoiceToTextService.ChatGpt.Models;

public class CompletionResponse
{
    [JsonPropertyName("choices")] 
    public IEnumerable<ChatGPTChoice> Choices { get; set; } = Enumerable.Empty<ChatGPTChoice>();
    
    [JsonPropertyName("usage")] 
    public ChatGPTUsage? Usage { get; set; }
}

public class ChatGPTUsage
{
    [JsonPropertyName("prompt_tokens")] 
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_token")] 
    public int CompletionTokens { get; set; }

    [JsonPropertyName("total_tokens")] 
    public int TotalTokens { get; set; }
}

public class ChatGPTChoice
{
    [JsonPropertyName("text")] 
    public string? Text { get; set; }
}