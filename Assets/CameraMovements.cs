using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraMovements : MonoBehaviour
{
    [SerializeField]
    float targetedCamSize;
    public bool zoomActive;
    public bool paningOnNewItem;
    Vector3 target;
    Vector3 originalPos;
    Camera cam;
    public float tweenTime;
    public float tweenTimeForNewItems;
    private void Start()
    {
        cam = Camera.main;
        originalPos = cam.transform.position;
    }

    private void DoTweenCamMovement()
    {
        if (zoomActive)
        {
            cam.transform.DOMove(target, tweenTime).SetEase(Ease.InOutSine);
            cam.DOOrthoSize(targetedCamSize, tweenTime);
        }
        else
        {
            cam.transform.DOMove(originalPos, tweenTime).SetEase(Ease.InOutSine);
            cam.DOOrthoSize(5, tweenTime);
        }
    }


    public void ZoomIn(GameObject obj)
    {
        zoomActive = !zoomActive;
        target = new Vector3(obj.transform.position.x, obj.transform.position.y - 1, obj.transform.position.z - 3);
        paningOnNewItem = obj.GetComponent<Interactable>().discovered;
        DoTweenCamMovement();
    }
}
