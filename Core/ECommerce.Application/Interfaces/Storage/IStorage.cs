using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Storage
{
    public interface IStorage
    {
        Task<(string fileName, string pathOrContainer)> UploadAsync(Guid id, string containerName, IFormFile file);
        Task<List<(string fileName, string pathOrContainer)>> UploadManyAsync(Guid id,string pathOrContainerName, IFormFileCollection files);
        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
