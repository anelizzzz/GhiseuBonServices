using FluentMigrator;
using FluentMigrator.Oracle;
using FluentMigrator.Postgres;
using FluentMigrator.Snowflake;

namespace GhiseuBonMigrations.Migrations;

[Migration(20240115093000)]
public class CreateUserTable : Migration
{
    public override void Up()
    {
        if (!Schema.Table("User").Exists())
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(1, 1)
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("Username").AsString(50).NotNullable().Unique()
                .WithColumn("PasswordHash").AsString(255).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable().Unique()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("RoleUser").AsInt32().NotNullable()
                .WithDefault(SystemMethods.CurrentDateTime);
        }
    }
    public override void Down()
    {
        Delete.Table("User");
    }
}
