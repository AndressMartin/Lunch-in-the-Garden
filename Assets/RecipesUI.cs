using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesUI : MonoBehaviour
{
    RecipesManager recipesManager;
    [SerializeField]
    UIElement recipeUIPanel;
    [SerializeField]
    UIElement ingredientUIPanel;

    //Structure
    [SerializeField]
    private GameObject recipesVerticalLayout;


    // Start is called before the first frame update
    void Start()
    {
        recipesManager = RecipesManager.GetInstance();
        SetupUI();
        
    }


    private void SetupUI()
    {
        foreach (var recipe in recipesManager.recipes)
        {
            UIElement newRecipe = Instantiate(recipeUIPanel, recipesVerticalLayout.transform);
            var ingredients = recipe.ingredients;
            List<UIElement> ingredientsUI = new List<UIElement>();
            foreach (var ingredient in ingredients)
            {
                var newIngredientUI = Instantiate(ingredientUIPanel, newRecipe.ingredientsGridLayout.transform);
                ingredientsUI.Add(newIngredientUI);
                newIngredientUI.Init(ingredient.art, ingredient._name);
            }
            newRecipe.Init(recipe.art, recipe._name, ingredientsUI);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
