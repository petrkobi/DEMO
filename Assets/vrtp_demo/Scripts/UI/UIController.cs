﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private Button changeColorButton;
    
    [Header("Window")] 
    [SerializeField] private GameObject colorPickerWindow;

    private GameObject colorPicerWindowSpawn;
    
    private void Start()
    {
        changeColorButton.onClick.AddListener(OnClickChangeColorButton);
    }

    private void OnClickChangeColorButton()
    {
       colorPicerWindowSpawn = Instantiate(colorPickerWindow, canvas.transform);
    }


}
