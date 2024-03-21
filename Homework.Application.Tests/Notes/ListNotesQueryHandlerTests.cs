using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Homework.Application.Common.Interfaces.Repositories;
using Homework.Application.Notes.Queries.ListNotes;
using Notes.Domain.Notes;
using NSubstitute;
using NUnit.Framework;

namespace Homework.Application.Tests.Notes;

[TestFixture]
public class ListNotesQueryHandlerTests
{
    private IFixture _fixture;
    private INotesRepository _notesRepository;
    private ListNotesQueryHandler _sut;
    
    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        _notesRepository = _fixture.Freeze<INotesRepository>();
        _sut = _fixture.Create<ListNotesQueryHandler>();
    }

    [Test]
    public async Task Handle_WhenCalled_ShouldReturnNotesFromPage()
    {
        // Arrange
        var allNotes = _fixture.CreateMany<Note>(21).ToList();
        var notes = allNotes.Take(10).ToList();
        var query = new ListNotesQuery(PageNumber: 1, PageSize: 10);
        _notesRepository.GetPageAsync(query.PageNumber, query.PageSize).Returns(Task.FromResult<(List<Note> Notes, int totalCount)>(new (notes, allNotes.Count)));
        
        // Act
        var result = await _sut.Handle(query, CancellationToken.None);
        
        // Assert
        result.Items.Should().BeEquivalentTo(notes);
        result.PageSize.Should().Be(query.PageSize);
        result.CurrentPageNumber.Should().Be(query.PageNumber);
        result.TotalEntries.Should().Be(allNotes.Count);
        result.MaxPageNumber.Should().Be(3);
    }
}