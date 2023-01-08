using MediatR;
using Tldl.VoiceToTextService.ChatGpt.Interfaces;
using Tldl.VoiceToTextService.ChatGpt.Models;

namespace Tldl.VoiceToTextService.Application.GetTextFromVoice;

public class SummarizeTextRequestHandler : IRequestHandler<SummarizeTextRequest, SummarizeTextResult>
{
    private readonly IChatGptApi _chatGptApi;

    public SummarizeTextRequestHandler(IChatGptApi chatGptApi)
    {
        _chatGptApi = chatGptApi;
    }

    public async Task<SummarizeTextResult> Handle(SummarizeTextRequest request, CancellationToken cancellationToken)
    {
        var completionRequest = new CompletionRequest
        {
            Model = "text-davinci-003",
            Prompt =
                $"""
                Can you please summarize the following text to a single sentence? the text is:
                "{request.Text}"
                Please summarize it in the language it was written.
                """,
            MaxTokens = 500,
            Temperature = 0,
        };

        var result = await _chatGptApi.Completion(completionRequest);

        return new SummarizeTextResult(string.Join(',', result.Choices.Select(x => x.Text)));
    }
};
