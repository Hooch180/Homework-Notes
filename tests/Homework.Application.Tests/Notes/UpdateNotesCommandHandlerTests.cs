using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Homework.Application.Common.Exceptions;
using Homework.Application.Common.Interfaces;
using Homework.Application.Common.Interfaces.Repositories;
using Homework.Application.Notes.Commands.UpdateNote;
using Notes.Domain.Notes;
using NSubstitute;
using NUnit.Framework;

namespace Homework.Application.Tests.Notes;

[TestFixture]
public class UpdateNotesCommandHandlerTests
{
    private IFixture _fixture = null!;
    private INotesRepository _notesRepository = null!;
    private IUnitOfWork _unitOfWork = null!;
    private UpdateNoteCommandHandler _sut = null!;
    
    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        _notesRepository = _fixture.Freeze<INotesRepository>();
        _unitOfWork = _fixture.Freeze<IUnitOfWork>();

        _sut = _fixture.Create<UpdateNoteCommandHandler>();
    }
    
    [Test]
    public async Task Handle_WhenNoteExists_ShouldUpdateNoteAndCommitChanges()
    {
        // Arrange
        var note = _fixture.Create<Note>();
        var command = new UpdateNoteCommand(note.Id, "New content");
        
        _notesRepository.GetByIdAsync(note.Id).Returns(note);
        
        // Act
        await _sut.Handle(command, CancellationToken.None);
        
        // Assert
        await _notesRepository.Received(1).UpdateAsync(note);
        await _unitOfWork.Received(1).CommitChangesAsync();
    }
    
    [Test]
    public async Task Handle_WhenNoteDoesNotExist_ShouldThrowException()
    {
        // Arrange
        var noteId = _fixture.Create<Guid>();
        var command = new UpdateNoteCommand(noteId, "New content");
        
        _notesRepository.GetByIdAsync(noteId).Returns((Note)null!);
        
        // Act
        var act = () => _sut.Handle(command, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        await _notesRepository.DidNotReceive().UpdateAsync(Arg.Any<Note>());
        await _unitOfWork.DidNotReceive().CommitChangesAsync();
    }
}