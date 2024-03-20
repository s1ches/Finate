using System.ComponentModel;

namespace Finate.Domain.Enums;

public enum Language
{
    [Description("French")]
    French = 1,
    
    [Description("English")]
    English = 2,
    
    [Description("Russian")]
    Russian = 3,
    
    [Description("Japanese")]
    Japanese = 4,
    
    [Description("German")]
    German = 5,
    
    [Description("Chinese")]
    Chinese = 6,
    
    [Description("Swedish")]
    Swedish = 7,
    
    [Description("Hungarian")]
    Hungarian = 8,
    
    [Description("Czech")]
    Czech = 9, 
    
    [Description("Italian")]
    Italian = 10,
    
    [Description("Spanish")]
    Spanish = 11,
    
    [Description("Turkish")]
    Turkish = 12,
    
    [Description("Indian")]
    Indian = 13,
    
    [Description("Arab")]
    Arab = 14,
    
    [Description("Portuguese")]
    Portuguese = 15,
    
    [Description("Korean")]
    Korean = 16,
    
    [Description]
    Any = 17
}