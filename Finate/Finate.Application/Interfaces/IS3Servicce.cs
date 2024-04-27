namespace Finate.Application.Interfaces;

public interface IS3Servicce
{
    public Task<string?> GetFileUrl(string filename ,CancellationToken cancellationToken = default);
    
    public Task<int> UploadFile(string filename, Stream fileStream, CancellationToken cancellationToken = default);

    public Task<int> UpdateFile(string fileName, Stream fileStream, CancellationToken cancellationToken = default);

    public Task<int> DeleteFile(string fileName, CancellationToken cancellationToken = default);
}