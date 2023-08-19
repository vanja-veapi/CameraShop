namespace CameraShop.Domain
{

    public class CartItem : Entity
    {
        public int CartId { get; set; }
        public int CameraId { get; set; }
        public int Quantity { get; set; }
        public Camera Camera { get; set; }
        public Cart Cart { get; set; }
    }
}
