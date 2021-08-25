using LowCost.Infrastructure.Manage_Files;
using LowCost.Repo.Repositories.Interfaces.Files;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Implementation.Files
{
    public class FilesRepository : IFilesRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesRepository(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public bool CheckFileExist(FileBaseData fileBaseData)
        {
            string filePath = "/Uploads/" + fileBaseData.folderName + "/" + fileBaseData.fileName + fileBaseData.fileExtention;
            FileInfo file = new FileInfo(_hostingEnvironment.WebRootPath + filePath);
            if (file.Exists)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteFileAsync(FileBaseData fileBaseData)
        {
            string filePath = "/Uploads/" + fileBaseData.folderName + "/" + fileBaseData.fileName + fileBaseData.fileExtention;
            FileInfo file = new FileInfo(_hostingEnvironment.WebRootPath + filePath);
            if (file.Exists)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                file.Delete();
            }
        }

        public async Task SaveFileAsync(SavingFileData savingFileData)
        {
            using (var file = new FileStream(_hostingEnvironment.WebRootPath + "/Uploads/" 
                + savingFileData.folderName + "/" + savingFileData.fileName + savingFileData.fileExtention
                , FileMode.Create))
            {
                await savingFileData.File.CopyToAsync(file);
            }
        }
    }
}
