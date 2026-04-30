using WebAppCasoPractico.Dominio;

public class AppDbContext : System.Data.Entity.DbContext
{
    public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options) { }

    public System.Data.Entity.DbSet<RegistroPago> PaymentIntents => Set<RegistroPago>();
}