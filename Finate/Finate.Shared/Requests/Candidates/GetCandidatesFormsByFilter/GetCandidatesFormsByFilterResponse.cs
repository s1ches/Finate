namespace Shared.Requests.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterResponse
{
    public List<GetCandidatesFormsByFilterResponseItem> CandidatesForms = [];

    public int TotalCount { get; set; } = 0;
}