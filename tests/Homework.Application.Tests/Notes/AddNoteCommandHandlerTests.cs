using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Homework.Application.Common.Interfaces;
using Homework.Application.Common.Interfaces.Repositories;
using Homework.Application.Notes.Commands.AddNote;
using Notes.Domain.Notes;
using NSubstitute;
using NUnit.Framework;

namespace Homework.Application.Tests.Notes;

[TestFixture]
public class AddNoteCommandHandlerTests
{
    private IFixture _fixture;
    private INotesRepository _notesRepository;
    private IUnitOfWork _unitOfWork;
    private AddNoteCommandHandler _sut;
    
    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        _notesRepository = _fixture.Freeze<INotesRepository>();
        _unitOfWork = _fixture.Freeze<IUnitOfWork>();
        
        _sut = _fixture.Create<AddNoteCommandHandler>();
    }
    
    [Test]
    public async Task Handle_ShouldAddNoteToRepository()
    {
        // Arrange
        var command = _fixture.Create<AddNoteCommand>();
        Note? savedNote = null;
        await _notesRepository.AddAsync(Arg.Do<Note>(note => savedNote = note));
        
        // Act
        await _sut.Handle(command, CancellationToken.None);
        
        // Assert
        await _notesRepository.Received(1).AddAsync(Arg.Any<Note>());
        await _unitOfWork.Received(1).CommitChangesAsync();
        savedNote.Should().NotBeNull();
        savedNote!.Content.Should().Be(command.Content);
        savedNote!.Id.Should().NotBeEmpty();
    }
}