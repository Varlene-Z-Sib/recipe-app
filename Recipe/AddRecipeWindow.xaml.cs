using System.Collections.Generic;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class AddRecipeWindow : Window
    {
        private RecipeManager recipeManager;
        private List<Ingredient> ingredients;
        private List<string> steps;

        public AddRecipeWindow(RecipeManager manager)
        {
            InitializeComponent();
            recipeManager = manager;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IngredientNameInput.Text) ||
                !double.TryParse(IngredientQuantityInput.Text, out double quantity) ||
                !int.TryParse(IngredientCaloriesInput.Text, out int calories) ||
                string.IsNullOrEmpty(IngredientUnitInput.Text) ||
                string.IsNullOrEmpty(IngredientFoodGroupInput.Text))
            {
                MessageBox.Show("Please enter valid ingredient details.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var ingredient = new Ingredient
            {
                Name = IngredientNameInput.Text,
                Quantity = quantity,
                Unit = IngredientUnitInput.Text,
                Calories = calories,
                FoodGroup = IngredientFoodGroupInput.Text
            };

            ingredients.Add(ingredient);
            IngredientsListBox.Items.Add($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit} - {ingredient.Calories} Calories - {ingredient.FoodGroup}");
            IngredientNameInput.Clear();
            IngredientQuantityInput.Clear();
            IngredientUnitInput.Clear();
            IngredientCaloriesInput.Clear();
            IngredientFoodGroupInput.Clear();
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(StepDescriptionInput.Text))
            {
                MessageBox.Show("Please enter a step description.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string step = StepDescriptionInput.Text;
            steps.Add(step);
            StepsListBox.Items.Add(step);
            StepDescriptionInput.Clear();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(RecipeNameInput.Text) || ingredients.Count == 0 || steps.Count == 0)
            {
                MessageBox.Show("Please enter valid recipe details.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var recipe = new Recipe
            {
                Name = RecipeNameInput.Text,
                Ingredients = ingredients,
                Steps = steps
            };

            recipeManager.AddRecipe(recipe);
            this.Close();
        }
    }
}
