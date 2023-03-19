
using Microsoft.EntityFrameworkCore;
using RepuestoM.Server.Models;

namespace RepuestoM.Server.Context;

public interface IMyDbContext
{
    DbSet<UsuarioRol> UsuariosRoles { get; set; }

    DbSet<Usuario> GetUsuarios();
    void SetUsuarios(DbSet<Usuario> value);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("20191498"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<UsuarioRol> UsuariosRoles { set; get; } = null!;

    private DbSet<Usuario> usuarios = null!;

    public DbSet<Usuario> GetUsuarios()
    {
        return usuarios;
    }

    public void SetUsuarios(DbSet<Usuario> value)
    {
        usuarios = value;
    }
    #endregion
}