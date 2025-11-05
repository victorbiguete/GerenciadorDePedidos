using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.Migration.Versions
{
    [Migration(DatabaseVersions.TABLE_PRODUCT, "Create Table to save the Product's information")]
    public class Version000002 : VersionBase
    {
        private const string PRODUCT_TABLE_NAME = "Products";
        public override void Up()
        {
            CreateTable(PRODUCT_TABLE_NAME)
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable();

            Insert.IntoTable(PRODUCT_TABLE_NAME)
                .Row(new
                {
                    Name = "Camiseta",
                    Price = 50.00m,
                    CreatedOn = DateTime.UtcNow,
                    Active = true
                });
            Insert.IntoTable(PRODUCT_TABLE_NAME)
                .Row(new
                {
                    Name = "Calça",
                    Price = 75.00m,
                    CreatedOn = DateTime.UtcNow,
                    Active = true
                });
            Insert.IntoTable(PRODUCT_TABLE_NAME)
                .Row(new
                {
                    Name = "Tênis",
                    Price = 100.00m,
                    CreatedOn = DateTime.UtcNow,
                    Active = true
                });
                
        }
    }
}
