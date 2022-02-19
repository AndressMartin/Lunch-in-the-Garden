using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI description;
    public GameObject ingredientsGridLayout;
    public List<UIElement> ingredients;

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
}
