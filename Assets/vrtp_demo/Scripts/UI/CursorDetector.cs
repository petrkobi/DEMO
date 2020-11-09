using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace vrtp_demo.Scripts.UI
{
    public class CursorDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
    
        //Is Pointer Enter into Intro button make a tween
        public void OnPointerEnter(PointerEventData eventData)
        {
            gameObject.transform.DOScale(new Vector3(0.7f, 0.7f, 0), 0.3f);
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.transform.DOScale(new Vector3(0.6f, 0.6f, 0), 0.2f);
        }
    }
}
