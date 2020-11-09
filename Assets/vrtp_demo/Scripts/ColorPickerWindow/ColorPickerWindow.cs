using DG.Tweening;
using HSVPicker;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.ColorPickerWindow.Events;
using vrtp_demo.Scripts.DoorController;
using vrtp_demo.Scripts.UI.Events;
using vrtp_demo.Scripts.UI.ScriptableObjects;
using Button = UnityEngine.UI.Button;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

namespace vrtp_demo.Scripts.ColorPickerWindow
{
    public class ColorPickerWindow : MonoBehaviour
    {

        [SerializeField] private ColorPicker colorPicker;
        [SerializeField] private Button saveColorButton;
        [SerializeField] private Image backgroundImage;

        [Header("Data")] 
        [SerializeField] private MazdaData _mazdaData;
        [SerializeField] private WindowDataStatus _windowDataStatus;
    
        
        private void Start()
        {
            colorPicker.CurrentColor = _mazdaData.MazdaColor;
            saveColorButton.onClick.AddListener(OnClickSaveColorButton);
        }

        //When Window spawns
        private void OnEnable()
        {
            //Set WindowStatus
            _windowDataStatus.Window = WindowDataStatus.WindowStatus.ColorPickerWindow;
        
            //Set as first sibling under Canvas, always visibility
            gameObject.transform.SetAsFirstSibling();
            
            //Start smooth Tween
            backgroundImage.DOColor(new Color(0, 0, 0, 0.7f), 0.5f);
        }

        private void OnClickSaveColorButton()
        {
            //Send ChangeColorEvent with selected color
            EventDispatcher.Publish(new ChangeColorEvent()
            {
                ChangeColor = colorPicker.CurrentColor
            }, false);

            _mazdaData.MazdaColor = colorPicker.CurrentColor;
            colorPicker.gameObject.SetActive(false);
            
            //Start sooth Tween
            backgroundImage.DOColor(new Color(0, 0, 0, 0.0f), 0.3f).OnComplete(OnColorPickerWindowClosed);
        }

        private void OnColorPickerWindowClosed()
        {
            //Request Main Window
            EventDispatcher.Publish(new RequestMainWindowEvent(), false);
            Destroy(gameObject);
        }
    }
}
