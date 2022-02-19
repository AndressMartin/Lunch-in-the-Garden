using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : Singleton<ClickManager>
{
    [SerializeField]
    private GameEvent ClickedInteractable;
    [SerializeField]
    private LayerMask layer;

    private void Update()
    {
        DoesCollideWithInteractable();
    }

    public bool Clicked()
    {
        if (!Input.GetMouseButtonDown(0)) return false;
        return true;
    }

    public Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void DoesCollideWithInteractable()
    {
        if (!Clicked()) return;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, layer);
        //Debug.Log($"Hit {hit}, {hit.collider}, {hit.collider.gameObject.layer}");
        if (hit.collider)
        {
            Debug.Log("Clicked" + hit.collider.gameObject);
            ClickedInteractable.Raise(hit.collider.gameObject);
        }
    }
}
