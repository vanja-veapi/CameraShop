namespace CameraShop.Domain
{
    public class UseCaseLog : Entity
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public DateTime ExecutionDateTime { get; set; }
        public string Data { get; set; }
        public int Duration { get; set; }
        public User User { get; set; }
        public UseCase UseCase { get; set; }

    }
}
