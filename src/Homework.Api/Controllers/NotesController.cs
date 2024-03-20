using Homework.Application.Notes.Commands.AddNote;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Contracts.Notes;

namespace Notes.Api.Controllers;

[ApiController]
[Route("notes")]
public class NotesController : ControllerBase
{
    private readonly ISender _sender;

    public NotesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("hello")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHelloWorld()
    {
        return Ok("Hello, World!");
    }
    
    [HttpGet("{noteId:guid}")]
    [ProducesResponseType<GetNoteResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNote(Guid noteId)
    {
        throw new NotImplementedException();
        return Ok();
    }
    
    [HttpPost]
    [ProducesResponseType<AddNoteResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddNote(AddNoteRequest request)
    {
        var command = new AddNoteCommand(request.Content);
        var result = await _sender.Send<AddNoteCommandResult>(command);
        var response = new AddNoteResponse(result.Id);
        
        return Ok(response);
    }
}