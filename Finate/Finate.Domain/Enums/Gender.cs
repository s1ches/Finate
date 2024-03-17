using System.ComponentModel;

namespace Finate.Domain.Enums;

public enum Gender
{
    [Description("Male")]
    Male = 1,
    
    [Description("Female")]
    Female = 2,
    
    [Description("Male or Female")]
    Any = 3
}