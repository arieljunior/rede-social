namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializeMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdFollower = c.Guid(nullable: false),
                        IdFollowed = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Follows");
        }
    }
}
