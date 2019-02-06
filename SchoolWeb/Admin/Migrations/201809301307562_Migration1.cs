namespace Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Azerbaijani = c.Int(nullable: false),
                        Math = c.Int(nullable: false),
                        Literature = c.Int(nullable: false),
                        Physics = c.Int(nullable: false),
                        Chemistry = c.Int(nullable: false),
                        Geography = c.Int(nullable: false),
                        Biology = c.Int(nullable: false),
                        English = c.Int(nullable: false),
                        History = c.Int(nullable: false),
                        Informatics = c.Int(nullable: false),
                        Semester = c.String(),
                        Result = c.String(),
                        StudentID = c.Int(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ClassID = c.Int(),
                        Image = c.Binary(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TableClasses", t => t.ClassID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.TableClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassNo = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        Address = c.String(),
                        Subject = c.String(),
                        Image = c.Binary(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeachersClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TableClasses", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.ClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeachersClasses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeachersClasses", "ClassID", "dbo.TableClasses");
            DropForeignKey("dbo.Students", "ClassID", "dbo.TableClasses");
            DropForeignKey("dbo.Marks", "StudentID", "dbo.Students");
            DropIndex("dbo.TeachersClasses", new[] { "ClassID" });
            DropIndex("dbo.TeachersClasses", new[] { "TeacherID" });
            DropIndex("dbo.Students", new[] { "ClassID" });
            DropIndex("dbo.Marks", new[] { "StudentID" });
            DropTable("dbo.TeachersClasses");
            DropTable("dbo.Teachers");
            DropTable("dbo.TableClasses");
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
        }
    }
}
