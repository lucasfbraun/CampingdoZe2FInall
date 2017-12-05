namespace CampingdoZe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segundo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoProdutoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoProdutoes");
        }
    }
}
