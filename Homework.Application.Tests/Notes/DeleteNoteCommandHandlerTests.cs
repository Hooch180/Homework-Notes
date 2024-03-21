using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Homework.Application.Common.Interfaces;
using Homework.Application.Common.Interfaces.Repositories;
using Homework.Application.Notes.Commands.DeleteNote;
using Notes.Domain.Notes;
using NSubstitute;
using NUnit.Framework;

namespace Homework.Application.Tests.Notes;

[TestFixture]
public class DeleteNoteCommandHandlerTests
{
    private IFixture _fixture;
    private INotesRepository _notesRepository;
    private IUnitOfWork _unitOfWork;
    private DeleteNoteCommandHandler _sut;
    
    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        _notesRepository = _fixture.Freeze<INotesRepository>();
        _unitOfWork = _fixture.Freeze<IUnitOfWork>();

        _sut = _fixture.Create<DeleteNoteCommandHandler>();
    }
    
    [Test]
    public async Task Handle_WhenNoteExists_ShouldRemoveNoteAndCommitChanges()
    {
        // Arrange
        var note = _fixture.Create<Note>();
        var command = new DeleteNoteCommand(note.Id);
        
        _notesRepository.GetByIdAsync(note.Id).Returns(note);
        
        // Act
        await _sut.Handle(command, default);
        
        // Assert
        await _notesRepository.Received(1).RemoveAsync(note);
        await _unitOfWork.Received(1).CommitChangesAsync();
    }
    
    [Test]
    public async Task Handle_WhenNoteDoesNotExist_ShouldNotRemoveNoteAndNotCommitChanges()
    {
        // Arrange
        var noteId = _fixture.Create<Guid>();
        var command = new DeleteNoteCommand(noteId);
        
        _notesRepository.GetByIdAsync(noteId).Returns((Note)null!);
        
        // Act
        await _sut.Handle(command, default);
        
        // Assert
        await _notesRepository.DidNotReceive().RemoveAsync(Arg.Any<Note>());
        await _unitOfWork.DidNotReceive().CommitChangesAsync();
    }
}