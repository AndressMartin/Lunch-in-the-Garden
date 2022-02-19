using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField]
    float targetedCamSize;
    public bool zoomActive;
    public bool paningOnNewItem;
    Vector3 target;
    Vector3 originalPos;
    Camera cam;
    public float speed;
    private float smoother;
    public float smootherMax = .5f;
    private void Start()
    {
        cam = Camera.main;
        originalPos = cam.transform.position;
    }

    private void LateUpdate()
    {
        if (zoomActive)
        {
            if (paningOnNewItem)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetedCamSize, speed*smoother);
                cam.transform.position = Vector3.Slerp(cam.transform.position, target, speed*smoother);
                if (smoother <= 1) smoother += 0.01f;
            }
            else
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetedCamSize, speed);
                cam.transform.position = Vector3.Slerp(cam.transform.position, target, speed);
            }
            
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speed);
            cam.transform.position = Vector3.Slerp(cam.transform.position, originalPos, speed);
        }
    }

    public void ZoomIn(GameObject obj)
    {
        zoomActive = !zoomActive;
        target = new Vector3(obj.transform.position.x, obj.transform.position.y - 1, obj.transform.position.z - 3);
        smoother = smootherMax;
        paningOnNewItem = obj.GetComponent<Interactable>().discovered;
    }
}
