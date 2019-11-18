using Microsoft.EntityFrameworkCore;

namespace ProjetoP.WebApi.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Veiculo> Veiculo { get; set; }
        
        public DbSet<Cidade> Cidade { get; set; }
    }
}