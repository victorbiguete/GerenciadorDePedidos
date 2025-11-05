using FluentMigrator;
using FluentMigrator.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.Migration.Versions
{
    [Migration(DatabaseVersions.TABLE_CUSTOMER,"Create table to save the Customer's information ")]
    public class Version000001 : VersionBase
    {
        private const string CUSTOMER_TABLE_NAME = "Customers";
        
        public override void Up()
        {
            CreateTable(CUSTOMER_TABLE_NAME)
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Phone").AsString(25).NotNullable();

            Insert.IntoTable(CUSTOMER_TABLE_NAME)
                .Row(new
                {
                    Name = "Cliente Padrão",
                    Email = "cliente@example.com",
                    Phone = "11999999999",
                    CreatedOn = DateTime.UtcNow,
                    Active = true
                });
        }

        
    }
}
