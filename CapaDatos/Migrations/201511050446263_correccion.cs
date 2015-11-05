namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correccion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cursoes", "Alumno_idAlumno", "dbo.Alumnos");
            DropForeignKey("dbo.Cursoes", "Instructor_idInstructor", "dbo.Instructores");
            DropIndex("dbo.Cursoes", new[] { "Alumno_idAlumno" });
            DropIndex("dbo.Cursoes", new[] { "Instructor_idInstructor" });
            CreateTable(
                "dbo.CursoAlumnoes",
                c => new
                    {
                        Curso_idCurso = c.Int(nullable: false),
                        Alumno_idAlumno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Curso_idCurso, t.Alumno_idAlumno })
                .ForeignKey("dbo.Cursoes", t => t.Curso_idCurso, cascadeDelete: true)
                .ForeignKey("dbo.Alumnos", t => t.Alumno_idAlumno, cascadeDelete: true)
                .Index(t => t.Curso_idCurso)
                .Index(t => t.Alumno_idAlumno);
            
            CreateTable(
                "dbo.InstructorCursoes",
                c => new
                    {
                        Instructor_idInstructor = c.Int(nullable: false),
                        Curso_idCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_idInstructor, t.Curso_idCurso })
                .ForeignKey("dbo.Instructores", t => t.Instructor_idInstructor, cascadeDelete: true)
                .ForeignKey("dbo.Cursoes", t => t.Curso_idCurso, cascadeDelete: true)
                .Index(t => t.Instructor_idInstructor)
                .Index(t => t.Curso_idCurso);
            
            DropColumn("dbo.Cursoes", "Alumno_idAlumno");
            DropColumn("dbo.Cursoes", "Instructor_idInstructor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursoes", "Instructor_idInstructor", c => c.Int());
            AddColumn("dbo.Cursoes", "Alumno_idAlumno", c => c.Int());
            DropForeignKey("dbo.InstructorCursoes", "Curso_idCurso", "dbo.Cursoes");
            DropForeignKey("dbo.InstructorCursoes", "Instructor_idInstructor", "dbo.Instructores");
            DropForeignKey("dbo.CursoAlumnoes", "Alumno_idAlumno", "dbo.Alumnos");
            DropForeignKey("dbo.CursoAlumnoes", "Curso_idCurso", "dbo.Cursoes");
            DropIndex("dbo.InstructorCursoes", new[] { "Curso_idCurso" });
            DropIndex("dbo.InstructorCursoes", new[] { "Instructor_idInstructor" });
            DropIndex("dbo.CursoAlumnoes", new[] { "Alumno_idAlumno" });
            DropIndex("dbo.CursoAlumnoes", new[] { "Curso_idCurso" });
            DropTable("dbo.InstructorCursoes");
            DropTable("dbo.CursoAlumnoes");
            CreateIndex("dbo.Cursoes", "Instructor_idInstructor");
            CreateIndex("dbo.Cursoes", "Alumno_idAlumno");
            AddForeignKey("dbo.Cursoes", "Instructor_idInstructor", "dbo.Instructores", "idInstructor");
            AddForeignKey("dbo.Cursoes", "Alumno_idAlumno", "dbo.Alumnos", "idAlumno");
        }
    }
}
