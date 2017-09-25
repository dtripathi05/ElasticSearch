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
            Post post = new Post();
            post.AddNewIndex(new Person("Deependra", "Tripathi", 23, "Bimal kishore Tripathi", "7503757272"));
            post.AddNewIndex(new Person("Subham", "Saraf", 23, "Shiv Kumar Saraf", "750375000"));
            Search index = new Search();
            var result = index.GetResult();
            if (result.FirstOrDefault<Person>(x => x.FirstName == "Deependra") != null)
            {
                Console.WriteLine("true");
            }
            var result2 = index.GetResult("Subham");
            foreach(var i in result2)
            {
                Console.WriteLine(i);
            }
            var result3 = index.GetResult("");
            Console.WriteLine(result3.Count);
            Console.ReadKey();
        }
    }
}

