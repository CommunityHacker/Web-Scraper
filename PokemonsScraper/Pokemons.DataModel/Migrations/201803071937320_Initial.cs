namespace Pokemons.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pokemons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Legendary = c.Boolean(nullable: false),
                        SessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PokemonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Pokemon_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pokemons", t => t.Pokemon_Id, cascadeDelete: true)
                .Index(t => t.Pokemon_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PokemonTypes", "Pokemon_Id", "dbo.Pokemons");
            DropForeignKey("dbo.Pokemons", "SessionId", "dbo.Sessions");
            DropIndex("dbo.PokemonTypes", new[] { "Pokemon_Id" });
            DropIndex("dbo.Pokemons", new[] { "SessionId" });
            DropTable("dbo.PokemonTypes");
            DropTable("dbo.Sessions");
            DropTable("dbo.Pokemons");
        }
    }
}
