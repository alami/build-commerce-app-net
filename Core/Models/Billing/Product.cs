using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Billing
{
//    [Table("products")]
    public class Product : BaseEntity
    {
//        [Column("name")]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public string PuctureUrl { get; set; } = null!;
        public ProductType ProductType { get; set; } = null!;
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; } = null!;
        public int ProductBrandId { get; set; }

    }
}
