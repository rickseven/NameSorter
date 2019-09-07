using DotNet.Sorter.Data.Repositories;
using DotNet.Sorter.Data.Sources;
using DotNet.Sorter.Domain.Entities;
using DotNet.Sorter.Domain.IRepositories;
using DotNet.Sorter.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace DotNet.Sorter.Tests.Domain.Services
{
    class PersonServiceTests
    {
        private IPersonService personService;
        const string path = @"D:\Projects\DotNet.Sorter\DotNet.Sorter\unsorted-names-list.txt";

        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileSource, FileSource>()
                .AddSingleton<ILocalRepository<Person>, PersonLocalRepository>()
                .AddSingleton<IFileService<Person>, FileService<Person>>()
                .AddSingleton<IPersonService, PersonService>()
                .BuildServiceProvider();
            personService = serviceProvider.GetService<IPersonService>();
        }

        [Test, TestCaseSource("GetPersonListTestData")]
        public void GetPersonListFromFile_ShouldReturnExpectedResult(IList<Person> expectedResult)
        {
            var result = personService.GetPersonListFromFile(path);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
        }

        [Test, TestCase(0)]
        public void GetPersonListFromFile_ShouldReturnEmpty_WhenGivenEmptyPath(int expectedResult) {
            var result = personService.GetPersonListFromFile("");
            Assert.AreEqual(expectedResult, result.Count);
        }

        private static IEnumerable GetPersonListTestData()
        {
            TestCaseData data;

            IList<Person> personList = new List<Person>();
            personList.Add(new Person { FullName = "Orson Milka Iddins" });
            personList.Add(new Person { FullName = "Erna Dorey Battelle" });
            personList.Add(new Person { FullName = "Flori Chaunce Franzel" });
            personList.Add(new Person { FullName = "Odetta Sue Kaspar" });
            personList.Add(new Person { FullName = "Roy Ketti Kopfen" });
            personList.Add(new Person { FullName = "Madel Bordie Mapplebeck" });
            personList.Add(new Person { FullName = "Selle Bellison" });
            personList.Add(new Person { FullName = "Leonerd Adda Mitchell Monaghan" });
            personList.Add(new Person { FullName = "Debra Micheli" });
            personList.Add(new Person { FullName = "Hailey Avie Annakin" });
            data = new TestCaseData(personList);
            yield return data;

        }
    }
}
