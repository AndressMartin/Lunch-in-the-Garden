using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : Singleton<RecipesManager>
{
    public List<RecipeSO> recipes = new List<RecipeSO>();
    public List<Recipe> recipeObjs = new List<Recipe>();
    public GameEvent WinGame;
    public void CheckAllRecipes(GameObject obj)
    {
        foreach (var recipe in recipeObjs)
        {
            if (!recipe.ShowRecipe)
            {
                return;
            }
        }
        Debug.LogWarning("YOU GOT ALL RECIPES!");
        WinGame.Raise();
    }
}
