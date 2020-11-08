using DG.Tweening;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.Common.Events;
using vrtp_demo.Scripts.DoorController;
using vrtp_demo.Scripts.UI.Events;

namespace vrtp_demo.Scripts.UI
{
    public class MainMenuWindow : MonoBehaviour
    {

        [SerializeField] private Button colorPickerWindow;
        [SerializeField] private CanvasGroup colorPickerGroupBtn;
        
        [Header("Data")]
        [SerializeField] private WindowDataStatus _windowDataStatus;

        
        private void Start()
        {
            colorPickerWindow.onClick.AddListener(OnClickColorPickerButton);
        }

        private void OnClickColorPickerButton()
        {
            EventDispatcher.Publish(new RequestColorPickerWindowEvent());
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            gameObject.transform.SetAsFirstSibling();
            _windowDataStatus.Window = WindowDataStatus.WindowStatus.MainView;
            colorPickerGroupBtn.alpha = 0;
            
            colorPickerGroupBtn.DOFade(1, 1f);
        }
    }
}
