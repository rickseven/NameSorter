using DotNet.Sorter.Domain.Entities;
using System.Collections.Generic;

namespace DotNet.Sorter.Domain.Services
{
    public interface IPersonService 
    {
        IList<Person> GetPersonListFromFile(string path);
        bool SavePersonListToFile(string path, IList<Person> personList);
    }
}
