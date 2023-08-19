namespace CameraShop.Domain
{
    public class UseCase : Entity
    {
        public string Name { get; set; }
        public int UseCaseNumber { get; set; }
        public ICollection<UserUseCase> UserUseCases { get; set; }
        public ICollection<UseCaseLog> UseCaseLogs { get; set; }

    }
}
