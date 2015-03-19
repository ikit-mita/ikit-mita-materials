namespace DatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChildItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildItems", "Parent_Id", "dbo.Items");
            DropIndex("dbo.ChildItems", new[] { "Parent_Id" });
            DropTable("dbo.ChildItems");
        }
    }
}
