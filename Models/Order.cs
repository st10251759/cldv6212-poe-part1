using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10251759_CLDV6212_POE_Par1.Models
{
    public class Order : ITableEntity
    {
        [Key]
        public int OrderId { get; set; }

        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string? Status { get; set; }

        public decimal? TotalPrice { get; set; }

        public virtual ICollection<OrderRequest> OrderRequests { get; set; } = new List<OrderRequest>();

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; } = null!;

        // ITableEntity implementation
        public string PartitionKey { get; set; }  // Can be based on OrderId.ToString()
        public string RowKey { get; set; }  // Can be based on OrderId.ToString()
        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
