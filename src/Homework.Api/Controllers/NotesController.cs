using Homework.Application.Notes.Commands.AddNote;
using Homework.Application.Notes.Commands.DeleteNote;
using Homework.Application.Notes.Commands.UpdateNote;
using Homework.Application.Notes.Queries.GetNote;
using Homework.Application.Notes.Queries.ListNotes;
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
    
    [HttpGet("pageNumber:int/pageSize:int")]
    [ProducesResponseType<ListNotesResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListNotes(int pageNumber, int pageSize)
    {
        var query = new ListNotesQuery(pageNumber, pageSize);
        var result = await _sender.Send(query);
        var notesDto = result
            .Items
            .Select(note => new Note(note.Id, note.Content))
            .ToList();
        
        var response = new ListNotesResponse()
        {
            Items = notesDto,
            PageSize = result.PageSize,
            CurrentPageNumber = result.CurrentPageNumber,
            TotalEntries = result.TotalEntries,
            MaxPageNumber = result.MaxPageNumber
        };
        
        return Ok(response);
    }
    
    [HttpGet("{noteId:guid}")]
    [ProducesResponseType<GetNoteResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNote(Guid noteId)
    {
        var query = new GetNoteQuery(noteId);
        var result = await _sender.Send(query);
        var response = new GetNoteResponse(result.Note.Id, result.Note.Content);
        
        return Ok(response);
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