using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractableDetails : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI desciption;
    [SerializeField]
    private Image image;

    [SerializeField]
    private bool showingObj;
    public void UpdateTitleAndDescription(GameObject obj)
    {
        ToggleShowingObj();
        if (showingObj)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Interactable interactable = obj.GetComponent<Interactable>();
            title.text = interactable.content.name;
            image.sprite = interactable.content.art;
            desciption.text = interactable.content.description;
        }
        else
        {
            foreach (Transform child in transform)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    public void ToggleShowingObj()
    {
        showingObj = !showingObj;
    }

}
