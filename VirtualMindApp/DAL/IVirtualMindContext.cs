using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMindApp.Models;

namespace VirtualMindApp.DAL
{
    public interface IVirtualMindContext
    {
        DbSet<Usuario> Usuarios { get; }
        int SaveChanges();
        void MarkAsModified(Usuario item);
    }
}
