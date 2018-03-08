using Pokemons.Classes;
using System.Data.Entity;

namespace Pokemons.DataModel
{
    public class PokemonContext:DbContext
    {

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
    }
}
