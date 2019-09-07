
using DotNet.Sorter.Data.Repositories;
using DotNet.Sorter.Data.Sources;
using DotNet.Sorter.Domain.Entities;
using DotNet.Sorter.Domain.IRepositories;
using DotNet.Sorter.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileSource, FileSource>()
                .AddSingleton<ILocalRepository<Person>, PersonLocalRepository>()
                .AddSingleton<IFileService<Person>, FileService<Person>>()
                .AddSingleton<IPersonService, PersonService>()
                .BuildServiceProvider();
            IPersonService personService = serviceProvider.GetService<IPersonService>();

            //run NameSorter
            new NameSorter(args[0], personService)
            .LoadDataFromFile() //load data from file
            .Print() //print unsorted data
            .AscendingByFirstName() //sorted ascending by first name
            .StoreDataToFile() //store data to file
            .Print(); //print sorted data

        }
    }
}
