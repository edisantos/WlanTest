namespace WlanTestSystem.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_WLAN",
                c => new
                    {
                        WlanId = c.Int(nullable: false, identity: true),
                        SN = c.String(nullable: false, maxLength: 50, unicode: false),
                        Data = c.DateTime(nullable: false),
                        MAC = c.String(nullable: false, maxLength: 50, unicode: false),
                        WIFI_MAC = c.String(nullable: false, maxLength: 50, unicode: false),
                        BT_MAC = c.String(nullable: false, maxLength: 50, unicode: false),
                        StatusTest = c.Int(nullable: false),
                        VEND_CODE = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.WlanId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_WLAN");
        }
    }
}
