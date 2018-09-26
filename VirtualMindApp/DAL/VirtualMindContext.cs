using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VirtualMindApp.Models;

namespace VirtualMindApp.DAL
{
    public class VirtualMindContext : DbContext, IVirtualMindContext
    {
        public VirtualMindContext() : base("VirtualMindContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public void MarkAsModified(Usuario item)
        {
            Entry(item).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}