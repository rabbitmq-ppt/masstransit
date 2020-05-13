namespace Common
{
    public static class RabbitMqConstants
    {
        public const string PatientCreatedQueue = "patient-created-queue";
        public const string SecondQueue = "patient-deleted-queue";        

        public const string HostName = @"rabbitmq://localhost/mass-transit";        
        public const string UserName = "guest";
        public const string Password = "guest";
    }
}
