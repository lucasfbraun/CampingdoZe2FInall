namespace CampingdoZe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudancas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Nome", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Nome", c => c.String());
        }
    }
}
