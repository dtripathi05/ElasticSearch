using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
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
        public Person(string firstName, string lastName, int age, string fatherName, string mobileNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FatherName = fatherName;
            MobileNumber = mobileNumber;
        }
        public override string ToString()
        {
            return ($" Name is ={FirstName} {LastName}\nAge={Age}\nFatherName={FatherName}\nMobileNumber={MobileNumber}");
        }
    }

    public class ConnectClient
    {
        public static Uri node;
        public static ElasticClient client = null;
        public static ConnectionSettings settings;
        public ConnectClient()
        {
            node = new Uri("http://172.16.14.121:9200/");
            settings = new ConnectionSettings(node);
            var rese = settings.DefaultIndex("person");
            client = new ElasticClient(settings);
            client.Index("person");
            var indexsettings = new IndexSettings();
            indexsettings.NumberOfReplicas = 2;
            indexsettings.NumberOfShards = 1;
        }
    }
    public class Search
    {
        public List<Person> GetResult()
        {

            if (ConnectClient.client.IndexExists("person").Exists)
            {
                var response = ConnectClient.client.Search<Person>();
                return response.Documents.ToList();
            }
            return null;
        }

        public List<Person> GetResult(string condition)
        {
            if (ConnectClient.client.IndexExists("person").Exists)
            {
                var query = condition;

                return ConnectClient.client.SearchAsync<Person>(s => s
                .From(0)
                .Take(10)
                .Query(qry => qry
                    .Bool(b => b
                        .Must(m => m
                            .QueryString(qs => qs
                                .DefaultField("_all")
                                .Query(query)))))).Result.Documents.ToList();
            }
            return null;
        }
    }
    public class Post
    {
        public void AddNewIndex(Person _person)
        {
            ConnectClient.client.IndexAsync<Person>(_person, null);
        }
    }
}
