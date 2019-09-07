using DotNet.Sorter.Data.Sources;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotNet.Sorter.Tests.Data.Sources
{
    class FileSourceTests
    {
        private IFileSource fileSource;
        const string path = @"D:\Projects\DotNet.Sorter\DotNet.Sorter\unsorted-names-list.txt";
        static IList<string> stringList = new List<string>(){
                "Orson Milka Iddins",
                "Erna Dorey Battelle",
                "Flori Chaunce Franzel",
                "Odetta Sue Kaspar",
                "Roy Ketti Kopfen",
                "Madel Bordie Mapplebeck",
                "Selle Bellison",
                "Leonerd Adda Mitchell Monaghan",
                "Debra Micheli",
                "Hailey Avie Annakin"
            };

        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileSource, FileSource>()
                .BuildServiceProvider();
            fileSource = serviceProvider.GetService<IFileSource>();
        }

        [Test, TestCaseSource("GetTestData")]
        public void Read_ShouldReturnExpectedResult(List<string> expectedResult)
        {
            var result = fileSource.Read(path);
            Assert.AreEqual(expectedResult.ToArray(), result);
        }

        [Test]
        public void Read_ShouldReturnFileNotFoundException_WhenGivenEmptyString()
        {
            var ex = Assert.Throws<FileNotFoundException>(() => fileSource.Read(""));
            Assert.That(ex.Message, Is.EqualTo("File Not Found"));
        }

        [Test, TestCase(true)]
        public void Write_ShouldReturnTrue_WhenSucceed(bool expectedResult) {
            var result = fileSource.Write(path, stringList.ToArray());
            Assert.AreEqual(expectedResult, result);
        }

        [Test, TestCase(false)]
        public void Write_ShouldReturnFalse_WhenGivenEmptyPath(bool expectedResult)
        {
            var result = fileSource.Write("", stringList.ToArray());
            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable GetTestData()
        {
            TestCaseData data;
            data = new TestCaseData(stringList);
            yield return data;

        }
    }
}
