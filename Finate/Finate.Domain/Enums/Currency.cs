using System.ComponentModel;

namespace Finate.Domain.Enums;

public enum Currency
{
    [Description("Euro")]
    Euro = 1,
    
    [Description("Dollar")]
    Dollar = 2,
    
    [Description("Ruble")]
    Ruble = 3,
    
    [Description("Pound")]
    Pound = 4,
    
    [Description("Yen")]
    Yen = 5,
    
    [Description("Swiss Frank")]
    SwissFrank = 6,
    
    [Description("Yuan")]
    Yuan = 7
}