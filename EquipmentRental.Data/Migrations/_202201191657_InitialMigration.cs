using FluentMigrator;

namespace EquipmentRental.Data.Migrations;

[Migration(202201191657)]
public class _202201191657_InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("Cart")
            .WithColumn("Id").AsGuid()
            .WithColumn("CustomerId").AsGuid().ForeignKey();

        Create.Table("Customer")
            .WithColumn("Id").AsGuid()
            .WithColumn("Name").AsString();

        Create.Table("Product")
            .WithColumn("Id").AsGuid()
            .WithColumn("CustomerId").AsGuid()
            .WithColumn("Name").AsString()
            .WithColumn("EquipmentType").AsInt32()
            .WithColumn("Days").AsInt32()
            .WithColumn("CreatedOn").AsDateTime()
            .WithColumn("Price").AsDecimal()
            .WithColumn("Bonus").AsDecimal();

        Create.Table("Purchase")
            .WithColumn("Id").AsGuid()
            .WithColumn("CreatedOn").AsDateTime()
            .WithColumn("CustomerId").AsGuid().ForeignKey();

        Create.Table("Equipment")
            .WithColumn("Id").AsGuid()
            .WithColumn("Type").AsInt32()
            .WithColumn("Name").AsString();
    }

    public override void Down()
    {
        
    }
}