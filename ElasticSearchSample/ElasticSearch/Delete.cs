using Nest;
namespace ElasticSearch
{
    public class Delete
    {
        public IDeleteIndexResponse DeleteIndex(string index)
        {
            var response = ConnectClient.client.DeleteIndex(index);
            return response;
        }
    }
}
