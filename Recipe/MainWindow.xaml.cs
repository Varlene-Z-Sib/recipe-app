using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class MainWindow : Window
    {
        private RecipeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipeManager);
            addRecipeWindow.ShowDialog();
            RefreshRecipeList();
        }

        private void DisplayAll_Click(object sender, RoutedEventArgs e)
        {
            RefreshRecipeList();
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = FilterIngredientTextBox.Text.Trim().ToLower();
            string foodGroup = FilterFoodGroupTextBox.Text.Trim().ToLower();
            bool isCaloriesValid = int.TryParse(FilterCaloriesTextBox.Text, out int maxCalories);

            var filteredRecipes = recipeManager.Recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup.ToLower().Contains(foodGroup))) &&
                (!isCaloriesValid || r.GetTotalCalories() <= maxCalories)).ToList();

            RecipeListBox.ItemsSource = filteredRecipes.OrderBy(r => r.Name).ToList();
        }

        private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                string details = recipeManager.GetRecipeDetails(selectedRecipe);
                MessageBox.Show(details, "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow(selectedRecipe, recipeManager);
                scaleRecipeWindow.ShowDialog();
                RefreshRecipeList();
            }
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                recipeManager.DeleteRecipe(selectedRecipe);
                RefreshRecipeList();
            }
        }

        private void RefreshRecipeList()
        {
            RecipeListBox.ItemsSource = null;
            RecipeListBox.ItemsSource = recipeManager.Recipes.OrderBy(r => r.Name).ToList();
        }
    }
}
