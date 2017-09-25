using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearch;
using Nest;
namespace ElasticSearchMain
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConnectClient connect = new ConnectClient();
            Post post = new Post("person","record");
            post.AddNewIndex(new Person("Deependra", "Tripathi", 23, "Bimal kishore Tripathi", "7503757272","abc123"));
            post.AddNewIndex(new Person("Subham", "Saraf", 23, "Shiv Kumar Saraf", "750375000","xyz987"));
            Search index = new Search();
            var result = index.GetResult("person","record");
            if (result.FirstOrDefault<Person>(x => x.FirstName == "Deependra") != null)
            {
                Console.WriteLine("Record Exists\n");
            }
            var result2 = index.GetResult("xyz987", "person", "record");
            foreach(var i in result2)
            {
                Console.WriteLine(i+"\n");
            }
            var result3 = index.GetResult("", "person", "record");
            Console.WriteLine("All The Records\n");
            foreach (var i in result3)
            {
                Console.WriteLine(i + "\n");
            }
            Console.WriteLine("Number Of Records ="+result3.Count+"\n");
            var delete = new Delete();
            Console.WriteLine(delete.DeleteIndex("person"));
            Console.ReadKey();
        }
    }
}

