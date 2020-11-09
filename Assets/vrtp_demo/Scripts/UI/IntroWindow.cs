using DG.Tweening;
using TMPro;
using UnityEngine;
using vrtp_demo.Scripts.UI.Events;
using vrtp_demo.Scripts.UI.ScriptableObjects;
using Button = UnityEngine.UI.Button;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;
using Image = UnityEngine.UI.Image;

namespace vrtp_demo.Scripts.UI
{
    public class IntroWindow : MonoBehaviour
    {

        [SerializeField] 
        private Button enterMainViewButton;
        [SerializeField] 
        private TextMeshProUGUI infoMessage;
        [SerializeField] 
        private Image virtuplexLogo;

        [Header("Data")]
        [SerializeField] private WindowDataStatus _windowDataStatus;


        private void Start()
        {
            enterMainViewButton.onClick.AddListener(OnClickEnterMainViewButton);

            //Set WindowStatus
            _windowDataStatus.Window = WindowDataStatus.WindowStatus.Intro;

            //Prepare Sequence for Tween - not used now
            /*
            Sequence s = DOTween.Sequence();
            s.Append(infoMessage.transform.DOShakeScale(1, new Vector3(0.1f, 0.1f, 0),1, 90, true));
            s.SetLoops(-1, LoopType.Restart);
            */

            //Sequence for Looping Tween virtuplex logo
            Sequence logoSeq = DOTween.Sequence();
            logoSeq.Append(virtuplexLogo.DOFade(0.1f, 1f));
            logoSeq.SetLoops(-1, LoopType.Yoyo);
        }
    
    
        private void OnClickEnterMainViewButton()
        {
            //Send Event for FadeInOut
            EventDispatcher.Publish(new RequestFadeInAndOutEvent(),false);
            //Send Event for Request Main Window
            EventDispatcher.Publish(new RequestMainWindowEvent(),false);
            //Destroy this Intro window
            Destroy(gameObject,0.5f);
        }
    }
}
