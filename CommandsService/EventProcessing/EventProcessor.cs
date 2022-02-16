namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        public void ProcessEvent(string message)
        {
            throw new System.NotImplementedException();
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined,
    }
}
