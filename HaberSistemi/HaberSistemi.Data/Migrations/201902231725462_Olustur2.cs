namespace HaberSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 150),
                        ParentId = c.Int(nullable: false),
                        AktifMi = c.Boolean(nullable: false),
                        URL = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Haber", "Kategori_Id", c => c.Int());
            CreateIndex("dbo.Haber", "Kategori_Id");
            AddForeignKey("dbo.Haber", "Kategori_Id", "dbo.Kategori", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Haber", "Kategori_Id", "dbo.Kategori");
            DropIndex("dbo.Haber", new[] { "Kategori_Id" });
            DropColumn("dbo.Haber", "Kategori_Id");
            DropTable("dbo.Kategori");
        }
    }
}
