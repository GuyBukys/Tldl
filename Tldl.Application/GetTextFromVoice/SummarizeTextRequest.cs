using MediatR;

namespace Tldl.VoiceToTextService.Application.GetTextFromVoice;

public record SummarizeTextRequest(string Text, int LanguageCode)
    : IRequest<SummarizeTextResult>;
