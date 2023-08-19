namespace CameraShop.Domain
{
    public class Discount : Entity
    {
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CameraId { get; set; }
        public Camera Camera { get; set; }
    }
}
