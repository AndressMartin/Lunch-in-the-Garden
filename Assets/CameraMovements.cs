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
        target = new Vector3(obj.transform.position.x, obj.transform.position.y - 1, obj.transform.position.z - 3);
        focusedObj = obj;
        paningOnNewItem = obj.GetComponent<Interactable>().undiscovered;

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
        if (paningOnNewItem)
        {
            time = tweenTimeForNewItems;
        }
        else
        {
            time = tweenTime;
        }
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
        focusedObj.GetComponent<Interactable>().undiscovered = false;
    }
}
