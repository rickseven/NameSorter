using System.Collections.Generic;
using DotNet.Sorter.Domain.Entities;

namespace DotNet.Sorter.Domain.Services
{
    public class PersonService : IPersonService
    {
        IFileService<Person> fileService;

        public PersonService(IFileService<Person> fileService)
        {
            this.fileService = fileService;
        }

        public IList<Person> GetPersonListFromFile(string path)
        {
            return fileService.ReadFromFile(path);
        }

        public bool SavePersonListToFile(string path, IList<Person> personList)
        {
            return fileService.WriteToFile(path, personList);
        }
    }
}
