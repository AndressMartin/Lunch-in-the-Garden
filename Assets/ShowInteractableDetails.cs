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
    private GameObject panel;
    public GameEvent clickedPanel;


    [SerializeField]
    private bool showingObj;
    public void UpdateTitleAndDescription(GameObject obj)
    {
        ToggleShowingObj();
        if (showingObj)
        {
            Interactable interactable = obj.GetComponent<Interactable>();
            title.text = interactable.content.name;
            image.sprite = interactable.content.art;
            desciption.text = interactable.content.description;
        }
    }

    public void ToggleShowingObj()
    {
        showingObj = !showingObj;

        panel.SetActive(showingObj);
        panel.GetComponent<Button>().interactable = showingObj;
    }

    public void ClickedPanel()
    {
        clickedPanel.Raise();
    }

}
