namespace Shared.Requests.Account.PatchEditMyProfile;

public class PatchEditMyProfileRequest
{
    public PatchEditMyProfileRequest(PatchEditMyProfileRequest request)
    {
        PhotoFileStream = request.PhotoFileStream;
        UserName = request.UserName;
    }
    
    public PatchEditMyProfileRequest()
    {
    }
    
    public Stream PhotoFileStream { get; set; }
    
    public string UserName { get; set; }
}