using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.Migration.Versions
{
    [Migration(DatabaseVersions.TABLE_ORDER, "Create table to save the Order's information")]
    public class Version000003:VersionBase
    {
        private const string ORDER_TABLE_NAME = "Order";

        public override void Up()
        {
            CreateTable(ORDER_TABLE_NAME)
                .WithColumn("OrderDate").AsDateTime().NotNullable()
                .WithColumn("TotalAmount").AsDecimal(18,2).NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("CustomerId").AsInt64().ForeignKey("FK_Orders_Customer","Customers","Id").OnDelete(System.Data.Rule.None);
        }
    }
}
