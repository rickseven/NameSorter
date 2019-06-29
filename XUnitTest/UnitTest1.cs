using NameSorter;
using NameSorter.Extentions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Should_FileNotFoundException_When_FileNotFound() {
            INameSorter nameSorter = new NameSorter.NameSorter("filename.txt");
            // action
            Action act = () => nameSorter.ascendingByLastName();
            // assert throw
            Xunit.Assert.Throws<FileNotFoundException>(act);
        }

        [Fact]
        public void Should_ReturnExpectedNameList_When_OrderByLastNameAscending()
        {
            // initialize test data
            string[] nameList = {
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

            IDictionary<int, Name> nameDictionary = new Dictionary<int, Name>();
            for (int key = 0; key < nameList.Length; key++) {
                nameDictionary.Add(key, new Name(nameList[key]));
            }

            // initialize expected data
            string[] expectedNameList = {
                "Hailey Avie Annakin",
                "Erna Dorey Battelle",
                "Selle Bellison",
                "Flori Chaunce Franzel",
                "Orson Milka Iddins",
                "Odetta Sue Kaspar",
                "Roy Ketti Kopfen",
                "Madel Bordie Mapplebeck",
                "Debra Micheli",
                "Leonerd Adda Mitchell Monaghan"
            };

            IDictionary<int, Name> expectedNameDictionary = new Dictionary<int, Name>();
            for (int key = 0; key < expectedNameList.Length; key++)
            {
                expectedNameDictionary.Add(key, new Name(expectedNameList[key]));
            }

            // Testing
            IDictionary<int, Name> sortedNameDictionary = nameDictionary.OrderByLastNameAscending();
            // Check name list must equal with expected 
            CollectionAssert.AreEqual(expectedNameDictionary.Values.Select(x => x.fullName).ToList(), sortedNameDictionary.Values.Select(x => x.fullName).ToList());

        }
    }
}
