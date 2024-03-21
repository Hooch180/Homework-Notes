using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Homework.Application.Common.Exceptions;
using Homework.Application.Common.Interfaces.Repositories;
using Homework.Application.Notes.Queries.GetNote;
using Notes.Domain.Notes;
using NSubstitute;
using NUnit.Framework;

namespace Homework.Application.Tests.Notes;

[TestFixture]
public class GetNoteQueryHandlerTests
{
    private IFixture _fixture = null!;
    private INotesRepository _notesRepository = null!;
    private GetNoteQueryHandler _sut = null!;

    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        _notesRepository = _fixture.Freeze<INotesRepository>();
        _sut = _fixture.Create<GetNoteQueryHandler>();
    }
    
    [Test]
    public async Task Handle_WhenNoteExists_ShouldReturnNote()
    {
        // Arrange
        var note = _fixture.Create<Note>();
        var query = new GetNoteQuery(note.Id);
        _notesRepository.GetByIdAsync(note.Id).Returns(note);
        
        // Act
        var result = await _sut.Handle(query, CancellationToken.None);
        
        // Assert
        result.Note.Should().BeEquivalentTo(note);
    }
    
    [Test]
    public async Task Handle_WhenNoteDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var query = new GetNoteQuery(Guid.NewGuid());
        _notesRepository.GetByIdAsync(query.Id).Returns((Note)null!);
        
        // Act
        var act = () => _sut.Handle(query, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}