using Azure;
using Azure.Data.Tables;
using System.ComponentModel.DataAnnotations;

namespace ST10251759_CLDV6212_POE_Par1.Models
{
    public class OrderRequest : ITableEntity
    {
        [Key]
        public int OrderRequestId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string? OrderStatus { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;

        // ITableEntity implementation
        public string PartitionKey { get; set; }  // Can be based on OrderId.ToString() or OrderRequestId.ToString()
        public string RowKey { get; set; }  // Can be based on OrderRequestId.ToString()
        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
