using System.Threading.Tasks;
using Tldl.VoiceToTextService.ChatGpt.Models;

namespace Tldl.VoiceToTextService.ChatGpt.Interfaces;

public interface IChatGptApi
{
    Task<CompletionResponse> Completion(CompletionRequest completionRequest);
}