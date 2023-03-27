
namespace Catalog.Application.Common
{
    public class QueryResult<T> where T : class
    {
        public int MessageCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
