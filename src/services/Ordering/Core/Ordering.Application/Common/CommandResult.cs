namespace Ordering.Application.Common
{
    public class CommandResult
    {
        public int MessageCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
