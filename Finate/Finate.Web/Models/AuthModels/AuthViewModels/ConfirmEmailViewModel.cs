namespace Finate.Web.Models.AuthModels.AuthViewModels;

public class ConfirmEmailViewModel
{
    public string ReturnUrl { get; set; } = default!;

    public string Email { get; set; } = default!;
    
    public string UserConfirmEmailToken { get; set; } = default!;
}