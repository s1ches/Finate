using System.ComponentModel;

namespace Finate.Domain.Enums;

public enum JobType
{
    [Description("Full Time")]
    FullTime = 1,
    
    [Description("1/2 Time")]
    HalfTime = 2,
    
    [Description("1/4 Time")]
    HalfHalfTime = 3,
    
    [Description("Negotiable work time")]
    Negotiable = 4
}