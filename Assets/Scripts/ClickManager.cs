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
        RaycastHit2D hit = Physics2D.Raycast(GetMousePosition(), Vector2.zero, 100, layer);
        if (hit.collider)
        {
            ClickedInteractable.Raise(hit.collider.gameObject);
        }
    }
}
