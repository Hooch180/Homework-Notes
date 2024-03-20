using Homework.Application.Notes.Commands.AddNote;
using Homework.Application.Notes.Commands.DeleteNote;
using Homework.Application.Notes.Commands.UpdateNote;
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
        var result = await _sender.Send(command);
        var response = new AddNoteResponse(result.Id);
        
        return Ok(response);
    }
    
    [HttpPut("{noteId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateNote(Guid noteId, [FromBody]UpdateNoteRequest request)
    {
        var command = new UpdateNoteCommand(noteId, request.Content);
        await _sender.Send(command);
        
        return Ok();
    }
    
    [HttpDelete("{noteId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteNote(Guid noteId)
    {
        var command = new DeleteNoteCommand(noteId);
        await _sender.Send(command);
        return Ok();
    }
}