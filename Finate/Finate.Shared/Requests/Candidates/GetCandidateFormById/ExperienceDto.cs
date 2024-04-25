﻿namespace Shared.Requests.Candidates.GetCandidateFormById;

public class ExperienceDto
{
    public string ExperienceType { get; set; } = default!;

    public int StartYear { get; set; } = default!;

    public int EndYear { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string PlaceName { get; set; } = default!;
}