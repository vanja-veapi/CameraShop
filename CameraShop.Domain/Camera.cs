namespace CameraShop.Domain
{
    public class Camera : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Megapixels { get; set; }
        public string ISO { get; set; }
        public string VideoResolution { get; set; }
        public bool WifiSupport { get; set; }
        public bool BluetoothSupport { get; set; }
        public bool LensMount { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int SensorTypeId { get; set; }
        public Brand Brand { get; set; }
        public SensorType SensorType { get; set; }
        public ICollection<CameraImage> CameraImages { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }

}
