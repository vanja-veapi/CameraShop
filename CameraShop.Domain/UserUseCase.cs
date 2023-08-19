namespace CameraShop.Domain
{
    public class UserUseCase : Entity
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public User User { get; set; }
        public UseCase UseCase { get; set; }
    }
}
