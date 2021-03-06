using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraMovements : MonoBehaviour
{
    [SerializeField]
    float targetedCamSize;
    public bool paningOnNewItem;
    Vector3 target;
    Vector3 originalPos;
    Camera cam;
    public float tweenTime;
    public float tweenTimeForNewItems;
    private float time;
    public GameEvent doneCameraTween;
    public GameEvent canClick;
    public GameObject focusedObj;

    private void Start()
    {
        cam = Camera.main;
        originalPos = cam.transform.position;
    }

    public void SetZoomIn(GameObject obj)
    {
        ToggleCanClick();
        if(target.x < 0)
            target = new Vector3(obj.transform.position.x+2f, obj.transform.position.y - .4f, obj.transform.position.z - 2f);
        else if (target.x >= 0)
            target = new Vector3(obj.transform.position.x, obj.transform.position.y - .4f, obj.transform.position.z - 2f);
        focusedObj = obj;
        if (obj.GetComponent<Interactable>())
            paningOnNewItem = obj.GetComponent<Interactable>().Undiscovered;
        else paningOnNewItem = false;

        if (paningOnNewItem)
        {
            time = tweenTimeForNewItems;
        }
        else
        {
            time = tweenTime;
        }
        cam.transform.DOMove(target, time).SetEase(Ease.InOutSine).OnComplete(() => { CompletedCameraTween(); });
        cam.DOOrthoSize(targetedCamSize, time);
    }

    public void SetZoomOut()
    {
        time = tweenTime;
        cam.transform.DOMove(originalPos, time).SetEase(Ease.InOutSine).OnComplete(() => { ToggleCanClick(); SetDiscovered(); });
        cam.DOOrthoSize(5, time);
    }

    private void CompletedCameraTween()
    {
        doneCameraTween.Raise(focusedObj);
    }

    private void ToggleCanClick()
    {
        canClick.Raise();
    }

    private void SetDiscovered()
    {
        if (focusedObj.GetComponent<Interactable>())
            focusedObj.GetComponent<Interactable>().Undiscovered = false;
    }
}
