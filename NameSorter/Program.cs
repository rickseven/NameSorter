
namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize NameSorter class with passing argument on constructor
            INameSorter nameSorter = new NameSorter(args[0]);
            // call method ascendingByLastName to process sorting
            nameSorter.ascendingByLastName();
        }
    }
}
