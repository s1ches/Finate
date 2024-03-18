using System.ComponentModel;

namespace Finate.Domain.Enums;

public enum PrivilegeType
{
    [Description("Can create candidate form")]
    CreateCandidateForm = 1,
    
    [Description("Can create candidate forms")]
    CreateManyCandidateForms = 2,
    
    [Description("Can create job forms")]
    CreateManyJobForms = 3,
    
    [Description("Can block users")]
    BlockUsers = 4,
    
    [Description("Can write to candidates")]
    WriteCandidates = 5,
    
    [Description("Can write to company")]
    WriteCompany = 6,
    
    [Description("Can block forms")]
    BlockForm = 7,
    
    [Description("Can change own forms")]
    ChangeOwnForms = 8,
    
    [Description("Can change all forms")]
    ChangeAllForms = 9,
    
    [Description("Can delete own account")]
    DeleteOwnAccount = 10,
    
    [Description("Can delete form")]
    DeleteOwnForm = 11,
    
    [Description("Can delete all forms")]
    DeleteAllForms = 12,
}