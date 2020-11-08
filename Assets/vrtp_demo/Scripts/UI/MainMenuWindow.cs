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
        
        [Header("Data")]
        [SerializeField] private WindowDataStatus _windowDataStatus;
        
        // Start is called before the first frame update
        void Start()
        {
            colorPickerWindow.onClick.AddListener(OnClickColorPickerButton);
        }

        private void OnClickColorPickerButton()
        {
            //EventDispatcher.Publish(new RequestFadeInEvent());
            EventDispatcher.Publish(new RequestColorPickerWindowEvent());
            
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            gameObject.transform.SetAsFirstSibling();
            _windowDataStatus.Window = WindowDataStatus.WindowStatus.MainView;
            
        }
    }
}
