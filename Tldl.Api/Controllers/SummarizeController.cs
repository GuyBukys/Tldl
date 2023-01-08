using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tldl.VoiceToTextService.Application.GetTextFromVoice;
using Tldl.VoiceToTextService.ChatGpt.Models;

namespace Tldl.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class VoiceToTextController : ControllerBase
{
    private readonly ILogger<VoiceToTextController> _logger;
    private readonly IMediator _mediator;

    public VoiceToTextController(ILogger<VoiceToTextController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<string> SummarizeText([FromBody] string text)
    {
        var getTextFromVoiceRequest = new SummarizeTextRequest(text, 0);

        var getTextFromVoiceResult = await _mediator.Send(getTextFromVoiceRequest);

        return getTextFromVoiceResult.SummarizedText;
    }
}