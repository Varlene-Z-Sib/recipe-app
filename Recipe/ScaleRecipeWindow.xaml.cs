using System.Windows;

namespace RecipeAppWPF
{
    public partial class ScaleRecipeWindow : Window
    {
        private Recipe recipe;
        private RecipeManager recipeManager;

        public ScaleRecipeWindow(Recipe selectedRecipe, RecipeManager manager)
        {
            InitializeComponent();
            recipe = selectedRecipe;
            recipeManager = manager;
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ScalingFactorInput.Text, out double scaleFactor) || scaleFactor <= 0)
            {
                MessageBox.Show("Please enter a valid scaling factor.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string scaledDetails = recipeManager.GetScaledRecipeDetails(recipe, scaleFactor);
            MessageBox.Show(scaledDetails, "Scaled Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
