using Microsoft.EntityFrameworkCore;

public class MeuDbContext : DbContext
{
    public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
    {
    }

    public DbSet<Mensagem> Mensagens { get; set; }
}