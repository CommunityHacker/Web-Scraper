namespace Pokemons.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pokemons", "SessionId", "dbo.Sessions");
            DropIndex("dbo.Pokemons", new[] { "SessionId" });
            CreateTable(
                "dbo.SessionPokemons",
                c => new
                    {
                        Session_Id = c.Int(nullable: false),
                        Pokemon_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Session_Id, t.Pokemon_Id })
                .ForeignKey("dbo.Sessions", t => t.Session_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pokemons", t => t.Pokemon_Id, cascadeDelete: true)
                .Index(t => t.Session_Id)
                .Index(t => t.Pokemon_Id);
            
            DropColumn("dbo.PokemonTypes", "TypeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PokemonTypes", "TypeName", c => c.String());
            DropForeignKey("dbo.SessionPokemons", "Pokemon_Id", "dbo.Pokemons");
            DropForeignKey("dbo.SessionPokemons", "Session_Id", "dbo.Sessions");
            DropIndex("dbo.SessionPokemons", new[] { "Pokemon_Id" });
            DropIndex("dbo.SessionPokemons", new[] { "Session_Id" });
            DropTable("dbo.SessionPokemons");
            CreateIndex("dbo.Pokemons", "SessionId");
            AddForeignKey("dbo.Pokemons", "SessionId", "dbo.Sessions", "Id", cascadeDelete: true);
        }
    }
}
