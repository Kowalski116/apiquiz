namespace BK_API_QUIZ_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "TypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Sex", c => c.Int());
            DropColumn("dbo.Quizs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizs", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Sex", c => c.Boolean());
            DropColumn("dbo.Users", "TypeId");
        }
    }
}
