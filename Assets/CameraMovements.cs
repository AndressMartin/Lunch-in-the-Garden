using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public bool zoomActive;
    Vector3 target;
    Vector3 originalPos;
    Camera cam;
    public float speed;

    private void Start()
    {
        cam = Camera.main;
        originalPos = cam.transform.position;
    }

    private void LateUpdate()
    {
        if (zoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, speed);
            Vector3 closePos = new Vector3(target.x, target.y, target.z - 3);
            cam.transform.position = Vector3.Lerp(cam.transform.position, closePos, speed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, originalPos, speed);
        }
    }

    public void ZoomIn(GameObject obj)
    {
        zoomActive = !zoomActive;
        target = obj.transform.position;
    }
}
