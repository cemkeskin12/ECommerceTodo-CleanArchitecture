using ECommerce.Application.Interfaces.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage storage;

        public StorageService(IStorage storage)
        {
            this.storage = storage;
        }

        public string StorageName { get => storage.GetType().Name;}

        public Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<(string fileName, string pathOrContainer)>> UploadManyAsync(Guid id, string pathOrContainerName, IFormFileCollection files)
        {
            throw new NotImplementedException();
        }
        public Task<(string fileName, string pathOrContainer)> UploadAsync(Guid id, string pathOrContainerName, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
