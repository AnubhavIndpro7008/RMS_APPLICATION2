namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.reg_Page",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        F_name = c.String(),
                        L_name = c.String(),
                        Phone_no = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.reg_Page");
        }
    }
}
