using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class GetSeleniumFunctions
    {
        public static string GetText(IWebDriver driver, string element, string elementType)
        {
            //  string[] pokemons; ;
            if (elementType == "Id")
            {
                // pokemons = driver.FindElements(By.Id(element)).ToString;
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

        public static void GetPokemonList(IWebDriver driver)
        {
            
          //  var pokemonTypes = new List<string[]>();
            var pokemonTypes = new List<IWebElement>();
            var currListOfTitles = new List<string>();
           // string[] currListOfTitles = new string[];

            var pokemonPanel = driver.FindElements(By.ClassName("infocard-tall"));
            foreach (var panel in pokemonPanel)
            {
                var title = panel.FindElement(By.ClassName("ent-name"));
                Console.WriteLine("Pokemon: " + title.Text);


                pokemonTypes.Add(title);
                var types = panel.FindElements(By.ClassName("aside"));


                foreach (var type in types)
                {
                    Console.WriteLine("Types: " + type.Text);
                    currListOfTitles.Add(type.Text);
                }

                /*
                    for (int i = 0; i < types.Count; i++)
                {
                    Console.WriteLine("Types: " + types[i].Text);
                    currListOfTitles.Add(types[i].Text);
                    
                }
                    */
            }


           // return pokemonTypes;
        }
    }
}
