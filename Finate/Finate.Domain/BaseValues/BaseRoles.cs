using Finate.Domain.Entities;
using Finate.Domain.Enums;

namespace Finate.Domain.BaseValues;

public static class BaseRoles
{
    public static Role AdminRole = new()
    {
        Id = new Guid("4B960FC2-23BC-4003-A03D-552FBA0E579E"),
        Name = "Admin",
        NormalizedName = "ADMIN"
    };
    
    public static Role CandidateRole = new()
    {
        Id = new Guid("33F3F505-60E8-4656-AA3D-5F427192C489"),
        Name = "Candidate",
        NormalizedName = "CANDIDATE"
    };

    public static Role EmployerRole = new() 
    {
        Id = new Guid("6D8E2FFC-8500-407B-9FEE-0312CACBFB48"),
        Name = "Employer",
        NormalizedName = "EMPLOYER"
    };
}