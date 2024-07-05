using System.Collections.Generic;
using System.Linq;

namespace RecipeAppWPF
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public int GetTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }
    }
}
