namespace Doccure.QueueService.Entities
{
    public class PatientQueue
    {
        public int PatientQueueId { get; set; }
        public string PatientQueueName { get; set; }
        public int QueueNumber { get; set; }
        public string Status { get; set; }
    }
}
