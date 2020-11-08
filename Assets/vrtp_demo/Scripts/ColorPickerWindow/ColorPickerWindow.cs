using HSVPicker;
using UnityEngine;
using vrtp_demo.Scripts.ColorPickerWindow.Events;
using vrtp_demo.Scripts.DoorController;
using vrtp_demo.Scripts.UI;
using Button = UnityEngine.UI.Button;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

public class ColorPickerWindow : MonoBehaviour
{

    [SerializeField] private ColorPicker colorPicker;
    [SerializeField] private Button saveColorButton;

    [Header("Data")] 
    [SerializeField] private MazdaData _mazdaData;
    [SerializeField] private WindowDataStatus _windowDataStatus;

    // Start is called before the first frame update
    void Start()
    {
        colorPicker.CurrentColor = _mazdaData.MazdaColor;
        
        saveColorButton.onClick.AddListener(OnClickSaveColorButton);
    }

    private void OnEnable()
    {
        _windowDataStatus.Window = WindowDataStatus.WindowStatus.ColorPickerWindow;
    }

    private void OnClickSaveColorButton()
    {
        EventDispatcher.Publish(new ChangeColorEvent()
        {
            ChangeColor = colorPicker.CurrentColor
        });

        _mazdaData.MazdaColor = colorPicker.CurrentColor;
        
        _windowDataStatus.Window = WindowDataStatus.WindowStatus.MainView;
        Destroy(gameObject,0.1f);
    }
}
