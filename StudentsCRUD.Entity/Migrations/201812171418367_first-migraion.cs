namespace StudentsCRUD.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigraion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Specialty = c.String(),
                        FacultyNumber = c.String(),
                        QualificationDegree = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Credits = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.People");
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.People");
        }
    }
}
