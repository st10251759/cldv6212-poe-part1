using Azure;
using Azure.Data.Tables;
using ST10251759_CLDV6212_POE_Par1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10251759_CLDV6212_POE_Par1.Services
{
    public class TableStorageService
    {
        private readonly TableClient _productTableClient;
        private readonly TableClient _customerTableClient;
        private readonly TableClient _orderTableClient;
        private readonly TableClient _orderRequestTableClient;

        public TableStorageService(string connectionString)
        {
            _productTableClient = new TableClient(connectionString, "Products");
            _customerTableClient = new TableClient(connectionString, "Customers");
            _orderTableClient = new TableClient(connectionString, "Orders");
            _orderRequestTableClient = new TableClient(connectionString, "OrderRequests");
        }

        // Product Operations
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = new List<Product>();
            await foreach (var product in _productTableClient.QueryAsync<Product>())
            {
                products.Add(product);
            }
            return products;
        }

        public async Task AddProductAsync(Product product)
        {
            if (string.IsNullOrEmpty(product.PartitionKey) || string.IsNullOrEmpty(product.RowKey))
            {
                throw new ArgumentException("PartitionKey and RowKey must be set.");
            }

            try
            {
                await _productTableClient.AddEntityAsync(product);
            }
            catch (RequestFailedException ex)
            {
                throw new InvalidOperationException("Error adding product to Table Storage", ex);
            }
        }

        public async Task DeleteProductAsync(string partitionKey, string rowKey)
        {
            await _productTableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<Product?> GetProductAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _productTableClient.GetEntityAsync<Product>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
        }

        // Customer Operations
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customers = new List<Customer>();
            await foreach (var customer in _customerTableClient.QueryAsync<Customer>())
            {
                customers.Add(customer);
            }
            return customers;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.PartitionKey) || string.IsNullOrEmpty(customer.RowKey))
            {
                throw new ArgumentException("PartitionKey and RowKey must be set.");
            }

            try
            {
                await _customerTableClient.AddEntityAsync(customer);
            }
            catch (RequestFailedException ex)
            {
                throw new InvalidOperationException("Error adding customer to Table Storage", ex);
            }
        }

        public async Task DeleteCustomerAsync(string partitionKey, string rowKey)
        {
            await _customerTableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<Customer?> GetCustomerAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _customerTableClient.GetEntityAsync<Customer>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
        }

        // Order Operations
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = new List<Order>();
            await foreach (var order in _orderTableClient.QueryAsync<Order>())
            {
                orders.Add(order);
            }
            return orders;
        }

        public async Task AddOrderAsync(Order order)
        {
            if (string.IsNullOrEmpty(order.PartitionKey) || string.IsNullOrEmpty(order.RowKey))
            {
                throw new ArgumentException("PartitionKey and RowKey must be set.");
            }

            try
            {
                await _orderTableClient.AddEntityAsync(order);
            }
            catch (RequestFailedException ex)
            {
                throw new InvalidOperationException("Error adding order to Table Storage", ex);
            }
        }

        public async Task DeleteOrderAsync(string partitionKey, string rowKey)
        {
            await _orderTableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<Order?> GetOrderAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _orderTableClient.GetEntityAsync<Order>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
        }

        // OrderRequest Operations
        public async Task<List<OrderRequest>> GetAllOrderRequestsAsync()
        {
            var orderRequests = new List<OrderRequest>();
            await foreach (var orderRequest in _orderRequestTableClient.QueryAsync<OrderRequest>())
            {
                orderRequests.Add(orderRequest);
            }
            return orderRequests;
        }

        public async Task AddOrderRequestAsync(OrderRequest orderRequest)
        {
            if (string.IsNullOrEmpty(orderRequest.PartitionKey) || string.IsNullOrEmpty(orderRequest.RowKey))
            {
                throw new ArgumentException("PartitionKey and RowKey must be set.");
            }

            try
            {
                await _orderRequestTableClient.AddEntityAsync(orderRequest);
            }
            catch (RequestFailedException ex)
            {
                throw new InvalidOperationException("Error adding order request to Table Storage", ex);
            }
        }

        public async Task DeleteOrderRequestAsync(string partitionKey, string rowKey)
        {
            await _orderRequestTableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<OrderRequest?> GetOrderRequestAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _orderRequestTableClient.GetEntityAsync<OrderRequest>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
        }
    }
}