using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : Singleton<ClickManager>
{
    [SerializeField]
    private GameEvent ClickedInteractable;
    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private bool canClickInteractable;

    private void Start()
    {
        canClickInteractable = false;
    }
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
        if (!canClickInteractable) return;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, layer);
        if (hit.collider)
        {
            Debug.Log("Clicked" + hit.collider.gameObject);
            ClickedInteractable.Raise(hit.collider.gameObject);
        }
    }

    public void ToggleCanClick()
    {
        canClickInteractable = !canClickInteractable;
    }
}
