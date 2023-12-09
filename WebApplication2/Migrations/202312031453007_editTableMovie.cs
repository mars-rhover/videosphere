namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editTableMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Ratings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Ratings", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Rating");
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
