using DotNet.Sorter.Domain.IRepositories;
using System.Collections.Generic;

namespace DotNet.Sorter.Domain.Services
{
    public class FileService<T> : IFileService<T>
    {
        private ILocalRepository<T> localRepository;

        public FileService(ILocalRepository<T> localRepository)
        {
            this.localRepository = localRepository;
        }

        public IList<T> ReadFromFile(string path)
        {
            return localRepository.GetList(path);
        }

        public bool WriteToFile(string path, IList<T> dataList)
        {
            return localRepository.Save(path, dataList);
        }
    }
}
