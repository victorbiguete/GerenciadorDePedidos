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
        private const string PRODUCT_TABLE_NAME = "Product";
        public override void Up()
        {
            CreateTable(PRODUCT_TABLE_NAME)
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable();
        }
    }
}
