//Facade design pattern - taking a system (composition and interaction with many
//components) and hiding its inner interactions behind simple interface.

using Madness.Dishes;
using Madness.Recipes;

namespace Madness
{
    //I am a facade, you only see the ready meal.
    //The kitchen is an illusion.

    //Facade - restaurant
    //Interface that they give you - menu
    //Whatever happens internally (Chef, ingredients, etc.) is hidden (we are not
    //concerned with the flexibility of the internal system).
    public interface IPrepareMealContext
    {
        BigMac PrepareBigMac();
    }

    public class PrepareMealContext
    {
        public BigMac PrepareBigMac()
        {
            var recipe = new BigMacRecipe();

            //Get beef from fridge

            //Get the tools

            //Fry

            //Etc.

            //Hide composition of components, we just want a specific thing

            return new();
        }
    }
}