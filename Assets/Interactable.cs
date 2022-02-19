using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractableSO content;
    public bool undiscovered = true;
    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = content.art;
    }
}
