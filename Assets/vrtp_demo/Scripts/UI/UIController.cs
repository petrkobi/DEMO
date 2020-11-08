using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private Button changeColorButton;
    
    [Header("Window")] 
    [SerializeField] private GameObject colorPickerWindow;


    [Header("Data")]
    [SerializeField] private WindowDataStatus _windowDataStatus;

    private GameObject colorPicerWindowSpawn;
    
    private void Start()
    {
        changeColorButton.onClick.AddListener(OnClickChangeColorButton);
        _windowDataStatus.Window = WindowDataStatus.WindowStatus.MainView;
    }

    private void OnClickChangeColorButton()
    {
       colorPicerWindowSpawn = Instantiate(colorPickerWindow, canvas.transform);
    }


}
