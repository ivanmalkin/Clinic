using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        [Column(TypeName = "decimal(20,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPrefferedService { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
