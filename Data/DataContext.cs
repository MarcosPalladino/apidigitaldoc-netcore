using Microsoft.EntityFrameworkCore;
using apidigitaldoc.Models;

namespace apidigitaldoc.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        :base(options)
        { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papeis { get; set; }

        public DbSet<Documento> Documentos { get; set; }
    }
}