using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.UI.Events;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;
using Image = UnityEngine.UI.Image;

public class FadeOutInController : MonoBehaviour
{

    [SerializeField] private Image fadeOutInPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        EventDispatcher.Receive<RequestFadeInAndOutEvent>()
            .Subscribe(_ =>
            {
                fadeOutInPanel.enabled = true;
                Sequence s = DOTween.Sequence();
                s.Append(fadeOutInPanel.DOFade(1, 0.5f));
                s.SetLoops(2, LoopType.Yoyo).OnComplete(FadeOutInComplete);

            });
    }

    private void FadeInComplete()
    {
        Debug.Log("Fade In Complete");
    }

    private void FadeOutInComplete()
    {
        fadeOutInPanel.enabled = false;
    }
}
