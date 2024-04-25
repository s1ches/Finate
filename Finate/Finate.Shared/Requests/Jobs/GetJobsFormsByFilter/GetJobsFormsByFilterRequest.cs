using Shared.Abstractions;

namespace Shared.Requests.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterRequest : PaginationRequest
{
    public GetJobsFormsByFilterRequest(GetJobsFormsByFilterRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        
        SearchValue = request.SearchValue;
        City = request.City;
        Category = request.Category;
        PageNumber = request.PageNumber;
        PageSize = request.PageNumber;
    }
    
    public GetJobsFormsByFilterRequest()
    {
    }
    
    public string? SearchValue { get; set; } = string.Empty;

    public string? City { get; set; } = string.Empty;

    public string? Category { get; set; } = string.Empty;
}