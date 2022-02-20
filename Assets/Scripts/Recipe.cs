using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public RecipeSO content;
    public List<Interactable> ingredients = new List<Interactable>();
    public bool showRecipe;
    public GameEvent recipeFound;
    public bool ShowRecipe
    {
        get{return showRecipe;}
        set
        {
            showRecipe = value;
            if (value == true) gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void Awake()
    {
        ShowRecipe = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnValidate()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = content.art;
        gameObject.name = content._name;
    }

    public void VerifyInteractable(GameObject obj)
    {
        if (ShowRecipe) return;
        foreach (var ingredient in ingredients)
        {
            if (ingredient.Undiscovered) return;

        }
        ShowRecipe = true;
        recipeFound.Raise(gameObject);
    }
}
