using ECommerce.Application.Interfaces.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment env;
        private readonly string _wwwroot;
        private const string folderPath = "images";

        public LocalStorage(IWebHostEnvironment env)
        {
            this.env = env;
            _wwwroot = env.WebRootPath;
        }
        public Task DeleteAsync(string path, string fileName)
        {
            path = folderPath;
            var fileToDelete = Path.Combine($"{_wwwroot}/{path}", fileName);
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);

            return Task.CompletedTask;
        }

        public List<string> GetFiles(string path)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string path, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string fileName, string pathOrContainer)>> UploadManyAsync(Guid productId, string path, IFormFileCollection files)
        {
            DateTime dateTime = DateTime.Now;

            if (!Directory.Exists($"{_wwwroot}/{folderPath}"))
                Directory.CreateDirectory($"{_wwwroot}/{folderPath}");

            List<(string fileName, string pathOrContainer)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileExtension = Path.GetExtension(file.FileName);


                string newFileName = $"{file.FileName.ToLower()}_{dateTime.Date:dd_MM_yyyy}{fileExtension}";
                path = Path.Combine($"{_wwwroot}/{folderPath}", newFileName);

                await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);
                await file.CopyToAsync(stream);
                await stream.FlushAsync();
                datas.Add((newFileName, path));
            }
            return datas;
        }
        public Task<(string fileName, string pathOrContainer)> UploadAsync(Guid id, string pathOrContainerName, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
