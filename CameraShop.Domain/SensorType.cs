namespace CameraShop.Domain
{

    public class SensorType : Entity
    {
        public string Type { get; set; }
        public virtual ICollection<Camera> Cameras { get; set; }
    }

}
