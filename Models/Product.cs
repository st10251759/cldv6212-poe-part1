﻿using Azure;
using Azure.Data.Tables;
using System;
using System.ComponentModel.DataAnnotations;

namespace ST10251759_CLDV6212_POE_Par1.Models
{
    public class Product : ITableEntity
    {
        [Key]
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? Price { get; set; }

        public string? Category { get; set; }

        public bool? Availability { get; set; }

        public string? ImageUrlPath { get; set; }  // URL to the image in Blob Storage

        // ITableEntity implementation
        public string? PartitionKey { get; set; }  // Typically used for logical partitioning, e.g., Category
        public string? RowKey { get; set; }  // Unique identifier, e.g., ProductId.ToString()
        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}