using Finate.Domain.BaseValues;

namespace Finate.Application.Constants;

public static class Roles
{
    public static readonly string AdminRoleName = BaseRoles.AdminRole.Name!;

    public static readonly string CandidateRoleName = BaseRoles.CandidateRole.Name!;

    public static readonly string EmployerRoleName = BaseRoles.EmployerRole.Name!;
}