using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI description;

    public GameObject ingredientsGridLayout; //For recipes
    public List<UIElement> ingredients; //For recipes
    public Interactable relatedInteractable; //For ingredients

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
        image.enabled = false;
    }

    public void ActivateIngredientTextAndImage(GameObject obj)
    {
        if (obj == relatedInteractable.gameObject)
        {
            image.enabled = true;
            description.color = new Color(68, 68, 68);
        }
    }
}
