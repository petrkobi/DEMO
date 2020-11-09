using DG.Tweening;
using UniRx;
using UnityEngine;
using vrtp_demo.Scripts.UI.Events;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;
using Image = UnityEngine.UI.Image;

public class FadeOutInController : MonoBehaviour
{

    [SerializeField] private Image fadeOutInPanel;
    
    // Start is called before the first frame update
    private void Start()
    {
        //When receive Event 
        EventDispatcher.Receive<RequestFadeInAndOutEvent>()
            .Subscribe(_ =>
            {
                //Launch Tween for FadeIn-Fade-Out smooth animation
                fadeOutInPanel.enabled = true;
                Sequence s = DOTween.Sequence();
                s.Append(fadeOutInPanel.DOFade(1, 0.5f));
                s.SetLoops(2, LoopType.Yoyo).OnComplete(FadeOutInComplete);

            });
    }
    
    private void FadeOutInComplete()
    {
        fadeOutInPanel.enabled = false;
    }
}
