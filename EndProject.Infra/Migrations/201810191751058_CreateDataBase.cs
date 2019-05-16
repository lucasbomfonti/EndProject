namespace EndProject.Infra.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(maxLength: 100, unicode: false),
                        Name_LastName = c.String(maxLength: 100, unicode: false),
                        Email_Address = c.String(maxLength: 100, unicode: false),
                        Password = c.String(maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Player");
            DropTable("dbo.Platform");
        }
    }
}
