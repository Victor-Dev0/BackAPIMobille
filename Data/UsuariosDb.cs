using BackAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BackAPI.Data
{
    public class UsuariosDb : DbContext
    {
        public UsuariosDb(DbContextOptions<UsuariosDb> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("TbUsuarios");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(200);
                
                entity.Property(x => x.Senha)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("TbClientes");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Nome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(x => x.Telefone)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasOne(u => u.Usuario)
                      .WithMany(u => u.Clientes)
                      .HasForeignKey(p => p.UsuarioId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
