namespace SALD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adulto",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 45),
                        Apellido = c.String(nullable: false, maxLength: 45),
                        Telefono = c.String(nullable: false, maxLength: 12),
                        Email = c.String(nullable: false),
                        AlumnoID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumno", t => t.AlumnoID)
                .Index(t => t.AlumnoID);
            
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 45),
                        Apellido = c.String(nullable: false, maxLength: 45),
                        FechaNAc = c.DateTime(nullable: false),
                        HojaVida = c.String(nullable: false),
                        AdultoID = c.String(nullable: false),
                        NivelID = c.String(maxLength: 128),
                        Salas_ID = c.String(maxLength: 128),
                        Usuario_ID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nivel", t => t.NivelID)
                .ForeignKey("dbo.Sala", t => t.Salas_ID)
                .ForeignKey("dbo.Usuario", t => t.Usuario_ID)
                .Index(t => t.NivelID)
                .Index(t => t.Salas_ID)
                .Index(t => t.Usuario_ID);
            
            CreateTable(
                "dbo.Nivel",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.Int(nullable: false),
                        RangoEdad = c.Int(nullable: false),
                        CantAlumnos = c.Int(nullable: false),
                        Año = c.Int(nullable: false),
                        Periodo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sala",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Horario = c.Int(nullable: false),
                        NivelID = c.String(nullable: false, maxLength: 128),
                        Ast = c.String(nullable: false, maxLength: 45),
                        Educ = c.String(nullable: false, maxLength: 45),
                        Planificacion_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nivel", t => t.NivelID, cascadeDelete: true)
                .ForeignKey("dbo.Planificacion", t => t.Planificacion_ID)
                .Index(t => t.NivelID)
                .Index(t => t.Planificacion_ID);
            
            CreateTable(
                "dbo.Planificacion",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Inicio = c.DateTime(nullable: false),
                        Termino = c.DateTime(nullable: false),
                        Encargado = c.String(nullable: false, maxLength: 45),
                        Objetivos_prop = c.String(),
                        Objetivos_cump = c.String(),
                        Actividades_prop = c.String(),
                        Actividades_cump = c.String(),
                        NivelID = c.String(maxLength: 128),
                        SalaID = c.String(),
                        NumeroR = c.Int(nullable: false),
                        Novedades = c.String(),
                        ListaAp = c.String(),
                        Usuario_ID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nivel", t => t.NivelID)
                .ForeignKey("dbo.Usuario", t => t.Usuario_ID)
                .Index(t => t.NivelID)
                .Index(t => t.Usuario_ID);
            
            CreateTable(
                "dbo.Bitacora",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Novedades = c.String(nullable: false),
                        PlanificacionID = c.String(nullable: false, maxLength: 128),
                        Sala_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Planificacion", t => t.PlanificacionID, cascadeDelete: true)
                .ForeignKey("dbo.Sala", t => t.Sala_ID)
                .Index(t => t.PlanificacionID)
                .Index(t => t.Sala_ID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 45),
                        Apellido = c.String(nullable: false, maxLength: 45),
                        Username = c.String(nullable: false, maxLength: 45),
                        Usrtype = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planificacion", "Usuario_ID", "dbo.Usuario");
            DropForeignKey("dbo.Alumno", "Usuario_ID", "dbo.Usuario");
            DropForeignKey("dbo.Sala", "Planificacion_ID", "dbo.Planificacion");
            DropForeignKey("dbo.Planificacion", "NivelID", "dbo.Nivel");
            DropForeignKey("dbo.Bitacora", "Sala_ID", "dbo.Sala");
            DropForeignKey("dbo.Bitacora", "PlanificacionID", "dbo.Planificacion");
            DropForeignKey("dbo.Sala", "NivelID", "dbo.Nivel");
            DropForeignKey("dbo.Alumno", "Salas_ID", "dbo.Sala");
            DropForeignKey("dbo.Alumno", "NivelID", "dbo.Nivel");
            DropForeignKey("dbo.Adulto", "AlumnoID", "dbo.Alumno");
            DropIndex("dbo.Bitacora", new[] { "Sala_ID" });
            DropIndex("dbo.Bitacora", new[] { "PlanificacionID" });
            DropIndex("dbo.Planificacion", new[] { "Usuario_ID" });
            DropIndex("dbo.Planificacion", new[] { "NivelID" });
            DropIndex("dbo.Sala", new[] { "Planificacion_ID" });
            DropIndex("dbo.Sala", new[] { "NivelID" });
            DropIndex("dbo.Alumno", new[] { "Usuario_ID" });
            DropIndex("dbo.Alumno", new[] { "Salas_ID" });
            DropIndex("dbo.Alumno", new[] { "NivelID" });
            DropIndex("dbo.Adulto", new[] { "AlumnoID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Bitacora");
            DropTable("dbo.Planificacion");
            DropTable("dbo.Sala");
            DropTable("dbo.Nivel");
            DropTable("dbo.Alumno");
            DropTable("dbo.Adulto");
        }
    }
}
