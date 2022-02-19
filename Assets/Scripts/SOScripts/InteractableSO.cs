using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InteractableSO : VisualElementSO
{
}

public class VisualElementSO : ScriptableObject 
{
    public string _name;
    public string description;
    public Sprite art;

}

