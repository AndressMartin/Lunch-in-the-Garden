using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractableSO content;
    public GameEvent discovered;
    public bool undiscovered;
    public bool Undiscovered
    {
        get { return undiscovered; }
        set
        {
            undiscovered = value;
            discovered.Raise(gameObject);
        }
    }
    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnValidate()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = content.art;
        name = content._name;
    }
}
