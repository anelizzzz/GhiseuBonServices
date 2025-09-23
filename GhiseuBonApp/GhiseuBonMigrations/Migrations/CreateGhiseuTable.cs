using FluentMigrator;

namespace GhiseuBonMigrations.Migrations;

[Migration(20230920120000)]
public class CreatedGhiseuTable : Migration
{

    public override void Up()
    {
        if (!Schema.Table("Ghiseu").Exists())
        {
            Create.Table("Ghiseu")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Cod").AsString(10).Nullable()
                .WithColumn("Denumire").AsString(50).Nullable()
                .WithColumn("Descriere").AsString(50).Nullable()
                .WithColumn("Icon").AsString(10).Nullable()
                .WithColumn("Activ").AsBoolean().NotNullable();
        }
    }

    public override void Down()
    {
        Delete.Table("Ghiseu");
    }
}