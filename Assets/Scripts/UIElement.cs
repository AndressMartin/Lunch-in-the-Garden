using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI description;
    public bool grayOutImage;
    public GameObject ingredientsGridLayout; //For recipes
    public List<UIElement> ingredients; //For recipes
    public Interactable relatedInteractable; //For ingredients
    public Recipe relatedRecipe; //For recipes
    public ColorPicker colorPicker;

    public void Init(Sprite image, string description, List<UIElement> ingredients)
    {
        Init(image, description);
        this.ingredients = ingredients;
    }

    public void Init(Sprite image, string description)
    {
        this.image.sprite = image;
        this.description.text = description;
    }

    private void Start()
    {
        if (!grayOutImage) image.enabled = false;
        else image.color = new Color(image.color.r, image.color.g, image.color.b, 100);
        description.color = colorPicker.NoReferenceColor;
    }

    public void ActivateIngredientUI(GameObject obj)
    {
        if (obj == relatedInteractable.gameObject)
        {
            image.enabled = true;
            description.color = colorPicker.PencilColor;
            description.fontStyle = FontStyles.Bold;
        }
    }

    public void ActivateRecipeUI(GameObject obj)
    {
        if (obj == relatedRecipe.gameObject)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
            description.color = colorPicker.PencilColor;
            description.fontStyle = FontStyles.Bold;
        }
    }
}
