using Core.Models.Billing;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public string PuctureUrl { get; set; } = null!;
        public ProductType ProductType { get; set; } = null!;
        public ProductBrand ProductBrand { get; set; } = null!;
    }
}
