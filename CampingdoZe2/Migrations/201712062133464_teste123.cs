namespace CampingdoZe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "TipoProdutoesId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "TipoProduto_Id", c => c.Int());
            CreateIndex("dbo.Produtoes", "TipoProduto_Id");
            AddForeignKey("dbo.Produtoes", "TipoProduto_Id", "dbo.TipoProdutoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "TipoProduto_Id", "dbo.TipoProdutoes");
            DropIndex("dbo.Produtoes", new[] { "TipoProduto_Id" });
            DropColumn("dbo.Produtoes", "TipoProduto_Id");
            DropColumn("dbo.Produtoes", "TipoProdutoesId");
        }
    }
}
