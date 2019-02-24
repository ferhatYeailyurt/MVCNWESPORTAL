namespace HaberSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kategori", "KategoriAdi", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kategori", "KategoriAdi", c => c.String(maxLength: 150));
        }
    }
}
