using System.Collections.Generic;
using System.Linq;
namespace ElasticSearch
{
    public class Search
    {
        public List<Person> GetResult(string index,string type)
        {

            if (ConnectClient.client.IndexExists("person").Exists)
            {
                var response = ConnectClient.client.Search<Person>( i => i.Index(index).Type(type));
                return response.Documents.ToList();
            }
            return null;
        }

        public List<Person> GetResult(string condition ,string index,string type)
        {
            if (ConnectClient.client.IndexExists("person").Exists)
            {
                var query = condition;

                return ConnectClient.client.SearchAsync<Person>(s => s
                .Index(index)
                .Type(type)
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
}
