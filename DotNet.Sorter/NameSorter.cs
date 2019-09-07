using DotNet.Sorter.Domain.Entities;
using DotNet.Sorter.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Sorter
{
    public class NameSorter
    {
        private string path = "";
        private IPersonService personService;
        private IList<Person> personList;

        public NameSorter(string path, IPersonService personService)
        {
            Console.WriteLine(@"
                _   __                        _____            __           
               / | / /___ _____ ___  ___     / ___/____  _____/ /____  _____
              /  |/ / __ `/ __ `__ \/ _ \    \__ \/ __ \/ ___/ __/ _ \/ ___/
             / /|  / /_/ / / / / / /  __/   ___/ / /_/ / /  / /_/  __/ /    
            /_/ |_/\__,_/_/ /_/ /_/\___/   /____/\____/_/   \__/\___/_/     
            By Moh Eric                       
            ");

            if (path.Equals(""))
            {
                Console.WriteLine("Please give a parameter as filepath");
                Console.WriteLine("Example: NameSorter ./filename.txt");
            }

            this.path = path;
            this.personService = personService;
        }

        public NameSorter LoadDataFromFile() {
            personList = personService.GetPersonListFromFile(path);
            return this;
        }

        public NameSorter StoreDataToFile() {
            if (!personService.SavePersonListToFile("sorted-names-list.txt", personList)) {
                Console.WriteLine("Failed write data to file");
            }
            return this;
        }

        public NameSorter Print() {
            foreach (var person in personList) {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine();
            return this;
        }

        public NameSorter AscendingByFirstName() {
            personList = personList.OrderBy(x => x.FirstName).ToList();
            return this;
        }
    }
}
