
namespace DotNet.Sorter.Domain.Entities
{
    public class Person
    {
        public string FullName { get; set; }
        public string FirstName {
            get {
                return FullName.Trim().Split(' ')[0];
            }
            set {
                FirstName = value;
            }
        }
    }
}
