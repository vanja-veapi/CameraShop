namespace CameraShop.Domain
{
    public class Stock : Entity
    {
        public int Quantity { get; set; }
        public int CameraId { get; set; }
        public int StockPlaceId { get; set; }
        public Camera Camera { get; set; }
        public StockPlace StockPlace { get; set; }
    }
}
