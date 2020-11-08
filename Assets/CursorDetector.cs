using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.DOScale(new Vector3(0.7f, 0.7f, 0), 0.3f);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.DOScale(new Vector3(0.6f, 0.6f, 0), 0.2f);
    }
}
