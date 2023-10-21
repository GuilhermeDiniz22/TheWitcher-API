namespace rpgapi.Data
{
    public class TheWitcherContext : DbContext
    {
        public TheWitcherContext(DbContextOptions<TheWitcherContext> options) : base(options)
        {

        }

        public DbSet<Personagem> Personagems { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
