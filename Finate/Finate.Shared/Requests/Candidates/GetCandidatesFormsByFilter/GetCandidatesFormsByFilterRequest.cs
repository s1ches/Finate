using Shared.Abstractions;

namespace Shared.Requests.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterRequest : PaginationRequest
{
    public GetCandidatesFormsByFilterRequest(GetCandidatesFormsByFilterRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        SearchValue = request.SearchValue;
        City = request.City;
        Category = request.Category;
        PageNumber = request.PageNumber;
        PageSize = request.PageNumber;
    }
    
    public GetCandidatesFormsByFilterRequest()
    {
    }
    
    public string? SearchValue { get; set; } = string.Empty;

    public string? City { get; set; } = string.Empty;

    public string? Category { get; set; } = string.Empty;
}