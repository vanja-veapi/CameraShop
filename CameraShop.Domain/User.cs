namespace CameraShop.Domain
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool IsAccountActivated { get; set; } = false;
        public string UniqueActivisonCode { get; set; }

        public Role Role { get; set; }
        public ICollection<UserUseCase> UserUseCases { get; set; }
        public ICollection<UseCaseLog> UseCaseLogs { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
