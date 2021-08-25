using LowCost.Infrastructure.Manage_Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Interfaces.Files
{
    public interface IFilesRepository
    {
        /// <summary>
        /// Saving Image To Uploads Folder in Root Folder Asynchronous
        /// </summary>
        /// <param name="savingFileData"></param>
        /// <returns></returns>
        Task SaveFileAsync(SavingFileData savingFileData);
        /// <summary>
        /// Check If File Is Exist Or Not
        /// </summary>
        /// <param name="fileBaseData"></param>
        /// <returns></returns>
        bool CheckFileExist(FileBaseData fileBaseData);
        /// <summary>
        /// Deleting File From Uploads Folder In Root Folder Asynchronous
        /// </summary>
        /// <param name="fileBaseData"></param>
        /// <returns></returns>
        Task DeleteFileAsync(FileBaseData fileBaseData);
    }
}
