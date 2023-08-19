using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int DeletedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }
    }
}
