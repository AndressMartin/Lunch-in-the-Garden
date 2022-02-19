using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = panel.transform.localScale;
    }
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
        if (showingObj)
        {
            panel.SetActive(showingObj);
            panel.GetComponent<Button>().interactable = showingObj;
            panel.transform.localScale = Vector3.zero;
            panel.transform.DOScale(originalScale, .3f);
        }
        else
        {
            panel.transform.DOScale(Vector3.zero, .3f).OnComplete(() => 
            {
                panel.SetActive(showingObj);
                panel.GetComponent<Button>().interactable = showingObj;
            });
        }
        
    }

    public void ClickedPanel()
    {
        clickedPanel.Raise();
    }

}
