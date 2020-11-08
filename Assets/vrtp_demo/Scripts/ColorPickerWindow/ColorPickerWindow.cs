using DG.Tweening;
using HSVPicker;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.ColorPickerWindow.Events;
using vrtp_demo.Scripts.DoorController;
using vrtp_demo.Scripts.UI;
using vrtp_demo.Scripts.UI.Events;
using Button = UnityEngine.UI.Button;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

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
        //canvasGroup.alpha = 0;
        colorPicker.CurrentColor = _mazdaData.MazdaColor;
        saveColorButton.onClick.AddListener(OnClickSaveColorButton);
    }

    private void OnEnable()
    {
        _windowDataStatus.Window = WindowDataStatus.WindowStatus.ColorPickerWindow;
        gameObject.transform.SetAsFirstSibling();
        //canvasGroup.alpha = 0;
        //canvasGroup.DOFade(1, 0.5f);
        backgroundImage.DOColor(new Color(0, 0, 0, 0.7f), 0.5f);
    }

    private void OnClickSaveColorButton()
    {
        EventDispatcher.Publish(new ChangeColorEvent()
        {
            ChangeColor = colorPicker.CurrentColor
        }, false);

        _mazdaData.MazdaColor = colorPicker.CurrentColor;

        colorPicker.gameObject.SetActive(false);
        //gameObject.transform.DOScale(new Vector3(0,0,0),0.5f).OnComplete(OnColorPickerWindowClosed);
        backgroundImage.DOColor(new Color(0, 0, 0, 0.0f), 0.3f).OnComplete(OnColorPickerWindowClosed);
    }

    private void OnColorPickerWindowClosed()
    {
        EventDispatcher.Publish(new RequestMainWindowEvent());
        Destroy(gameObject);
    }
}
