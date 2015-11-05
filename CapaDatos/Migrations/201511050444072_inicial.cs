namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
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
                "dbo.Cursoes",
                c => new
                    {
                        idCurso = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        sese = c.String(),
                        fecha = c.DateTime(nullable: false),
                        fechaFinalizacion = c.DateTime(nullable: false),
                        telefonoContacto = c.String(),
                        nombreFacilitador = c.String(),
                        mostrarPrecio = c.Boolean(nullable: false),
                        imagen = c.String(),
                        contenido = c.String(),
                        Alumno_idAlumno = c.Int(),
                        Instructor_idInstructor = c.Int(),
                    })
                .PrimaryKey(t => t.idCurso)
                .ForeignKey("dbo.Alumnos", t => t.Alumno_idAlumno)
                .ForeignKey("dbo.Instructores", t => t.Instructor_idInstructor)
                .Index(t => t.Alumno_idAlumno)
                .Index(t => t.Instructor_idInstructor);
            
            CreateTable(
                "dbo.TemasCurso",
                c => new
                    {
                        idTema = c.Int(nullable: false, identity: true),
                        nombreTema = c.String(),
                        idCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTema)
                .ForeignKey("dbo.Cursoes", t => t.idCurso, cascadeDelete: true)
                .Index(t => t.idCurso);
            
            CreateTable(
                "dbo.ContenidoTemas",
                c => new
                    {
                        idContenido = c.Int(nullable: false, identity: true),
                        soloInscritos = c.Boolean(nullable: false),
                        tituloContenido = c.String(),
                        contenido = c.String(),
                        idTema = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idContenido)
                .ForeignKey("dbo.TemasCurso", t => t.idTema, cascadeDelete: true)
                .Index(t => t.idTema);
            
            CreateTable(
                "dbo.Materiales",
                c => new
                    {
                        idMaterial = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        idTema = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMaterial)
                .ForeignKey("dbo.TemasCurso", t => t.idTema, cascadeDelete: true)
                .Index(t => t.idTema);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursoes", "Instructor_idInstructor", "dbo.Instructores");
            DropForeignKey("dbo.Cursoes", "Alumno_idAlumno", "dbo.Alumnos");
            DropForeignKey("dbo.Materiales", "idTema", "dbo.TemasCurso");
            DropForeignKey("dbo.TemasCurso", "idCurso", "dbo.Cursoes");
            DropForeignKey("dbo.ContenidoTemas", "idTema", "dbo.TemasCurso");
            DropIndex("dbo.Materiales", new[] { "idTema" });
            DropIndex("dbo.ContenidoTemas", new[] { "idTema" });
            DropIndex("dbo.TemasCurso", new[] { "idCurso" });
            DropIndex("dbo.Cursoes", new[] { "Instructor_idInstructor" });
            DropIndex("dbo.Cursoes", new[] { "Alumno_idAlumno" });
            DropTable("dbo.Instructores");
            DropTable("dbo.Materiales");
            DropTable("dbo.ContenidoTemas");
            DropTable("dbo.TemasCurso");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Alumnos");
        }
    }
}
