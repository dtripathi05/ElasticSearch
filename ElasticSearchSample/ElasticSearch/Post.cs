using Nest;
namespace ElasticSearch
{
    public class Post
    {
        private string _index { get; set; }
        private string _type { get; set; }
        public Post(string index, string type)
        {
            _index = index;
            _type = type;
        }
        public IIndexResponse AddNewIndex(Person person)
        {
            var response = ConnectClient.client.Index(person, i => i.Index(_index).Type(_type).Id(person.AdharNumber));
            return response;
        }
    }
}
