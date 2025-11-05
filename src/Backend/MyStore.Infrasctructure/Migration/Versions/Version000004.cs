using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.Migration.Versions
{
    [Migration(DatabaseVersions.TABLE_ORDER_ITEM, "Create table to save the Order itens information")]
    public class Version000004:VersionBase
    {
        private const string ORDER_ITEM_TABLE_NAME = "OrderItems";
        private const string PRODUCT_TABLE_NAME = "Products";
        private const string ORDER_TABLE_NAME = "Orders";

        public override void Up()
        {
            CreateTable(ORDER_ITEM_TABLE_NAME)
                .WithColumn("OrderId").AsInt64().NotNullable()
                .WithColumn("ProductId").AsInt64().NotNullable()
                .WithColumn("ProductName").AsString(100).NotNullable()
                .WithColumn("Quantity").AsInt32().NotNullable()
                .WithColumn("UnitPrice").AsDecimal(18,2).NotNullable()
                .WithColumn("TotalPrice").AsDecimal(18,2).NotNullable();

            Create.ForeignKey("FK_OrderItems_Orders_OrderId")
                .FromTable(ORDER_ITEM_TABLE_NAME)
                .ForeignColumn("OrderId")
                .ToTable(ORDER_TABLE_NAME)
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_OrderItems_Products_ProductId")
                .FromTable(ORDER_ITEM_TABLE_NAME)
                .ForeignColumn("ProductId")
                .ToTable(PRODUCT_TABLE_NAME)
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.None);
        }
    }
}
