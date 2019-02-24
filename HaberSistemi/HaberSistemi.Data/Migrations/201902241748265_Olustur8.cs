namespace HaberSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategori", "Kullanici_Id", c => c.Int());
            CreateIndex("dbo.Kategori", "Kullanici_Id");
            AddForeignKey("dbo.Kategori", "Kullanici_Id", "dbo.Kullanici", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kategori", "Kullanici_Id", "dbo.Kullanici");
            DropIndex("dbo.Kategori", new[] { "Kullanici_Id" });
            DropColumn("dbo.Kategori", "Kullanici_Id");
        }
    }
}
