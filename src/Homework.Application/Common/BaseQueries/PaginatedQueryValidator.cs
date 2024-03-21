using FluentValidation;

namespace Homework.Application.Common.BaseQueries;

public class PaginatedQueryValidator : AbstractValidator<PaginatedQuery>
{
    public PaginatedQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithErrorCode("INVALID_PAGE_NUMBER");
        
        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithErrorCode("INVALID_PAGE_SIZE");
    }
}