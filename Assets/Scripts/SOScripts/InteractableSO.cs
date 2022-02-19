using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InteractableSO : VisualElementSO
{
    
}

public class VisualElementSO : ScriptableObject 
{
    public new string name;
    public string description;
    public Sprite art;
}

