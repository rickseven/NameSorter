
namespace NameSorter
{
    public class Name : IName
    {
        public string fullName { get; set; }

        public Name(string fullName) {
            this.fullName = fullName;
        }

        /// <summary>
        /// Get Last Name
        /// </summary>
        /// <returns></returns>
        public string getLastName()
        {
            // split full name by space to string array
            string[] fullNameSplited = this.fullName.Split(' ');
            // get a last name of splited name array
            string lastName = fullNameSplited[fullNameSplited.Length - 1];
            // return a last name
            return lastName;
        }
    }
}
