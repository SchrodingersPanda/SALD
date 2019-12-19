using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SALD.Models;

namespace SALD.DAL
{
    public class SALDInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SALDContext>
    {
        protected override void Seed(SALDContext context)
        {
            var usuarios = new List<Usuario>
            {
            new Usuario{Nombre="Alejandro",Apellido="Soto",ID="11.111.111-1", Username="asotoz", Usrtype=1, Password="asoto2019"},
            new Usuario{Nombre="Miguel",Apellido="Romero",ID="22.222.222-2", Username="mromero", Usrtype=2, Password="mromero2019"},
            new Usuario{Nombre="Benjamin",Apellido="Mora",ID="33.333.333-3", Username="bmora", Usrtype=3, Password="bmora2019"}
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();

            var niveles = new List<Nivel>
            {
            new Nivel{ID="SCMY-2019-1",RangoEdad=1,CantAlumnos=10,Año=2019,Periodo=EnumPeriodo.Primer_Trimestre,Nombre=EnumNombre.Sala_cuna_mayor},
            new Nivel{ID="MMY-2019-2",RangoEdad=3,CantAlumnos=10,Año=2019,Periodo=EnumPeriodo.Segundo_Trimestre,Nombre=EnumNombre.Medio_mayor},
            new Nivel{ID="KDR-2019-3",RangoEdad=5,CantAlumnos=10,Año=2019,Periodo=EnumPeriodo.Tercer_Trimestre,Nombre=EnumNombre.Kinder},
            };
            niveles.ForEach(s => context.Niveles.Add(s));
            context.SaveChanges();

            var salas = new List<Sala>
            {
            new Sala{ID="S-01",NivelID="SCMY-2019-1",Horario=EnumHorario.Mañana,Ast="Evelyn Aravena", Educ="Natalia Garrido"},
            new Sala{ID="S-02",NivelID="MMY-2019-2",Horario=EnumHorario.Completa,Ast="Maricel Ortega", Educ="Carolina Moya"},
            new Sala{ID="S-03",NivelID="KDR-2019-3",Horario=EnumHorario.Extension,Ast="Barbara Vasquez", Educ="Marcela Martinez"},
            };
            salas.ForEach(s => context.Salas.Add(s));
            context.SaveChanges();

            var alumnos = new List<Alumno>
            {
            new Alumno{ID="77.777.777-7",Nombre="Ines", Apellido="Suarez", FechaNAc=DateTime.Parse("2018-09-01"),NivelID="SCMY-2019-1",HojaVida="Sin novdedad", AdultoID="44.444.444-4"},
            new Alumno{ID="88.888.888-8",Nombre="Pedro", Apellido="Valdivia", FechaNAc=DateTime.Parse("2016-09-01"),NivelID="MMY-2019-2",HojaVida="Sin novdedad", AdultoID="55.555.555-5"},
            new Alumno{ID="99.999.999-9",Nombre="Diego", Apellido="Almagro", FechaNAc=DateTime.Parse("2014-09-01"),NivelID="KDR-2019-3",HojaVida="Sin novdedad", AdultoID="66.666.666-6"},
            };
            alumnos.ForEach(s => context.Alumnos.Add(s));
            context.SaveChanges();

            var adultos = new List<Adulto>
            {
            new Adulto{ID="44.444.444-4",Nombre="Javier", Apellido="Suarez", Telefono="56912345678",Email="correo@mail.cl",AlumnoID="77.777.777-7"},
            new Adulto{ID="55.555.555-5",Nombre="Rosario", Apellido="Valdivia", Telefono="56912345678",Email="correo@mail.cl",AlumnoID="88.888.888-8"},
            new Adulto{ID="66.666.666-6",Nombre="Alfonso", Apellido="Suarez", Telefono="56912345678",Email="correo@mail.cl",AlumnoID="99.999.999-9"},
            };
            adultos.ForEach(s => context.Adultos.Add(s));
            context.SaveChanges();

            var planificaciones = new List<Planificacion>
            {
            new Planificacion{ID="Plan-001", Inicio=DateTime.Parse("2019-01-01"),Termino=DateTime.Parse("2019-03-01"), Encargado="Natalia Garrido", Objetivos_prop="PPP", Objetivos_cump="CCC",Actividades_prop="AAA", Actividades_cump="AAA",NivelID="SCMY-2019-1", SalaID="S-01", NumeroR=1,Novedades="Sin novedad",ListaAp="a,b,c",UsuarioID="11.111.111-1"},
            new Planificacion{ID="Plan-002", Inicio=DateTime.Parse("2019-01-01"),Termino=DateTime.Parse("2019-03-01"), Encargado="Carolina Moya", Objetivos_prop="PPP", Objetivos_cump="CCC",Actividades_prop="AAA", Actividades_cump="AAA",NivelID="MMY-2019-2", SalaID="S-02", NumeroR=1,Novedades="Sin novedad",ListaAp="a,b,c",UsuarioID="22.222.222-3"},
            new Planificacion{ID="Plan-003", Inicio=DateTime.Parse("2019-01-01"),Termino=DateTime.Parse("2019-03-01"), Encargado="Marcela Martinez", Objetivos_prop="PPP", Objetivos_cump="CCC",Actividades_prop="AAA", Actividades_cump="AAA",NivelID="KDR-2019-3", SalaID="S-03", NumeroR=1,Novedades="Sin novedad",ListaAp="a,b,c",UsuarioID="33.333.333-3"},
            };
            planificaciones.ForEach(s => context.Planificaciones.Add(s));
            context.SaveChanges();

            var bitacoras = new List<Bitacora>
            {
            new Bitacora{ID="B-001",Novedades="Sin novedades",SalaID="S-01",PlanificacionID="Plan-001", },
            new Bitacora{ID="B-002",Novedades="Sin novedades",SalaID="S-02",PlanificacionID="Plan-002", },
            new Bitacora{ID="B-002",Novedades="Sin novedades",SalaID="S-03",PlanificacionID="Plan-003",},
            };
            bitacoras.ForEach(s => context.Bitacoras.Add(s));
            context.SaveChanges();
        }
    }
}