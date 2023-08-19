namespace CameraShop.Domain
{
    public class Cart : Entity
    {
        public int UserId { get; set; }
        public int? OrderId { get; set; }
        public bool ActiveCart { get; set; }
        public bool MovedToOrder { get; set; }
        public Order Order { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }

}
