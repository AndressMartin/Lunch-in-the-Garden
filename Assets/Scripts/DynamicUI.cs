using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DynamicUI : MonoBehaviour
{
    private Vector3 originalSize;
    public UnityEvent startEvents; 
    private void Start()
    {
        originalSize = transform.localScale;
        startEvents.Invoke();
    }
    public void Shrink()
    {
        transform.localScale = Vector3.zero;
    }

    public void ShrinkTween()
    {
        transform.DOScale(Vector3.zero, 1).SetEase(Ease.InOutSine);
    }

    public void Show()
    {
        transform.DOScale(originalSize, 1).SetEase(Ease.InOutSine);
    }
}
