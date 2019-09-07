using DotNet.Sorter.Data.Sources;
using DotNet.Sorter.Domain.Entities;
using DotNet.Sorter.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Sorter.Data.Repositories
{
    public class PersonLocalRepository : ILocalRepository<Person>
    {
        private IFileSource fileSource;

        public PersonLocalRepository(IFileSource fileSource)
        {
            this.fileSource = fileSource;
        }

        public IList<Person> GetList(string path)
        {
            IList<Person> personList = new List<Person>();

            try
            {
                string[] stringArr = fileSource.Read(path);
                foreach (var v in stringArr)
                {
                    personList.Add(new Person { FullName = v });
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
            return personList;
        }

        public bool Save(string path, IList<Person> dataList)
        {
            string[] stringArr = dataList.Select(x => x.FullName).ToArray();

            return fileSource.Write(path, stringArr);
        }
    }
}
