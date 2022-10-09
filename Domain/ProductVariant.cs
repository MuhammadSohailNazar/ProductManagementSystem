using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Domain
{
    public class ProductVariant
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool HasImages { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }
        public int StockNotificationLimit { get; set; }
        public string VariantCode { get; set; }
        public bool TrackStockQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public string BaseCurrency { get; set; }
        public bool IsDimensionAvailable { get; set; }
        public int ThresholdLimit { get; set; }
    }
}
