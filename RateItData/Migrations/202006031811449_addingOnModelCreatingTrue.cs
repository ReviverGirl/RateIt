namespace RateItData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingOnModelCreatingTrue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Review", "MusicId", "dbo.Music");
            DropForeignKey("dbo.Review", "ShowId", "dbo.Show");
            AddForeignKey("dbo.Review", "MovieId", "dbo.Movie", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.Review", "MusicId", "dbo.Music", "MusicId", cascadeDelete: true);
            AddForeignKey("dbo.Review", "ShowId", "dbo.Show", "ShowId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "ShowId", "dbo.Show");
            DropForeignKey("dbo.Review", "MusicId", "dbo.Music");
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            AddForeignKey("dbo.Review", "ShowId", "dbo.Show", "ShowId");
            AddForeignKey("dbo.Review", "MusicId", "dbo.Music", "MusicId");
            AddForeignKey("dbo.Review", "MovieId", "dbo.Movie", "MovieId");
        }
    }
}
