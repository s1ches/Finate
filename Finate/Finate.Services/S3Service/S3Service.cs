using Finate.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Finate.Services.S3Service;

public class S3Service(IConfiguration configuration, IMinioClient minio, ILogger<S3Service> logger) : IS3Servicce
{
    private readonly string _bucketName = configuration["S3:BucketName"]!;
    
    public async Task<string?> GetFileUrl(string filename, CancellationToken cancellationToken = default)
    {
        try
        {
            var presignedGetObjectArgs = new PresignedGetObjectArgs().WithBucket(_bucketName).WithObject(filename);
            var objectStat = await minio.PresignedGetObjectAsync(presignedGetObjectArgs).ConfigureAwait(false);
            return objectStat;
        }
        catch (MinioException e)
        {
            logger.Log(LogLevel.Error, $"Cannot get file url: {filename} \nError: {e.Message}");
        }

        return null;
    }

    public async Task<int> UploadFile(string filename, Stream fileStream, CancellationToken cancellationToken = default)
    {
        try
        {
            // Make a bucket on the server, if not already present.
            var beArgs = new BucketExistsArgs()
                .WithBucket(_bucketName);
            
            var found = await minio.BucketExistsAsync(beArgs, cancellationToken).ConfigureAwait(false);
            
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(_bucketName);
                await minio.MakeBucketAsync(mbArgs, cancellationToken).ConfigureAwait(false);
            }
            // Upload a file to bucket.
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(filename)
                .WithStreamData(fileStream); 
            var putObjectResult =  await minio.PutObjectAsync(putObjectArgs, cancellationToken).ConfigureAwait(false);
            
            logger.Log(LogLevel.Information, $"Successfully uploaded {filename}" );
            return 1;
        }
        catch (MinioException e)
        {
            logger.Log(LogLevel.Error, $"File Upload Error: {filename}\nError: {e.Message}");
            return 0;
        }   
    }

    public async Task<int> UpdateFile(string fileName, Stream fileStream, CancellationToken cancellationToken = default)
    {
        var deleteFileResult = await DeleteFile(fileName, cancellationToken);

        if (deleteFileResult == 0)
            return 0;

        var uploadFileResult = await UploadFile(fileName, fileStream, cancellationToken);

        return uploadFileResult == 0 ? 0 : 1;
    }

    public async Task<int> DeleteFile(string fileName, CancellationToken cancellationToken = default)
    {
        var removeObjectArgs = new RemoveObjectArgs().WithObject(fileName).WithBucket(_bucketName);

        if (removeObjectArgs == null)
            return 0;

        try
        {
            await minio.RemoveObjectAsync(removeObjectArgs, cancellationToken).ConfigureAwait(false);
        }
        catch (MinioException e)
        {
            logger.Log(LogLevel.Error, $"Cannot delete file: {fileName} \nError: {e.Message}");
        }

        return 1;
    }
}