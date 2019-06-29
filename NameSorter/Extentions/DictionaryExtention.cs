using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Extentions
{
    public static class DictionaryExtention
    {
        /// <summary>
        /// Order By Last Name Ascending
        /// </summary>
        /// <param name="nameDictionary"></param>
        /// <returns></returns>
        public static IDictionary<int, Name> OrderByLastNameAscending(this IDictionary<int, Name> nameDictionary) {
            var sortedDict = (from name in nameDictionary orderby name.Value.getLastName() ascending select name)
                .ToDictionary(name => name.Key,name => name.Value);
            return sortedDict;
        }
    }
}
