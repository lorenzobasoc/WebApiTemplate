using FluentValidation;

namespace WebApiTemplate.Endpoints.Requests;

public class DefaultReq
{
    public char[] Commands { get; set; }
}

public class DefaultReqValidator : Validator<DefaultReq>
{
    public DefaultReqValidator()
    {
        RuleFor(x => x.Commands)
            .NotEmpty()
            .WithMessage("Commands cannot be empty.");
    }
}
