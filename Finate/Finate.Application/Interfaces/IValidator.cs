namespace Finate.Application.Interfaces;

public interface IValidator<in TRequest>
{
    public List<string> Validate(TRequest request);
}