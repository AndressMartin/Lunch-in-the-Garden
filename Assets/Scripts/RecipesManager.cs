using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : Singleton<RecipesManager>
{
    public List<RecipeSO> recipes = new List<RecipeSO>();
}
