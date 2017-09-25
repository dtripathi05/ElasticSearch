using System.Text;
using System.Threading.Tasks;
namespace ElasticSearch
{
    public class Person
    {
        public string FirstName
        {
            get;
            private set;
        }
        public string LastName
        {
            get;
            private set;
        }
        public int Age
        {
            get;
            private set;
        }
        public string FatherName
        {
            get;
            private set;
        }
        public string MobileNumber
        {
            get;
            private set;
        }
        public string AdharNumber
        {
            get;
            private set;
        }
        public Person(string firstName, string lastName, int age, string fatherName, string mobileNumber, string adharNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FatherName = fatherName;
            MobileNumber = mobileNumber;
            AdharNumber = adharNumber;
        }
        public override string ToString()
        {
            return ($"Name is ={FirstName} {LastName}\nAge={Age}\nFatherName={FatherName}\nMobileNumber={MobileNumber}");
        }
    }
}
