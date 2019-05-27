namespace WlanTestSystem.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MagazineSize",
                c => new
                    {
                        MagazineSizeId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Operador = c.String(nullable: false, maxLength: 50, unicode: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagazineSizeId);
            
            CreateTable(
                "dbo.WlanTesteVerification",
                c => new
                    {
                        WlanTesteVerificationId = c.Int(nullable: false, identity: true),
                        SN = c.String(nullable: false, maxLength: 50, unicode: false),
                        TEST_END_TIME = c.DateTime(nullable: false),
                        MAC = c.String(maxLength: 100, unicode: false),
                        WIFI_MAC = c.String(nullable: false, maxLength: 50, unicode: false),
                        BT_MAC = c.String(nullable: false, maxLength: 50, unicode: false),
                        RESULT = c.String(nullable: false, maxLength: 1, unicode: false),
                        VEND_CODE = c.String(nullable: false, maxLength: 50, unicode: false),
                        StatusWlan = c.Boolean(nullable: false),
                        MagazineSizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WlanTesteVerificationId)
                .ForeignKey("dbo.MagazineSize", t => t.MagazineSizeId)
                .Index(t => t.MagazineSizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WlanTesteVerification", "MagazineSizeId", "dbo.MagazineSize");
            DropIndex("dbo.WlanTesteVerification", new[] { "MagazineSizeId" });
            DropTable("dbo.WlanTesteVerification");
            DropTable("dbo.MagazineSize");
        }
    }
}
