using Microsoft.AspNetCore.Mvc;

namespace Notes.Api.Controllers;

[ApiController]
[Route("notes")]
public class NotesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetHelloWorld(Guid noteId)
    {
        return Ok("Hello, World!");
    }
    
    [HttpGet("{noteId:guid}")]
    public async Task<IActionResult> GetNote(Guid noteId)
    {
        throw new NotImplementedException();
        return Ok();
    }
}