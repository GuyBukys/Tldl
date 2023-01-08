using System.Text.Json.Serialization;

namespace Tldl.VoiceToTextService.ChatGpt.Models;

public class CompletionRequest
{
    [JsonPropertyName("model")] 
    public string? Model { get; set; }
    
    [JsonPropertyName("prompt")] 
    public string? Prompt { get; set; }
    
    [JsonPropertyName("max_tokens")] 
    public int? MaxTokens { get; set; }
    
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }
}