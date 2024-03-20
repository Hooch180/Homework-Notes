using Microsoft.AspNetCore.Mvc;
using Notes.Contracts.Notes;

namespace Notes.Api.Controllers;

[ApiController]
[Route("notes")]
public class NotesController : ControllerBase
{
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
}