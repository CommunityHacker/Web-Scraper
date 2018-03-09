using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Pokemons.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            ChromeDriver driver = new ChromeDriver();
            Database.SetInitializer(new NullDatabaseInitializer<PokemonContext>());
          

            NavigateToPokemons.PokemonNavigate(driver, "Pokemon List");
            GetPokemonListAndSave(driver);


        }
        public static void GetPokemonListAndSave(IWebDriver driver)
        {
            
            GetSeleniumFunctions.GetPokemonList(driver);
            


        }

       



    }
}
