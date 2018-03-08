using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class NavigateToPokemons
    {

        public static void PokemonNavigate(IWebDriver driver,string pokemonSearchString)
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            String xpath = "//*[@id='rso']/div/div/div[2]/div/div/h3/a";
            SetSeleniumFunctions.EnterText(driver, "q", pokemonSearchString, "Name", true);
            SetSeleniumFunctions.Click(driver, xpath, "XPath");

            //*[@id="rso"]/div/div/div[2]/div/div/h3/a

            


           

            
        }
    }
}
