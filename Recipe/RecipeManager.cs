using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeAppWPF
{
    public class RecipeManager
    {
        public List<Recipe> Recipes { get; private set; }

        public RecipeManager()
        {
            Recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
            if (recipe.GetTotalCalories() > 300)
            {
                MessageBox.Show($"Warning: The total calories of the recipe \"{recipe.Name}\" exceed 300 (Total: {recipe.GetTotalCalories()} calories).", "Calorie Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            Recipes.Remove(recipe);
        }

        public string GetRecipeDetails(Recipe recipe)
        {
            string details = $"Recipe: {recipe.Name}\n\nIngredients:\n";
            foreach (var ingredient in recipe.Ingredients)
            {
                details += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})\n";
            }

            details += "\nSteps:\n";
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                details += $"{i + 1}. {recipe.Steps[i]}\n";
            }

            details += $"\nTotal Calories: {recipe.GetTotalCalories()}";

            return details;
        }

        public string GetScaledRecipeDetails(Recipe recipe, double scaleFactor)
        {
            string details = $"Scaled Recipe for {recipe.Name} (Factor: {scaleFactor}):\n\n";
            foreach (var ingredient in recipe.Ingredients)
            {
                details += $"{ingredient.Quantity * scaleFactor} {ingredient.Unit} of {ingredient.Name}\n";
            }

            details += $"\nTotal Scaled Calories: {recipe.GetTotalCalories() * scaleFactor}";

            return details;
        }
    }
}
