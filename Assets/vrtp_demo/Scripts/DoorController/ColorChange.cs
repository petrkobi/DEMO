﻿using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using vrtp_demo.Scripts.ColorPickerWindow.Events;
using vrtp_demo.Scripts.DoorController;
using EventDispatcher = vrtp_demo.Scripts.Common.Events.EventDispatcher;

public class ColorChange : MonoBehaviour
{

    [SerializeField] private List<MeshRenderer> carCaseList = new List<MeshRenderer>();
    
    [Header("Data")]
    [SerializeField] private MazdaData _mazdaData;

    private void Start()
    {
        //Set "tmp" init - first color in SO MazdaData
        _mazdaData.MazdaColor = carCaseList[0].material.color;
        
        //When receive Event - set all parts to color;
        EventDispatcher.Receive<ChangeColorEvent>()
            .Subscribe(e =>
            {
                foreach (var part in carCaseList)
                {
                    part.material.color = e.ChangeColor;
                }
            });
    }
}
