using MongoDB.Bson;
using MongoDB.Driver;
using MyStore.Domain.ReadModel;
using MyStore.Infrasctructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.Seed
{
    public static class MongoSeedData
    {
        
        public static async Task SeedAsync(AppDbContext context, MongoDbContext mongoContext)
        {
            var customerCollection = mongoContext.GetCollection<CustomerReadModel>("Customers");
            var productColletion = mongoContext.GetCollection<ProductReadModel>("Products");
            var orderCollection = mongoContext.GetCollection<OrderReadModel>("Orders");
            var orderItemCollectionOrderItem = mongoContext.GetCollection<OrderItemReadModel>("OrderItens");

            var hasCustomer = await customerCollection.CountDocumentsAsync(_ => true);

            if(hasCustomer == 0)
            {
                var customers = context.Customers.Where(customer => customer.Active).ToList();

                var customerDocs = customers.Select(customer => new CustomerReadModel
                {
                    MongoId = ObjectId.GenerateNewId().ToString(),
                    Id = customer.Id,
                    Active = customer.Active,
                    CreatedAt = customer.CreatedOn,
                    Email = customer.Email,
                    Name = customer.Name,
                    Phone = customer.Phone

                }).ToList();

                await customerCollection.InsertManyAsync(customerDocs);
            }

            var hasProduct = await productColletion.CountDocumentsAsync(_ => true);

            if(hasProduct == 0)
            {
                var products = context.Products.Where(product => product.Active).ToList();  

                var productDocs = products.Select(product => new ProductReadModel
                {
                    MongoId = ObjectId.GenerateNewId().ToString(),
                    Id = product.Id,
                    Active = product.Active,
                    CreatedOn = product.CreatedOn,
                    Name = product.Name,
                    Price = product.Price
                }).ToList();

                await productColletion.InsertManyAsync(productDocs);
            }
            var hasOrder = await orderCollection.CountDocumentsAsync(_ => true);

            if(hasOrder == 0)
            {
                var orders = context.Orders.Where(order => order.Active).ToList();  

                var orderDocs = orders.Select(order => new OrderReadModel
                {
                    MongoId = ObjectId.GenerateNewId().ToString(),
                    Id = order.Id,
                    Active = order.Active,
                    CreatedOn = order.CreatedOn,
                    CustomerId = order.CustomerId,
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderItems.Select(item => new OrderItemReadModel()
                    {
                        Active = item.Active,
                        CreatedOn= item.CreatedOn,
                        Id = item.Id,
                        MongoId = ObjectId.GenerateNewId().ToString(),
                        OrderId = item.OrderId,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        TotalPrice = item.TotalPrice,
                        UnitPrice = item.UnitPrice,
                    }).ToList(),
                    Status = order.Status,
                    TotalAmount = order.TotalAmount
                }).ToList();

                await orderCollection.InsertManyAsync(orderDocs);
            }
            var hasOrderItem = await orderItemCollectionOrderItem.CountDocumentsAsync(_ => true);

            if (hasOrderItem == 0)
            {
                var orderItems = context.OrderItems.Where(orderItem => orderItem.Active).ToList();

                var orderItemsDocs = orderItems.Select(item => new OrderItemReadModel
                {
                    Active = item.Active,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    MongoId = ObjectId.GenerateNewId().ToString(),
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice,
                }).ToList();

                await orderItemCollectionOrderItem.InsertManyAsync(orderItemsDocs);
            }
        }
    }
}
