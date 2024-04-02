namespace Shared.Requests;

public abstract class ResponseBase
{
    public bool IsSuccessful { get; set; }

    public List<ResponseErrorMessageItem> ErrorMessages { get; set; } = [];
}