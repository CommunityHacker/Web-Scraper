using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Pokemons.Classes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class GetSeleniumFunctions
    {
        public static string GetText(IWebDriver driver, string element, string elementType)
        {
           
            if (elementType == "Id")
            {
                
                return driver.FindElement(By.Id(element)).Text;
            }
            else if (elementType == "Class")
            {
                return driver.FindElement(By.ClassName(element)).GetAttribute("a");
            }
            else if (elementType == "Class")
            {
                return driver.FindElement(By.ClassName(element)).Text;
            }
            else
            {
                return string.Empty;
            }
        }
        public static void resultsLists(IWebDriver driver)
        {
            var currListOfTitles = new List<IWebElement>();

            var titles = driver.FindElements(By.ClassName("ent-name"));
            foreach (var title in titles)
            {
                Console.WriteLine("Title: " + title.Text);
            }



        }

        public static void GetPokemonList(IWebDriver driver )
        {
            
          
            var pokemonTypes = new List<IWebElement>();
            var   pokemons = new List<string>();
        
           

            var pokemonPanel = driver.FindElements(By.ClassName("infocard-tall"));
            foreach (var panel in pokemonPanel)
            {
                var title = panel.FindElement(By.ClassName("ent-name"));
               
                pokemons.Add(title.Text);
                pokemonTypes.Add(title);
                var types = panel.FindElements(By.ClassName("aside"));


                foreach (var type in types)
                {
                   
                    string typesString = type.Text;
                   
                    DatabaseLogic.InsertPokemon(pokemons.Last(), false, type.Text);
                  
                }
            }       
        }
    }
}
