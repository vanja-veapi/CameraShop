namespace CameraShop.Domain
{
    public class Order : Entity
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsOrderComplete { get; set; } = false;
        public Cart Cart { get; set; }
        public User User { get; set; }

    }
}
