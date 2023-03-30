
namespace EventBus.Messages.Events
{
    public class CreateOrderEvent : IntegrationBaseEvent
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
    }
}
