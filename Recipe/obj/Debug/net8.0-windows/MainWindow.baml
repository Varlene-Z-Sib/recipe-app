   M S B A M L   `   `   `  ����  RecipeAppWPF    RecipeAppWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Recipe Manager��5   	   $	��450��6    $	��800��6-    � WindowState$ 	Maximized=�5      .��5      � $��10q�6   ��5   
   �� 5       �� ImageSource$^ XC:\Users\zazis\OneDrive\Desktop\POE\RecipeAppWPF\bin\Debug\net8.0-windows\_image\let.jpg��6    j� Stretch$ UniformToFill=�6�    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5        $��
Add Recipe��5      $��0,0,10,0q�6B   �� 5      -   5        $��Display All��5      $��0,0,10,0q�6D   �� 5      $��Filter by Ingredient:��6   $��Center=�65   $
��10,0q�6P   �� 5      -   5         ��Name$ FilterIngredientTextBox��5      $	��120��67   $��0,0,10,0q�6C   �� 5      $��Filter by Food Group:��6   $��Center=�65   $
��10,0q�6P   �� 5      -   5        $ FilterFoodGroupTextBox��5      $	��120��66   $��0,0,10,0q�6B   �� 5      $��Max Calories:��6   $��Center=�6-   $
��10,0q�6H   �� 5      -   5        $ FilterCaloriesTextBox��5      $��60��65   $��0,0,10,0q�6@   �� 5      -   5        $��Apply Filter��5      6,   5      �� 5   
   -   5         ��Name$ RecipeListBox��5      $��1��6)   66   �� 5   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5        $��Scale Recipe��5      $��0,0,10,0q�6F   �� 5      -	   5        $��Delete Recipe��5      $��0,0,10,0q�6H   5      5      5       