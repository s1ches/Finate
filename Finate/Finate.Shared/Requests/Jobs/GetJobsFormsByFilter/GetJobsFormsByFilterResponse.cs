namespace Shared.Requests.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterResponse
{
    public List<GetJobsFormsByFilterResponseItem> JobsForms { get; set; } = [];

    public int TotalCount { get; set; } = 0;
}