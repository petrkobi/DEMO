using System.Collections;
using System.Collections.Generic;
using HSVPicker;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.ColorPickerWindow.Events;
using vrtp_demo.Scripts.DoorController;
using Button = UnityEngine.UI.Button;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

public class ColorPickerWindow : MonoBehaviour
{

    [SerializeField] private ColorPicker colorPicker;
    [SerializeField] private Button saveColorButton;

    [Header("Data")] [SerializeField] private MazdaData _mazdaData;
    
    // Start is called before the first frame update
    void Start()
    {
        colorPicker.CurrentColor = _mazdaData.MazdaColor;
        
        saveColorButton.onClick.AddListener(OnClickSaveColorButton);
    }

    private void OnClickSaveColorButton()
    {
        EventDispatcher.Publish(new ChangeColorEvent()
        {
            ChangeColor = colorPicker.CurrentColor
        });

        _mazdaData.MazdaColor = colorPicker.CurrentColor;
        
        Destroy(gameObject,0.1f);
    }
}
