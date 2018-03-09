using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pokemons.Classes
{

    public class Pokemon
    {

        // Add Session with pokemon if there is no one like that 
        public Pokemon()
        {
            Sessions = new List<Session>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Legendary { get; set; }
        public List <Session> Sessions { get; set; }
        public int SessionId { get; set; }
        public List<PokemonType> Type { get; set; }
        public string TypeString { get; set; }

    }

    public class Session
    {
        
        public int Id { get; set; }
        public SessionNameEnum SessionName { get; set; }
        public List<Pokemon> Pokemons { get; set; }

    }

    public class PokemonType
    {
        public int Id { get; set; }
        public List<string> TypeNames { get; set; }
        [Required]
        public Pokemon Pokemon { get; set; }
    }
       
}
