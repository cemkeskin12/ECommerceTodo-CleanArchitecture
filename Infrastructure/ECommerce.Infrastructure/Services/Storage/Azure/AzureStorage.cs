using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ECommerce.Application.Interfaces.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        readonly BlobServiceClient blobServiceClient;
        BlobContainerClient BlobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            this.blobServiceClient = new(configuration["Storage:Azure"]);
        }
        public async Task DeleteAsync(string containerName, string fileName)
        {
            BlobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = BlobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            BlobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return BlobContainerClient.GetBlobs().Select(x => x.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            BlobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return BlobContainerClient.GetBlobs().Any(x => x.Name == fileName);
        }
        public async Task<(string fileName, string pathOrContainer)> UploadAsync(Guid id, string containerName, IFormFile file)
        {
            BlobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await BlobContainerClient.CreateIfNotExistsAsync();
            await BlobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            (string fileName, string pathOrContainer) data = new();

            string fileExtension = Path.GetExtension(file.FileName);

            DateTime dateTime = DateTime.Now;
            string newFileName = $"{file.FileName}_{id}_{dateTime.Date:dd_MM_yyyy}_{dateTime.Millisecond}{dateTime.Microsecond}{fileExtension}";


            BlobClient blobClient = BlobContainerClient.GetBlobClient(newFileName);
            await blobClient.UploadAsync(file.OpenReadStream());
            data.fileName = newFileName;
            data.pathOrContainer = containerName;


            return data;
        }
        public async Task<List<(string fileName, string pathOrContainer)>> UploadManyAsync(Guid id, string containerName, IFormFileCollection files)
        {
            BlobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await BlobContainerClient.CreateIfNotExistsAsync();
            await BlobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainer)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                DateTime dateTime = DateTime.Now;
                string newFileName = $"{file.FileName}_{id}_{dateTime.Date:dd_MM_yyyy}_{dateTime.Millisecond}{dateTime.Microsecond}{fileExtension}";


                BlobClient blobClient = BlobContainerClient.GetBlobClient(newFileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((newFileName, containerName));
            }
            return datas;
        }
        
    }
}
