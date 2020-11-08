using DG.Tweening;
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
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Data")] 
    [SerializeField] private MazdaData _mazdaData;
    [SerializeField] private WindowDataStatus _windowDataStatus;
    
    private void Start()
    {
        canvasGroup.alpha = 0;
        colorPicker.CurrentColor = _mazdaData.MazdaColor;
        saveColorButton.onClick.AddListener(OnClickSaveColorButton);
    }

    private void OnEnable()
    {
        _windowDataStatus.Window = WindowDataStatus.WindowStatus.ColorPickerWindow;
        
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, 0.5f);
    }

    private void OnClickSaveColorButton()
    {
        EventDispatcher.Publish(new ChangeColorEvent()
        {
            ChangeColor = colorPicker.CurrentColor
        }, false);

        _mazdaData.MazdaColor = colorPicker.CurrentColor;
        _windowDataStatus.Window = WindowDataStatus.WindowStatus.MainView;
        canvasGroup.DOFade(0, 0.5f).OnComplete(OnColorPickerWindowClosed);
    }

    private void OnColorPickerWindowClosed()
    {
        Destroy(gameObject,0.1f);
    }
}
