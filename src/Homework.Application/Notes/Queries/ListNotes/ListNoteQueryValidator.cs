using FluentValidation;
using Homework.Application.Common.BaseQueries;

namespace Homework.Application.Notes.Queries.ListNotes;

public class ListNoteQueryValidator : AbstractValidator<ListNotesQuery>
{
    public ListNoteQueryValidator()
    {
        Include(new PaginatedQueryValidator());
    }
}