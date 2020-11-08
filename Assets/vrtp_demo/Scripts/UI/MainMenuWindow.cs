using DG.Tweening;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.Common.Events;
using vrtp_demo.Scripts.DoorController;
using vrtp_demo.Scripts.DoorController.Events;
using vrtp_demo.Scripts.UI.Events;

namespace vrtp_demo.Scripts.UI
{
    public class MainMenuWindow : MonoBehaviour
    {
        [Header("Color Picker Button")]
        [SerializeField] private Button colorPickerWindow;
        
        [Header("Door Buttons")]
        [SerializeField] private Button frontLeftDoorButton;
        [SerializeField] private Button frontRightDoorButton;
        [SerializeField] private Button rearLeftDoorButton;
        [SerializeField] private Button rearRightDoorButton;
        [SerializeField] private Button tailDoorButton;
        
        [Space]
        [SerializeField] private CanvasGroup colorPickerGroupBtn;

        [Header("Light Slider Controller")]
        [SerializeField] private Slider lightSlider;
        
        [Header("Data")]
        [SerializeField] private WindowDataStatus _windowDataStatus;

        
        private void Start()
        {
            colorPickerWindow.onClick.AddListener(OnClickColorPickerButton);
            
            frontLeftDoorButton.onClick.AddListener(OnClickFrontLeftDoorButton);
            frontRightDoorButton.onClick.AddListener(OnClickFrontRightDoorButton);
            rearLeftDoorButton.onClick.AddListener(OnClickRearLeftDoorButton);
            rearRightDoorButton.onClick.AddListener(OnClickRearRightDoorButton);
            tailDoorButton.onClick.AddListener(OnClickTailDoorButton);
            
            lightSlider.onValueChanged.AddListener(OnLightIntensityChangeSlider);
            lightSlider.value = 1.0f;
        }

        private void OnLightIntensityChangeSlider(float arg0)
        {
            _windowDataStatus.SetValue(arg0);
        }

        private void OnClickTailDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent()
            {
                DoorName = "TAIL_DOOR"
            });
        }

        private void OnClickRearRightDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent()
            {
                DoorName = "REAR_RIGHT_DOOR"
            });
        }

        private void OnClickRearLeftDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent()
            {
                DoorName = "REAR_LEFT_DOOR"
            });
        }

        private void OnClickFrontRightDoorButton()
        {
            EventDispatcher.Publish(new OpenDoorEvent()
            {
                DoorName = "FRONT_RIGHT_DOOR"
            });
        }

        private void OnClickFrontLeftDoorButton()
        {
           EventDispatcher.Publish(new OpenDoorEvent()
           {
               DoorName = "FRONT_LEFT_DOOR"
           });
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
