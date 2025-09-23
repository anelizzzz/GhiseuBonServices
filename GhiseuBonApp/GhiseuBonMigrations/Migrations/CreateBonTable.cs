using FluentMigrator;

namespace GhiseuBonMigrations.Migrations;

[Migration(20230920121000)]
public class CreateBonTable : Migration
{
    public override void Up()
    {
        if (!Schema.Table("Ghiseu").Exists())
        {
            Create.Table("Bon")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("GhiseuId").AsInt32().NotNullable().ForeignKey("Ghiseu", "Id")
                .WithColumn("Numar").AsString(20).NotNullable()
                .WithColumn("Data").AsDateTime().NotNullable()
                .WithColumn("Suma").AsDecimal().NotNullable();
        }
    }

    public override void Down()
    {
        Delete.Table("Bon");
    }

}

