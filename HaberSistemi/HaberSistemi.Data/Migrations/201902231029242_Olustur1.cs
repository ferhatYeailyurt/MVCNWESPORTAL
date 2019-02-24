namespace HaberSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 255),
                        KisaAciklama = c.String(),
                        Aciklama = c.String(),
                        Okunma = c.Int(nullable: false),
                        AktifMi = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Resim = c.String(maxLength: 255),
                        Kullanici_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanici", t => t.Kullanici_Id)
                .Index(t => t.Kullanici_Id);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResimUrl = c.String(),
                        Haber_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Haber", t => t.Haber_Id)
                .Index(t => t.Haber_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resim", "Haber_Id", "dbo.Haber");
            DropForeignKey("dbo.Haber", "Kullanici_Id", "dbo.Kullanici");
            DropIndex("dbo.Resim", new[] { "Haber_Id" });
            DropIndex("dbo.Haber", new[] { "Kullanici_Id" });
            DropTable("dbo.Resim");
            DropTable("dbo.Haber");
        }
    }
}
