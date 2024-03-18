using Finate.Domain.Entities;

namespace Finate.Domain.BaseValues;

public static class BaseRoles
{
    public static Guid AdminRoleId = new ("4B960FC2-23BC-4003-A03D-552FBA0E579E");

    public const string AdminRoleName = "Admin";

    public const string AdminNormalizedRoleName = "ADMIN";

    public static Guid CandidateRoleId = new("33F3F505-60E8-4656-AA3D-5F427192C489");

    public const string CandidateRoleName = "Candidate";

    public const string CandidateNormalizedRoleName = "CANDIDATE";

    public static Guid EmployerRoleId = new("6D8E2FFC-8500-407B-9FEE-0312CACBFB48");

    public const string EmployerRoleName = "Employer";

    public const string EmployerNormalizedRoleName = "EMPLOYER";
}