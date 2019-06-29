using NameSorter.Extentions;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter
{
    public class NameSorter : INameSorter
    {
        private string filePath;
        public NameSorter(string filePath = "") {
            Console.WriteLine(@"
                _   __                        _____            __           
               / | / /___ _____ ___  ___     / ___/____  _____/ /____  _____
              /  |/ / __ `/ __ `__ \/ _ \    \__ \/ __ \/ ___/ __/ _ \/ ___/
             / /|  / /_/ / / / / / /  __/   ___/ / /_/ / /  / /_/  __/ /    
            /_/ |_/\__,_/_/ /_/ /_/\___/   /____/\____/_/   \__/\___/_/     
            By Moh Eric                       [Sort Ascending By Last Name]
            ");
            
            if (!filePath.Equals(""))
            {
                this.filePath = filePath;
            }
            else {
                Console.WriteLine("Please give a parameter as filepath");
                Console.WriteLine("Example: NameSorter ./filename.txt");
            }
        }

        /// <summary>
        /// Ordering Ascending By Last Name
        /// </summary>
        public void ascendingByLastName()
        {
            try
            {
                // display input filepath
                Console.WriteLine(this.filePath);
                // read the file using System.IO namespace
                string[] nameList = File.ReadAllLines(this.filePath);

                // populate name list to dictionary
                IDictionary<int, Name> nameDictionary = new Dictionary<int, Name>();
                for (int key = 0; key < nameList.Length; key++)
                {
                    string fullName = nameList[key].Trim();
                    if (!fullName.Equals(""))
                    {
                        // display full name
                        Console.WriteLine(fullName);
                        // add name to dictionary
                        nameDictionary.Add(key, new Name(fullName));
                    }

                }
                Console.WriteLine("");
                Console.WriteLine("The Result saved to : sorted-names-list.txt");
                //sorting last name dictionary by ascending with extention function
                IDictionary<int, Name> sortedNameDictionary = nameDictionary.OrderByLastNameAscending();

                // using a StreamWriter object to write a file 
                StreamWriter streamWriter = new StreamWriter("./sorted-names-list.txt");

                // display full name order by last name ascending 
                foreach (var sortedName in sortedNameDictionary)
                {
                    // tricky in here, get sorted fullname by sorted lastname key
                    string fullName = nameList[sortedName.Key].Trim();
                    Console.WriteLine(fullName);
                    streamWriter.WriteLine(fullName);
                }

                // close the file
                streamWriter.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw new FileNotFoundException("File Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}
