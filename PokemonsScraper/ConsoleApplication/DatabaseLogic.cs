using Pokemons.Classes;
using Pokemons.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    class DatabaseLogic
    {
        public static void InsertSession()
        {
            var session = new Session
            {
                SessionName = SessionNameEnum.Hoenn

            };
            using (var context = new PokemonContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Sessions.Add(session);
                context.SaveChanges();

            }

        }
        public static void InsertPokemon(string name,bool legendary,string types )
        {
            var pokemon = new Pokemon
            {
                Name = name,
                Legendary = legendary,
                TypeString = types


            };
            using (var context = new PokemonContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Pokemons.Add(pokemon);
                context.SaveChanges();

            }

        }
        public static void InsertMultiplePokemons()
        {
            var pokemon1 = new Pokemon
            {
                Name = "Eevee",
                Legendary = false,
                SessionId = 1

            };

            var pokemon2 = new Pokemon
            {
                Name = "Onix",
                Legendary = false,
                SessionId = 1
            };
            using (var context = new PokemonContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Pokemons.AddRange(new List<Pokemon> { pokemon1, pokemon2 });
                context.SaveChanges();

            }

        }

        public static void SimplePokemonQueries()
        {
            using (var contex = new PokemonContext())
            {
                

                var pokemons = contex.Pokemons.
                    Where(n => n.Name == "Eevee")
                    .OrderBy(n => n.Name);

                foreach (var pokemon in pokemons)
                {
                    Console.WriteLine(pokemon.Name);
                }



            }

        }

        public static void SimplePokemonGraphQuery()
        {
            using (var contex = new PokemonContext())
            {
                /*
                var pokemons = contex.Pokemons.Include(n => n.Sessions);
                */

                var pokemon = contex.Pokemons
                   .FirstOrDefault(n => n.Name.StartsWith("Eevee"));
                /*
                 * context.Entry(pokemon).Collection(n => n.Sessions.Count());
                 */
            }

        }

        public static void ProjectionQuery()
        {
            using (var contex = new PokemonContext())
            {
                contex.Database.Log = Console.WriteLine;
                var pokemon = contex.Pokemons
                    .Select(n => new { n.Name, n.Legendary })
                    .ToList();

            }
        }
    }
}
