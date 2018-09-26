using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualMindApp.Models;

namespace VirtualMindApp.DAL
{
    public class VIrtualMindContextInitizializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VirtualMindContext>
    {
        protected override void Seed(VirtualMindContext context)
        {
            //var usuarios = new List<Usuario>
            //{
            //new Usuario{Nombre="Leandro",Apellido="Bressanello",Email="lean_0211@hotmail.com", Password=".lbresPa$$w0rd"},
            //new Usuario{Nombre="Julieta",Apellido="Roscardi",Email="julieta.roscardi@gmail.com", Password=".jroscPa$$w0rd"},
            //new Usuario{Nombre="Milo",Apellido="Roscardi",Email="elperrov@hotmail.com", Password=".mroscPa$$w0rd"},
            //new Usuario{Nombre="Tita",Apellido="Bressanello",Email="sonlas8@hotmail.com", Password=".tbresPa$$w0rd"}
            //};

            //usuarios.ForEach(s => context.Usuarios.Add(s));
            //context.SaveChanges();
        }
    }
}