using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.Common.Events;
using vrtp_demo.Scripts.UI;
using vrtp_demo.Scripts.UI.Events;

public class UIController : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private Button changeColorButton;
    
    [Header("Window")] 
    [SerializeField] private GameObject colorPickerWindow;
    [SerializeField] private GameObject mainMenuWindow;


    [Header("Data")]
    [SerializeField] private WindowDataStatus _windowDataStatus;

    private GameObject colorPicerWindowSpawn;
    
    private void Start()
    {
        //changeColorButton.onClick.AddListener(OnClickChangeColorButton);
        //_windowDataStatus.Window = WindowDataStatus.WindowStatus.MainView;

        EventDispatcher.Receive<RequestColorPickerWindowEvent>()
            .Subscribe(_ =>
            {
                Instantiate(colorPickerWindow, canvas.transform);
            });

        EventDispatcher.Receive<RequestMainWindowEvent>()
            .Subscribe(_ =>
            {
                Instantiate(mainMenuWindow, canvas.transform);
            });
    }

    private void OnClickChangeColorButton()
    {
       colorPicerWindowSpawn = Instantiate(colorPickerWindow, canvas.transform);
    }


}
