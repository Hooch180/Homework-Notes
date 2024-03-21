using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Homework.Application.Common.Behaviours;
using Homework.Application.Common.Exceptions;
using Homework.Application.Notes.Commands.AddNote;
using MediatR;
using NSubstitute;
using NUnit.Framework;

namespace Homework.Application.Tests.Common.Behaviours;

[TestFixture]
public class ValidationBehaviourTests
{
    private IFixture _fixutre;
    private IValidator<AddNoteCommand> _validator;
    private RequestHandlerDelegate<AddNoteCommandResult> _nextBehavior;
    private ValidationBehavior<AddNoteCommand, AddNoteCommandResult> _sut;

    [SetUp]
    public void SetUp()
    {
        _fixutre = new Fixture().Customize(new AutoNSubstituteCustomization());
        _validator = _fixutre.Freeze<IValidator<AddNoteCommand>>();
        _nextBehavior = Substitute.For<RequestHandlerDelegate<AddNoteCommandResult>>();
        
        _sut = _fixutre.Create<ValidationBehavior<AddNoteCommand, AddNoteCommandResult>>();
    }
    
    [Test]
    public async Task WhenValidatorReturnValid_CallNext()
    {
        // Arrange
        var request = _fixutre.Create<AddNoteCommand>();
        var response = _fixutre.Create<AddNoteCommandResult>();
        var validationResult = new ValidationResult();
        
        _nextBehavior.Invoke().Returns(response);
        _validator
            .ValidateAsync(request, Arg.Any<CancellationToken>())
            .Returns(validationResult);

        // Act
        var result = await _sut.Handle(request, _nextBehavior, default);

        // Assert
        result.Should().Be(response);
    }

    [Test]
    public async Task WhenValidationFails_ThrowCommandValidationException()
    {
        // Arrange
        var request = _fixutre.Create<AddNoteCommand>();
        var response = _fixutre.Create<AddNoteCommandResult>();
        var validationResult = new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("foo", "bad foo")
        });
        
        _nextBehavior.Invoke().Returns(response);
        _validator
            .ValidateAsync(request, Arg.Any<CancellationToken>())
            .Returns(validationResult);
        
        // Act
        var act = () => _sut.Handle(request, _nextBehavior, default);
        
        // Assert
        await act.Should().ThrowAsync<CommandValidationException>();
    }
}