namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        idAlumno = c.Int(nullable: false, identity: true),
                        razonSocial = c.String(),
                        direccionFac = c.String(),
                        rfc = c.String(),
                        usuario = c.String(),
                        idUnico = c.String(),
                        apellidoP = c.String(),
                        apellidoM = c.String(),
                        telefono = c.String(),
                        email = c.String(),
                        direccion = c.String(),
                        direccion2 = c.String(),
                        edad = c.Int(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idAlumno);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        idCurso = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        sede = c.String(),
                        fecha = c.DateTime(nullable: false),
                        fechaFinalizacion = c.DateTime(nullable: false),
                        telefonoContacto = c.String(),
                        nombreFacilitador = c.String(),
                        mostrarPrecio = c.Boolean(nullable: false),
                        urlSlug = c.String(),
                        imagen = c.String(),
                        contenido = c.String(),
                        idCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCurso)
                .ForeignKey("dbo.Categorias", t => t.idCategoria, cascadeDelete: true)
                .Index(t => t.idCategoria);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nombreCategoria = c.String(),
                        descripcionCategoria = c.String(),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.Instructores",
                c => new
                    {
                        idInstructor = c.Int(nullable: false, identity: true),
                        experiencia = c.String(),
                        institucionProcedencia = c.String(),
                        usuario = c.String(),
                        idUnico = c.String(),
                        apellidoP = c.String(),
                        apellidoM = c.String(),
                        telefono = c.String(),
                        email = c.String(),
                        direccion = c.String(),
                        direccion2 = c.String(),
                        edad = c.Int(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idInstructor);
            
            CreateTable(
                "dbo.TemasCurso",
                c => new
                    {
                        idTema = c.Int(nullable: false, identity: true),
                        nombreTema = c.String(),
                        idCurso = c.Int(),
                    })
                .PrimaryKey(t => t.idTema)
                .ForeignKey("dbo.Cursos", t => t.idCurso)
                .Index(t => t.idCurso);
            
            CreateTable(
                "dbo.ContenidoTemas",
                c => new
                    {
                        idContenido = c.Int(nullable: false, identity: true),
                        soloInscritos = c.Boolean(nullable: false),
                        tituloContenido = c.String(),
                        contenido = c.String(),
                        idTema = c.Int(),
                    })
                .PrimaryKey(t => t.idContenido)
                .ForeignKey("dbo.TemasCurso", t => t.idTema)
                .Index(t => t.idTema);
            
            CreateTable(
                "dbo.Materiales",
                c => new
                    {
                        idMaterial = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        idTema = c.Int(),
                    })
                .PrimaryKey(t => t.idMaterial)
                .ForeignKey("dbo.TemasCurso", t => t.idTema)
                .Index(t => t.idTema);
            
            CreateTable(
                "dbo.CursoAlumnoes",
                c => new
                    {
                        Curso_idCurso = c.Int(nullable: false),
                        Alumno_idAlumno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Curso_idCurso, t.Alumno_idAlumno })
                .ForeignKey("dbo.Cursos", t => t.Curso_idCurso, cascadeDelete: true)
                .ForeignKey("dbo.Alumno", t => t.Alumno_idAlumno, cascadeDelete: true)
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
                .ForeignKey("dbo.Cursos", t => t.Curso_idCurso, cascadeDelete: true)
                .Index(t => t.Instructor_idInstructor)
                .Index(t => t.Curso_idCurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materiales", "idTema", "dbo.TemasCurso");
            DropForeignKey("dbo.TemasCurso", "idCurso", "dbo.Cursos");
            DropForeignKey("dbo.ContenidoTemas", "idTema", "dbo.TemasCurso");
            DropForeignKey("dbo.InstructorCursoes", "Curso_idCurso", "dbo.Cursos");
            DropForeignKey("dbo.InstructorCursoes", "Instructor_idInstructor", "dbo.Instructores");
            DropForeignKey("dbo.Cursos", "idCategoria", "dbo.Categorias");
            DropForeignKey("dbo.CursoAlumnoes", "Alumno_idAlumno", "dbo.Alumno");
            DropForeignKey("dbo.CursoAlumnoes", "Curso_idCurso", "dbo.Cursos");
            DropIndex("dbo.InstructorCursoes", new[] { "Curso_idCurso" });
            DropIndex("dbo.InstructorCursoes", new[] { "Instructor_idInstructor" });
            DropIndex("dbo.CursoAlumnoes", new[] { "Alumno_idAlumno" });
            DropIndex("dbo.CursoAlumnoes", new[] { "Curso_idCurso" });
            DropIndex("dbo.Materiales", new[] { "idTema" });
            DropIndex("dbo.ContenidoTemas", new[] { "idTema" });
            DropIndex("dbo.TemasCurso", new[] { "idCurso" });
            DropIndex("dbo.Cursos", new[] { "idCategoria" });
            DropTable("dbo.InstructorCursoes");
            DropTable("dbo.CursoAlumnoes");
            DropTable("dbo.Materiales");
            DropTable("dbo.ContenidoTemas");
            DropTable("dbo.TemasCurso");
            DropTable("dbo.Instructores");
            DropTable("dbo.Categorias");
            DropTable("dbo.Cursos");
            DropTable("dbo.Alumno");
        }
    }
}
