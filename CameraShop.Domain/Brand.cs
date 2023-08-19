namespace CameraShop.Domain
{
    public class Brand : Entity
    {
        public string BrandName { get; set; }
        public virtual ICollection<Camera> Cameras { get; set; } 
    }

}
